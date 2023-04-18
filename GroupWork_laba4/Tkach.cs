using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GroupWork_laba4
{
    public class Tkach
    {
        public void Insert1BeforeEven(ref int[] arr)
        {
            int choice;
            do
            {
                Console.WriteLine("Якщо ви хочете виконати завдання за допомогою масиву, введiть 1");
                Console.WriteLine("Якщо ви хочете виконати завдання за допомогою колекцiї List, введiть 2");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Insert1BeforeEvenArray(ref arr);
                        break;
                    case 2:
                        Insert1BeforeEvenList(ref arr);
                        break;
                    default:
                        Console.WriteLine("Команда \"{0}\" не розпiзнана. Зробiть, будь ласка, вибiр iз 1, 2.", choice);
                        break;
                }
            } while (choice != 1 && choice != 2);
        }
        static void ArrayOutput(int[] arr)
        {
            string str = string.Join(' ', arr);
            Console.WriteLine("Змiнений масив:");
            Console.WriteLine(str);
        }
        static void Insert1BeforeEvenArray(ref int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    count++;
                }
            }
            if (count != 0)
            {
                int[] newArr = new int[arr.Length + count];
                int adds = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0)
                    {
                        newArr[i + adds] = 1;
                        newArr[i + adds + 1] = arr[i];
                        adds++;
                    }
                    else if (adds != 0)
                    {
                        newArr[i + adds] = arr[i];
                    }
                    else
                    {
                        newArr[i] = arr[i];

                    }
                }
                arr = newArr;
            }

            ArrayOutput(arr);
        }
        static void ListOutput(List<int> list)
        {
            string str = string.Join(' ', list);
            Console.WriteLine("Змiнена колекцiя:");
            Console.WriteLine(str);
        }
        static void Insert1BeforeEvenList(ref int[] arr)
        {
            List<int> list = new List<int>();
            list.AddRange(arr);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    list.Insert(i, 1);
                    i++;
                }
            }
            arr = list.ToArray();
            ListOutput(list);
        }
        public void AddRowAfterLastRowWithTheSmallestElement(ref int[][] arr)
        {
            int choice;
            do
            {
                Console.WriteLine("Якщо ви хочете виконати завдання за допомогою масиву, введiть 1");
                Console.WriteLine("Якщо ви хочете виконати завдання за допомогою колекцiї List, введiть 2");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddRowAfterLastRowWithTheSmallestElementArray(ref arr);
                        break;
                    case 2:
                        AddRowAfterLastRowWithTheSmallestElementList(ref arr);
                        break;
                    default:
                        Console.WriteLine("Команда \"{0}\" не розпiзнана. Зробiть, будь ласка, вибiр iз 1, 2.", choice);
                        break;
                }
            } while (choice != 1 && choice != 2);
        }
        static void AddRowAfterLastRowWithTheSmallestElementArray(ref int[][] arr)
        {
            Console.WriteLine($"Введiть рядок з кiлькiстю елементiв {arr[0].Length}, який бажаєте вставити:");
            string[] str2 = Console.ReadLine().Trim().Split();
            int[] row = new int[arr[0].Length];
            for (int i = 0; i < arr[0].Length; i++)
            {
                row[i] = int.Parse(str2[i]);
            }

            int indexOfMin = 0;
            int min = arr[0][0];
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] <= min)
                    {
                        indexOfMin = i;
                        min = arr[i][j];
                    }
                }
            }
            Insert(ref arr, indexOfMin + 1, row);
            JaggedArrayOutput(arr);
        }
        static void Insert(ref int[][] arr, int idx, int[] row)
        {
            Array.Resize(ref arr, arr.Length + 1);
            for (int i = arr.Length - 2; i >= idx; i--)
            {
                arr[i + 1] = arr[i];
            }
            arr[idx] = row;
        }
        static void JaggedArrayOutput(int[][] arr)
        {
            Console.WriteLine("Змiнений масив:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(string.Join(" ", arr[i]));
            }
        }
        static void AddRowAfterLastRowWithTheSmallestElementList(ref int[][] arr)
        {
            //list2.Count=cols
            List<int> list = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                list.AddRange(arr[i]);
            }
            int cols = arr[0].Length;
            Console.WriteLine($"Введiть рядок з кiлькiстю елементiв {cols}, який бажаєте вставити:");
            string[] str2 = Console.ReadLine().Trim().Split();
            List<int> list2 = new List<int>();
            for (int i = 0; i < cols; i++)
            {
                list2.Add(int.Parse(str2[i]));
            }
            int indexOfMin = list.LastIndexOf(list.Min());
            int index = 0;
            while (index <= indexOfMin)
            {
                index += list2.Count;
            }
            list.InsertRange(index, list2);
            ListAsJaggedArrayyOutput(list, list2.Count);
            for (int i = 0, k = 0; i < arr.Length; i++,k+=cols)
            {
                arr[i] = list.GetRange(k,cols).ToArray();
            }
        }
        static void ListAsJaggedArrayyOutput(List<int> list, int cols)
        {
            Console.WriteLine("Змiнена колекцiя у виглядi масиву:");
            for (int i = 0, k = 0; i < list.Count / cols; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{list[k]} ");
                    k++;
                }
                Console.WriteLine();
            }
        }
    }
}
