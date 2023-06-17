namespace Logic_Game_Georgi
{
    internal class Program
    {
        static void Main(string[] args)       
        {
            int first = 123;
            int second = 222;
            int rowLength = first.ToString().Length + 3 + second.ToString().Length;
            int result = first * second;

            int[] firstMassiv = first.ToString().Select(n => int.Parse(n.ToString())).Reverse().ToArray(); //Convert first parameter to int array
            //int[] secondMassiv = second.ToString().Select(n => int.Parse(n.ToString())).Reverse().ToArray();//Convert first parameter to int array
                   
          
            Console.WriteLine($"{first} * {second}");
            Console.WriteLine(new string('-', rowLength));

            for (int i = 0; i < firstMassiv.Length; i++)
            {
                Console.WriteLine($"{new string(' ', second.ToString().Length + 3 - i)}{firstMassiv[i] * second}");
            }

            Console.WriteLine(new string('-', rowLength));
            Console.WriteLine($"{new string(' ', )}");


        }
    }
}