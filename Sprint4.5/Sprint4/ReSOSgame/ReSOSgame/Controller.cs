using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ReSOSgame
{
    
    public class Controller
    {
        private Tablero tablero;
        public Tablero Tablero { get { return tablero; } set { tablero = value; } }
        private Juego juego;
        private Player player1, player2;
        public Juego Juego { get {  return juego; } set { juego = value; } }
        public Player Player1 { get { return player1; } set { player1 = value; } }
        public Player Player2 { get { return player2; } set { player2 = value; } }
        public Player CurrentPlayer { get { return Tablero.JugadorActual; } set { Tablero.JugadorActual = value; } }
        public Tablero.Jugador Turno { get { return Tablero.Turno; } set { Tablero.Turno = value; } } 
        public Tablero.Cell Ficha { get { return CurrentPlayer.Ficha; } set { CurrentPlayer.Ficha = value; } }
        public int X { get { return CurrentPlayer.X; } }
        public int Y { get { return CurrentPlayer.Y; } }
        public int Tamanio { get { return Tablero.Tamanio; } }
        public void InitTurn()
        {
            // Nota: Antes de usar el init turn debe haberse inicializado el player1
            CurrentPlayer= player1;
        }
        public void ChangeTurn()
        {
            CurrentPlayer = (tablero.Turno == Tablero.Jugador.JAZUL) ? player1 : player2;
        }
    }
}
