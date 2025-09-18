namespace lab_2
{
    class class1
    {
        static int[] rand()
        {
            int[] list = new int[10];
            Random random = new Random();
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = random.Next(20);
            }
            return list;
        }

        static void Main(string[] args)
        {
            int[] list = rand();

            Console.WriteLine("Введите число N");
            string input = Console.ReadLine();
            int N = int.Parse(input);

            int a = 0, a_value = int.MaxValue, b = 0, b_value = int.MaxValue;
            
            foreach (int i in list)
            {
                if (Math.Abs(N - i) < a_value)
                {
                    b = a; b_value = a_value;
                    a = i; a_value = Math.Abs(N - i);
                }
                else if (i == a)
                {
                    b = a; b_value = a_value;
                }
                else if (Math.Abs(N - i) < b_value)
                {
                    b = i; b_value = Math.Abs(N - i);
                }
            }

            Console.WriteLine($"Массив чисел - {string.Join(", ", list)}");
            Console.WriteLine($"Первое число - {a}, близость числа - {a_value}, второе число - {b}, близость второго числа - {b_value}");

            Console.ReadKey();
        }   
    }
}