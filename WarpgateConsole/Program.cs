using System;
using System.Collections.Generic;
using System.Text;
using Warpgate;

namespace WarpgateConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var gamestate = GameState.LoadGame("game.xml");
            }
            catch (Exception )
            {
                
            }
        }
    }
}
