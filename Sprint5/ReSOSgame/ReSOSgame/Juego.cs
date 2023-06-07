using System.Diagnostics.Contracts;
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
        //Metodo que se encarga de realizar movimientos
        public abstract void MakeMove(int row,int col ,Cell ficha); // Funcion para realizar un movimiento
        
        //si es una celda válida
        protected bool IsOnBoard(int row, int column)
        {
            return row >= 0 && row < Tablero.Tamanio && column >= 0 && column < Tablero.Tamanio;
        }

        //si la celda se encuentra vacia
        protected bool IsEmpty(int row, int column)
        {
            return Tablero[row, column] == 0;
        }
    }
    public class JuegoSimple : Juego
    {
        private bool HasWon { get; set; }
        public JuegoSimple(Tablero tablero) : base(tablero)
        {
        }
        // Funcion que verifica si se ha ganado el juego simple
        // Funcion que actualiza el estado del juego Simple 
        protected virtual void FinalGameState() 
        {
            Contract.Requires(Tablero.EstadoDeJuego == GameState.JUGANDO, "Un juego en curso");
            Contract.Ensures(Tablero.EstadoDeJuego == GameState.EMPATE && Validator.FullBoard() && !HasWon ||
                             Tablero.EstadoDeJuego == GameState.GANOAZUL && Tablero.Turno == Jugador.JAZUL && (Validator.FullBoard() || HasWon) ||
                             Tablero.EstadoDeJuego == GameState.GANOROJO && Tablero.Turno == Jugador.JROJO && (Validator.FullBoard() || HasWon),
                "El estado de juego se ha actualizado correctamente después de finalizar el juego");


            //si el tablero está lleno sin ganador
            if (Validator.FullBoard() && !HasWon)
            {
                Tablero.EstadoDeJuego = GameState.EMPATE;
            }
            //cuando hay un ganador cuando el tablero esté lleno o no 
            else
            {
                Tablero.EstadoDeJuego = Tablero.Turno == Jugador.JROJO ?
                    GameState.GANOAZUL : GameState.GANOROJO;  // Cambia el estado del tablero
            }
        }
        public override void MakeMove(int row, int column, Cell ficha)
        {
            Contract.Requires(!Validator.GameOver(), "El juego debe estar en curso");
            Contract.Requires(IsOnBoard(row,column), "El movimiento debe ser válido");
            Contract.Requires(IsEmpty(row,column),"La casilla debe estar vacía");
            Contract.Ensures(Tablero.ValidMove==true, "Cuando el movimiento es válido");
            Contract.Ensures(Tablero.ValidMove == Contract.OldValue(Tablero.ValidMove) || 
                             !Validator.GameOver(), "El estado del juego no ha cambiado si el movimiento no es válido");
            if (!Validator.GameOver()) // Si es el estado de juego es JUGANDO
            {
                // si el movimiento tiene coordenadas inválidas o está ocupada la casilla, da return
                if (!IsOnBoard(row, column) || !IsEmpty(row,column))
                {
                    Tablero.ValidMove = false;
                    return;
                } 
                Tablero.ValidMove = true; // El atributo ValidMove es verdadero. 
                Tablero.Ficha = ficha; // rellena el atributo Ficha
                Tablero[row, column] = ficha; // rellena el grid del tablero con ficha
                Tablero.Turno = (Tablero.Turno == Jugador.JAZUL) ? Jugador.JROJO : Jugador.JAZUL; // Se hace el cambio de turno
                // Cuando se ha hecho un punto
                if (Validator.HasOnePoint(row,column,Tablero.Ficha)) 
                {
                    HasWon = true;
                    FinalGameState(); // Actualiza el estado final del tablero
                }
                // Cuando el tablero esté lleno
                if (Validator.FullBoard())
                {
                    FinalGameState();
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
        public int PuntajeAzul { get; private set; }
        public int PuntajeRojo { get; private set; }

        public JuegoGeneral(Tablero tablero) : base(tablero)
        {
        }
        
        // Método que verifica si se ha ganado en un Juego General
        protected virtual void FinalGameState() // Calcula el estado final comparando los puntajes
        {
            Contract.Requires(Tablero.EstadoDeJuego == GameState.JUGANDO, "Un juego en curso");
            Contract.Ensures(Tablero.EstadoDeJuego == GameState.GANOAZUL && PuntajeAzul > PuntajeRojo ||
                             Tablero.EstadoDeJuego == GameState.GANOROJO && PuntajeRojo > PuntajeAzul ||
                             Tablero.EstadoDeJuego == GameState.EMPATE && PuntajeAzul == PuntajeRojo ||
                             Tablero.EstadoDeJuego == GameState.JUGANDO,
                "El estado de juego se ha actualizado correctamente después de calcular el estado final");

            if (PuntajeAzul > PuntajeRojo)
            {
                Tablero.EstadoDeJuego = GameState.GANOAZUL; // Establece que el azul ha ganado
            }
            else if (PuntajeAzul < PuntajeRojo)
            {
                Tablero.EstadoDeJuego = GameState.GANOROJO; // Establece que el rojo ha ganado
            }
            else if (PuntajeRojo==PuntajeAzul)
            {
                Tablero.EstadoDeJuego = GameState.EMPATE; // Establece que ha habido un empate
            }
            //sino, el estado de juego es JUGANDO
        }

        public override void MakeMove(int row, int column, Cell ficha)
        {
            Contract.Requires(!Validator.GameOver(), "El juego debe estar en curso");
            Contract.Requires(IsOnBoard(row, column), "El movimiento debe ser válido");
            Contract.Requires(IsEmpty(row, column), "La casilla debe estar vacía");
            Contract.Requires(PuntajeAzul>=0 && PuntajeRojo>=0, "Los puntajes son positivos");
            Contract.Ensures(Tablero.ValidMove == true, "Cuando el movimiento es válido");
            Contract.Ensures(Tablero.ValidMove == Contract.OldValue(Tablero.ValidMove) ||
                             !Validator.GameOver(), "El estado del juego no ha cambiado si el movimiento no es válido");
            Contract.Ensures(Tablero.Turno == Jugador.JAZUL && PuntajeAzul == Contract.OldValue(PuntajeAzul) + 1 ||
                             Tablero.Turno == Jugador.JROJO && PuntajeRojo == Contract.OldValue(PuntajeRojo) + 1,
                "El puntaje se ha actualizado correctamente después de obtener un punto");
            if (!Validator.GameOver())
            {
                // si el movimiento tiene coordenadas inválidas o está ocupada la casilla, da return
                if (!IsOnBoard(row, column) || !IsEmpty(row,column))
                {
                    Tablero.ValidMove = false;
                    return;
                }
                Tablero.ValidMove = true;
                Tablero.Ficha = ficha;
                Tablero[row, column] = ficha;
                Tablero.Turno = (Tablero.Turno == Jugador.JAZUL) ? Jugador.JROJO : Jugador.JAZUL; // Se cambia de turno al jugador contrario
                if (Validator.HasOnePoint(row, column, Tablero.Ficha)) // Si se ha obtenido un punto
                {
                    //en el turno del jugador JAZUL
                    if (Tablero.Turno == Jugador.JROJO)
                    {
                        PuntajeAzul++; // Se agrega un punto al jugador Azul
                    } //en el turno del jugador JROJO
                    else                        {
                        PuntajeRojo++; // Se agrega un punto al jugador Rojo
                    }
                }
                if (Validator.FullBoard())
                {
                    FinalGameState(); // Actualiza el estado del juego cuando el tablero esta lleno
                }
            }
            else
            {
                Tablero.ValidMove = false;
            }
        }
    }
}