using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        public void PrintGame()
        {
            const string filePath = "game.txt";
            string contenido = "Turno: ";
            contenido += Turno == Tablero.Jugador.JAZUL ? "Azul\n" : "Rojo\n";
            // Construir el contenido a escribir
            contenido += "-------\n";
            for (var row = 0; row < tablero.Tamanio; row++)
            {
                for (var column = 0; column < tablero.Tamanio; column++)
                {
                    contenido += "|" + Symbol(tablero.GetCell(row, column));
                }
                contenido += "|\n";
            }
            contenido += "-------\n";
            if (Juego is JuegoGeneral aux)
            {
                contenido += aux.PuntajeAzul + "\n";
                contenido += aux.PuntajeRojo + "\n";
            }

            contenido += "Estado de juego: ";
            switch (Tablero.EstadoDeJuego)
            {
                case Tablero.GameState.JUGANDO:
                    contenido += "JUGANDO\n";
                    break;
                case Tablero.GameState.GANOROJO:
                    contenido += "GANÓ EL JUGADOR ROJO\n";
                    break;
                case Tablero.GameState.GANOAZUL:
                    contenido += "GANÓ EL JUGADOR AZUL\n";
                    break;
                case Tablero.GameState.EMPATE:
                    contenido += "EMPATE\n";
                    break;
            }
            // Verificar si el archivo existe
            if (!File.Exists(filePath))
            {
                // Crear el archivo si no existe
                using (File.Create(filePath))
                {
                    // El archivo se crea y se cierra automáticamente
                }
            }

            if (Tablero.ValidMove)
            {
                // Añadir contenido al archivo existente o al archivo recién creado
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.Write(contenido);
                }
            }
        }

        private static string Symbol(Tablero.Cell a)
        {
            switch (a)
            {
                case Tablero.Cell.S:
                    return "S";
                case Tablero.Cell.O:
                    return "O";
                case Tablero.Cell.VACIA:
                case Tablero.Cell.INVALIDA:
                default:
                    return " ";
            }
        }
    }
}
