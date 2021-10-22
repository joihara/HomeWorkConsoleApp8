using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace HomeWorkConsoleApp8
{
    public class Utils
    {
        /// <summary>
        /// Проверка на правильность введённых данных с клавиатуры
        /// </summary>
        /// <param name="minValue">Минимальное допустимое значение</param>
        /// <param name="maxValue">Максимальное допустимое значение</param>
        /// <returns>Результат чтения строки (null не проходит по условиям)</returns>
        public long? WaitEnterPass(long minValue, long maxValue, bool okSpace)
        {
            string input = Console.ReadLine();
            bool result = long.TryParse(input, out long outNumber);
            if (result && outNumber >= minValue && outNumber <= maxValue)
            {
                return outNumber;
            } else if (input.Equals("") && okSpace) {
                return -1;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Ожидает пока игрок введёт число в правильном диапазоне
        /// </summary>
        /// <param name="text">Текст который выводиться перед тем как ввести число</param>
        /// <param name="minValue">Минимальное допустимое значение</param>
        /// <param name="maxValue">Максимальное допустимое значение</param>
        /// <returns>правильно введенное число</returns>
        public long WaitEnterPassAddText(string text, long minValue = long.MinValue, long maxValue = long.MaxValue, bool okSpace = true)
        {
            while (true)
            {
                Console.Write(text);
                var readNumberOrNull = WaitEnterPass(minValue, maxValue, okSpace);

                if (readNumberOrNull != null) {
                        return (long)readNumberOrNull;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода");
                }
            }
        }

        /// <summary>
        /// Корректировка даты
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string СorrectionDateTimeIsString(string text = "")
        {
            var data = GetDateTimeIsString(text);
            return data.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Проверка строки на правильную дату
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public DateTime GetDateTimeIsString(string text = "")
        {
            DateTime myDate;

            while (true)
            {
                int countCell = text.Split(':').Length;
                text = text.Replace('.', ' ');
                if (text == "")
                    text = Console.ReadLine();
                try
                {
                    if (countCell > 1)
                    {
                        myDate = DateTime.ParseExact(text, "dd MM yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        myDate = DateTime.ParseExact(text, "dd MM yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    }

                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Дата введена неверно Повторите снова:");
                    text = Console.ReadLine();
                }
            }
            return myDate;
        }

        public void SerializeCollection(string filename)
        {
            Console.Write("ФИО: ");
            var fullName = Console.ReadLine();
            Console.Write("Улица: ");
            var streat = Console.ReadLine();
            var houseNumber = WaitEnterPassAddText("Номер дома: ", 1, 9999, false);
            var flatNumber = WaitEnterPassAddText("Номер квартиры: ", 1, 9999, false);
            var mobilePhone = WaitEnterPassAddText("Мобильный телефон: ", 1, 89999999999999, false);
            var flatPhone = WaitEnterPassAddText("Домашний телефон: ", 1, 89999999999999, false);

            StructAdress adress = new() {
                Street = streat,
                HouseNumber = houseNumber,
                FlatNumber = flatNumber
            };

            StructPhone phone = new()
            {
                MobilePhone = mobilePhone,
                FlatPhone = flatPhone
            };

            StructUser user = new()
            {
                name = fullName,
                Address = adress,
                Phones = phone
            };

            XmlSerializer x = new(typeof(StructUser));
            TextWriter writer = new StreamWriter(filename);
            x.Serialize(writer, user);
            Console.Write("Файл записан");
        }
    }
}
