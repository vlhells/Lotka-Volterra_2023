﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotka_Volterra_2023
{
    internal class Wolf : Animal
    {
        private protected override char Ico { get { return 'W'; } }

        internal Wolf(char[,] field) : base(field)
        {

        }

        internal Wolf(char[,] field, (int x, int y) coords) : base(field, coords)
        {

        }

    }
}
