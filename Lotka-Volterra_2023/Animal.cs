using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotka_Volterra_2023
{
    internal abstract class Animal : ISpawnable, IEating
    {
        private protected static Random random = new Random();
        int _x = 999;
        int _y = 999;
        int _isHungry = 0; // Сколько ходов осталось до того, чтобы есть, если в окрестности кто-то есть. 0 -- ест. Больше -- не ест.

        internal int X { get { return _x; } }

        internal int Y { get { return _y; } }

        internal int IsHungry { get { return _isHungry; } set { _isHungry = value; } }

        private protected abstract char Ico { get; }

        internal Animal(char[,] field)
        {
            Spawn(field);
        }

        internal Animal(char[,] field, (int x, int y) coords)
        {
            Spawn(field, coords);
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

        public void Spawn(char[,] field, (int x, int y) coords)
        {
            do
            {
                _x = random.Next(coords.x - 1, coords.x + 2);
                _y = random.Next(coords.y - 1, coords.y + 2);
            }
            while (!(_x > 0 && _y > 0 && _x < field.GetLength(0) && _y < field.GetLength(1) && field[_x, _y] == '.')); // Тут был беск. цикл)))

            field[_x, _y] = field[coords.x, coords.y];
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
                    if (!(i > 0 && j > 0 && i < field.GetLength(0) && j < field.GetLength(1) && field[i, j] == '.'))
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

        //internal bool HaveToEat(char[,] field, List<Wolf> eater, List<Sheep> eaten)
        //{

        //}


        public (int x, int y) Eat(char[,] field, List<Animal> Animals)
        {
            foreach (Animal a in Animals)
            {
                if (a.IsHungry == 0)
                {
                    for (int i = a._x - 1; i <= a._x + 1; i++)
                    {
                        for (int j = a._y - 1; j <= a._y + 1; j++)
                        {
                            if (i == a._x && j == a._y)
                                continue;

                            if (i >= 0 && j >= 0 && i < field.GetLength(0) && j < field.GetLength(1))
                            {
                                //field[i, j] = 'X';

                                if (a.Ico == 'W' && field[i, j] == 'S')
                                {
                                    for (int s = 0; s < Animals.Count; s++)
                                    {
                                        if (Animals[s]._x == i && Animals[s]._y == j)
                                        {
                                            Animals.RemoveAt(s);
                                            field[i, j] = '.';
                                            a.IsHungry = 3;
                                            return (a._x, a._y);
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
            return (-1000, -1000);
        }

        public (int x, int y) Eat(char[,] field, List<Animal> Animals, List<Grass> grass)
        {
            foreach (Animal a in Animals)
            {
                if (a.IsHungry == 0)
                {
                    for (int i = a._x - 1; i <= a._x + 1; i++)
                    {
                        for (int j = a._y - 1; j <= a._y + 1; j++)
                        {
                            if (i == a._x && j == a._y)
                                continue;

                            if (i >= 0 && j >= 0 && i < field.GetLength(0) && j < field.GetLength(1))
                            {
                                //field[i, j] = 'X';

                                if (a.Ico == 'S' && field[i, j] == '@')
                                {
                                    for (int s = 0; s < grass.Count; s++)
                                    {
                                        if (grass[s].X == i && grass[s].Y == j)
                                        {
                                            grass.RemoveAt(s);
                                            field[i, j] = '.';
                                            a.IsHungry = 3;
                                            return (a._x, a._y);
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
            return (-1000, -1000);
        }
    }
}