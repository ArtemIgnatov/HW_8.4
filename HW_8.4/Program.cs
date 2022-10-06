using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        XElement myPhoneBook = new XElement("MYPHONEBOOK");

        //Запускаем цикл по вводу данных
        char key = 'д';
        do
        {
            //Создаем элемент персоны
            XElement person = new XElement("Person");

            //Создаем атрибут ФИО и добавляем его в элемент персоны
            Console.WriteLine("Введите ФИО:");
            string fio = Console.ReadLine();
            XAttribute xAttributeFIO = new XAttribute("name", fio);
            person.Add(xAttributeFIO);

            #region Адрес

            //Создаем элемент с адресом
            XElement xElementAdress = new XElement("Adress");

            //Создаем атрибут с названием улицы
            Console.WriteLine("Введите название улицы:");
            string street = Console.ReadLine();
            XAttribute xAttributeStreet = new XAttribute("Street", street);

            //Создаем элемент с названием улицы
            //и заполняем его
            XElement xElementStreet = new XElement("Street");
            xElementStreet.Add(xAttributeStreet);

            //Создаем атрибут с номером дома
            Console.WriteLine("Введите номер дома:");
            string housnumber = Console.ReadLine();
            XAttribute xAttributeHousNumber = new XAttribute("HousNumber", housnumber);

            //Создаем элемент с номером дома
            //и заполняем его
            XElement xElementHousNumber = new XElement("HousNumber");
            xElementHousNumber.Add(xAttributeHousNumber);

            //Создаем атрибут с номером квартиры
            Console.WriteLine("Введите номер квартиры:");
            string flatnumber = Console.ReadLine();
            XAttribute xAttributeFlatNumber = new XAttribute("FlatNumber", flatnumber);

            //Создаем элемент с номером квартиры
            //и заполняем его
            XElement xElementFlatNumber = new XElement("FlatNumber");
            xElementFlatNumber.Add(xAttributeFlatNumber);

            //Добавляем все элементы в ээлемент адреса
            xElementAdress.Add(xElementStreet, xElementHousNumber, xElementFlatNumber);

            #endregion;

            #region Номера телефонов

            //Создаем элемент с номерами телефонов
            XElement xElementPhones = new XElement("Phones");

            //Создаем атрибут с мобильным номером телефона
            Console.WriteLine("Введите мобильный номер телефона:");
            string mobilephone = Console.ReadLine();
            XAttribute xAttributeMobilePhone = new XAttribute("MobilePhone", mobilephone);

            //Создаем элемент с мобильныи номером
            //и заполняем его
            XElement xElementMobilePhone = new XElement("MobilePhone");
            xElementMobilePhone.Add(xAttributeMobilePhone);

            //Создаем атрибут с домашним номером телефона
            Console.WriteLine("Введите домашний номер телефона:");
            string flatphone = Console.ReadLine();
            XAttribute xAttributeFlatPhone = new XAttribute("FlatPhone", flatphone);

            //Создаем элемент с домашним номером
            //и заполняем его
            XElement xElementFlatPhone = new XElement("FlatPhone");
            xElementFlatPhone.Add(xAttributeFlatPhone);

            //Добавляем все атрибуты в ээлемент номеров телефона
            xElementPhones.Add(xElementMobilePhone, xElementFlatPhone);

            #endregion;

            //Добавляем элементы адреса и телефона в элемент персоны
            person.Add(xElementAdress, xElementPhones);

            //Добавляем элемент персоны в адресную книгу
            myPhoneBook.Add(person);

            Console.WriteLine("Продолжить? н/д");
            key = Console.ReadKey(true).KeyChar;
        } while (char.ToLower(key) == 'д');

        //Сохраняем введеные значения в xml файл
        myPhoneBook.Save("_myPhoneBook.xml");
    }
}