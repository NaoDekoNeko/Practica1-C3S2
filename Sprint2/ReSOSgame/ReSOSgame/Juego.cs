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
        public Juego(Tablero tablero)
        {
            this.tablero = tablero;
        }
    }
    public class JuegoSimple : Juego,IJuegoTerminado,IJuegoGanado
    {
        public JuegoSimple(Tablero tablero) : base(tablero)
        {
            
        }

        public bool JuegoGanado()
        {
            // revisa las filas
            for (int i = 0; i < tablero.Tamanio; i++)
            {
                bool tieneS = false;
                bool tieneO = false;

                for (int j = 0; j < tablero.Tamanio; j++)
                {
                    if (tablero.GetCell(i, j) == Tablero.Cell.S)
                    {
                        tieneS = true;
                    }
                    else if (tablero.GetCell(i, j) == Tablero.Cell.O)
                    {
                        tieneO = true;
                    }
                }

                if (tablero.Ficha=='S' && tieneS && !tieneO)
                {
                    return true;
                }
                else if (tablero.Ficha == 'O' && tieneO && !tieneS)
                {
                    return true;
                }
            }

            // revisa las columnas
            for (int j = 0; j < tablero.Tamanio;j++)
                {
                bool tieneS = false;
                bool tieneO = false;

                for (int i = 0; i < tablero.Tamanio; i++)
                {
                    if (tablero.GetCell(i, j) == Tablero.Cell.S)
                    {
                        tieneS = true;
                    }
                    else if (tablero.GetCell(i, j) == Tablero.Cell.O)
                    {
                        tieneO = true;
                    }
                }

                if (tablero.Ficha == 'S' && tieneS && !tieneO)
                {
                    return true;
                }
                else if (tablero.Ficha == 'O' && tieneO && !tieneS)
                {
                    return true;
                }
            }

            // revisa las diagonales
            bool tieneS1 = false;
            bool tieneO1 = false;
            bool tieneS2 = false;
            bool tieneO2 = false;

            for (int i = 0; i < tablero.Tamanio; i++)
            {
                if (tablero.GetCell(i, i) == Tablero.Cell.S)
                {
                    tieneS1 = true;
                }
                else if (tablero.GetCell(i, i) == Tablero.Cell.O)
                {
                    tieneO1 = true;
                }

                if (tablero.GetCell(i, tablero.Tamanio - i - 1) == Tablero.Cell.S)
                {
                    tieneS2 = true;
                }
                else if (tablero.GetCell(i, tablero.Tamanio - i - 1) == Tablero.Cell.O)
                {
                    tieneO2 = true;
                }
            }

            if (tablero.Ficha == 'S' && ((tieneS1 && !tieneO1) || (tieneS2 && !tieneO2)))
            {
                return true;
            }
            else if (tablero.Ficha == 'S' && ((tieneO1 && !tieneS1) || (tieneO2 && !tieneS2)))
            {
                return true;
            }

            return false;
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
    public class JuegoGeneral : Juego
    {
        public JuegoGeneral(Tablero tablero) : base(tablero)
        {
        }
    }
}
