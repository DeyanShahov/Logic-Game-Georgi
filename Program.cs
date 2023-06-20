using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic_Game_Georgi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Random random = new Random();
                long firstParameter = 0;
                long secondParameter = 0;

                char[] charArray = Enumerable.Range('A', 26).Select(x=> (char)x).ToArray();
                char[] symbolArray = {'/', '?', '!', '"', '#', '@', '$', '%', '&', '+', '-',
                            '(', ')', '=', '_', '{', '}', '[', ']', '~'};

                SetParameters(random, out firstParameter, out secondParameter); // Функция за въвеждане на параметрите
                Console.WriteLine();

                //-----------------------------------------------------------------------------------------------------------------------------------------------

                int rowLength = firstParameter.ToString().Length + 3 + secondParameter.ToString().Length; // Максимална дължина на целия израз
                long result = firstParameter * secondParameter; // Резултатът на умножението

                int[] secondMassive = secondParameter.ToString().Select(n => int.Parse(n.ToString())).Reverse().ToArray(); // Преобразуване на втория елемент в масив




                //-----------------------------------------------------------------------------------------------------------------------------------------------

                var selectedArray = random.Next(2) == 0 ? charArray : symbolArray; // Избирам на случаен принцип един от двата варианта на символи

                List<char> letters =  selectedArray
                    .OrderBy(x => random.Next())
                    .Take(10) // Произволно разбъркване на списъка с буквите и избиране на първите 10
                    .ToList();

                Dictionary<int, char> letterToDigit = new Dictionary<int, char>(); // Заместване на буквите с цифрите от 0 до 9
                for (int i = 0; i < letters.Count; i++)
                {
                    letterToDigit[i] = letters[i];
                }

                //-----------------------------------------------------------------------------------------------------------------------------------------------


                string toPrint = string.Empty;

                toPrint += ConvertDigitsToLetter(firstParameter, letterToDigit, toPrint);

                toPrint += " * ";

                toPrint = ConvertDigitsToLetter(secondParameter, letterToDigit, toPrint);

                Console.WriteLine(toPrint);
                Console.WriteLine(new string('-', rowLength));

                toPrint = string.Empty;

                for (int i = 0; i < secondMassive.Length; i++)
                {
                    long sum = firstParameter * secondMassive[i];
                    Console.WriteLine("{0}{1}", new string(' ', rowLength - sum.ToString().Length - i), ConvertDigitsToLetter(firstParameter * secondMassive[i], letterToDigit, toPrint));
                }

                Console.WriteLine(new string('-', rowLength));
                Console.WriteLine("{0}{1}", new string(' ', rowLength - result.ToString().Length), ConvertDigitsToLetter(result, letterToDigit, toPrint));

                int command = ShowMenu();

                while (true) // Стартиране на нов постоянен "game loop"
                {

                    if (command == 1) // Ново зареждане на задача
                    {
                        break;
                    }
                    else if (command == 2) // Край и затваряне на приложението
                    {
                        return;
                    }
                    else if (command == 3) // Решението преди да е замаскирано
                    {
                        RealNubers(firstParameter, secondParameter, rowLength, result, secondMassive); 
                        command = ShowMenu();
                    }
                    else if (command == 4) // Отпечатване на списък с цифри кум букви
                    {
                        ViewDigitsToLetters(letterToDigit);
                        command = ShowMenu();
                    }
                }
            }
        }

        private static void RunApp()
        {

        }

        private static int ShowMenu()
        {
            List<string> menuOptions = new List<string> // Генерира лист със съдържанието на менюто
            {
                "\nЗа нов опит:  1",
                "За отказване изберете: 2",
                "За показване оригинал: 3",
                "За показване на списък: 4"
            };
   
            Console.WriteLine(string.Join("\n", menuOptions)); // Отпечатва менюто

            string command = Console.ReadLine(); // Въвеждане на опция от потребителя


            // Проверява дали въведената опция е реален избор, докато не получи реална опция, пита отново
            while (!Enumerable.Range(1, menuOptions.Count).Select(x => x.ToString()).Contains(command)) 
            {
                Console.Write("\nНевалидна опция!\nИзберете наново: ");
                command = Console.ReadLine();
            }

            return int.Parse(command);
        }

        private static void ViewDigitsToLetters(Dictionary<int, char> letterToDigit)
        {
            Console.WriteLine(); // Добавяне на празен ред за визуализация
            foreach (var kvp in letterToDigit) // Отпечатване на съответствието между буквите и цифрите
            {
                Console.Write("{0} - {1} / ", kvp.Key, kvp.Value);
            }
            Console.WriteLine(); // Добавяне на празен ред за визуализация
        }

        private static void RealNubers(long firstParameter, long secondParameter, int rowLength, long result, int[] secondMassive)
        {
            Console.WriteLine("\n{0} * {1}", firstParameter, secondParameter);
            Console.WriteLine(new string('-', rowLength));

            for (int i = 0; i < secondMassive.Length; i++)
            {
                long sum = firstParameter * secondMassive[i];
                Console.WriteLine("{0}{1}", new string(' ', rowLength - sum.ToString().Length - i), sum);
            }

            Console.WriteLine(new string('-', rowLength));
            Console.WriteLine("{0}{1}", new string(' ', rowLength - result.ToString().Length), result);
        }

        private static void SetParameters(Random random, out long firstParameter, out long secondParameter)
        {
            int inputNumber = 1;
            bool isValidNumber = false;

            while (!isValidNumber)
            {

                Console.Write("Въведете парвия множител до колко цифрен да е. Възможният избор е в интервала от 1 до 9: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out inputNumber)) // Обръщане и проверка дали въведеното е число 
                {
                    Console.WriteLine("Въведеното не е число!");
                    continue;

                }

                if (inputNumber < 1 || inputNumber > 9) // Проверка дали числото е позволено
                {
                    Console.WriteLine("Въведеното число не е в правилния интервал!");
                    continue;
                }

                isValidNumber = true;
            }

            switch (inputNumber)
            {
                case 1:
                    firstParameter = random.Next(1, 9);
                    break;
                case 2:
                    firstParameter = random.Next(10, 99);
                    break;
                case 3:
                    firstParameter = random.Next(100, 999);
                    break;
                case 4:
                    firstParameter = random.Next(1000, 9999);
                    break;
                case 5:
                    firstParameter = random.Next(10000, 99999);
                    break;
                case 6:
                    firstParameter = random.Next(100000, 999999);
                    break;
                case 7:
                    firstParameter = random.Next(1000000, 9999999);
                    break;
                case 8:
                    firstParameter = random.Next(10000000, 99999999);
                    break;
                case 9:
                    firstParameter = random.Next(100000000, 999999999);
                    break;
                default:
                    firstParameter = random.Next(1, 999999999);
                    break;
            }

            isValidNumber = false;

            while (!isValidNumber)
            {

                Console.Write("Въведете втория множител до колко цифрен да е. Възможният избор е в интервала от 1 до 9: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out inputNumber)) // Обръщане и проверка дали въведеното е число 
                {
                    Console.WriteLine("Въведеното не е число!");
                    continue;

                }

                if (inputNumber < 1 || inputNumber > 9) // Проверка дали числото е позволено
                {
                    Console.WriteLine("Въведеното число не е в правилния интервал!");
                    continue;
                }

                isValidNumber = true;
            }

            switch (inputNumber)
            {
                case 1:
                    secondParameter = random.Next(1, 9);
                    break;
                case 2:
                    secondParameter = random.Next(10, 99);
                    break;
                case 3:
                    secondParameter = random.Next(100, 999);
                    break;
                case 4:
                    secondParameter = random.Next(1000, 9999);
                    break;
                case 5:
                    secondParameter = random.Next(10000, 99999);
                    break;
                case 6:
                    secondParameter = random.Next(100000, 999999);
                    break;
                case 7:
                    secondParameter = random.Next(1000000, 9999999);
                    break;
                case 8:
                    secondParameter = random.Next(10000000, 99999999);
                    break;
                case 9:
                    secondParameter = random.Next(100000000, 999999999);
                    break;
                default:
                    secondParameter = random.Next(1, 999999999);
                    break;
            }

            Console.Clear();
        }

        private static string ConvertDigitsToLetter(long number, Dictionary<int, char> letterToDigit, string toPrint)
        {
            foreach (var n in number.ToString())
            {
                toPrint += letterToDigit[int.Parse(n.ToString())];
            }

            return toPrint;
        }
    }
}