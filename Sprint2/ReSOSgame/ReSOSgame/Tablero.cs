using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReSOSgame.Tablero;

namespace ReSOSgame
{ 
    public class Tablero
    {
        public enum Cell { VACIA, INVALIDA, S,O}
        private int tamanio;
        private Cell[,] grid;
        private char ficha = 'S';
        private string jugador = "Azul";
        private string estadoDeJuego;
        public Tablero(int tamanio)
        {
            grid = new Cell[tamanio, tamanio];
            this.tamanio = tamanio;
        }
        public Cell GetCell(int row, int column)
        {
            if (row >= 0 && column >= 0 && row < tamanio && column < tamanio)
                return grid[row, column];
            else
                return Cell.INVALIDA;
        }
        public char Ficha { get { return ficha; } }
        public string Jugador { get { return jugador; } }
        public int Tamanio { get { return tamanio; } }
        public string EstadoDeJuego {  get { return estadoDeJuego; } }
        public void MakeMove(int row, int column, char _ficha)
        {
            if (row >= 0 && row < tamanio && column >= 0 && column < tamanio
                       && grid[row,column] == 0)
            {
                ficha = _ficha;
                grid[row,column] = (ficha == 'S')? Cell.S:Cell.O;
                jugador = (jugador == "Azul")? "Rojo": "Azul";

            }
        }

        public void InitBoard()
        {
            for(int row = 0; row < tamanio; row++)
            {
                for(int column = 0; column < tamanio; column++)
                {
                    grid[row, column] = Cell.VACIA;
                }
            }
            estadoDeJuego = "JUGANDO";
            ficha = 'S';
            jugador = "Azul";
        }
    }
}
