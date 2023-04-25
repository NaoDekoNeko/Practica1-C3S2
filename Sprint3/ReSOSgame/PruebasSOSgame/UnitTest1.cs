using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReSOSgame;
using System;

namespace PruebasSOSgame
// HU :Historia de Usuario
{
    [TestClass] // Clase de Codigo de Prueba HU.1
    public class TestEmptyBoard
    {
        static readonly int preferredSize = 7;
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
        private Tablero tablero = new Tablero(6);
        

        [TestMethod]
        public void SelectSimpleGameMode()
        {
            JuegoSimple juegoSimple;
            juegoSimple = new JuegoSimple(tablero);
            Assert.IsTrue(juegoSimple is JuegoSimple);
        }
        //Criterio de aceptacion 2.2
        [TestMethod]
        public void SelectGeneralGameMode() 
        {
            JuegoGeneral juegoGeneral;
            juegoGeneral = new JuegoGeneral(tablero);
            Assert.IsTrue(juegoGeneral is JuegoGeneral);
        }
    }

    [TestClass] // Clase de Codigo de Prueba HU.3
    public class TestShowGameState
    {
        private Tablero tablero = new Tablero(6);
        
        //Criterio de aceptacion 3.1
        [TestMethod]
        public void ShowGameState() 
        {
            tablero.InitBoard();
            Assert.AreEqual(Tablero.EstadoJuego.JUGANDO, tablero.EstadoDeJuego);
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
            tablero.InitBoard();
        }
        [TestCleanup]
        public void Teardown()
        {
        }
        //Criterio de aceptacion 4.1
        [TestMethod]
        public void MakeBlueMoveS_SimpleGame()
        {
            tablero.MakeMove(1, 1, Tablero.Cell.S);
            Assert.AreEqual(Tablero.Cell.S, tablero.GetCell(1, 1));
            Assert.AreEqual(Tablero.Jugador.ROJO, tablero.Turno);
        }
        //Criterio de aceptacion 4.2
        [TestMethod]
        public void MakeRedMoveO_SimpleGame()
        {
            tablero.MakeMove(0, 0, Tablero.Cell.S);
            tablero.MakeMove(2, 2, Tablero.Cell.O);
            Assert.AreEqual(Tablero.Cell.O,tablero.GetCell(2, 2));
            Assert.AreEqual(Tablero.Jugador.AZUL, tablero.Turno);
        }
    }

    [TestClass] // Clase de Codigo de Prueba HU.5
    public class TestGameVictory
    {
        private Tablero tablero;
        private JuegoSimple juego;
        [TestInitialize]
        public void Init()
        {
            tablero = new Tablero(3);
            juego = new JuegoSimple(tablero);
            tablero.InitBoard();
        }
        [TestCleanup]
        public void Teardown()
        {
        }
        //Criterio de aceptacion 5.1
        [TestMethod]
        public void VictorybluePlayerWithS()
        {
            tablero.MakeMove(0, 0, Tablero.Cell.S);
            tablero.MakeMove(0, 1, Tablero.Cell.O);
            tablero.MakeMove(1, 1, Tablero.Cell.O);
            tablero.MakeMove(0, 2, Tablero.Cell.O);
            tablero.MakeMove(2, 2, Tablero.Cell.S);
            new Consola(tablero).DisplayBoard();
            Assert.AreEqual(Tablero.Jugador.ROJO, tablero.Turno);
            Assert.AreEqual(Tablero.Cell.S, tablero.Ficha);
            Assert.AreEqual(true, juego.JuegoGanado());
        }
        //Criterio de aceptacion 5.2
        [TestMethod]
        public void VictoryRedPlayerWithO()
        {
            tablero.MakeMove(0, 0, Tablero.Cell.S);
            tablero.MakeMove(0, 2, Tablero.Cell.S);
            tablero.MakeMove(2, 2, Tablero.Cell.S);
            tablero.MakeMove(0, 1, Tablero.Cell.O);
            new Consola(tablero).DisplayBoard();
            Assert.AreEqual(Tablero.Jugador.AZUL, tablero.Turno);
            Assert.AreEqual(Tablero.Cell.O, tablero.Ficha);
            Assert.AreEqual(true,juego.JuegoGanado());
        }
    }
}
