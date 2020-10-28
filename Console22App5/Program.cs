using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console22App5
    // Автор: Николай Ильичев
{
    class Program

    {

        /// <summary>Метод проверки на соответствие логина требованиям</summary>
        /// <param name="login">Логин</param>
        /// <returns></returns>
        static bool CheckLogin(string login)
        {
            int length = login.Length;
            if (length >= 2 && length <= 10)
            {
                bool check = true;
                char letter = login[0];
                if (Char.IsDigit(letter))
                    return false;
                for (int i = 1; i < length; i++)
                {
                    letter = login[i];
                    if (!(Char.IsDigit(letter) || IsLatinLetter(letter)))
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                    return true;
            }
            return false;
        }

        /// <summary>Метод проверки на соответствие логина требованиям через регулярные выражения</summary>
        /// <param name="login">Значение логина</param>
        /// <returns></returns>
        static bool CheckLoginReg(string login)
        {
            char letter = login[0];
            if (Char.IsDigit(letter))
                return false;
            if (!Regex.IsMatch(login, @"^[a-zA-Z0-9]+${2,10}"))
                return false;
            return true;
        }

        /// <summary>Метод проверяет, что символ - латинская буква</summary>
        /// <param name="letter">Символ</param>
        /// <returns></returns>
        private static bool IsLatinLetter(char letter)
        {
            int num = letter;
            if ((num >= 65 && num <= 90) || (num >= 97 && num <= 122))
                return true;
            else
                return false;
        }

        static void Main(string[] args)
        {
            // Автор: Николай Ильичев 

            // 1. Создать программу, которая будет проверять корректность ввода логина. 
            // Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, 
            // при этом цифра не может быть первой:
            // а) без использования регулярных выражений;
            // б) **с использованием регулярных выражений.

                                    
            Console.WriteLine("Программа проверки корректности логина:");
            int AmountOfTries = 3;

            do
            {
                Console.Write("Введите логин: ");
                string login = Console.ReadLine();

                if (CheckLogin(login) && CheckLoginReg(login))
                {
                    Console.WriteLine("Логин корректен");
                    break;
                }
                else
                {
                    AmountOfTries--;
                    Console.WriteLine("Неверный ввод логина. \nДолжны быть соблюдены следующие условия:"
                        + "\nдлина строки 2 до 10 символов;"
                        + "\nбуквы только латинского алфавита или цифры;"
                        + "\nцифра не может быть первой."
                        + "У Вас осталось " + AmountOfTries + " попыток");
                } 

            } while (AmountOfTries > 0);

            Console.WriteLine("Продолжаем дальше");

            Console.ReadLine();


            // 2. Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
            // а) Вывести только те слова сообщения,  которые содержат не более n букв.
            // б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
            // в) Найти самое длинное слово сообщения.
            // г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
            // д) ***Создать метод, который производит частотный анализ текста.
            // В качестве параметра в него передается массив слов и текст, 
            // в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. 
            // Здесь требуется использовать класс Dictionary.


           Console.WriteLine("2. Возможности статического класса Message: ");

            Console.WriteLine("\nИмеется следующий текст: \n" + Message.text);

            Console.WriteLine("\nВыведем слова текста, которые содержат не более 5 букв:");
            Message.GetWordsByLength(5);

            Console.WriteLine();
            Console.Write("\nУдалим из текста слова, заканчивающиеся на 'я': ");
            Message.DeleteWordByEndChar('я');

            Console.WriteLine();
            Console.WriteLine("\nСамое длинное слово в тексте: " + Message.FindMaxLengthWord());


            Console.WriteLine("\nСформированная строка StringBuilder из самых длинных слов сообщения: \n" + Message.GetLongWordsString());

            Console.WriteLine("\nПроизведём частотный анализ текста: ");
            string[] arr = { "шторм", "пошли", "воде", "рыбка", "выпустил", "много" };
            Message.FrequencyAnalysis(arr, Message.text);
            Console.ReadLine();

            string txt = ("Благодарю за внимание!!! С Уважением, Н. Ильичев");
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - txt.Length / 2, Console.WindowHeight / 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(txt);
            Console.ReadLine();

        }
    }
}
