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
        public enum Jugador { JAZUL,JROJO}
        public enum GameState { JUGANDO,EMPATE,GANOAZUL,GANOROJO }
        private int tamanio;
        private Cell[,] grid;
        private Cell ficha;
        private Jugador turno; //  Jugador que va hacer la jugada "MakeMove"
        private GameState estadoDeJuego;
        private Player jugadorActual;
        public Player JugadorActual { get { return jugadorActual; } set { jugadorActual = value; } }
        private bool validMove = false;
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
        public Cell Ficha { get { return ficha; }
        set { ficha = value; } }
        public Jugador Turno { get { return turno; }
            set { turno = value; }}
        public int Tamanio { get { return tamanio; } }
        public GameState EstadoDeJuego { get { return estadoDeJuego; } 
            set { estadoDeJuego = value; } }
        public Cell[,] Grid { get { return grid; } }
        public bool ValidMove { get { return validMove; }
            set { validMove = value; }}
        
        public void InitBoard()
        {
            for(int row = 0; row < tamanio; row++)
            {
                for(int column = 0; column < tamanio; column++)
                {
                    grid[row, column] = Cell.VACIA;
                }
            }
            estadoDeJuego = GameState.JUGANDO;
            ficha = Cell.S;
            turno = Jugador.JAZUL;
        }
        
    }
}
