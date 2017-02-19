using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Warpgate.Pawn;
using Warpgate.Universe;

namespace Warpgate
{
    public class GameState
    {
        public Captain Captain { get; set; }
        public List<Sector> Sectors { get; set; }
        
        public static void SaveGame(string filename, GameState state)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(GameState));
                using (var file = new StreamWriter(filename))
                {
                    serializer.Serialize(file, state);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static GameState LoadGame(string filename)
        {
            GameState state = null;
            try
            {
                var serializer = new XmlSerializer(typeof (GameState));
                using (var file = new StreamReader(filename))
                {
                    state = (GameState)serializer.Deserialize(file);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return state;
        }
    }
}
