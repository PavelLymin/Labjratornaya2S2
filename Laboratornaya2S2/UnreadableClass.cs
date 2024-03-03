using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya2S2
{
    public class Unreadable: Attribute
    {
        public bool itogU {  get; set; }

        public Unreadable(bool itogU)
        {
            this.itogU = itogU;
        }
    }
}
