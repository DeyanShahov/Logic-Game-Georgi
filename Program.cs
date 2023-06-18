using System;
using System.Collections.Generic;
using System.Linq;


namespace Logic_Game_Georgi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            long firstParameter = 0;
            long secondParameter = 0;

           

            int inputNumber = 1;
            bool isValidNumber = false;

            while (!isValidNumber)
            {
              
                Console.Write($"Изберете парвия множител до колко цифрен да е. Възможният избор е в интервала от 1 до 9: ");
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

                Console.Write($"Изберете втория множител до колко цифрен да е. Възможният избор е в интервала от 1 до 9: ");
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

            int rowLength = firstParameter.ToString().Length + 3 + secondParameter.ToString().Length; // Максимална дължина на целия израз
            long result = firstParameter * secondParameter; // Резултатът на сметката

            int[] firstMassive = firstParameter.ToString().Select(n => int.Parse(n.ToString())).Reverse().ToArray(); // Преобразуване на първия елемент в масив
            int[] secondMassive = secondParameter.ToString().Select(n => int.Parse(n.ToString())).Reverse().ToArray();


            Console.WriteLine($"{firstParameter} * {secondParameter}");
            Console.WriteLine(new string('-', rowLength));

            for (int i = 0; i < secondMassive.Length; i++)
            {
                long sum = firstParameter * secondMassive[i];
                Console.WriteLine($"{new string(' ', rowLength - sum.ToString().Length - i)}{sum}");
            }

            Console.WriteLine(new string('-', rowLength));
            Console.WriteLine($"{new string(' ', rowLength - result.ToString().Length)}{result}");

            //-----------------------------------------------------------------------------------------------------------------------------------------------


            List<char> letters = Enumerable.Range('A', 26).Select(x => (char)x).ToList(); // Създаване на списък с буквите от английската азбука

            letters = letters.OrderBy(x => random.Next()).Take(10).ToList();  // Произволно разбъркване на списъка с буквите и избиране на първите 10

            Dictionary<int, char> letterToDigit = new Dictionary<int, char>(); // Заместване на буквите с цифрите от 0 до 9
            for (int i = 0; i < letters.Count; i++)
            {
                letterToDigit[i] = letters[i];
            }

            Console.WriteLine(); // Добавяне на празен ред за визуализация
            foreach (var kvp in letterToDigit) // Отпечатване на съответствието между буквите и цифрите
            {
                Console.Write($"{kvp.Key} - {kvp.Value} / ");
            }
            Console.WriteLine(); // Добавяне на празен ред за визуализация
            Console.WriteLine(); // Добавяне на празен ред за визуализация


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
                Console.WriteLine($"{new string(' ', rowLength - sum.ToString().Length - i)}{ConvertDigitsToLetter(firstParameter * secondMassive[i], letterToDigit, toPrint)}");
            }

            Console.WriteLine(new string('-', rowLength));
            Console.WriteLine($"{new string(' ', rowLength - result.ToString().Length)}{ConvertDigitsToLetter(result, letterToDigit, toPrint)}");
        }

        private static string ConvertDigitsToLetter(long number, Dictionary<int, char> letterToDigit, string toPrint)
        {
            foreach (var n in number.ToString())
            {
                toPrint += letterToDigit[int.Parse(n.ToString())];
            }

            return toPrint;
        }

        private static void SetParameters()
        {

        }
    }
}