using System;
using System.Text;

namespace ITEA_Homework9v2
{
    
    public class Program
    {
        public static void Main()
        {
            ChessMap.GenerateMap();
            int[] arr = new int[4];
            while (true)
            {
                arr[0] = Convert.ToInt32(Console.ReadLine());
                arr[1] = Convert.ToInt32(Console.ReadLine());
                arr[2] = Convert.ToInt32(Console.ReadLine());
                arr[3] = Convert.ToInt32(Console.ReadLine());
                ChessMap.Move(arr[0], arr[1], arr[2], arr[3]);
                Console.WriteLine("Do you want to continue?");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    break;
            }
            Console.ReadKey();
        }
    }
}
