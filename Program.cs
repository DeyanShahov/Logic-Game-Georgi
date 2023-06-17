namespace Logic_Game_Georgi
{
    internal class Program
    {
        static void Main(string[] args)       
        {
            int first = 123;
            int second = 222;
            int rowLength = first.ToString().Length + 3 + second.ToString().Length; //Максимална дължина на целия израз
            int result = first * second; //Резултатът на сметката

            int[] firstMassive = first.ToString().Select(n => int.Parse(n.ToString())).Reverse().ToArray(); //Преобразуване на първия елемент в масив
            //int[] secondMassive = second.ToString().Select(n => int.Parse(n.ToString())).Reverse().ToArray();
                   
          
            Console.WriteLine($"{first} * {second}");
            Console.WriteLine(new string('-', rowLength));

            for (int i = 0; i < firstMassive.Length; i++)
            {
                Console.WriteLine($"{new string(' ', second.ToString().Length + 3 - i)}{firstMassive[i] * second}");
            }

            Console.WriteLine(new string('-', rowLength));
            Console.WriteLine($"{new string(' ', rowLength - result.ToString().Length)}{result}");



            Random random = new Random();
           
            List<char> letters = Enumerable.Range('A', 26).Select(x => (char)x).ToList(); // Създаване на списък с буквите от английската азбука
           
            letters = letters.OrderBy(x => random.Next()).Take(10).ToList();  // Произволно разбъркване на списъка с буквите и избиране на първите 10

            Dictionary<char, int> letterToDigit = new Dictionary<char, int>(); // Заместване на буквите с цифрите от 0 до 9
            for (int i = 0; i < letters.Count; i++)
            {
                letterToDigit[letters[i]] = i;
            }
            
            foreach (var kvp in letterToDigit) // Отпечатване на съответствието между буквите и цифрите
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }



        }
    }
}