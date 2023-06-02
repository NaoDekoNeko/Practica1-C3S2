using System;
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
                Console.WriteLine("-------");
                for (int column = 0; column < tablero.Tamanio; column++)
                {
                    Console.Write("|" + Symbol(tablero[row, column]));
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("-------");
        }

        private char Symbol(Cell cell)
        {
            switch (cell)
            {
                case Cell.S:
                    return 'S';
                case Cell.O:
                    return 'O';
                case Cell.VACIA:
                case Cell.INVALIDA:
                default:
                    return ' ';
            }
        }
    }
}