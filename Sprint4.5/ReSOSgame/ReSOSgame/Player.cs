using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ReSOSgame.Tablero;

namespace ReSOSgame
{
    public abstract class Player
    {
        private Tablero.Jugador player;
        private Tablero.Cell ficha;
        private int Cord_X_ficha;
        private int Cord_Y_ficha;
        public int X { get { return Cord_X_ficha; } set { Cord_X_ficha = value; } }
        public int Y { get { return Cord_Y_ficha; } set { Cord_Y_ficha = value; } }
        public Tablero.Jugador Jugador {  get { return player; } }
        public Tablero.Cell Ficha { get { return ficha; } set { ficha = value; } }
        public Player(Tablero.Jugador player)
        {
            this.player = player;
            X = -1;
            Y = -1;
        }
        public abstract void MakeMove(int row, int col, Tablero.Cell _ficha, Juego juego);
    }
    public class Human:Player
    {
        public Human(Tablero.Jugador player):base(player)
        {
        }
        public override void MakeMove(int row, int col, Tablero.Cell _ficha, Juego juego)
        {   
            juego.MakeMove(row, col, _ficha);
            if (juego.tablero.ValidMove)
            {
                Ficha = _ficha;
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
        public Computer(Tablero.Jugador player) : base(player)
        {
        }

        public override void MakeMove(int row, int col, Tablero.Cell _ficha, Juego juego)
        {
            int numberOfEmptyCells = GetNumberOfEmptyCells(juego);
            Random random = new Random();
            int targetMove = random.Next(numberOfEmptyCells);
            int index = 0;
            for (int i = 0; i < juego.tablero.Tamanio; ++i)
            {
                for (int j = 0; j< juego.tablero.Tamanio; ++j)
                {
                    if (juego.tablero.GetCell(i, j) == 0)
                    {
                        if (targetMove == index)
                        {
                            //Relleno la ficha , cordenadax y cordenada y del player para que lo pinte
                            Ficha = (Cell)(random.Next(2) + 2);
                            X = i;
                            Y = j;
                            juego.MakeMove(i, j, Ficha);
                            Console.WriteLine("Movimiento de la computadora:");
                            Console.WriteLine("Casilla: [{0}, {1}]", i, j);
                            Console.WriteLine("Valor de ficha: {0}", _ficha);

                            return;
                        }
                        else
                        {
                            index++;
                        }
                    }
                }
            }

        }

        private int GetNumberOfEmptyCells(Juego juego)
        {
            int numberOfEmptyCells = 0;
            for (int row = 0; row < juego.tablero.Tamanio; ++row)
            {
                for (int col = 0; col < juego.tablero.Tamanio; ++col)
                {
                    if (juego.tablero.GetCell(row, col) == Cell.VACIA)
                    {
                        numberOfEmptyCells++;
                    }
                }
            }
            return numberOfEmptyCells;
        }

    }
}
