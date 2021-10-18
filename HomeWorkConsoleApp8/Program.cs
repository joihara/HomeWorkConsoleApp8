using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWorkConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {

            //Задание 1. Работа с листом.
            //Задание 2.Телефонная книга.
            //Задание 3.Проверка повторов.
            //Задание 4.Записная книжка.

            //Задание 1.Работа с листом
            //Что нужно сделать
            //Создайте лист целых чисел.
            //Заполните лист 100 случайными числами в диапазоне от 0 до 100.
            //Выведите коллекцию чисел на экран.
            //Удалите из листа числа, которые больше 25, но меньше 50.
            //Снова выведите числа на экран.
            List<int> numberList = new();
            Random random = new();
            Console.WriteLine("100 случайными числами в диапазоне от 0 до 100");
            for (int i = 0; i < 100; i++)
            {
                numberList.Add(random.Next(100));
            }

            foreach (var item in numberList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("больше 25, но меньше 50");
            var t = numberList.RemoveAll(e=>e>25&&e<50);

            foreach (var item in numberList)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        
    }
}
