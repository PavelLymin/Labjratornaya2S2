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
                    item += $"Найдено расхождение в типах \nВ позиции: {i} \nПолучено: {ControlList[i].GetType().Name} \nОжидалось: {ObjectList[i].GetType().Name} \n\n";
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
                var fieldObjList = ObjectList[i].GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
                var fieldCntrList = ControlList[i].GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
                foreach(var  field1 in fieldObjList)
                {
                    var valuefld1 = field1.GetValue(ObjectList[i]);

                    foreach (var field2 in fieldCntrList)
                    {
                        var valuefld2 = field2.GetValue(ControlList[i]);

                        if (field1.Name == field2.Name)
                        {

                            if (!valuefld1.Equals(valuefld2))
                            {
                                item += $"\nНайдено расхаждение в значениях в позиции: {i}\n" +
                                    $"В поле: {field1.Name} \n" +
                                    $"Получено: {valuefld2}\n" +
                                    $"Ожидалось: {valuefld1}";
                            }
                        }
                    }
                }
            }
            return item;
        }
    }
}
