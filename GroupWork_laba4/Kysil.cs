using System;
using System.Collections.Generic;
using System.Text;

namespace GroupWork_laba4
{
    public class Kysil
    {
        static void Output1(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        static int MaxOfElements(int[] array, out int count)
        {
            int max = array[0];
            count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (max <= array[i])
                {
                    max = array[i];
                    count++;
                }
            }
            return max;
        }
        public void InsertHalfOfMaxNum(ref int[] arr)
        {
            int max = MaxOfElements(arr, out int count);
            if (max % 2 == 0)
            {
                int[] mass = new int[arr.Length + count];
                for (int i = 0, k = 0; k < arr.Length; i++, k++)
                {
                    if (arr[k] == max)
                    {
                        mass[i] = arr[k] / 2;
                        mass[i + 1] = mass[i];
                        i++;
                    }
                    else
                    {
                        mass[i] = arr[k];
                    }
                }
                arr = mass;
            }
            Output1(arr);
        }
        public void AddRowAfterFirstRowWithMaxElem(ref int[][] arr)
        {
            int max = arr[0][0], firstIndex = 0;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                for (int j = arr[i].Length - 1; j >= 0; j--)
                {
                    if (arr[i][j] >= max)
                    {
                        max = arr[i][j];
                        firstIndex = i;
                    }
                }
            }
            int[] row = InputRow(arr);
            Insert(ref arr, row, firstIndex);
            Output2(arr);
        }
        static int[] InputRow(int[][]arr)
        {
            string[] str = Console.ReadLine().Trim().Split();
            int[] row = new int[arr[0].Length];
            for (int i = 0; i < arr[0].Length; i++)
            {
                row[i] = Convert.ToInt32(str[i]);
            }
            return row;
        }
        static void Insert(ref int[][] arr, int[] row, int firstIndex)
        {
            Array.Resize(ref arr, arr.Length + 1);
            for (int i = arr.Length - 1; i > firstIndex; i--)
            {
                arr[i] = arr[i - 1];
            }
            arr[firstIndex] = row;
        }
        static void Output2(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}