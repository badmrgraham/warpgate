using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Warpgate;
using Warpgate.Universe;

namespace WarpgateUniverseDesigner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private GameState mState;
        private Sector mSelectedSector;
        private SolarSystem mSelectedSystem;
        private Station mSelectedStation;
        private string mSelectedFilename;
        private ObservableCollection<Sector> mSectors;
        private ObservableCollection<SolarSystem> mSystems;
        private ObservableCollection<Station> mStations;

        public string SelectedFilename
        {
            get { return mSelectedFilename; }
            set { mSelectedFilename = value; NotifyPropertyChanged("SelectedFilename"); }
        }
        public SolarSystem SelectedSystem
        {
            get { return mSelectedSystem; }
            set { mSelectedSystem = value; NotifyPropertyChanged("SelectedSystem"); }
        }
        public Sector SelectedSector
        {
            get { return mSelectedSector; }
            set { mSelectedSector = value; NotifyPropertyChanged("SelectedSector"); }
        }
        public Station SelectedStation
        {
            get { return mSelectedStation; }
            set { mSelectedStation = value; NotifyPropertyChanged("SelectedStation"); }
        }
        public ObservableCollection<Sector> Sectors
        {
            get { return mSectors; }
            set { mSectors = value; NotifyPropertyChanged("Sectors"); }
        }
        public ObservableCollection<SolarSystem> Systems
        {
            get { return mSystems; }
            set { mSystems = value; NotifyPropertyChanged("Systems"); }
        }
        public ObservableCollection<Station> Stations
        {
            get { return mStations; }
            set { mStations = value; NotifyPropertyChanged("Stations"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
        }

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void CboSectorSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in UniverseTreeView.Items)
            {
                if (item == cboSector.SelectedValue)
                {
                    var tvi = UniverseTreeView.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
                    tvi.IsSelected = true;
                    tvi.IsExpanded = true;
                }
            }
            Systems = new ObservableCollection<SolarSystem>(SelectedSector.Systems);
        }

        private void SyssSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedSystem != null)
            {
                Stations = new ObservableCollection<Station>(SelectedSystem.Stations);
                foreach (var item in UniverseTreeView.Items)
                {
                    if (item == cboSys.SelectedValue)
                    {
                        var tvi = UniverseTreeView.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
                        tvi.IsSelected = true;
                        tvi.IsExpanded = true;
                    }
                }
            }
            else
            {
                Stations = null;
            }
        }

        private void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in UniverseTreeView.Items)
            {
                if (item == cboStation.SelectedValue)
                {
                    var tvi = UniverseTreeView.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
                    tvi.IsSelected = true;
                    tvi.IsExpanded = true;
                }
            }
        }

        private void UniverseTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var node = e.NewValue;
            if (node is Station)
            {
                var sector = Sectors.First(sect => sect.Systems.Any(sys => sys.Stations.Contains(node as Station)));
                var system = sector.Systems.First(sys => sys.Stations.Contains(node as Station));
                cboSector.SelectedValue = sector;
                cboSys.SelectedValue = system;
                cboStation.SelectedValue = node as Station;
            }
            else if (node is SolarSystem)
            {
                var sector = Sectors.First(sect => sect.Systems.Contains(node as SolarSystem));
                cboSector.SelectedValue = sector;
                cboSys.SelectedValue = node as SolarSystem;
                cboStation.SelectedValue = null;

            }
            else if (node is Sector)
            {
                cboSector.SelectedValue = node as Sector;
                cboSys.SelectedValue = null;
                cboStation.SelectedValue = null;
            }
        }

        private void CboFilenameSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mState = GameState.LoadGame(string.Format("{0}.unv", SelectedFilename));
            Sectors = new ObservableCollection<Sector>(mState.Sectors.ToArray());
            foreach (var item in UniverseTreeView.Items)
            {
                (UniverseTreeView.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem).IsExpanded = false;
            }
            NotifyPropertyChanged("SelectedSector");
            NotifyPropertyChanged("SelectedSystem");
            NotifyPropertyChanged("SelectedStation");
        }

        private void SaveButtonClick1(object sender, RoutedEventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                AddExtension = true, 
                DefaultExt = ".unv", 
                Filter = "Universe Files|*.unv",
                InitialDirectory = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName,
                OverwritePrompt = true, 
                Title = "Where do you want to save the universe?"
            };
            var result = sfd.ShowDialog();
            if (result.Value)
            {
                GameState.SaveGame(sfd.FileName, mState);
            }
        }

        private void LoadButtonClick1(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                AddExtension = true,
                DefaultExt = ".unv",
                Filter = "Universe Files|*.unv",
                InitialDirectory = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName,
                CheckFileExists = true,
                Title = "Where do you want to save the universe?"
            };
            var result = ofd.ShowDialog();
            if (result.Value)
            {
                mState = GameState.LoadGame(ofd.FileName);
                Sectors = new ObservableCollection<Sector>(mState.Sectors);
            }
        }

        private void AddSectorClick1(object sender, RoutedEventArgs e)
        {
            var sect = new Sector();
            Sectors.Add(sect);
            cboSector.SelectedItem = sect;
        }

        private void AddSystemClick1(object sender, RoutedEventArgs e)
        {
            var sys = new SolarSystem();
            Systems.Add(sys);
            cboSys.SelectedItem = sys;
        }
    }

    public class SourceIsNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
