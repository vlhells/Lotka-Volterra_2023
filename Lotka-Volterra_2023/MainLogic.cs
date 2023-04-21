using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Lotka_Volterra_2023
{
    internal class MainLogic
    {
        static List<Sheep> Sheep = new List<Sheep>();
        static List<Wolf> Wolves = new List<Wolf>();

        static int i = 0;

        internal static char[,]? Cycle(char[,] field)
        {
            bool game_over = false;

            if (i == 0)
            {
                int wolves_count = (int)(0.025f * field.Length);
                int sheep_count = (int)(0.05f * field.Length);

                for (int w = 0; w <= wolves_count; w++) // Спавн на поле волков на 0 ходе.
                {
                    Wolves.Add(new Wolf(field));
                }

                for (int s = 0; s <= sheep_count; s++)
                {
                    Sheep.Add(new Sheep(field));
                }

                i++;
            }

            foreach (var s in Sheep) // Движение всех овец.
            {
                s.Move(field);
            }

            foreach (var w in Wolves) // Движение всех волков.
            {
                w.Move(field);
            }







            // Проверка на завершение цикла:
            game_over = CalculateSheep(field);
            if (game_over)
                return null;
            return field;
        }

        private static bool CalculateSheep(char[,] field)
        {
            int sheep_count = 0;

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == 'S')
                        sheep_count++;
                }
            }

            if (sheep_count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
