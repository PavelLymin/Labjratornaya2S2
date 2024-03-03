using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya2S2
{
    public class C
    {
        public int num1 { get; set; } 
        public string num2 { get; set; } 
        private int num3 { get; set; } 

        public C (int num1, string num2, int num3)
        {
            this.num1 = num1;
            this.num2 = num2;
            this.num3 = num3;
        }
    }
}
