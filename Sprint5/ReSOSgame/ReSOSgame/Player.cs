using System;
using static ReSOSGame.Tablero;

namespace ReSOSGame
{
    public abstract class Player
    {
        //Almacenar coordenadas del movimiento 
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public Jugador Jugador { get; }
        public Cell Ficha { get; set; }

        protected Player(Jugador player)
        {
            this.Jugador = player;
            X = -1;
            Y = -1;
        }
        public abstract void MakeMove(int row, int col, Cell ficha, Juego juego);
    }
    public class Human:Player
    {
        public Human(Jugador player):base(player)
        {
        }
        public override void MakeMove(int row, int col, Cell ficha, Juego juego)
        {   
            juego.MakeMove(row, col, ficha);
            if (juego.Tablero.ValidMove)
            {
                Ficha = ficha;
                X = row;
                Y = col;
            }
            else
            {
                X = -1;
                Y = -1;
            }
                
        }
    }

    public class Computer : Player
    {
        public Computer(Jugador player) : base(player)
        {
        }

        public override void MakeMove(int row, int col, Tablero.Cell ficha, Juego juego)
        {
            //esta solución hace más eficaz que la computadora llene casillas vacías sin hacer movimientos inválidos
            int numberOfEmptyCells = juego.NumberOfEmptyCells;
            Random random = new Random();
            int targetMove = random.Next(numberOfEmptyCells);
            int index = 0;
            for (int i = 0; i < juego.Tablero.Tamanio; ++i)
            {
                for (int j = 0; j< juego.Tablero.Tamanio; ++j)
                {
                    if (juego.Tablero[i, j] != 0) continue;
                    if (targetMove == index)
                    {
                        //Relleno la ficha , cordenadax y cordenada y del player para que lo pinte
                        Ficha = (Cell)(random.Next(2) + 2);
                        X = i;
                        Y = j;
                        juego.MakeMove(i, j, Ficha);
                        Console.WriteLine("Movimiento de la computadora:");
                        Console.WriteLine("Casilla: [{0}, {1}]", i, j);
                        Console.WriteLine("Valor de ficha: {0}", ficha);

                        return;
                    }
                    index++;
                }
            }
        }
    }
}
