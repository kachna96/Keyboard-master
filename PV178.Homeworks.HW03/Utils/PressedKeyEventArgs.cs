using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW03.Utils
{
    /// <summary>
    /// Class for storing keys pressed by player
    /// </summary>
    public class PressedKeyEventArgs : EventArgs
    {
        public char Key { get; private set; }
        public int Position { get; private set; }

        /// <summary>
        /// If player didn't press anything
        /// </summary>
        /// <param name="position">Position in a song</param>
        public PressedKeyEventArgs(int position) : this(' ', position)
        {

        }

        /// <summary>
        /// If player pressed some key
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="position">Position in a song</param>
        public PressedKeyEventArgs(char key, int position)
        {
            Key = key;
            Position = position;
        }
    }
}
