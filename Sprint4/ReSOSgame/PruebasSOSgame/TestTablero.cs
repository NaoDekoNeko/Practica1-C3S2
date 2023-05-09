using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReSOSgame;
using System;
using System.Security.Permissions;

namespace PruebasSOSgame
{
    [TestClass]
    public class TestTablero
    {
        static int tamanio_a_gusto = 7;
        private Tablero tablero = new Tablero(tamanio_a_gusto);
        //Criterio de aceptacion 1.1
        [TestMethod]
        public void TableroNuevo()
        {
            // Refactorizable ( Funcion assert para verificar si la tablae sta vacia )
            for (int row = 0; row < tablero.Tamanio; row++)
            {
                for (int column = 0; column < tablero.Tamanio; column++)
                {
                    Assert.AreEqual(tablero.GetCell(row, column), Tablero.Cell.VACIA);
                }
        }
            Assert.AreEqual(tablero.Ficha,'S');
            Assert.AreEqual(tablero.Jugador, "Azul");
      }
    }
    
}
