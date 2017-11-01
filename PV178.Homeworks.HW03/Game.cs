using PV178.Homeworks.HW03.Utils;
using System;
using System.Linq;
using PV178.Homeworks.HW03.Extensions;

namespace PV178.Homeworks.HW03
{
    /// <summary>
    /// Base class for playing this game
    /// </summary>
    public class Game : IGame
    {
        public int Score { get; set; }
        public Reader Reader { get; set; }

        public void Run()
        {
            bool userPaid = UserPaid();
            Console.WriteLine("Select a song");
            string input = Console.ReadLine();
            try
            {
                this.Initalize(new Reader(input, userPaid));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Your score: " + Score);
            Console.ReadKey();
        }

        /// <summary>
        /// Ask player if he/she/it paid for a game
        /// </summary>
        /// <returns>true if he/she/it paid, false otherwise</returns>
        private bool UserPaid()
        {
            Console.WriteLine("Have you paid for this app? (y/n)");
            string response = Console.ReadLine();
            return response.Equals("y") ? true : false;
        }

        /// <summary>
        /// Adjust score based od players success
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="args">Arguments</param>
        internal void AdjustScore(object sender, PressedKeyEventArgs args)
        {
            char expectedKey = Reader.Text.ElementAt(args.Position);
            if (!expectedKey.Equals(args.Key))
            {
                Score--;
            }
        }
    }
}
