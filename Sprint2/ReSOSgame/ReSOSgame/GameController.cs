using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReSOSgame
{
    internal class GameController
    {
        private Juego juego;
        private Tablero tablero;
        
        public GameController(Juego juego,Tablero tablero) {
            this.juego = juego;
            this.tablero = tablero;
        }
                    

    }
}
