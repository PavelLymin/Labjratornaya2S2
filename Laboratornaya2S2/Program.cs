using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya2S2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<object> Controllist = new List<object>();
            A class1 = new A();
            B class2 = new B();
            C class3 = new C(); 
            Controllist.Add(class1);
            Controllist.Add(class2);
            Controllist.Add(class3);

            Reflection reflection = new Reflection();
            Console.WriteLine(reflection.Comparison(Controllist));
        }
    }
}
