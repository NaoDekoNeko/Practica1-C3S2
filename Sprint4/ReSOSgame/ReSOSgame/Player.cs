using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        /*
        public override void MakeMove(int row, int col, Tablero.Cell _ficha, Juego juego)
        {
            Random rd = new Random();
            Tablero.Cell fichaAux;
            int rowAux;
            int colAux;
            X = -1; Y = -1;
            do {
                //un número de fila aleatorio escogido entre el numero de celdas dividido por el numero de filas
                rowAux = rd.Next(juego.Tamanio * juego.Tamanio) / juego.Tamanio; //   
                colAux = rd.Next(juego.Tamanio * juego.Tamanio) % juego.Tamanio; //                                                                   
                int aux = rd.Next(juego.Tamanio*juego.Tamanio)%2;
                if (aux == 0)
                    fichaAux = Tablero.Cell.S;
                else
                    fichaAux = Tablero.Cell.O;
                juego.MakeMove(rowAux,colAux,fichaAux);
            } while (!juego.tablero.ValidMove);
            Ficha = fichaAux;
            X = rowAux;
            Y = colAux;
        }
        */
        public override void MakeMove(int row, int col, Tablero.Cell _ficha, Juego juego)
        {
            Random rd = new Random();
            Tablero.Cell fichaAux;
            int rowAux;
            int colAux;
            X = -1; Y = -1;

            // Verificar si hay alguna posición en la que se pueda hacer un movimiento ganador
            for (int i = 0; i < juego.Tamanio; i++)
            {
                for (int j = 0; j < juego.Tamanio; j++)
                {
                    if (juego.tablero.GetCell(i, j) == Tablero.Cell.VACIA &&
                        (juego.validator.HasOnePoint(i, j, Tablero.Cell.S) ||
                         juego.validator.HasOnePoint(i, j, Tablero.Cell.O)))
                    {
                        juego.MakeMove(i, j, _ficha);
                        Ficha = _ficha;
                        X = i;
                        Y = j;
                        return;
                    }
                }
            }

            // Si no encontramos una posición ganadora, hacemos un movimiento aleatorio
            do
            {
                // Generar números aleatorios para la fila y la columna
                rowAux = rd.Next(juego.Tamanio);
                colAux = rd.Next(juego.Tamanio);
                int aux = rd.Next(2);
                if (aux == 0)
                    fichaAux = Tablero.Cell.S;
                else
                    fichaAux = Tablero.Cell.O;

                // Hacer el movimiento
                juego.MakeMove(rowAux, colAux, fichaAux);
            } while (!juego.tablero.ValidMove);

            Ficha = fichaAux;
            X = rowAux;
            Y = colAux;
        }

    }
}
