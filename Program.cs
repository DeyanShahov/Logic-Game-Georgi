namespace Logic_Game_Georgi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int first = 123;
            int second = 222;
            int rowLength = first.ToString().Length + 3 + second.ToString().Length; // Максимална дължина на целия израз
            int result = first * second; // Резултатът на сметката

            int[] firstMassive = first.ToString().Select(n => int.Parse(n.ToString())).Reverse().ToArray(); // Преобразуване на първия елемент в масив
            //int[] secondMassive = second.ToString().Select(n => int.Parse(n.ToString())).Reverse().ToArray();


            Console.WriteLine($"{first} * {second}");
            Console.WriteLine(new string('-', rowLength));

            for (int i = 0; i < firstMassive.Length; i++)
            {
                Console.WriteLine($"{new string(' ', second.ToString().Length + 3 - i)}{firstMassive[i] * second}");
            }

            Console.WriteLine(new string('-', rowLength));
            Console.WriteLine($"{new string(' ', rowLength - result.ToString().Length)}{result}");

            //-----------------------------------------------------------------------------------------------------------------------------------------------

            Random random = new Random();

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


            //------------------------------------------------------------------------------------------------------------------------------------------------


            string toPrint = string.Empty;

            toPrint += ConvertDigitsToLetter(first, letterToDigit, toPrint);

            toPrint += " * ";

            toPrint = ConvertDigitsToLetter(second, letterToDigit, toPrint);

            Console.WriteLine(toPrint);
            Console.WriteLine(new string('-', rowLength));

            toPrint = string.Empty;

            for (int i = 0; i < firstMassive.Length; i++)
            {
                Console.WriteLine($"{new string(' ', second.ToString().Length + 3 - i)}{ConvertDigitsToLetter(firstMassive[i] * second, letterToDigit, toPrint)}");
            }

            Console.WriteLine(new string('-', rowLength));
            Console.WriteLine($"{new string(' ', rowLength - result.ToString().Length)}{ConvertDigitsToLetter(result, letterToDigit, toPrint)}");
        }

        private static string ConvertDigitsToLetter(int second, Dictionary<int, char> letterToDigit, string toPrint)
        {
            foreach (var n in second.ToString())
            {
                toPrint += letterToDigit[int.Parse(n.ToString())];
            }

            return toPrint;
        }
    }
}