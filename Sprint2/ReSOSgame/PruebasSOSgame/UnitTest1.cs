using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
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
            Assert.AreEqual(preferredSize,tablero.Tamanio);
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
            Assert.AreEqual("SIMPLE", juegoSimple.tipoDeJuego);
        }
        //Criterio de aceptacion 2.2
        [TestMethod]
        public void SelectGeneralGameMode() 
        {
            JuegoGeneral juegoGeneral;
            juegoGeneral = new JuegoGeneral(tablero);
            Assert.AreEqual("GENERAL", juegoGeneral.tipoDeJuego);
        }
    }

    [TestClass] // Clase de Codigo de Prueba HU.3
    public class TestShowGameState
    {
        private Tablero t = new Tablero(6);
        
        //Criterio de aceptacion 3.1
        [TestMethod]
        public void ShowGameState() 
        {
            t.InitBoard();
            Assert.AreEqual("JUGANDO", t.EstadoDeJuego);
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
        [TestCleanup]
        public void Teardown()
        {
        }
        //Criterio de aceptacion 4.1
        [TestMethod]
        public void MakeBlueMoveS_SimpleGame()
        {
            tablero.MakeMove(1, 1, 'S');
            Assert.AreEqual(Tablero.Cell.S, tablero.GetCell(1, 1));
            Assert.AreEqual("Rojo", tablero.Jugador);
        }
        //Criterio de aceptacion 4.2
        [TestMethod]
        public void MakeRedMoveO_SimpleGame()
        {
            tablero.MakeMove(0, 0, 'S');
            tablero.MakeMove(2, 2, 'O');
            Assert.AreEqual(Tablero.Cell.O,tablero.GetCell(2, 2));
            Assert.AreEqual("Azul", tablero.Jugador);
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
        }
        [TestCleanup]
        public void Teardown()
        {
        }
        //Criterio de aceptacion 5.1
        [TestMethod]
        public void VictorybluePlayerWithS()
        {
            
            tablero.MakeMove(0, 0, 'S');
            tablero.MakeMove(0, 1, '0');
            tablero.MakeMove(1, 1, '0');
            tablero.MakeMove(0, 2, '0');
            tablero.MakeMove(2, 2, 'S');
            new Consola(tablero).DisplayBoard();
            Assert.AreEqual("Rojo", tablero.Jugador);
            Assert.AreEqual('S', tablero.Ficha);
            Assert.AreEqual(true, juego.JuegoGanado());
        }
        //Criterio de aceptacion 5.2
        [TestMethod]
        public void VictoryRedPlayerWithO()
        {
            Assert.AreEqual("Azul", tablero.Jugador);
            tablero.MakeMove(0, 0, 'S');
            tablero.MakeMove(0, 2, 'S');
            tablero.MakeMove(2, 2, 'S');
            tablero.MakeMove(0, 1, 'O');
            new Consola(tablero).DisplayBoard();
            Assert.AreEqual("Azul", tablero.Jugador);
            Assert.AreEqual('O', tablero.Ficha );
            Assert.AreEqual(true,juego.JuegoGanado());

        }
    }
}
