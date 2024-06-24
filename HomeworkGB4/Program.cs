namespace HomeworkGB4
{
    internal class Program
    {
        /* Условие задачи:
         * Дан массив и число. Найдите три числа в массиве, сумма которых равна искомому числу.
         * Подсказка: если взять первое число в массиве, можно ли 
         * найти в оставшейся его части два числа, равных по сумме первому.
         * 
         * Мой комментарий:
         * Метод Searching реализует поиск по массиву из условия дз.
         * Метод FullSearching перебирает абсолютно все комбинации для поиска любого числа.
         * Если Searching не нашел число, то можно ввести вручную это число, чтобы его  
         * попытался найти FullSearching. FullSearching подберет нужную комбинацию, если она есть в массиве.
         */
        static void Main()
        {
            Console.WriteLine("Коллекция из рандомных чисел длиной 50 элементов: ");

            int[] array = new int[50];
            Random rnd = new();

            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(0, 100);

            Console.WriteLine(string.Join(", ", array) + "\n");

            int target = array[0] * 2;

            Console.WriteLine($"Ищем элементы, сумма которых равна {target} (по условию задачи): ");

            Console.WriteLine(Searching(array, target, out string result) ? result : "Не найдено");

            Console.WriteLine("\nТеперь вы можете попробовать ввести число самостоятельно! \nВведите число, чтобы продолжить, или любой буквенный символ для выхода: ");

            while (int.TryParse(Console.ReadLine(), out int value))
            {
                Console.WriteLine(FullSearching(array, value, out result) ? result : "Не найдено");
            }

            Console.ReadKey(true);
        }
        static bool Searching(int[] arr, int target, out string res)
        {
            var hashSet = new HashSet<int>();
            res = "";

            for (int i = 1; i < arr.Length; i++)
            {
                var temp = arr[0] - arr[i];
                if (hashSet.Contains(temp))
                {
                    res = $"{arr[0]} + {arr[i]} + {temp} = {target}";
                    return true;
                }
                else
                {
                    hashSet.Add(arr[i]);
                }
            }
            return false;
        }

        static bool FullSearching(int[] arr, int target, out string res)
        {
            var hashSet = new HashSet<int>();
            res = "";
            int halfTarget, temp;

            for (int i = 0; i < arr.Length; i++)
            {
                halfTarget = target - arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    temp = halfTarget - arr[j];
                    if (hashSet.Contains(temp))
                    {
                        res = $"{arr[i]} + {arr[j]} + {temp} = {target}";
                        return true;
                    }
                    else
                    {
                        hashSet.Add(arr[j]);
                    }
                }
                hashSet.Clear();
            }
            return false;
        }
    }
}
