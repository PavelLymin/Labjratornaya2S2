using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya2S2
{
    public class Reflection
    {
        private List<object> ObjectList { get; set; }
        public int i;

        public Reflection() 
        {
            ObjectList = new List<object>(); 
        }

        public string Comparison(List<object> ControlList)
        {
            A class1 = new A();
            B class2 = new B();
            C class3 = new C();
            ObjectList.Add(class1);
            ObjectList.Add(class2);
            ObjectList.Add(class3);
            
            //1 условие
            string item;
            if (ControlList.Count == ObjectList.Count)
                item = "Тест 1 \nСписки равны \n\n";
            else item = "Тест 1 \nСписки не равны \n\n";

            //3 условие
            item += "\nТест 2 \n";
            bool item2 = true;
            for (int i = 0; i < ObjectList.Count; i++)
            {
                if (ObjectList[i].GetType() != ControlList[i].GetType())
                {
                    int index = ControlList.IndexOf(ControlList[i]);
                    item += $"Найдено расхождение в типах \nВ позиции: {index} \nПолучено: {ControlList[i].GetType().Name} \nОжидалось: {ObjectList[i].GetType().Name} \n\n";
                    item2 = false;
                }
            }
            if (item2) 
            {
                item += $"Не найдено расхождения в типах \n\n";
            }

            //4 условие
            for (int i = 0; i < ObjectList.Count; i++)
            {
                var fieldsObjectList = ObjectList[i].GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                //var fieldsControlList = ControlList[i].GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                foreach (var obj in fieldsObjectList)
                {
                    var valueObj = obj.GetValue(ObjectList[i]);
                    var valueControl = obj.GetValue(ControlList[i]);

                    if (valueObj != valueControl)
                    {
                        item += $"Расхождение в значении поля '{obj.Name}' {valueControl} {valueObj} объекта на позиции {i + 1}.";
                    }
                }
            }
            return item;
        }
    }
}
