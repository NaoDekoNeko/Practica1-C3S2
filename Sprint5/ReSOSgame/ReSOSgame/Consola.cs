using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReSOSGame.Tablero;

namespace ReSOSGame
{
    public class Consola
    {
        private Tablero tablero;

        public Consola(Tablero tablero)
        {
            this.tablero = tablero;
        }

        public void DisplayBoard()
        {
            for (int row = 0; row < tablero.Tamanio; row++)
            {
                System.Console.WriteLine("-------");
                for (int column = 0; column < tablero.Tamanio; column++)
                {
                    System.Console.Write("|" + Symbol(tablero.GetCell(row, column)));
                }
                System.Console.WriteLine("|");
            }
            System.Console.WriteLine("-------");
        }

        private char Symbol(Tablero.Cell cell)
        {
            if (cell == Tablero.Cell.S)
                return 'S';
            else
            if (cell == Tablero.Cell.O)
                return 'O';
            else return ' ';
        }
    }
}