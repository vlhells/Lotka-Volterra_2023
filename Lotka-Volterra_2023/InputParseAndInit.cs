using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotka_Volterra_2023
{
    internal class InputParseAndInit
    {
        internal static char[,] InitializeField(string[] field_sizes)
        {
            int x = int.Parse(field_sizes[0]);
            int y = int.Parse(field_sizes[1]);

            char[,] field = new char[x, y];

            for (int i = 0; i < field.GetLength(0); i++) // Заполнение поля значениями.
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = '.';
                }
            }

            return field;
        }
    }
}
