using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Stats
{
    public class Stat
    {
        public int Value { get; set; } = 1;

        public int Modifier
        {
            get
            {
                return (int)Math.Floor((double)((Value - 10) / 2));
            }
        }
    }
}
