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
        public enum Jugador { AZUL,ROJO}
        public enum EstadoJuego { JUGANDO,EMPATE,GANOAZUL,GANOROJO }
        private int tamanio;
        private Cell[,] grid;
        private Cell ficha;
        private Jugador turno;
        private EstadoJuego estadoDeJuego;
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
        public Cell Ficha { get { return ficha; } }
        public Jugador Turno { get { return turno; } }
        public int Tamanio { get { return tamanio; } }
        public EstadoJuego EstadoDeJuego {  get { return estadoDeJuego; } }
        public Cell[,] Grid { get { return grid; } }
        public void MakeMove(int row, int column, Cell _ficha)
        {
            if (row >= 0 && row < tamanio && column >= 0 && column < tamanio
                       && grid[row,column] == 0)
            {
                ficha = _ficha;
                grid[row, column] = ficha;
                turno = (turno == Jugador.AZUL)? Jugador.ROJO: Jugador.AZUL;
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
            estadoDeJuego = EstadoJuego.JUGANDO;
            ficha = Cell.S;
            turno = Jugador.AZUL;
        }
    }
}
