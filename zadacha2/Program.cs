/*
 выполнялись задачи имеющие номер 0 в таблицах.  
нумерация в меню следующая: первые две цыфры номер документа, третья номер задачи в нем (по счету)
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace C_Sharp_zadacha_2
{

    class funk
    {
        public static void urozaynost(double cent_ga, int proc) // метод подсчета урожайности с гектара за год
        {
            double p = (double)proc / 100; // переводим процеты в сотые доли
            for (int i = 2; i <= 8; i++) // по условию нас интересуют года со второго по восьмой
            {
                cent_ga += (cent_ga * p); // рассчитываем урожайность этого года 
                Console.WriteLine($"средняя урожайность с одного гектара в {i}-ом году: {cent_ga} (ц/га)"); //выводим             
            }
        }
        public static void pole(double ga, int proc) // метод подсчета площади земельного участка
        {
            double p = (double)proc / 100;  // переводим процеты в сотые доли         
            for (int i = 2; i < 8; i++) // т.к рассчитать шаг заранее мы не можем: перебор до седьмого года
            {
                ga += (ga * p);
                if (i >= 4) // выводим только с четвертого года
                    Console.WriteLine($"площадь участка в {i}-ом году: {ga} (га)");
            }
        }
        public static void urozay(double cent_ga, int proc_u, double ga, int proc_g) //урожай за первые 6 лет
        {
            double sum = cent_ga * ga; // первый элемент из данных первого года
            double p2 = (double)proc_g / 100;
            double p1 = (double)proc_u / 100;

            for (int i = 2; i <= 6; i++) // нас интересуют первые шесть лет
            {
                cent_ga += (cent_ga * p1); //урожайность в этот год
                ga += (ga * p2); // площадь участка в этот год
                sum += cent_ga * ga; // к общей сумме добавляем урожай этого года
            }
            Console.WriteLine($"урожай за первые 6 лет: {sum} (ц)"); //выводим
        }
        public static int chislo() //просто случайное натуральное число
        {
            var rnd = new Random();
            int value = rnd.Next(10, 100000);
            Console.WriteLine($"натуральное число: {value}");
            return value;
        }
        public static bool naity_a_in_chis(string chislo, string a) // нахождение цифры в числе
        {
            for (int i = 0; i < chislo.Length; i++) //проходим по числу (строке) как по массиву
                if (chislo[i] == a[0]) // если в числе найдена цыфра
                    return true;

            return false;
        }
        public static void function3(string chislo) // среднеарифм цифр числа
        {
            double summa = 0;
            int k;
            for (int i = 0; i < chislo.Length; i++)
            {
                k = (int)Char.GetNumericValue(chislo[i]); //переводим символ в соотв. цифру                             
                summa += k;
            }
            Console.WriteLine($"среднее арифм. цифр данного числа = {summa /= chislo.Length}");
        }

        public static void IsArmstrong(int chislo)
        {
            int ch = chislo;

            var cifr = new List<int>(4);
            while (chislo > 0) // в этом цикле разбиваем число на цифры
            {
                cifr.Add(chislo % 10);
                chislo /= 10;
            }

            var cifr_v_st = cifr.ToArray(); // для цифр, возведенных в n-ю степень

            for (int j = 0; j < (cifr_v_st.Length - 1); j++)
            {
                for (int i = 0; i < cifr_v_st.Length; i++)
                {
                    cifr_v_st[i] *= cifr[i];
                }
            }

            var sum = cifr_v_st.Sum(); // считаем сумму
            if (sum == ch)
                Console.WriteLine(ch);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = 0;
            string chislo;

            while (a != 1010) //циклим что бы всегда до момента выхода появлялось меню
            {
                a = 0;
                Console.WriteLine($"\n<>=======<>====MENU====<>========<>");
                for (int i = 1; i <= 4; i++)
                {
                    a++;
                    Console.WriteLine($"для решения задачи № 2.2.{i} нажмите {a}"); // предложение выбрать одну из четырех задач второго блока
                }
                Console.WriteLine($"для выхода нажмите 0 \n");
                a = Convert.ToInt32(Console.ReadLine()); // ввод номера задачи
                switch (a)
                {
                    case 1: // задача с зем. участком
                        {
                            int ga = 100, zem_proc = 5, uroz_proc = 2; // площадь, проценты прироста площади и урожайности
                            double cent_ga = 20; // урожайность
                            string str = "1"; // строчка для выбора   (перфекционизм наше все!)


                            while (str != " ") //пока строка не пуста после любого выбора ввыводим мини-меню
                            {
                                Console.WriteLine($"\nдля задачи a введите 'а' \nдля задачи b введите 'b' \nдля задачи c введите 'c' \nвыход - любая другая буква");
                                str = Console.ReadLine(); // выбираем желаемую к решению часть задачи (саму задачу в программе выводить нне продуктивно хотя и можно)

                                switch (str)
                                {
                                    case "a": // задание с приростом урожайности
                                        funk.urozaynost(cent_ga, uroz_proc);
                                        break;

                                    case "b": // задание с приростом площади
                                        funk.pole((double)ga, zem_proc);
                                        break;

                                    case "c": // задание с урожаем за 6 лет
                                        funk.urozay(cent_ga, uroz_proc, ga, zem_proc);
                                        break;

                                    default:
                                        str = " ";
                                        break;
                                }
                            }

                        }

                        break;

                    case 2: // Дано натуральное число. Определить, есть ли в нем цифра а. 
                        {
                            chislo = Convert.ToString(funk.chislo()); //получаем случайное число
                            Console.WriteLine($"наличие какой цифры вы хотите проверить?");
                            var str = Console.ReadLine(); //вводи цифру для проверки
                            if (funk.naity_a_in_chis(chislo, str))
                                Console.WriteLine($"цифра есть в числе");
                            else Console.WriteLine($"цифры нет в числе");
                        }
                        break;

                    case 3: // Дано натуральное число. Определить: среднее арифметическое его цифр
                        chislo = Convert.ToString(funk.chislo());
                        funk.function3(chislo);
                        break;

                    case 4://числа Армстронга
                        {
                            int y = 1, n;
                            do
                            {
                                Console.WriteLine("Введите число (не более 4 цифр)");
                                n = (int)uint.Parse(Console.ReadLine());
                            }
                            while (n > 10000);
                            while (y <= n) { funk.IsArmstrong(y); y++; }

                        }
                        break;

                    default:
                        a = 1010;
                        break;
                }
            }

        }
    }
}

