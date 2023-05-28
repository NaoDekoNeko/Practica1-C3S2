using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ReSOSgame.Tablero;
namespace ReSOSgame
{
    public class ScoreValidator
    {
        Tablero tablero;
        public ScoreValidator(Tablero tablero)
        {
            this.tablero = tablero;
        }
        // Funcion booleana que verifica si el tablero esta lleno
        public bool FullBoard()
        {
            for (int i = 0; i < tablero.Tamanio; i++)
            {
                for (int j = 0; j < tablero.Tamanio; j++)
                {
                    if (tablero.GetCell(i, j) == Tablero.Cell.VACIA)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool HasOnePoint(int row, int col, Cell ficha)
        {
            if (ficha == Cell.S)
            {
                return (tablero.GetCell(row + 1, col + 1) == Cell.O && tablero.GetCell(row + 2, col + 2) == Cell.S) ||
                    (tablero.GetCell(row - 1, col - 1) == Cell.O && tablero.GetCell(row - 2, col - 2) == Cell.S) ||
                    (tablero.GetCell(row, col + 1) == Cell.O && tablero.GetCell(row, col + 2) == Cell.S) ||
                    (tablero.GetCell(row, col - 1) == Cell.O && tablero.GetCell(row, col - 2) == Cell.S) ||
                    (tablero.GetCell(row + 1, col) == Cell.O && tablero.GetCell(row + 2, col) == Cell.S) ||
                    (tablero.GetCell(row - 1, col) == Cell.O && tablero.GetCell(row - 2, col) == Cell.S);
            }
            else if (ficha == Cell.O)
            {
                return (tablero.GetCell(row - 1, col - 1) == Cell.S && tablero.GetCell(row + 1, col + 1) == Cell.S) ||
                    (tablero.GetCell(row + 1, col - 1) == Cell.S && tablero.GetCell(row - 1, col + 1) == Cell.S) ||
                    (tablero.GetCell(row - 1, col) == Cell.S && tablero.GetCell(row + 1, col) == Cell.S) ||
                    (tablero.GetCell(row, col - 1) == Cell.S && tablero.GetCell(row, col + 1) == Cell.S);
            }
            return false;
        }
        // Funcion que verifica si el juego se ha terminado
        public bool GameOver()
        {
            return tablero.EstadoDeJuego != GameState.JUGANDO;
        }
        // Funcion que verifica si algunos de los dos jugadores ha ganado
        public bool HasWon()
        {
            return tablero.EstadoDeJuego == Tablero.GameState.GANOAZUL ||
                tablero.EstadoDeJuego == Tablero.GameState.GANOROJO;
        }
    }
}
