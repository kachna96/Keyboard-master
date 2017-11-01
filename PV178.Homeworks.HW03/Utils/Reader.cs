using System;
using System.IO;
using System.Threading;

namespace PV178.Homeworks.HW03.Utils
{
    /// <summary>
    /// Class responsible for reading songs from textfiles and handling user input.
    /// </summary>
    public class Reader : IDisposable
    {
        public Displayer Displayer = new Displayer();

        public string Text { get; set; }

        public event EventHandler<PressedKeyEventArgs> PressedKey;

        private const int Timeout = 300;

        private AutoResetEvent trackDone;
        private Thread checkingThread;
        private Thread gettingThread;
        private Piano piano = new Piano();
        private char? input;
        private bool userPaid;

        public Reader(string songName, bool userPaid)
        {
            if (File.Exists(@"..\..\Songs\" + songName + ".txt"))
            {
                Text = File.ReadAllText(@"..\..\Songs\" + songName + ".txt");
                trackDone = new AutoResetEvent(false);
                checkingThread = new Thread(CheckInput) { IsBackground = true };
                gettingThread = new Thread(GetInput) { IsBackground = true };
                this.userPaid = userPaid;
            }
            else
            {
                throw new ArgumentException("Wrong song path");
            }
        }

        /// <summary>
        /// Invokes event that says which key was pressed and what is actual reading position.
        /// </summary>
        /// <param name="key">pressed key</param>
        /// <param name="position">actual reading position</param>
        protected virtual void OnKeyPressed(char key, int position)
        {
            PressedKey?.Invoke(this, new PressedKeyEventArgs(key, position));
        }

        /// <summary>
        /// Invokes event that says no key was pressed and what is actual reading position.
        /// </summary>
        /// <param name="position">actual reading position</param>
        protected virtual void OnKeyNotPressed(int position)
        {
            PressedKey?.Invoke(this, new PressedKeyEventArgs(position));
        }

        /// <summary>
        /// Periodically checks if some key was pressed.
        /// </summary>
        private void CheckInput()
        {
            for (var i = -6; i < Text.Length; i++)
            {
                Displayer.ActualDisplay(Text, i + 6);
                Thread.Sleep(Timeout);
                // First chars just skip (because animation)
                if (i < 0)
                {
                    continue;
                }
                if (input != null)
                {
                    OnKeyPressed((char)input, i);
                    input = null;
                }
                else
                {
                    OnKeyNotPressed(i);
                }
            }
            trackDone.Set();
        }

        /// <summary>
        /// Gets input from the user.
        /// </summary>
        private void GetInput()
        {
            while (true)
            {
                input = Console.ReadKey(true).KeyChar;
                if (input != null)
                {
                    if (userPaid)
                    {
                        Sounder.MakeCoolSound(input);
                    }
                    else
                    {
                        Sounder.MakeSound(GetFrequencyFromKey(input));
                    }
                }
            }
        }

        /// <summary>
        /// Starts reading keys and checking whether user pressed some.
        /// </summary>
        public void ReadKeys()
        {
            gettingThread.Start();
            checkingThread.Start();
            trackDone.WaitOne();
        }

        /// <summary>
        /// Performs cleanup.
        /// </summary>
        public void Dispose()
        {
            trackDone.Dispose();
            Console.Clear();
        }

        /// <summary>
        /// Look up frequency in a collection and return it
        /// </summary>
        /// <param name="key">Desired key</param>
        /// <returns>Frequency of the key, 37 if key is not present in collection</returns>
        private int GetFrequencyFromKey(char? key)
        {
            var result = piano.Collection.GetInfo(key.GetValueOrDefault());
            return result == null ? 37 : result.Item1;
        }
    }
}
