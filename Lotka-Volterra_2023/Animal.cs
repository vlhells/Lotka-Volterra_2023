using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotka_Volterra_2023
{
    internal abstract class Animal : ISpawnable
    {
        private protected static Random random = new Random();
        int _x = 999;
        int _y = 999;

        internal abstract char Ico { get; set; }

        internal Animal(char[,] field)
        {
            Spawn(field);
        }

        public void Spawn(char[,] field)
        {
            do
            {
                _x = random.Next(0, field.GetLength(0));
                _y = random.Next(0, field.GetLength(1));
            }
            while (field[_x, _y] != '.');

            field[_x, _y] = Ico;
        }

        private (int, int) GenerateNewCoords(char[,] field)
        {
            int x = _x;
            int y = _y;

            int direction = random.Next(0, 4);
            switch (direction)
            {
                case 0:
                    x += 1;
                    break;

                case 1:
                    y += 1;
                    break;

                case 2:
                    x -= 1;
                    break;

                case 3:
                    y -= 1;
                    break;
            }

            return (x, y);

        }

        private bool CheckNewCoords(char[,] field, (int x, int y) coords)
        {
            for (int i = coords.x - 1; i < coords.x + 1; i++)
            {
                for (int j = coords.y - 1; j < coords.y + 1; j++)
                {
                    if (!(i > 0 && j > 0 && i < field.GetLength(0) && j < field.GetLength(1)))
                    {
                        if (i == coords.x && j == coords.y)
                            return false;
                    }
                }
            }

            return true;
        }

        internal void Move(char[,] field)
        {
            field[_x, _y] = '.';

            (int x, int y) coords;

            do
            {
                coords = GenerateNewCoords(field);
            }
            while (!CheckNewCoords(field, coords));

            _x = coords.x;
            _y = coords.y;

            field[_x, _y] = Ico;
        }

        internal void Eat(char[,] field, List<Wolf> eater, List<Sheep> eaten)
        {
            foreach (Wolf w in eater)
            {
                for (int i = w._x - 1; i < w._x + 1; i++)
                {
                    for (int j = w._y - 1; j < w._y + 1; j++)
                    {
                        if (!(i > 0 && j > 0 && i < field.GetLength(0) && j < field.GetLength(1)))
                        {
                            if (i == w._x && j == w._y)
                                continue;

                            if (field[i, j] == 'S')
                            {
                                for (int s = 0; s < eaten.Count; s++)
                                {
                                    if (eaten[s]._x == i && eaten[s]._y == j)
                                    {
                                        field[i, j] = '.';
                                        eaten.RemoveAt(s);
                                    }
                                }
                            }

                        }
                    }
                }
            }

            
        }
    }
}
