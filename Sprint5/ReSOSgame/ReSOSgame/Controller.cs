namespace ReSOSGame
{ 
    public class Controller
    {
        public Tablero Tablero { get; set; }

        public Juego Juego { get; set; }

        public Player Player1 { get; set; }

        public Player Player2 { get; set; }

        public Player CurrentPlayer
        {
            get { return Tablero.JugadorActual; }
            set { Tablero.JugadorActual = value; }
        }

        public Tablero.Jugador Turno => Tablero.Turno;
        public Tablero.Cell Ficha => CurrentPlayer.Ficha;
        public int X => CurrentPlayer.X;
        public int Y => CurrentPlayer.Y;
        public int Tamanio => Tablero.Tamanio;

        public void InitTurn()
        {
            // Nota: Antes de usar el init turn debe haberse inicializado el player1
            CurrentPlayer = Player1;
        }

        //cambia de jugador
        public void ChangeTurn()
        {
            CurrentPlayer = (Tablero.Turno == Tablero.Jugador.JAZUL) ? Player1 : Player2;
        }
    }
}
