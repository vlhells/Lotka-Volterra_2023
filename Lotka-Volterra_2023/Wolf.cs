using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotka_Volterra_2023
{
    internal class Wolf : Animal
    {
        internal override char Ico { get { return 'W'; } set => value = 'W'; }

        internal Wolf(char[,] field) : base(field)
        {

        }
    }
}
