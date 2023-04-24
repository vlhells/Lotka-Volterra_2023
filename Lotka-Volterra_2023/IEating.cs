using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotka_Volterra_2023
{
    internal interface IEating
    {
        public (int x, int y) Eat(char[,] field, List<Animal> Animals);

        public (int x, int y) Eat(char[,] field, List<Animal> Animals, List<Grass> Grass);
    }
}
