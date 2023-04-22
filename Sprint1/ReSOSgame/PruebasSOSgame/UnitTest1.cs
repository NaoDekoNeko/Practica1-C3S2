using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReSOSgame;
using System;
using System.Security.Permissions;

namespace PruebasSOSgame
{
    [TestClass]
    public class TestTableroVacio
    {
        private Tablero tablero = new Tablero(3);
        //Criterio de aceptacion 1.1
        [TestMethod]
        public void TableroNuevo()
        {
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
    [TestClass]
    public class TestMovimientosValidos
    {
        private Tablero tablero
            ;
        [TestInitialize]
        public void Init()
        {
            tablero = new Tablero(3);
        }
        //Critero de aceptacion 4.1
        [TestMethod]
        public void TestMovimientoAzulSCeldaVacia()
        {
            tablero.MakeMove(0, 0,'S');
            Assert.AreEqual(tablero.GetCell(0, 0), Tablero.Cell.S);
            Assert.AreEqual(tablero.Jugador, "Rojo");
        }
        //Critero de aceptacion 4.2
        [TestMethod]
        public void TestMovimientoRojoOCeldaVacia()
        {
            tablero.MakeMove(0, 0,'S');
            tablero.MakeMove(1, 1,'O');
            Assert.AreEqual(tablero.GetCell(1, 1), Tablero.Cell.O);
            Assert.AreEqual(tablero.Jugador, "Azul");
        }
    }
}
