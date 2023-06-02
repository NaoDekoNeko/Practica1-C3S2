using static ReSOSGame.Tablero;

namespace ReSOSGame
{
    public abstract class Juego
    {
        public Tablero Tablero { get; }
        public ScoreValidator Validator;

        public int NumberOfEmptyCells
        {
            get
            {
                int numberOfEmptyCells = 0;
                for (int row = 0; row < Tablero.Tamanio; ++row)
                {
                    for (int col = 0; col < Tablero.Tamanio; ++col)
                    {
                        if (Tablero[row, col] == Cell.VACIA)
                        {
                            numberOfEmptyCells++;
                        }
                    }
                }
                return numberOfEmptyCells;
            }
        }
        public Juego(Tablero tablero)
        {
            Tablero = tablero;
            Validator = new ScoreValidator(tablero);
        }

        // Funcion que indica el estado final del juego
        public abstract void MakeMove(int row,int col ,Cell ficha); // Funcion para realizar un movimiento

        protected bool IsOnBoard(int row, int column)
        {
            return row >= 0 && row < Tablero.Tamanio && column >= 0 && column < Tablero.Tamanio;
        }

        protected bool IsEmpty(int row, int column)
        {
            return Tablero[row, column] == 0;
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
            if (Validator.FullBoard())
            {
                Tablero.EstadoDeJuego = GameState.EMPATE;
            }
            else
            {
                Tablero.EstadoDeJuego = Tablero.Turno == Jugador.JAZUL ?
                    GameState.GANOAZUL : GameState.GANOROJO;  // Cambia el estado del tablero
            }
        }
        public override void MakeMove(int row, int column, Cell ficha)
        {
            if(!Validator.GameOver()) // Si es el estado de juego es JUGANDO
            {
                if ( IsOnBoard(row,column) && IsEmpty(row,column)) // Si la posicion :[row,column] esta en el trablero y esa posicion esta vacia
                {
                    Tablero.ValidMove = true; // El atributo ValidMove es verdadero. 
                    Tablero.Ficha = ficha; // rellena el atributo Ficha
                    Tablero[row, column] = ficha; // rellena el grid del tablero con ficha
                    if (Validator.HasOnePoint(row,column,Tablero.Ficha) || Validator.FullBoard()) // Cuando se ha hecho ganado 1 punto o esta el tablero lleno
                    {
                        FinalGameState(); // Actualiza el estado final del tablero
                    }
                    if (Tablero.EstadoDeJuego == GameState.JUGANDO)  // Si el estado de juego es JUGANDO entonces ...
                    {
                        Tablero.Turno = (Tablero.Turno == Jugador.JAZUL) ? Jugador.JROJO : Jugador.JAZUL; // Se hace el cambio de turno
                    }
                }
                else
                {
                    Tablero.ValidMove = false;
                }
            }
            else
            {
                Tablero.ValidMove = false;
            }
        }

    }



    public class JuegoGeneral : Juego
    {
        // Atributos para tener los puntajes de cada jugador
        private int puntajeAzul;
        private int puntajeRojo;
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
                Tablero.EstadoDeJuego = GameState.GANOAZUL; // Establece que el azul ha ganado
            }
            else if (puntajeAzul < puntajeRojo)
            {
                Tablero.EstadoDeJuego = GameState.GANOROJO; // Establece que el rojo ha ganado
            }
            else if (puntajeRojo==puntajeAzul)
            {
                Tablero.EstadoDeJuego = GameState.EMPATE; // Establece que ha habido un empate
            }
            //sino, el estado de juego es JUGANDO
        }
        public override void MakeMove(int row, int column, Cell ficha)
        {
            if(!Validator.GameOver())
            {
                if (!IsOnBoard(row, column)) return;
                Tablero.ValidMove = true;
                Tablero.Ficha = ficha;
                Tablero[row, column] = ficha;
                if (Validator.HasOnePoint(row, column, Tablero.Ficha)) // Si se ha obtenido un punto
                {
                    //en el turno del jugador JAZUL
                    if (Tablero.Turno == Jugador.JAZUL)
                    {
                        puntajeAzul++; // Se agrega un punto al jugador Azul
                    } //en el turno del jugador JROJO
                    else                        {
                        puntajeRojo++; // Se agrega un punto al jugador Rojo
                    }
                }
                if (Validator.FullBoard())
                {
                    FinalGameState(); // Actualiza el estado del juego cuando el tablero esta lleno
                }
                // Nota: esa funcion detiene el cambio de turno cuando ya se halla ganado o empatado
                if (Tablero.EstadoDeJuego == GameState.JUGANDO) // Si se sigue jugando
                {
                    Tablero.Turno = (Tablero.Turno == Jugador.JAZUL) ? Jugador.JROJO : Jugador.JAZUL; // Se cambia de turno al jugador contrario
                }
            }
            else
            {
                Tablero.ValidMove = false;
            }
        }
    }
}