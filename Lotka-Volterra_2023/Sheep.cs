using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotka_Volterra_2023
{
    internal class Sheep : Animal
    {
        internal override char Ico { get { return 'S'; } set => value = 'S'; }

        internal Sheep(char[,] field) : base(field)
        {

        }
    }
}
