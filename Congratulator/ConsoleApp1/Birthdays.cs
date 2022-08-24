using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Congratulator
{
    class Birthdays 
    {
        static DateTime a = new DateTime(2000, 7, 23);
        static DateTime b = new DateTime(2004, 6, 1);
        static DateTime c = new DateTime(2003, 9, 13);
        static DateTime d = new DateTime(2004, 10, 20);
        static DateTime e = new DateTime(1999, 2, 11);
        static DateTime f = new DateTime(2000, 8, 24);
        static DateTime g = new DateTime(1996, 8, 24);
        static DateTime x = new DateTime(2000, 1, 7);
        static DateTime y = new DateTime(2002, 8, 31);
        static DateTime z = new DateTime(2003, 8, 4);
        List<DateTime> BDnumbers = new List<DateTime>() {a, b, c, d, e, f, g, x, y, z};
        List<string> BDnames = new List<string>() {"Олег", "Алексей", "Валерия", "Даниил", "Антон", "Кирилл", "Ольга", "Денис", "Мария", "Николай"};
        
        public void DisplayingTheEntireList(string str)
        {
            StreamWriter memory = new StreamWriter("ПОЗДРАВЛЯТОР - дни рождения коллег.txt");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Список дней рождений коллег{0}: ", str);
            Console.ResetColor();

            memory.WriteLine("Список дней рождений коллег{0}: ", str);
            for (int i = 0; i < BDnumbers.Count; i++)
            {
                Console.WriteLine($"{i+1}. " + BDnumbers[i].ToLongDateString() + " - " + BDnames[i]);
                memory.WriteLine($"{i + 1}. " + BDnumbers[i].ToLongDateString() + " - " + BDnames[i]);
            }
            memory.Close();
            Console.WriteLine();
        }

        public void DisplayingTheListOfTodaysAndUpcoming()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Ближайшие дни рождения: ");
            Console.ResetColor();

            DateTime today = new DateTime();
            today = DateTime.Today;
            for (int i = 0; i < BDnumbers.Count; i++)
            {
                int result = BDnumbers[i].Day - today.Day;
                
                if ((result <= 7) && (result > 0) && (today.Month == BDnumbers[i].Month))
                    Console.WriteLine(BDnumbers[i].ToString("M") + " - " + BDnames[i]);
            }
            for (int i = 0; i < BDnumbers.Count; i++)
            {
                if ((today.Day == BDnumbers[i].Day) && (today.Month == BDnumbers[i].Month))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Сегодня день рождения у коллеги: ");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(BDnames[i] + " ");
                    Console.ResetColor();

                }
            }
            Console.WriteLine();
        }

        public void DisplayingTheListOfOverdue()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Просроченные дни рождения: ");
            Console.ResetColor();

            DateTime today = new DateTime();
            today = DateTime.Today;
            for (int i = 0; i < BDnumbers.Count; i++)
            {
                int resultday = BDnumbers[i].Day - today.Day;
                int resultmonth = BDnumbers[i].Month - today.Month;

                if ( (resultmonth < 0) || ( (resultday > 0) && (resultmonth < 0)) || ((resultday < 0) && (resultmonth == 0)))
                    Console.WriteLine(BDnumbers[i].ToString("M") + " - " + BDnames[i]);
            }
        }

        public void AddingEntriesToTheList(int N)
        {
            int year = 0, month = 0, day = 0;
            int stop = BDnumbers.Count;
            for (int i = stop; i < N + stop; i++)
            {
                Console.Write("Имя коллеги: ");
                string name = Console.ReadLine();
                BDnames.Add(name);
                Console.WriteLine("День рождения коллеги " + BDnames[i]);
                Console.Write(" год: ");
                year = int.Parse(Console.ReadLine());
                Console.Write(" месяц: ");
                month = int.Parse(Console.ReadLine());
                Console.Write(" день: ");
                day = int.Parse(Console.ReadLine());
                DateTime newDateTime = new DateTime(year, month, day);
                BDnumbers.Add(newDateTime);
            }
        }

        public void RemovingEntriesFromTheList(int N)
        {
            for(int i = 0; i < N; i++)
            {
                Console.Write("Введите имя коллеги, день рождения которого вы хотите удалить из списка: ");
                string name = Console.ReadLine();
                int k = 0;
                foreach (string str in BDnames)
                {
                    if (str == name)
                    {
                        BDnumbers.RemoveAt(k);
                        break;
                    }
                    k++;
                }
                BDnames.Remove(name);
            }
        }

        public void EditingEntriesInTheList(int N)
        {
            int year = 0, month = 0, day = 0;
            for (int i = 0; i < N; i++)
            {
                Console.Write("Введите номер коллеги, день рождения которого вы хотите отредактировать: ");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine("Новый день рождения коллеги " + BDnames[number-1]);
                Console.Write(" год: ");
                year = int.Parse(Console.ReadLine());
                Console.Write(" месяц: ");
                month = int.Parse(Console.ReadLine());
                Console.Write(" день: ");
                day = int.Parse(Console.ReadLine());
                BDnumbers[number-1] = new DateTime(year, month, day);
            }
        }
    }
}
