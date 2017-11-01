using System;

namespace PV178.Homeworks.HW03.Utils
{
    /// <summary>
    /// Create new piano with predefined tones
    /// </summary>
    class Piano : SoundCollection<char, Tuple<int, string>>
    {
        public SoundCollection<char, Tuple<int, string>> Collection { get; set; } = new SoundCollection<char, Tuple<int, string>>();

        /// <summary>
        /// Init new piano with these tones
        /// </summary>
        public Piano()
        {
            SoundCollection<char, Tuple<int, string>> source = new SoundCollection<char, Tuple<int, string>>();
            source.Add('a', new Tuple<int, string>(261, "C"));
            source.Add('s', new Tuple<int, string>(293, "D"));
            source.Add('d', new Tuple<int, string>(330, "E"));
            source.Add('f', new Tuple<int, string>(349, "F"));
            source.Add('g', new Tuple<int, string>(392, "G"));
            source.Add('h', new Tuple<int, string>(440, "A"));
            source.Add('j', new Tuple<int, string>(494, "H"));
            Collection.AddRange(source);
        }
    }
}
