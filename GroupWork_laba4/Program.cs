using System;

namespace GroupWork_laba4
{
    class Program
    {

        static void Main()
        {
            Console.WriteLine("Головне меню:");
            int choice;
            do
            {
                Console.WriteLine("Введiть 1 для запуску розв'язку завдання блоку 1 \n(Дано одновимiрний цiлочисельний масив. Виконати перетворення, яке може змiнювати кiлькiсть елементiв у ньому)");
                Console.WriteLine("Введiть 2 для запуску розв'язку завдання блоку 2 \n(Дано цiлочисельний прямокутний масив. Виконати вказане перетворення)");
                Console.WriteLine("Для виходу з програми введiть 0");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Виконую блок 1");
                       DoBlock1();
                        break;
                    case 2:
                        Console.WriteLine("Виконую блок 2");
                        DoBlock2();
                        break;
                    case 0:
                        Console.WriteLine("Зараз завершимо, тiльки натиснiть будь ласка ще раз Enter");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Команда \"{0}\" не розпiзнана. Зробiть, будь ласка, вибiр iз 1, 2, 0.", choice);
                        break;
                }
            } while (choice != 0);
        }
        static void DoBlock1()
        {
            int choice;
            do
            {
                Console.WriteLine("Якщо ви хочете створити масив, заповнивши випадково введiть 1");
                Console.WriteLine("Якщо ви хочете створити масив, заповнивши з клавiатури введiть 2");
                Console.WriteLine("Для виходу в головне меню введiть 0");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                       Block1RandomFill();
                        break;
                    case 2:
                       Block1UserFill();
                        break;
                    case 0:
                        Main();
                        break;
                    default:
                        Console.WriteLine("Команда \"{0}\" не розпiзнана. Зробiть, будь ласка, вибiр iз 1, 2, 0.", choice);
                        break;
                }
            } while (choice != 0 && choice != 1 && choice != 2);
        }

        static void Block1RandomFill()
        {
            Console.WriteLine("Введiть кiлькiсть елементiв одновимiрного масиву:");
            int elements = int.Parse(Console.ReadLine());
            int[] arr = new int[elements];
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-500, 501);
            }
            StudentChoice(arr);
        }
        static void Block1UserFill()
        {
            Console.WriteLine("Введiть елементи одновимiрного масиву через пробiл:");
            string[] str = Console.ReadLine().Trim().Split();
            int[] arr = new int[str.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(str[i]);
            }
            StudentChoice(arr);
        }
        static void Array1Output(int[] arr)
        {
            Console.WriteLine("Поточний стан масиву:");
            Console.WriteLine(string.Join(" ", arr));
        }

        static void StudentChoice(int[] arr)
        {
            int choice;
            do
            {
                Console.WriteLine("Якщо ви хочете виконати варiант 14 студентки Ткач К.В введiть 1");
                Console.WriteLine("Якщо ви хочете виконати варiант 11 студентки Кисiль А.О введiть 2");
                Console.WriteLine("Якщо ви хочете виконати варiант 10 студента Анiщенка Д.С введiть 3");
                Console.WriteLine("Щоб вивести поточний стан масиву введiть 4");
                Console.WriteLine("Щоб перестворити масив заново введiть 5");
                Console.WriteLine("Для виходу в головне меню до вибору блоку введiть 0");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Tkach t = new Tkach();
                        t.Insert1BeforeEven(ref arr);
                        break;
                    case 2:
                        Kysil k = new Kysil();
                        k.InsertHalfOfMaxNum(ref arr);
                        break;
                    case 3:
                        Anishchenko a = new Anishchenko();
                        a.InsertArrBeforeNum(ref arr);
                        break;
                    case 4:
                        Array1Output(arr);
                        break;
                    case 5:
                        DoBlock1();
                        break;
                    case 0:
                        Main();
                        break;
                    default:
                        Console.WriteLine("Команда \"{0}\" не розпiзнана. Зробiть, будь ласка, вибiр iз 1, 2, 3, 4, 5, 0.", choice);
                        break;
                }
            } while (choice != 0);
        }
        static void DoBlock2()
        {
            int choice;
            do
            {
                Console.WriteLine("Якщо ви хочете створити масив, заповнивши випадково, введiть 1");
                Console.WriteLine("Якщо ви хочете створити масив, заповнивши з клавiатури, введiть 2");
                Console.WriteLine("Для виходу в головне меню введiть 0");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                       Block2RandomFill();
                        break;
                    case 2:
                       Block2UserFill();
                        break;
                    case 0:
                        Main();
                        break;
                    default:
                        Console.WriteLine("Команда \"{0}\" не розпiзнана. Зробiть, будь ласка, вибiр iз 1, 2, 0.", choice);
                        break;
                }
            } while (choice != 0 && choice != 1 && choice != 2);
        }
        static void Block2RandomFill()
        {
            Console.WriteLine("Введiть через пробiл кiлькiсть рядочкiв та стовпчикiв прямокутного масиву:");
            string[] str = Console.ReadLine().Trim().Split();
            int rows = Convert.ToInt32(str[0]);
            int cols = Convert.ToInt32(str[1]);
            int[][] arr = new int[rows][];
            Random rnd = new Random();
            for (int i = 0; i < rows; i++)
            {
                arr[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    arr[i][j] = rnd.Next(-500,501);
                }
            }
            StudentChoice(arr);
        }
        static void Block2UserFill()
        {
            Console.WriteLine("Введiть через пробiл кiлькiсть рядочкiв та стовпчикiв прямокутного масиву:");
            string[] str = Console.ReadLine().Trim().Split();
            int rows = Convert.ToInt32(str[0]);
            int cols = Convert.ToInt32(str[1]);
            int[][] arr = new int[rows][];
            Console.WriteLine("Введiть через Enter кожен рядок, елементи розділіть пробiлом");
            for (int i = 0; i < rows; i++)
            {
                arr[i] = new int[cols];
                string[] str1 = Console.ReadLine().Trim().Split();
                for (int j = 0; j < cols; j++)
                {
                    arr[i][j] = int.Parse(str1[j]);
                }
            }
            StudentChoice(arr);
        }
        static void Array2Output(int[][] arr)
        {
            Console.WriteLine("Поточний стан масиву:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(string.Join(" ", arr[i]));
            }
        }
        
        static void StudentChoice(int[][] arr)
        {
            int choice;
            do
            {
                Console.WriteLine("Якщо ви хочете виконати варiант 14 студентки Ткач К.В введiть 1");
                Console.WriteLine("Якщо ви хочете виконати варiант 11 студентки Кисiль А.О введiть 2");
                Console.WriteLine("Якщо ви хочете виконати варiант 10 студента Анiщенка Д.С введiть 3");
                Console.WriteLine("Щоб вивести поточний стан масиву введiть 4");
                Console.WriteLine("Щоб перестворити масив заново введiть 5");
                Console.WriteLine("Для виходу в головне меню до вибору блоку введiть 0");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Tkach t = new Tkach();
                        t.AddRowAfterLastRowWithTheSmallestElement(ref arr);
                        break;
                    case 2:
                        Kysil k = new Kysil();
                        k.AddRowAfterFirstRowWithMaxElem(ref arr);
                        break;
                    case 3:
                        Anishchenko a = new Anishchenko();
                        a.AddRoWAfterEvenRow(ref arr);
                        break;
                    case 4:
                        Array2Output(arr);
                        break;
                    case 5:
                        DoBlock2();
                        break;
                    case 0:
                        Main();
                        break;
                    default:
                        Console.WriteLine("Команда \"{0}\" не розпiзнана. Зробiть, будь ласка, вибiр iз 1, 2, 3, 4, 5, 0.", choice);
                        break;
                }
            } while (choice != 0);
        }
    }
}
