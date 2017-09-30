using System;
using WaxenV_1.Game_Class;
using Microsoft.Xna.Framework;

namespace OuroborosEngine
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (Waxen game = new Waxen())
                game.Run();
        }
    }
}