using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW03.Utils
{
    /// <summary>
    /// Collection for storing tone frequency, tone name and key
    /// </summary>
    /// <typeparam name="TKey">Key (key on a keyboard)</typeparam>
    /// <typeparam name="Tuple">Tuple(Tone frequency, Tone name)/typeparam>
    class SoundCollection<TKey, Tuple> : Dictionary<TKey, Tuple>
    {
        private Dictionary<TKey, Tuple> data;

        public SoundCollection()
        {
            data = new Dictionary<TKey, Tuple>();
        }

        /// <summary>
        /// Add all records from one collection to this collection
        /// </summary>
        /// <param name="source">Source collection</param>
        /// <exception cref="ArgumentException">When we find a duplicate</exception>
        public void AddRange(SoundCollection<TKey, Tuple> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("SoundCollection is null");
            }
            source.ToList().ForEach(x =>
                {
                    try
                    {
                        data.Add(x.Key, x.Value);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Value with the same key already exists in dictionary. {0}", ex);
                    }
                });
        }

        /// <summary>
        /// Get tone freq. and tone name for a desired record
        /// </summary>
        /// <param name="key">Key on a keyboard</param>
        /// <returns>Tone freq. and tone name if the record exists, default Tuple otherwise</returns>
        public Tuple GetInfo(TKey key)
        {
            if (data.Keys.Contains(key))
            {
                return data[key];
            }
            return default(Tuple);
        }
    }
}
