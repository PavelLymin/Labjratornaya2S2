using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya2S2
{
    public class Reflection
    {
        private List<object> ObjectList { get; set; }

        public Reflection()
        {
            ObjectList = new List<object>();
        }

        public string Comparison(List<object> ControlList)
        {
            A class1 = new A(0 , "Hello", 27);
            B class2 = new B(0, "Hello", 27);
            C class3 = new C(0, "Hello", 27);
            ObjectList.Add(class1);
            ObjectList.Add(class2);
            ObjectList.Add(class3);
           
            //1 условие
            string item;
            if (ControlList.Count == ObjectList.Count)
                item = "Тест 1 \nСписки равны \n\n";
            else item = "Тест 1 \nСписки не равны \n";

            //2 условие
            item += "\nТест 3\n";
            for (int i = 0; i < ObjectList.Count; i++)
            {
                Type type = ObjectList[i].GetType();

                object[] attributes = type.GetCustomAttributes(true);

                foreach (object attribute in attributes) 
                {
                    if (attribute is NotComparable notComparable)
                    {
                        item += $"Найден не читаемый тип: {type.Name}\n" +
                            $"В позиции {i}\n";
                    }
                    if (attribute is Unreadable unreadable)
                    {
                        item += $"Проверка на наличие атрибута Unreadable : {Attribute.IsDefined(type, typeof(Unreadable))}\n";
                    }
                }
            }

            //3 условие
            item += "\nТест 3 \n";
            bool item2 = true;
            for (int i = 0; i < ObjectList.Count; i++)
            {
                if (ObjectList[i].GetType() != ControlList[i].GetType())
                {
                    item += $"Найдено расхождение в типах \nВ позиции: {i} \nПолучено: {ControlList[i].GetType().Name} \nОжидалось: {ObjectList[i].GetType().Name} \n\n";
                    item2 = false;
                }
            }
            if (item2) 
            {
                item += $"Не найдено расхождения в типах \n\n";
            }

            //4 условие
            item += "\nТест 4";
            for (int i = 0; i < ObjectList.Count; i++) 
            {
                var fieldObjList = ObjectList[i].GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
                var fieldCntrList = ControlList[i].GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
                foreach(var  field1 in fieldObjList)
                {
                    var valuefld1 = field1.GetValue(ObjectList[i]);

                    foreach (var field2 in fieldCntrList)
                    {
                        var valuefld2 = field2.GetValue(ControlList[i]);

                        if (ObjectList[i].GetType() == ControlList[i].GetType() && field1.Name == field2.Name)
                        {

                            if (!valuefld1.Equals(valuefld2))
                            {
                                item += $"\nНайдено расхождение в значениях в позиции: {i}\n" +
                                    $"В поле: {field1.Name} \n" +
                                    $"Получено: {valuefld2}\n" +
                                    $"Ожидалось: {valuefld1}\n";
                            }
                        }
                    }
                }
            }
            return item;
        }
    }
}
