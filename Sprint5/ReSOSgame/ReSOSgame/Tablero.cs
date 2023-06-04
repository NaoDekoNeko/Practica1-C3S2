namespace ReSOSGame
{ 
    public class Tablero
    {
        public enum Cell { VACIA, INVALIDA, S,O}
        public enum Jugador { JAZUL,JROJO}
        public enum GameState { JUGANDO,EMPATE,GANOAZUL,GANOROJO }
        
        public bool ValidMove { get; set; }
        public Player JugadorActual { get; set; }
        public Cell Ficha { get; set; }
        public Jugador Turno { get; set; }
        public int Tamanio { get; }
        public GameState EstadoDeJuego { get; set; }
        public Cell[,] Grid { get; }

        public Cell this[int row, int column]
        {
            get
            {
                if (row >= 0 && column >= 0 && row < Tamanio && column < Tamanio)
                    return Grid[row, column];
                return Cell.INVALIDA;
            }
            set
            {
                if (row >= 0 && column >= 0 && row < Tamanio && column < Tamanio)
                    Grid[row, column] = value;
            }
        }

        public Tablero(int tamanio)
        {
            //se espera que el tamaño del tablero sea mínimo 1 y como máximo 12
            Grid = new Cell[tamanio, tamanio];
            this.Tamanio = tamanio;
        }

        //Inicia el tablero
        public void InitBoard()
        {
            for(int row = 0; row < Tamanio; row++)
            {
                for(int column = 0; column < Tamanio; column++)
                {
                    Grid[row, column] = Cell.VACIA;
                }
            }
            EstadoDeJuego = GameState.JUGANDO;
            Ficha = Cell.S;
            Turno = Jugador.JAZUL;
        }
    }
}
