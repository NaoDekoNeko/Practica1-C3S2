using static ReSOSGame.Tablero;
namespace ReSOSGame
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
                    if (tablero[i, j] == Cell.VACIA)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool HasOnePoint(int row, int col, Cell ficha)
        {
            switch (ficha)
            {
                case Cell.S:
                    return (tablero[row + 1, col + 1] == Cell.O && tablero[row + 2, col + 2] == Cell.S) ||
                           (tablero[row - 1, col - 1] == Cell.O && tablero[row - 2, col - 2] == Cell.S) ||
                           (tablero[row, col + 1] == Cell.O && tablero[row, col + 2] == Cell.S) ||
                           (tablero[row, col - 1] == Cell.O && tablero[row, col - 2] == Cell.S) ||
                           (tablero[row + 1, col] == Cell.O && tablero[row + 2, col] == Cell.S) ||
                           (tablero[row - 1, col] == Cell.O && tablero[row - 2, col] == Cell.S) ||
                           (tablero[row - 1, col + 1] == Cell.O && tablero[row - 2, col + 2] == Cell.S) ||
                           (tablero[row + 1, col - 1] == Cell.O && tablero[row + 2, col - 2] == Cell.S);

                case Cell.O:
                    return (tablero[row - 1, col - 1] == Cell.S && tablero[row + 1, col + 1] == Cell.S) ||
                           (tablero[row + 1, col - 1] == Cell.S && tablero[row - 1, col + 1] == Cell.S) ||
                           (tablero[row - 1, col] == Cell.S && tablero[row + 1, col] == Cell.S) ||
                           (tablero[row, col - 1] == Cell.S && tablero[row, col + 1] == Cell.S);
                case Cell.VACIA:
                case Cell.INVALIDA:
                default:
                    return false;
            }
        }

        // Funcion que verifica si el juego se ha terminado
        public bool GameOver()
        {
            return tablero.EstadoDeJuego != GameState.JUGANDO;
        }
    }
}