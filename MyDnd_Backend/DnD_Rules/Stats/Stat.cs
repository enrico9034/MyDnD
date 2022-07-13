using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Stats
{
    public class Stat
    {
        protected int _value = 1;
        public int Value
        {
            get => _value;
            set
            {
                if (value < 1)
                    value = 1;
                if (value > 20)
                    value = 20;
                _value = value;
            }
        }

        public int Modifier
        {
            get
            {
                var partial = (double)(Value - 10) / 2;
                if(partial > 0)
                    return (int)Math.Floor(Math.Abs(partial));
                return -1 * (int)Math.Ceiling(Math.Abs(partial));
            }
        }
    }
}
