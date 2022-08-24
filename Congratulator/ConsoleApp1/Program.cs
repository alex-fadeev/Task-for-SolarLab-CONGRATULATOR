using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Congratulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(new string(' ', 55) + "...");
            Console.WriteLine(new string(' ', 50) + "~ПОЗДРАВЛЯТОР~");
            Console.ResetColor();

            Birthdays instance = new Birthdays();
            instance.DisplayingTheEntireList("");
            instance.DisplayingTheListOfTodaysAndUpcoming();
            instance.DisplayingTheListOfOverdue();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new string(' ', 53) + "|Меню|");
            Console.WriteLine(new string(' ', 45) + "1. Добавить в список \n" + new string(' ', 45) + "2. Удалить из списка\n" + new string(' ', 45) + "3. Редактировать список\n" + new string(' ', 45) + "4. Выйти");
            Console.ResetColor();

            int Choose;
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Введите команду: ");
                Console.ResetColor();
                Choose = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (Choose)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(new string(' ', 45) + "(Добавление в список)");
                        Console.ResetColor();
                        Console.Write("Введите количество человек, дни рождения которых вы хотите добавить в список: ");
                        int number1 = int.Parse(Console.ReadLine());
                        instance.AddingEntriesToTheList(number1);
                        instance.DisplayingTheEntireList(" (новый)");
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(new string(' ', 45) + "(Удаление из списка)");
                        Console.ResetColor();
                        Console.Write("Введите количество человек, дни рождения которых вы хотите удалить из списка: ");
                        int number2 = int.Parse(Console.ReadLine());
                        instance.RemovingEntriesFromTheList(number2);
                        instance.DisplayingTheEntireList(" (новый)");
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(new string(' ', 45) + "(Редактирование списка)");
                        Console.ResetColor();
                        Console.Write("Введите количество человек, дни рождения которых вы хотите отредактировать в списке: ");
                        int number3 = int.Parse(Console.ReadLine());
                        instance.EditingEntriesInTheList(number3);
                        instance.DisplayingTheEntireList(" (новый)");
                        break;
                    
                    default:
                        if(Choose != 4)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Неверная команда, попробуйте ещё раз");
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                        break;
                }
            } while (Choose != 4);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(new string(' ', 25
                
                
                ) + "~Спасибо, что воспользовались ПОЗДРАВЛЯТОР, до новых встреч~");
            Console.WriteLine(new string(' ', 55) + "...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
