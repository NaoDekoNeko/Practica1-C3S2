using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReSOSgame;

namespace PruebasSOSgame
// HU :Historia de Usuario
{
    [TestClass] // Clase de Codigo de Prueba HU.1
    public class TestEmptyBoard
    {
        static int preferredSize = 7;
        private Tablero tablero = new Tablero(preferredSize);
        //Criterio de aceptacion 1.1
        [TestMethod]
        public void NewTablero()
        {
            
            // Refactorizable - Comprueba que todas las celdas del tablero estén vacías
            for (int row = 0; row < tablero.Tamanio; row++)
            {
                for (int column = 0; column < tablero.Tamanio; column++)
                {
                    Assert.AreEqual(tablero.GetCell(row, column), Tablero.Cell.VACIA);
                }
            }
            // Esto podria ser otro criterio de aceptacion no manual ni automatico
            // Assert.AreEqual(tablero.Ficha, 'S');
            // Assert.AreEqual(tablero.Jugador, "Azul");
        }
    }

    [TestClass] // Clase de Codigo de Prueba HU.2
    public class TestSelectorModeGame
    {
        //Criterio de aceptacion 2.1        
        private Tablero t = new Tablero(6);
        private Juego juego;
        [TestMethod]
        public void selectSimpleGameMode()
        {
            
        }
        //Criterio de aceptacion 2.2
        [TestMethod]
        public void selectGeneralGameMode() 
        {
            Assert.AreEqual(0, 0);
        }
    }

    [TestClass] // Clase de Codigo de Prueba HU.3
    public class TestShowGameState
    {
        //Criterio de aceptacion 3.1
        [TestMethod]
        public void showGameState() 
        {
            Assert.AreEqual(0, 0);
        }
    }

    [TestClass] // Clase de Codigo de Prueba HU.4
    public class TestMakeMove
    {
        private Tablero tablero;
        [TestInitialize]
        public void Init()
        {
            tablero = new Tablero(3);
        }
        //Criterio de aceptacion 4.1
        [TestMethod]
        public void makeBlueMoveS_SimpleGame()
        {
            tablero.MakeMove(0, 0, 'S');
            Assert.AreEqual(tablero.GetCell(0, 0), Tablero.Cell.S);
            Assert.AreEqual(tablero.Jugador, "Rojo");
        }
        //Criterio de aceptacion 4.2
        [TestMethod]
        public void makeRedMoveO_SimpleGame()
        {
            tablero.MakeMove(0, 0, 'S');
            tablero.MakeMove(1, 1, 'O');
            Assert.AreEqual(tablero.GetCell(1, 1), Tablero.Cell.O);
            Assert.AreEqual(tablero.Jugador, "Azul");
        }
    }

    [TestClass] // Clase de Codigo de Prueba HU.5
    public class TestGameVictory
    {
        //Criterio de aceptacion 5.1
        [TestMethod]
        public void VictorybluePlayerWithS()
        {
            Assert.AreEqual(0, 0);
        }
        //Criterio de aceptacion 5.2
        [TestMethod]
        public void VictoryRedPlayerWithO()
        {
            Assert.AreEqual(0, 0);

        }
    }
    
}
