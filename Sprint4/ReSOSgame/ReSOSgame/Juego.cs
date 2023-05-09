using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ReSOSgame.Tablero;

namespace ReSOSgame
{
    public abstract class Juego
    {
        public Tablero tablero;
        public ScoreValidator validator;
        public Juego(Tablero tablero)
        {
            this.tablero = tablero;
            validator = new ScoreValidator(tablero);
        }
        public abstract void FinalGameState(); // Funcion que indica el estado final del juego
        public abstract void MakeMove(int row,int col ,Cell ficha); // Funcion para realizar un movimiento
        
    }
    public class JuegoSimple : Juego
    {
        public JuegoSimple(Tablero tablero) : base(tablero)
        {
        }
        // Funcion que verifica si se ha ganado el juego simple
        // Funcion que actualiza el estado del juego Simple 
        public override void FinalGameState() 
        {
            if (validator.FullBoard())
            {
                tablero.EstadoDeJuego = Tablero.GameState.EMPATE;
            }
            else
            {
                tablero.EstadoDeJuego = tablero.Turno == Tablero.Jugador.AZUL ?
                    Tablero.GameState.GANOAZUL : Tablero.GameState.GANOROJO;  // Cambia el estado del tablero
            }
        }
        public override void MakeMove(int row, int column, Cell _ficha)
        {
            if(!validator.GameOver()) // Si es el estado de juego es JUGANDO
            {
                if (row >= 0 && row < tablero.Tamanio && column >= 0 && column < tablero.Tamanio
                       && tablero.GetCell(row, column) == 0)
                {
                    tablero.ValidMove = true;
                    tablero.Ficha = _ficha;
                    tablero.Grid[row, column] = _ficha;
                    if(validator.HasOnePoint(row,column,tablero.Ficha) || validator.FullBoard()) // Cuando se ha hecho ganado 1 punto 
                    {
                        FinalGameState();
                    }
                    if (tablero.EstadoDeJuego == GameState.JUGANDO)
                    {
                        tablero.Turno = (tablero.Turno == Jugador.AZUL) ? Jugador.ROJO : Jugador.AZUL;
                    }
                }
                else
                {
                    tablero.ValidMove = false;
                }
            }
            else
            {
                tablero.ValidMove = false;
            }
        }
    }
    public class JuegoGeneral : Juego
    {
        // Atributos para tener los puntajes de cada jugador
        private int puntajeAzul = 0;
        private int puntajeRojo = 0;
        public JuegoGeneral(Tablero tablero) : base(tablero)
        {
        }
        public int PuntajeAzul { get { return puntajeAzul; } }
        public int PuntajeRojo { get { return puntajeRojo; } }
        // Funcion que verifica si se ha ganado en un Juego General

        public override void FinalGameState() // Calcula el estado final comparando los puntajes
        {

            if (puntajeAzul > puntajeRojo)
            {
                tablero.EstadoDeJuego = Tablero.GameState.GANOAZUL; // Establece que el azul ha ganado
            }
            else if (puntajeAzul < puntajeRojo)
            {
                tablero.EstadoDeJuego = Tablero.GameState.GANOROJO; // Establece que el rojo ha ganado
            }
            else if (puntajeRojo==puntajeAzul)
            {
                tablero.EstadoDeJuego = Tablero.GameState.EMPATE; // Establece que ha habido un empate
            }
            //sino, el estado de juego es JUGANDO
        }
        public override void MakeMove(int row, int column, Cell _ficha)
        {
            if(!validator.GameOver())
            {
                if (row >= 0 && row < tablero.Tamanio && column >= 0 && column < tablero.Tamanio
                       && tablero.Grid[row, column] == 0)
                {
                    tablero.ValidMove = true;
                    tablero.Ficha = _ficha;
                    tablero.Grid[row, column] = _ficha;
                    if (validator.HasOnePoint(row, column, tablero.Ficha)) // Si se ha obtenido un punto
                    {
                        //en el turno del jugador AZUL
                        if (tablero.Turno == Jugador.AZUL)
                        {
                            puntajeAzul++; // Se agrega un punto al jugador Azul
                        } //en el turno del jugador ROJO
                        else                        {
                            puntajeRojo++; // Se agrega un punto al jugador Rojo
                        }
                    }
                    if (validator.FullBoard())
                    {
                        FinalGameState(); // Actualiza el estado del juego cuando el tablero esta lleno
                    }
                    // Nota: esa funcion detiene el cambio de turno cuando ya se halla ganado o empatado
                    if (tablero.EstadoDeJuego == GameState.JUGANDO) // Si se sigue jugando
                    {
                        tablero.Turno = (tablero.Turno == Jugador.AZUL) ? Jugador.ROJO : Jugador.AZUL; // Se cambia de turno al jugador contrario
                    }
                }
            }
            else
            {
                tablero.ValidMove = false;
            }
        }
    }
}