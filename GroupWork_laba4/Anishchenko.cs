﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GroupWork_laba4
{
    internal class Anishchenko
    {
        static void ArrayOutput(int[] arr)
        {
            string str = string.Join(' ', arr);
            Console.WriteLine("Змiнений масив:");
            Console.WriteLine(str);
        }

        public void InsertArrBeforeNum(ref int[] arr)
        {
            Console.WriteLine("Введiть розмiр вставки");
            int size = int.Parse(Console.ReadLine());
            int[] paste = new int[size];
            Console.WriteLine("Введiть елементи вставки");
            string[] str = Console.ReadLine().Split();
            for (int i = 0; i < str.Length; i++)
            {
                paste[i] = int.Parse(str[i]);
            }

            int pos = 0;
            bool ispossible = false;
            while (!ispossible)
            {
                Console.WriteLine("Введiть позицiю вставки");
                pos = int.Parse(Console.ReadLine());
                if (pos > 0 && pos < arr.Length)
                {
                    ispossible = true;
                }
                else
                {
                    Console.WriteLine("Неможливо вставити на цю позицiю");
                }
            }


            int[] res = new int[arr.Length + paste.Length];
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == pos - 2)
                {
                    res[count] = arr[i];
                    count++;
                    for (int j = 0; j < paste.Length; j++)
                    {
                        res[count] = paste[j];
                        count++;
                    }
                }
                else
                {
                    res[count] = arr[i];
                    count++;
                }
            }

            ArrayOutput(res);
        }

        static void Output(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write($"{arr[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        public void AddRoWAfterEvenRow(ref int[][] arr)
        {
            int numberOfRows = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    numberOfRows++;
                }
            }

            int[][] res = new int[arr.Length + numberOfRows][];
            int[][] insert = new int[numberOfRows][];

            Console.WriteLine("Введiть довжини вставлених рядкiв матрицi");
            for (int i = 0; i < numberOfRows; i++)
            {
                Console.WriteLine($"Введiть довжину рядка {i + 1}");
                string input = Console.ReadLine();
                insert[i] = new int[int.Parse(input)];
                Console.WriteLine($"Введiть елементи рядка {i + 1}");
                string[] str = Console.ReadLine().Split();
                for (int j = 0; j < int.Parse(input); j++)
                {
                    insert[i][j] = int.Parse(str[j]);
                }
            }

            int count = 0;
            int arrCount = 0;
            int insertCount = 0;
            int arrRows = arr.Length;
            int insertRows = insert.Length;

            while ((arrRows != 0) | (insertRows != 0))
            {
                if (arrRows != 0)
                {
                    res[count] = new int[arr[arrCount].Length];
                    for (int i = 0; i < res[count].Length; i++)
                    {
                        res[count][i] = arr[arrCount][i];
                    }
                    count++;
                    arrRows--;
                }


                if (insertRows != 0)
                {
                    if ((arrCount + 1) % 2 == 0)
                    {
                        res[count] = new int[insert[insertCount].Length];
                        for (int i = 0; i < res[count].Length; i++)
                        {
                            res[count][i] = insert[insertCount][i];
                        }
                        count++;
                        insertCount++;
                        insertRows--;
                    }

                }

                if (arrRows != 0)
                {
                    arrCount++;
                }
            }

            Output(res);
        }

    }
}
