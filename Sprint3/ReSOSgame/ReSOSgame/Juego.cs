using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReSOSgame
{
    public abstract class Juego
    {
        public char ficha;
        public string jugador;
        public Tablero tablero;
        public string tipoDeJuego;
        public Juego(Tablero tablero, string tipoDeJuego)
        {
            this.tablero = tablero;
            this.tipoDeJuego = tipoDeJuego;
        }
        public bool JuegoTerminado()
        {
            for (int i = 0; i < tablero.Tamanio; i++)
            {
                for (int j = 0; j < tablero.Tamanio; j++)
                {
                    if (tablero.GetCell(i, j) == Tablero.Cell.VACIA)
                        return false;
                }
            }
            return true;
        }
    }
    public class JuegoSimple : Juego,IJuegoGanado
    {
        public JuegoSimple(Tablero tablero) : base(tablero,"SIMPLE")
        {
            
        }

        public bool JuegoGanado()
        {
            // revisa las filas
            for (int i = 0; i < tablero.Tamanio; i++)
            {
                for (int j = 0; j < tablero.Tamanio-2; j++)
                {
                    if (tablero.GetCell(i, j) == Tablero.Cell.S &&
                        tablero.GetCell(i, j + 1) == Tablero.Cell.O &&
                        tablero.GetCell(i, j + 2) == Tablero.Cell.S)
                    {
                        return true;
                    }
                }
            }
            // revisa las columnas
            for (int j = 0; j < tablero.Tamanio;j++)
                {
                for (int i = 0; i < tablero.Tamanio-2; i++)
                {
                    if (tablero.GetCell(i, j) == Tablero.Cell.S &&
                        tablero.GetCell(i+1,j) == Tablero.Cell.O &&
                        tablero.GetCell(i+2,j) == Tablero.Cell.S)
                    {
                        return true;
                    }
                }
            }

            // revisa las diagonales
            for (int i = 0; i < tablero.Tamanio-2; i++)
            {
                for(int j= 0;j<tablero.Tamanio-2;j++)
                {
                    if (tablero.GetCell(i, j) == Tablero.Cell.S &&
                    tablero.GetCell(i + 1, j + 1) == Tablero.Cell.O &&
                    tablero.GetCell(i + 2, j + 2) == Tablero.Cell.S)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
    public class JuegoGeneral : Juego,IJuegoGanado
    {
        private int puntajeAzul = 0;
        private int puntajeRojo = 0;
        public JuegoGeneral(Tablero tablero) : base(tablero,"GENERAL")
        {
        }

        public bool JuegoGanado()
        {
            while (!JuegoTerminado())
            {
                // revisa las filas
                for (int i = 0; i < tablero.Tamanio; i++)
                {
                    for (int j = 0; j < tablero.Tamanio - 2; j++)
                    {
                        if (tablero.GetCell(i, j) == Tablero.Cell.S &&
                            tablero.GetCell(i, j + 1) == Tablero.Cell.O &&
                            tablero.GetCell(i, j + 2) == Tablero.Cell.S)
                        {
                            return true;
                        }
                    }
                }
                // revisa las columnas
                for (int j = 0; j < tablero.Tamanio; j++)
                {
                    for (int i = 0; i < tablero.Tamanio - 2; i++)
                    {
                        if (tablero.GetCell(i, j) == Tablero.Cell.S &&
                            tablero.GetCell(i + 1, j) == Tablero.Cell.O &&
                            tablero.GetCell(i + 2, j) == Tablero.Cell.S)
                        {
                            return true;
                        }
                    }
                }

                // revisa las diagonales
                for (int i = 0; i < tablero.Tamanio - 2; i++)
                {
                    for (int j = 0; j < tablero.Tamanio - 2; j++)
                    {
                        if (tablero.GetCell(i, j) == Tablero.Cell.S &&
                        tablero.GetCell(i + 1, j + 1) == Tablero.Cell.O &&
                        tablero.GetCell(i + 2, j + 2) == Tablero.Cell.S)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
