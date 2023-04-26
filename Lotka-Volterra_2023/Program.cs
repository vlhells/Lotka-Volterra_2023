namespace Lotka_Volterra_2023
{
    internal class Program
    {
        private static void Main()
        {
            // Ввод:
            Messages.SayHello();
            string[] field_sizes = Console.ReadLine().Split('x');

            // Иниализация поля:
            char[,] field = InputParseAndInit.InitializeField(field_sizes);

            do // Основной цикл отрисовки:
            {
                field = MainLogic.Cycle(field);
                if (field != null)
                {
                    CalculateAnimals(field, out (int s, int w, int g) counts);
                    Draw(field, counts);
                }
            }
            while (field != null);
        }

        private static void Draw(char[,] field, (int s, int w, int g) counts) // Вывод поля на консоль.
        {
            Thread.Sleep(750);
            Console.Clear();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    switch (field[i, j])
                    {
                        case 'S':
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;

                        case 'W':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                    }
                    
                    Console.Write(field[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write($"Овец: {counts.s}\nВолков:{counts.w}\nТравы:{counts.g}");
        }

        private static void CalculateAnimals(char[,] field, out (int s, int w, int g) counts)
        {
            counts = (0, 0, 0);

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    switch (field[i, j])
                    {
                        case 'S':
                            counts.s++;
                            break;

                        case 'W':
                            counts.w++;
                            break;

                        case '@':
                            counts.g++; 
                            break;
                    }
                }
            }
        }
    }
}