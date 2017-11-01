using System;
using System.Threading;
using System.Media;
using System.IO;

namespace PV178.Homeworks.HW03.Utils
{
    /// <summary>
    /// Class for making sound in other thread.
    /// </summary>
    public static class Sounder
    {
        /// <summary>
        /// Makes sound with given frequency and duration.
        /// </summary>
        /// <param name="frequency">frequency</param>
        /// <param name="duration">duration</param>
        public static void MakeSound(int frequency, int duration = 300)
        {
            ThreadPool.QueueUserWorkItem(state =>
                Console.Beep(frequency, duration));
        }

        /// <summary>
        /// Makes COOLER sound from a wav file
        /// </summary>
        /// <param name="key">Tone name</param>
        /// <exception cref="ArgumentException">If wav file of a tone name is not present</exception>
        public static void MakeCoolSound(char? key)
        {
            if (File.Exists(@"..\..\Sounds\piano-" + key + ".wav"))
            {
                SoundPlayer player = new SoundPlayer(@"..\..\Sounds\piano-" + key + ".wav");
                player.Play();
            }
            else
            {
                throw new ArgumentException("Unknown piano sound", key.ToString());
            }
        }
    }
}
