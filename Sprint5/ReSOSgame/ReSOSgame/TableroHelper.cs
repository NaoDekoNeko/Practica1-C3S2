using static ReSOSGame.Tablero;

namespace ReSOSGame
{
    public static class TableroHelper
    {
        public static string Symbol(Cell cell)
        {
            switch (cell)
            {
                case Cell.S:
                    return "S";
                case Cell.O:
                    return "O";
                case Cell.VACIA:
                case Cell.INVALIDA:
                default:
                    return " ";
            }
        }
        public static string GetFormattedBoard(Tablero tablero)
        {
            string formattedBoard = "";
            for (int row = 0; row < tablero.Tamanio; row++)
            {
                formattedBoard += "-------\n";
                for (int column = 0; column < tablero.Tamanio; column++)
                {
                    formattedBoard += "|" + Symbol(tablero[row, column]);
                }
                formattedBoard += "|\n";
            }
            formattedBoard += "-------\n";

            return formattedBoard;
        }
    }
}