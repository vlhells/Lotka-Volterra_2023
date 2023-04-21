﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotka_Volterra_2023
{
    internal class Grass : ISpawnable
    {
        private protected static Random random = new Random();
        int _x = -999;
        int _y = -999;
        internal char Ico { get { return '@'; } set => value = '@'; }

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
    }
}
