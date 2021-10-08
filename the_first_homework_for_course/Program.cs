/*
 выполнялись задачи имеющие номер 0 в таблицах.  
нумерация в меню следующая: первые две цыфры номер документа, третья номер задачи в нем (по счету)
 */
using System;

namespace C_Sharp_course1
{
    class funk
    {
        public static double Zapolnenie(double[] nums, double kv_sum) // метод который заполнит массив случайными числами в диапазоне от нуля до 100
        {
            double value, ver;
            var rnd = new Random(); //Создание объекта для генерации чисел
            var rand = new Random();

            for (int i = 0; i < nums.Length; i++)
            {
                value = rnd.Next(0, 100);//Получить случайное число (в диапазоне от 0 до 100)
                ver = rand.Next(0, 3); //Получить случайное число (0 или 1)
                switch (ver) // В зависимости от полученого числа "ver" в массив будет записано целое либо дробное
                {
                    case 0:
                        nums[i] = value /= 100;
                        kv_sum += value * value; //т.к программа подбирает чиисла независимо от пользователя,
                                                 //целесообразно подсчитывать сумму как только появляется подходящее значение
                        break;
                    case 1:
                        nums[i] = value /= 10;
                        break;
                    default:
                        nums[i] = value;
                        break;
                }
            }
            return kv_sum;
        }

        public static void Delitel(int n) // метод находит кол-во делителей
        {
            string s3; // строка "+"
            for (int i = 1; i <= n; i++) //берем число из заданого диапазона
            {
                s3 = "";
                for (int j = 1; j <= i; j++) //т.к делителем может быть только меньшее или равное
                {
                    if (i % j == 0) //если делится без остатка значит делитель
                    {
                        s3 = String.Concat(s3, " +"); // добавляем "+" в строку
                    }
                }
                Console.WriteLine($"{i}: {s3}"); //выводит число из диапазона и столько у него плюсов сколько делителей
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = 0;

            while (a != 1010)
            {
                a = 0;
                Console.WriteLine($"\n<>=======<>====MENU====<>========<>");
                for (int i = 1; i < 3; i++)
                {
                    a++;
                    Console.WriteLine($"для решения задачи № 2.1.{i} введите {a}"); //выводим номера задач и соотв клавиши
                }
                Console.WriteLine($"для выхода введите 0 \n");
                a = Convert.ToInt32(Console.ReadLine());    // считываем выбор пользователя          
                switch (a)
                {
                    case 1: //вызываем решение 1 задачи
                        {
                            double kv_sum = 0; // сумма квадратов
                            double[] nums = new double[7]; // массив чисел
                            kv_sum = funk.Zapolnenie(nums, kv_sum); // вызываем заполнение массива  
                            Console.WriteLine(string.Join(" \t ", nums)); // выводим все элементы массива в строку (разделитель таб)
                            Console.WriteLine($"сумма квадратов чисел < 1 но > 0 равна: {kv_sum} \n"); // вывод посчитанной сумы
                        }
                        break;

                    case 2: // вызываем решение второй задачи
                        {
                            int n;
                            Console.WriteLine($"Введите N");
                            n = Convert.ToInt32(Console.ReadLine()); // вводим граничное значение
                            funk.Delitel(n);
                        }
                        break;

                    default: // иначе присваиваем выход
                        a = 1010;
                        break;
                }
            }

        }
    }
}

