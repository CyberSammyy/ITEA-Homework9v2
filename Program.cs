﻿using System;
using System.Text;

namespace ITEA_Homework9v2
{
    
    public class Program
    {
        public static int count = 0;
        public static void Main()
        {
            ChessMap.GenerateMap();
            int[] arr = new int[4];
            while (true)
            {
                if (count % 2 == 0)
                {
                    Console.WriteLine("White");
                }
                else Console.WriteLine("Black");
                string[] arr1 = Console.ReadLine().Split();
                arr[0] = Convert.ToInt32(arr1[0]);
                arr[1] = Convert.ToInt32(arr1[1]);
                arr[2] = Convert.ToInt32(arr1[2]);
                arr[3] = Convert.ToInt32(arr1[3]);
                //try
                //{
                //    r = Convert.ToChar(arr1[4]);
                //}
                //catch(Exception ex)
                //{
                //    r = '\0';
                //}
                if (count % 2 == 0 && ChessMap.MoveWhite(arr[0], arr[1], arr[2], arr[3]))
                {
                    count++;
                }
                else if(count % 2 != 0 && ChessMap.MoveBlack(arr[0], arr[1], arr[2], arr[3]))
                {
                    count++;
                }
            }
        }
    }
}
