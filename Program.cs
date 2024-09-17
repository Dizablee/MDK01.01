using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { -10, -5, -3, 0, 5, 7, 9, 10, 12, 15 }; //Список целых чисел
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                if (numbers[i] >= -5 && numbers[i] < 10)
                {
                    numbers.RemoveAt(i);
                }
            }
            Console.WriteLine("Список после удалений:");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
