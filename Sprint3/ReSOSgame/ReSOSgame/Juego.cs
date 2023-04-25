using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReSOSgame
{
    public abstract class Juego
    {
        public Tablero tablero;
        public Juego(Tablero tablero)
        {
            this.tablero = tablero;
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
        public JuegoSimple(Tablero tablero) : base(tablero)
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
    public class JuegoGeneral : Juego, IJuegoGanado
    {
        private int puntajeAzul = 0;
        private int puntajeRojo = 0;
        public JuegoGeneral(Tablero tablero) : base(tablero)
        {
        }

        public bool JuegoGanado()
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
                        AumentarPuntaje(tablero.Turno);
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
                        AumentarPuntaje(tablero.Turno);
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
                        AumentarPuntaje(tablero.Turno);
                    }
                }
            }
            if (puntajeAzul != puntajeRojo)
                return true;
            return false;
        }
        public void AumentarPuntaje(Tablero.Jugador turno)
        {
            if (turno == Tablero.Jugador.AZUL)
                puntajeAzul++;
            else
                puntajeRojo++;
        }
    }
}
