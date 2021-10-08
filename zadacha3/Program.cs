using System;
using System.Collections.Generic;


namespace C_Sharp_zadacha_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n_m = 15, y = 0, j = 0; // размер массива, число y, индекс
            int[] mas = new int[n_m]; // создаем массив
            fill_array(mas, 1000);



            var a = 0;

            while (a != 1010)
            {
                a = MEnu(a);
                switch (a)
                {
                    case 1: //вызываем решение 1 задачи
                        {

                            Console.WriteLine(string.Join("  ", mas)); // выводим массив на экран
                            zadacha1(mas, y, j);
                        }
                        break;

                    case 2: // вызываем решение 2 задачи
                        {

                            var mas_z = new List<int>(1); //создаем список
                            var rand = new Random();
                            int[] mas_x = new int[rand.Next(5, 25)]; // создаем массивы
                            int[] mas_y = new int[rand.Next(5, 25)];

                            fill_array(mas_x, 20);
                            fill_array(mas_y, 20);

                            Console.WriteLine(string.Join("  ", mas_x)); // выводим массив на экран
                            Console.WriteLine(string.Join("  ", mas_y)); // выводим массив на экран

                            if (mas_x.Length < mas_y.Length)
                                form_z(mas_x, mas_y, mas_z);
                            else
                                form_z(mas_y, mas_x, mas_z);

                        }
                        break;

                    case 3: // вызываем решение 3 задачи
                        {
                            Console.WriteLine($" тут ничего нету ");
                        }
                        break;

                    case 4: // вызываем решение 4 задачи
                        {
                            int n, m;

                            Console.WriteLine($" введите кол-во строк");
                            n = Convert.ToInt32(Console.ReadLine());    // считываем выбор пользователя    

                            Console.WriteLine($"введите кол-во столбцов");
                            m = Convert.ToInt32(Console.ReadLine());    // считываем выбор пользователя    

                            int[,] array = new int[n, m];

                            Random ran = new Random();//новый элемент типа рандом

                            // Инициализируем массив
                            for (int i = 0; i < n; i++) //проходим по строкам
                            {
                                for (j = 0; j < m; j++) //проходим по столбцам
                                {
                                    array[i, j] = ran.Next(1, 15);
                                    Console.Write("{0}\t", array[i, j]);
                                }
                                Console.WriteLine();
                            }

                            Console.WriteLine($"на сколько элементов произвести сдвиг?");
                            int sdvig = Convert.ToInt32(Console.ReadLine());    // считываем выбор пользователя    

                            Console.WriteLine("какой сдвиг?\n1-циклический вправо (барабаном)\n2-циклический вниз (барабаном)" +
                                "\n3-циклический вправо (z-перемещение)\n ");
                            int vibor = Convert.ToInt32(Console.ReadLine());    // считываем выбор пользователя    


                            switch (vibor)
                            {
                                case 1:
                                    baraban_prav(array, sdvig);
                                    break;

                                case 2:
                                    baraban_vniz(array, sdvig);
                                    break;

                                case 3:
                                    Z_circle_zsuv(array, sdvig);
                                    break;

                                default:
                                    break;
                            }

                            Console.WriteLine();
                            for (int i = 0; i < n; i++)
                            {
                                for (j = 0; j < m; j++)
                                {
                                    Console.Write("{0}\t", array[i, j]);
                                }
                                Console.WriteLine();
                            }
                        }
                        break;

                    default: // иначе присваиваем выход
                        a = 1010;
                        break;
                }
            }
        }
        private static int MEnu(int a)
        {
            a = 0;
            Console.WriteLine($"\n<>=======<>====MENU====<>========<>");
            for (int i = 1; i <= 4; i++)
            {
                a++;
                Console.WriteLine($"для решения задачи № 2.3.{i} введите {a}"); //выводим номера задач и соотв клавиши
            }
            Console.WriteLine($"для выхода введите 0 \n");
            a = Convert.ToInt32(Console.ReadLine());    // считываем выбор пользователя  
            return a;
        }
        private static void fill_array(int[] mas, int gran)
        {
            var rnd = new Random();
            for (int i = 0; i < mas.Length; i++) // в цикле заполняем массив случайными числами
            {
                mas[i] = rnd.Next(0, gran);
            }
            Array.Sort(mas); // вызываем встроенную функцию сортировки

        }
        private static void zadacha1(int[] mas, int y, int j)
        {

            Console.WriteLine($"введите число \n");
            y = Convert.ToInt32(Console.ReadLine());    // считываем выбор пользователя


            if (y < mas[0]) // если число меньше первого элемента массива
                Console.WriteLine($"число {y} необходимо поставить перед 1-ым элементом (имеющим индекс 0) \n");
            else
            {
                while (j < mas.Length && y > mas[j]) //пока не вышли за пределы массива и пока у больше текущего
                { j++; }//увеличиваем номер места
                Console.WriteLine($"число {y} необходимо поставить после {j}-го элемента (имеющего индекс {j - 1}) \n");
            }
        }
        private static void form_z(int[] mas_m, int[] mas_b, List<int> list)
        {
            int kol_m = 0, kol_b = 0, temp = -1000;

            for (int i = 0; i < mas_m.Length; i++)//запускаем обход меньшего
            {
                if (mas_m[i] > temp && oba(mas_m[i], mas_b)) // если новый элемент больше предыдущего (иначе нет смысла его проверять)
                {
                    temp = mas_m[i]; // сохр. его

                    kol_m = skolko_raz(mas_m, temp);
                    kol_b = skolko_raz(mas_b, temp);

                    if (kol_m < kol_b)//опр. меньшее кол-во повторений
                    {
                        for (int local = 0; local < kol_m; local++)//заносим в список столько раз
                            list.Add(temp);
                    }
                    else
                    {
                        for (int local = 0; local < kol_b; local++)
                            list.Add(temp);
                    }
                }
            }
            var cifr = list.ToArray();//преобразуем список в массив
            Console.WriteLine(string.Join("  ", cifr)); //выводим
        }
        private static int skolko_raz(int[] mas1, int temp)
        {
            int kol = 0;
            int j = 0;
            while (j < mas1.Length && (temp >= mas1[j])) //пока не вышли за пределы и сохраненный
                                                         //больше или равен рассматриваемому 
            {
                if (temp == mas1[j]) // если равен
                    kol++; // увеличиваем количество
                j++; // идем по масиву дальше
            }
            return kol;
        }
        private static bool oba(int elem, int[] mas_b)
        {
            int result = Array.Find(mas_b, i => i == elem);
            // не видит 0 потому что при не нахождении тоже 0

            if (mas_b[0] == 0 && elem == 0)//да это костыль, но при моем методе заполнения ничем не грозит
                result = 1;



            if (result == 0)
                return false;
            else
                return true;
        }

        private static void baraban_prav(int[,] mas, int sdvig)
        {
            int rows = mas.GetUpperBound(0); //кол-во строк (в данном варианте последн. индекс)
            int columns = mas.GetUpperBound(1);//кол-во столбцов (в данном варианте последн. индекс)
            for (int outline = 0; outline < sdvig; outline++) //зацикливаем одинарный сдвиг
            {
                for (int i = 0; i <= rows; i++) //перебираем строки
                {
                    int temp = mas[i, columns]; //запоминаем последний элемент строки
                    for (int j = columns; j >= 0; j--) // перебираем колонки в обратном порядке
                    {
                        if (j == 0)//если первая колонка записываем в нее сохраненный элемент
                            mas[i, j] = temp;
                        else
                            mas[i, j] = mas[i, j - 1];//иначе просто предыдущий
                    }
                }
            }
        }

        private static void baraban_vniz(int[,] mas, int sdvig)
        {
            int rows = mas.GetUpperBound(0);
            int columns = mas.GetUpperBound(1);

            for (int outline = 0; outline < sdvig; outline++) //зацикливаем одинарный сдвиг
            {
                for (int j = 0; j <= columns; j++)// перебираем колонки
                {
                    int temp = mas[rows, j];//запоминаем последний элемент колонки
                    for (int i = rows; i >= 0; i--) //перебираем строки в обратном порядке
                    {
                        if (i == 0)
                            mas[i, j] = temp;//если первая строка записываем в нее сохраненный элемент
                        else
                            mas[i, j] = mas[i - 1, j];//иначе просто предыдущий
                    }
                }
            }
        }

        private static void Z_circle_zsuv(int[,] mas, int sdvig)
        {
            for (int outline = 0; outline < sdvig; outline++)//зацикливаем одинарный сдвиг
            {
                int rows = mas.GetUpperBound(0);
                int columns = mas.GetUpperBound(1);

                int temp = mas[rows, columns];//запоминаем последний элемент матрицы

                for (int i = rows; i >= 0; i--) //перебираем строки в обратном порядке
                {
                    for (int j = columns; j >= 0; j--) // перебираем колонки в обратном порядке
                    {
                        if (j > 0) { mas[i, j] = mas[i, j - 1]; } //если просто очередной элемент заносим предыдущий
                        if (j == 0 && i > 0) { mas[i, j] = mas[i - 1, columns]; } //если начало строки но не первая
                                                                                  //строка, заносим последний элемент
                                                                                  //предыдущей строки
                        if (j == 0 && i == 0) { mas[i, j] = temp; }//если начало строки и первая
                                                                   //строка, заносим сохраненный элемент
                    }
                }
            }
        }
    }
}

