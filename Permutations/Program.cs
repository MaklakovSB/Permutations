using System;

namespace Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array;
            ushort lengthN = 0;
            ushort lengthM = 0;

            string stringLengthN = string.Empty;
            string stringLengthM = string.Empty;

            ulong operationsCount = 0;

            // Получим n.
            do
            {
                Console.WriteLine("Введите длину массива, от 10 до 65535 n: ");
                stringLengthN = Console.ReadLine();
            }
            while (!ushort.TryParse(stringLengthN, out lengthN) || lengthN < 10 || lengthN > 65535);

            // Получим m.
            do
            {
                Console.WriteLine("Введите длину области массива для переноса её в конец, от 1 до 65535 m: ");
                stringLengthM = Console.ReadLine();
            }
            while (!ushort.TryParse(stringLengthM, out lengthM) || lengthM < 1 || lengthM > 65535);

            // Инициализируем массив.
            array = new int[lengthN];

            // Заполним массив.
            for(ushort i = 0; i < array.Length; i++)
            {
                array[i] = i+1;
            }

            Console.WriteLine("Содержимое массива до перестановки:");

            // Выведем массив до перестановок.
            foreach (var element in array)
            {
                Console.Write($@"[{element}] ");
            }

            Console.WriteLine("\r");

            // Перестановки.
            for (var i = 0; i < lengthM;i++)
            {
                var m = array[0];

                // Подсчёт операциий считывания.
                operationsCount++;

                for (var j = 1; j < lengthN; j++)
                {
                    var n = array[j];
                    array[j-1] = n;

                    // Подсчёт операциий чтения и записи.
                    operationsCount +=2;
                }

                array[lengthN -1] = m;

                // Подсчёт операциий записи.
                operationsCount++;
            }

            Console.WriteLine("Содержимое массива после перестановки:");

            // Выведм массив после перестановок.
            foreach (var element in array)
            {
                Console.Write($@"[{element}] ");
            }

            Console.WriteLine("\r");
            Console.WriteLine($@"Количество операций по счётчику: {operationsCount}");
            Console.WriteLine("\r");
            Console.WriteLine($@"Формула расчёта операций: K = m * (2 + (n - 1) * 2)");
            Console.WriteLine($@"Проверочный расчёт: {lengthM} * (2 + ({lengthN} -1) * 2) = {lengthM * (2 + (lengthN -1) * 2)}");
            Console.WriteLine("\r");
            Console.WriteLine($@"Проверка кратности m: {operationsCount} / {lengthM} = {operationsCount / lengthM}, остаток {operationsCount % lengthM}");
            Console.WriteLine($@"Проверка кратности n: {operationsCount} / {lengthN} = {operationsCount / lengthN}, остаток {operationsCount % lengthN}");

            Console.ReadKey();
        }
    }
}
