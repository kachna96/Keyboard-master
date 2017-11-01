using PV178.Homeworks.HW03.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW03.Extensions
{
    /// <summary>
    /// Extension method for Game
    /// </summary>
    public static class Init
    {
        /// <summary>
        /// Init reader and hook up events
        /// </summary>
        /// <param name="game">Game</param>
        /// <param name="reader">Reader</param>
        public static void Initalize(this Game game, Reader reader)
        {
            game.Reader = reader;

            game.Score = reader.Text.Length;

            reader.PressedKey += game.AdjustScore;

            reader.ReadKeys();

            reader.PressedKey -= game.AdjustScore;
        }
    }
}
