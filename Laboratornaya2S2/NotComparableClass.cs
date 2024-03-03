using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya2S2
{
    public class NotComparable: Attribute
    {
        public bool itogN {  get; set; }

        public NotComparable(bool itogN)
        {
            this.itogN = itogN;
        }
    }
}
