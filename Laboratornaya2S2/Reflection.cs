using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laboratornaya2S2
{
    public class Reflection
    {
        public List<object> ObjectList { get; set; }

        public Reflection()
        {
            ObjectList = new List<object>();
        }

        public string Comparison(List<object> ControlList)
        {           
            //1 условие
            string item = "";
            bool item3 = true;
            if (ControlList.Count != ObjectList.Count)
            {
                item3 = false;
                item += "Списки не равны \n";
            }

            //2 условие
            for (int i = 0; i < ObjectList.Count; i++)
            {
                Type type = ObjectList[i].GetType();

                object[] attributes = type.GetCustomAttributes(false);

                foreach (object attribute in attributes)
                {
                    if (attribute is NotComparable notComparable)
                    {
                        item += $"Найден не читаемый тип: {type.Name}\n" +
                            $"В позиции {i}\n";
                    }
                }
                PropertyInfo[] props = type.GetProperties();
                foreach (var prop in props)
                {
                    if (prop.GetCustomAttribute<Unreadable>() != null)
                    {
                        item += $"Свойство {prop.Name} имеет атрибут Unreadable\n";
                    }
                }
            }

            //3 условие
            for (int i = 0; i < ObjectList.Count; i++)
            {
                if (ObjectList[i].GetType() != ControlList[i].GetType())
                {
                    item3 = false;
                    item += $"\nНайдено расхождение в типах \nВ позиции: {i} \nПолучено: {ControlList[i].GetType().Name} \nОжидалось: {ObjectList[i].GetType().Name} \n\n";
                }
            }

            //4 условие
            for (int i = 0; i < ObjectList.Count; i++) 
            {
                PropertyInfo[] fieldObjList = ObjectList[i].GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
                PropertyInfo[] fieldCntrList = ControlList[i].GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
                foreach(PropertyInfo field1 in fieldObjList)
                {
                    var valuefld1 = field1.GetValue(ObjectList[i]);

                    foreach (PropertyInfo field2 in fieldCntrList)
                    {
                        var valuefld2 = field2.GetValue(ControlList[i]);

                        if (ObjectList[i].GetType() == ControlList[i].GetType() && field1.Name == field2.Name)
                        {
                            if (valuefld1.ToString() != valuefld2.ToString())
                            {
                                item3 = false;
                                item += $"\nНайдено расхождение в значениях в позиции: {i}\n" +
                                    $"В поле: {field1.Name} \n" +
                                    $"Получено: {valuefld2}\n" +
                                    $"Ожидалось: {valuefld1}\n";
                            }
                        }
                    }
                }
            }
            if (item3) 
            {
                item += "Расхождений не найдено\n";
            }
            return item;
        }
    }
}
