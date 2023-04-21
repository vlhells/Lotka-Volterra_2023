using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotka_Volterra_2023
{
    internal interface ISpawnable
    {
        public void Spawn(char[,] field);
    }
}
