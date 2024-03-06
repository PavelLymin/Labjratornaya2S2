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
            Reflection reflection = new Reflection();
            A class4 = new A(0, "Hello", 27);
            B class5 = new B(0, "Hello", 27);
            C class6 = new C(0, "Hello", 27);
            reflection.ObjectList.Add(class4);
            reflection.ObjectList.Add(class5);
            reflection.ObjectList.Add(class6);

            List<object> Controllist = new List<object>();
            A class1 = new A(0, "Hello", 27);
            B class2 = new B(0, "Hello", 27);
            C class3 = new C(0, "Hello", 27);
            Controllist.Add(class1);
            Controllist.Add(class2);
            Controllist.Add(class3);

            List<object> Controllist1 = new List<object>();
            A class7 = new A(0, "Hello", 27);
            B class8 = new B(0, "Hello", 27);
            C class9 = new C(0, "Hello", 27);
            Controllist1.Add(class7);
            Controllist1.Add(class8);
            Controllist1.Add(class9);
            Controllist1.Add(class9);

            List<object> Controllist2 = new List<object>();
            A class10 = new A(0, "Hello", 27);
            B class11 = new B(0, "Hello", 27);
            C class12 = new C(0, "Hello", 20);
            Controllist2.Add(class10);
            Controllist2.Add(class11);
            Controllist2.Add(class12);

            Console.WriteLine("Тест 1");
            Console.WriteLine(reflection.Comparison(Controllist));
            Console.WriteLine("Тест 2");
            Console.WriteLine(reflection.Comparison(Controllist1));
            Console.WriteLine("Тест 3");
            Console.WriteLine(reflection.Comparison(Controllist2));
        }
    }
}
