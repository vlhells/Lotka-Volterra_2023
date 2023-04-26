using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotka_Volterra_2023
{
    internal class Sheep : Animal
    {
        private protected override char Ico { get { return 'S'; } }

        internal Sheep(char[,] field) : base(field)
        {

        }
        internal Sheep(char[,] field, (int x, int y) coords) : base(field, coords)
        {

        }
    }
}
