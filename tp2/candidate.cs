using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp2
{
    public class candidate : IComparable<candidate>
    {
        public string? Name { get; set; }
        public int vote { get; set; }
        public string percentage { get; set; }

        int IComparable<candidate>.CompareTo(candidate other)
        {
            float sumOther = float.Parse(other.percentage);
            float sumThis = float.Parse(this.percentage);

            if (sumOther > sumThis)
                return -1;
            else if (sumOther == sumThis)
                return 0;
            else
                return 1;
        }
    }
}
