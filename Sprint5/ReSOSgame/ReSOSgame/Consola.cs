using System;
using static ReSOSGame.TableroHelper;

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
            string formattedBoard = GetFormattedBoard(tablero);
            Console.WriteLine(formattedBoard);
        }
    }
}