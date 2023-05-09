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
        public Tablero.Jugador Jugador {  get { return player; } }
        public Tablero.Cell Ficha { get { return ficha; } set { ficha = value; } }
        public Player(Tablero.Jugador player)
        {
            this.player = player;
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
                Ficha = _ficha;
        }
    }

    public class Computer : Player
    {
        public Computer(Tablero.Jugador player) : base(player)
        {
        }
        public override void MakeMove(int row,int col,Tablero.Cell _ficha,Juego juego)
        {
            Random rd = new Random();
            Tablero.Cell fichaAux;
            do {
                //un número de fila aleatorio escogido entre el numero de celdas dividido por el numero de filas
                int rowAux = rd.Next(juego.tablero.Tamanio * juego.tablero.Tamanio) / juego.tablero.Tamanio; //   
                int colAux = rd.Next(juego.tablero.Tamanio * juego.tablero.Tamanio) % juego.tablero.Tamanio; // 
                int aux = rd.Next(juego.tablero.Tamanio*juego.tablero.Tamanio)%2;
                if (aux == 0)
                    fichaAux = Tablero.Cell.S;
                else
                    fichaAux = Tablero.Cell.O;
                juego.MakeMove(rowAux,colAux,fichaAux);
            } while (!juego.tablero.ValidMove);
            Ficha = fichaAux;
        }
    }
}
