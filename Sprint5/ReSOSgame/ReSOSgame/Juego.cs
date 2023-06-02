﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ReSOSGame.Tablero;

namespace ReSOSGame
{
    public abstract class Juego
    {
        public Tablero tablero;
        public ScoreValidator validator;
        public int Tamanio { get { return tablero.Tamanio; } }
        public Juego(Tablero tablero)
        {
            this.tablero = tablero;
            validator = new ScoreValidator(tablero);
        }

        // Funcion que indica el estado final del juego
        public abstract void MakeMove(int row,int col ,Tablero.Cell ficha); // Funcion para realizar un movimiento

        protected bool IsOnBoard(int row, int column)
        {
            return row >= 0 && row < tablero.Tamanio && column >= 0 && column < tablero.Tamanio;
        }

        protected bool IsEmpty(int row, int column)
        {
            return tablero.GetCell(row, column) == 0;
        }
    }
    public class JuegoSimple : Juego
    {
        public JuegoSimple(Tablero tablero) : base(tablero)
        {
        }
        // Funcion que verifica si se ha ganado el juego simple
        // Funcion que actualiza el estado del juego Simple 
        protected virtual void FinalGameState() 
        {
            if (validator.FullBoard())
            {
                tablero.EstadoDeJuego = Tablero.GameState.EMPATE;
            }
            else
            {
                tablero.EstadoDeJuego = tablero.Turno == Tablero.Jugador.JAZUL ?
                    Tablero.GameState.GANOAZUL : Tablero.GameState.GANOROJO;  // Cambia el estado del tablero
            }
        }
        public override void MakeMove(int row, int column, Tablero.Cell ficha)
        {
            if(!validator.GameOver()) // Si es el estado de juego es JUGANDO
            {
                if ( IsOnBoard(row,column) && IsEmpty(row,column)) // Si la posicion :[row,column] esta en el trablero y esa posicion esta vacia
                {
                    tablero.ValidMove = true; // El atributo ValidMove es verdadero. 
                    tablero.Ficha = ficha; // rellena el atributo Ficha
                    tablero.Grid[row, column] = ficha; // rellena el grid del tablero con ficha
                    if (validator.HasOnePoint(row,column,tablero.Ficha) || validator.FullBoard()) // Cuando se ha hecho ganado 1 punto o esta el tablero lleno
                    {
                        FinalGameState(); // Actualiza el estado final del tablero
                    }
                    if (tablero.EstadoDeJuego == Tablero.GameState.JUGANDO)  // Si el estado de juego es JUGANDO entonces ...
                    {
                        tablero.Turno = (tablero.Turno == Tablero.Jugador.JAZUL) ? Tablero.Jugador.JROJO : Tablero.Jugador.JAZUL; // Se hace el cambio de turno
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
        public int PuntajeAzul => puntajeAzul;

        public int PuntajeRojo => puntajeRojo;
        // Funcion que verifica si se ha ganado en un Juego General

        protected virtual void FinalGameState() // Calcula el estado final comparando los puntajes
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
        public override void MakeMove(int row, int column, Tablero.Cell ficha)
        {
            if(!validator.GameOver())
            {
                if (!IsOnBoard(row, column)) return;
                tablero.ValidMove = true;
                tablero.Ficha = ficha;
                tablero.Grid[row, column] = ficha;
                if (validator.HasOnePoint(row, column, tablero.Ficha)) // Si se ha obtenido un punto
                {
                    //en el turno del jugador JAZUL
                    if (tablero.Turno == Tablero.Jugador.JAZUL)
                    {
                        puntajeAzul++; // Se agrega un punto al jugador Azul
                    } //en el turno del jugador JROJO
                    else                        {
                        puntajeRojo++; // Se agrega un punto al jugador Rojo
                    }
                }
                if (validator.FullBoard())
                {
                    FinalGameState(); // Actualiza el estado del juego cuando el tablero esta lleno
                }
                // Nota: esa funcion detiene el cambio de turno cuando ya se halla ganado o empatado
                if (tablero.EstadoDeJuego == Tablero.GameState.JUGANDO) // Si se sigue jugando
                {
                    tablero.Turno = (tablero.Turno == Tablero.Jugador.JAZUL) ? Tablero.Jugador.JROJO : Tablero.Jugador.JAZUL; // Se cambia de turno al jugador contrario
                }
            }
            else
            {
                tablero.ValidMove = false;
            }
        }
    }
}