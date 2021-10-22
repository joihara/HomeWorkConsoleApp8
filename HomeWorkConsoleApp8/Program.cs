using System;
using System.Collections.Generic;

namespace HomeWorkConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            Utils utils = new();

            string startWork = "Выберите действие:\n" +
                     "1) Задание 1.Работа с листом\n" +
                     "2) Задание 2.Телефонная книга.\n" +
                     "3) Задание 3.Проверка повторов.\n" +
                     "4) Задание 4.Записная книжка.\n" +
                     "Для прекращения работы нажмите Enter\n";
            bool endWork = false;
            while (!endWork)
            {
                var step1 = utils.WaitEnterPassAddText(startWork, 1, 4);
                switch (step1)
                {
                    case 1:
                        Work1();
                        break;
                    case 2:
                        Work2(utils);
                        break;
                    case 3:
                        Work3(utils);
                        break;
                    case 4:
                        Work4(utils);
                        break;
                    default:
                        endWork = true;
                        break;
                }
            }

            //Console.ReadLine();
        }
        private static void Work4(Utils utils)
        {
            utils.SerializeCollection("book.xml");
        }

        #region Work3
            private static void Work3(Utils utils)
        {
            HashSet<long> indexator = new();
            while (true)
            {
                var number = utils.WaitEnterPassAddText("Введите любое число от нуля: ",0);
                if (number == -1)
                {
                    break;
                }
                bool okAdd = indexator.Add(number);
                string sub = okAdd ? "успешно сохранено" : "уже вводилось ранее";
                Console.WriteLine($"Число {number} {sub}");
            }
        }
        #endregion
        #region Work2
        private static void Work2(Utils utils)
        {
            Dictionary<long, string> users = new();
            bool okEnter = false;
            while (true)
            {
                long phoneNumber;
                if (!okEnter)
                {
                    phoneNumber = utils.WaitEnterPassAddText("Введите номер телефона (без +7): ", 0, 9999999999);
                }
                else {
                    phoneNumber = -1;
                }

                if (phoneNumber != -1)
                {
                    EnterData(users, phoneNumber);
                }
                else
                {
                    okEnter = SearchData(utils, users);
                    if (!okEnter)
                    {
                        break;
                    }

                }
            }
        }

        /// <summary>
        /// Поиск данных в словаре с данными
        /// </summary>
        /// <param name="utils"></param>
        /// <param name="users"></param>
        /// <returns></returns>
        private static bool SearchData(Utils utils, Dictionary<long, string> users)
        {
            var phoneNumberSearch = utils.WaitEnterPassAddText("Для поиска введите номер телефона (без +7): ", 0, 9999999999);
            bool okEnter = users.TryGetValue(phoneNumberSearch, out string getOkFullName);
            if (okEnter)
            {
                Console.WriteLine($"Телефон: +7{phoneNumberSearch} Ф.И.О.: {getOkFullName}");
            }
            else {
                Console.WriteLine("Такого номера не существует в телефонной книге");
            }

            bool okEnterNumber = phoneNumberSearch != -1;

            return okEnterNumber;
        }

        /// <summary>
        /// Ввод данных в словарь
        /// </summary>
        /// <param name="users"></param>
        /// <param name="phoneNumber"></param>
        private static void EnterData(Dictionary<long, string> users, long phoneNumber)
        {
            if (!users.ContainsKey(phoneNumber))
            {
                Console.Write("Введите Ф.И.О.: ");
                var fullName = Console.ReadLine();
                users.Add(phoneNumber, fullName);
            }
            else {
                Console.WriteLine("Такой номер уже содержится в телефонной книге");
            }
        }
        #endregion
        #region Work1
        private static void Work1()
        {
            List<int> numberList = new();
            GenerateRandomNumbers(numberList);
            PrintList(numberList);
            ConditionalRemove(numberList);
            PrintList(numberList);
            Console.ReadKey();
        }

        /// <summary>
        /// Удаление по условию
        /// </summary>
        /// <param name="numberList"></param>
        private static void ConditionalRemove(List<int> numberList)
        {
            Console.WriteLine("больше 25, но меньше 50");
            numberList.RemoveAll(e => e > 25 && e < 50);
        }

        /// <summary>
        /// Вывод листа в консоль
        /// </summary>
        /// <param name="numberList"></param>
        private static void PrintList(List<int> numberList)
        {
            foreach (var item in numberList)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Сгенерировать случайные числа в листе
        /// </summary>
        /// <param name="numberList"></param>
        private static void GenerateRandomNumbers(List<int> numberList)
        {
            Random random = new();
            Console.WriteLine("100 случайными числами в диапазоне от 0 до 100");
            for (int i = 0; i < 100; i++)
            {
                numberList.Add(random.Next(100));
            }
        }
        #endregion


    }
}
