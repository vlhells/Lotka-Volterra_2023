using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Lotka_Volterra_2023
{
    internal class MainLogic
    {
        static List<Animal> Animals = new List<Animal>();
        static List<Grass> grass = new List<Grass>();

        static int i = 0;

        internal static char[,]? Cycle(char[,] field) // Ввести вывод числа овец, волков и травы.
        {
            bool game_over = false;

            if (i == 0) // Спавн на 0 раунде.
            {
                int wolves_count = (int)(0.015f * field.Length);
                int sheep_count = (int)(0.05f * field.Length);
                int grass_count = (int)(0.035f * field.Length);

                for (int w = 0; w <= wolves_count; w++) // Спавн на поле волков на 0 ходе.
                {
                    Animals.Add(new Wolf(field));
                }
                for (int s = 0; s <= sheep_count; s++)
                {
                    Animals.Add(new Sheep(field));
                }
                for (int g = 0; g <= grass_count; g++)
                {
                    grass.Add(new Grass(field));
                }
            }

            if (i >= 1)
            {
                (int x, int y) wellfed = (1200, 1200);
                for (int a = 0; a < Animals.Count; a++) // Основной игровой цикл.
                {
                    Animals[a].Move(field);
                    switch (Animals[a])
                    {
                        case Wolf:
                            wellfed = Animals[a].Eat(field, Animals);
                            if (wellfed != (-1000, -1000))
                            {
                                Animals.Add(new Wolf(field, wellfed));
                            }
                            break;

                        case Sheep:
                            wellfed = Animals[a].Eat(field, Animals, grass);
                            if (wellfed != (-1000, -1000))
                            {
                                Animals.Add(new Sheep(field, wellfed));
                            }
                            break;

                    }
                    wellfed = (1200, 1200);
                }

                foreach (Animal a in Animals)
                {
                    if (a.IsHungry > 0)
                        a.IsHungry--;
                }
            }








            // Проверка на завершение цикла:
            game_over = CalculateSheep(field);
            if (game_over)
                return null;
            i++;
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
                //return true;
            }
            return false;
        }
    }
}
