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
        private Tablero tablero = new Tablero(6);
        //Criterio de aceptacion 2.1
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
            Assert.AreEqual(Tablero.GameState.JUGANDO, tablero.EstadoDeJuego);
        }
    }

    [TestClass] // Clase de Codigo de Prueba HU.4
    public class TestMakeMoveSimple
    {
        private Tablero tablero;
        private Juego juego;
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
        //Criterio de aceptacion 4.1
        [TestMethod]
        public void MakeBlueMoveS_SimpleGame()
        {
            juego.MakeMove(1, 1, Tablero.Cell.S);
            Assert.AreEqual(Tablero.Cell.S, tablero.GetCell(1, 1));
            Assert.AreEqual(Tablero.Jugador.ROJO, tablero.Turno);
        }
        //Criterio de aceptacion 4.2
        [TestMethod]
        public void MakeRedMoveO_SimpleGame()
        {
            juego.MakeMove(0, 0, Tablero.Cell.S);
            juego.MakeMove(2, 2, Tablero.Cell.O);
            Assert.AreEqual(Tablero.Cell.O,tablero.GetCell(2, 2));
            Assert.AreEqual(Tablero.Jugador.AZUL, tablero.Turno);
        }
    }

    [TestClass] // Clase de Codigo de Prueba HU.5
    public class TestSimpleGameVictory
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
            juego.MakeMove(0, 0, Tablero.Cell.S);
            juego.MakeMove(0, 1, Tablero.Cell.O);
            juego.MakeMove(1, 1, Tablero.Cell.O);
            juego.MakeMove(0, 2, Tablero.Cell.O);
            juego.MakeMove(2, 2, Tablero.Cell.S);
            new Consola(tablero).DisplayBoard();
            Assert.AreEqual(Tablero.Jugador.AZUL, tablero.Turno);
            Assert.AreEqual(Tablero.Cell.S, tablero.Ficha);
            Assert.AreEqual(Tablero.GameState.GANOAZUL, tablero.EstadoDeJuego);
        }
        //Criterio de aceptacion 5.2
        [TestMethod]
        public void VictoryRedPlayerWithO()
        {
            juego.MakeMove(0, 0, Tablero.Cell.S);
            juego.MakeMove(0, 2, Tablero.Cell.S);
            juego.MakeMove(2, 2, Tablero.Cell.S);
            juego.MakeMove(0, 1, Tablero.Cell.O);
            new Consola(tablero).DisplayBoard();
            Assert.AreEqual(Tablero.Jugador.ROJO, tablero.Turno);
            Assert.AreEqual(Tablero.Cell.O, tablero.Ficha);
            Assert.AreEqual(Tablero.GameState.GANOROJO, tablero.EstadoDeJuego);
        }
    }
    [TestClass]// Clase de Codigo de Prueba HU.6
    public class TestMakeMoveGeneral
    {
        private Tablero tablero;
        private Juego juego;
        [TestInitialize]
        public void Init()
        {
            tablero = new Tablero(3);
            juego = new JuegoGeneral(tablero);
            tablero.InitBoard();
        }
        [TestCleanup]
        public void Teardown()
        {
        }
        [TestMethod]//Criterio de aceptacion 6.1
        public void MakeBlueMoveO_GeneralGame()
        {
            juego.MakeMove(0, 2, Tablero.Cell.O);
            Assert.AreEqual(Tablero.Cell.O, tablero.GetCell(0, 2));
            Assert.AreEqual(Tablero.Jugador.ROJO, tablero.Turno);

        }
        [TestMethod]//Criterio de aceptacion 6.2
        public void MakeRedMoveS_GeneralGame()
        {
            juego.MakeMove(0, 0, Tablero.Cell.O);
            juego.MakeMove(2, 2, Tablero.Cell.S);
            Assert.AreEqual(Tablero.Cell.S, tablero.GetCell(2, 2));
            Assert.AreEqual(Tablero.Jugador.AZUL, tablero.Turno);
        }
    }
    [TestClass] // Clase de Codigo de Prueba HU.7
    public class TestGeneralGameVictory
    {
        private Tablero tablero;
        private JuegoGeneral juego;
        [TestInitialize]
        public void Init()
        {
            tablero = new Tablero(3);
            juego = new JuegoGeneral(tablero);
            tablero.InitBoard();
        }
        [TestCleanup]
        public void Teardown()
        {
        }
        //Criterio de aceptacion 7.1
        [TestMethod]
        public void FullBoard()
        {
            Random rd = new Random();
            int n;
            for (int i = 0; i < tablero.Tamanio; i++)
            {
                for(int j = 0; j< tablero.Tamanio;j++)
                {
                    n = rd.Next(100);
                    if(n%2 ==0)
                    {
                        juego.MakeMove(i, j, Tablero.Cell.S);
                    }
                    else
                    {
                        juego.MakeMove(i, j, Tablero.Cell.O);
                    }
                }
            }
            new Consola(tablero).DisplayBoard();
            Assert.IsTrue(juego.validator.FullBoard());
        }
        //Criterio de aceptacion 7.2
        [TestMethod]
        public void VictoryFullboardBlue()
        {
            juego.MakeMove(0, 0, Tablero.Cell.S); ImprimirTest();
            juego.MakeMove(1, 1, Tablero.Cell.O); ImprimirTest();
            juego.MakeMove(2, 2, Tablero.Cell.S); ImprimirTest();
            juego.MakeMove(1, 0, Tablero.Cell.S); ImprimirTest();
            juego.MakeMove(0, 1, Tablero.Cell.S); ImprimirTest();
            juego.MakeMove(1, 2, Tablero.Cell.O); ImprimirTest();
            juego.MakeMove(2, 1, Tablero.Cell.O); ImprimirTest();
            juego.MakeMove(0, 2, Tablero.Cell.O); ImprimirTest();
            juego.MakeMove(2, 0, Tablero.Cell.S); ImprimirTest();
            Assert.AreEqual(Tablero.GameState.GANOAZUL, tablero.EstadoDeJuego);
        }
        public void ImprimirTest() 
        {
            new Consola(tablero).DisplayBoard();
            System.Console.WriteLine("Puntaje Azul: " + juego.PuntajeAzul);
            System.Console.WriteLine("Puntaje Rojo: " + juego.PuntajeRojo);
        }
        //Criterio de aceptacion 7.3
        [TestMethod]
        public void VictoryFullboardRed()
        {
            juego.MakeMove(0, 0, Tablero.Cell.S);
            juego.MakeMove(0, 1, Tablero.Cell.S);
            juego.MakeMove(0, 2, Tablero.Cell.S);
            juego.MakeMove(1, 0, Tablero.Cell.O);
            juego.MakeMove(1, 1, Tablero.Cell.S);
            juego.MakeMove(1, 2, Tablero.Cell.S);
            juego.MakeMove(2, 1, Tablero.Cell.S);
            juego.MakeMove(2, 0, Tablero.Cell.S);
            juego.MakeMove(2, 2, Tablero.Cell.O);
            new Consola(tablero).DisplayBoard();
            Assert.AreEqual(Tablero.GameState.GANOROJO, tablero.EstadoDeJuego);
        }
        //Criterio de aceptacion 7.4
        [TestMethod]
        public void DrawFullBoardS()
        {
            for(int i=0;i<tablero.Tamanio;i++)
            {
                for(int j=0;j<tablero.Tamanio;j++)
                {
                    juego.MakeMove(i, j, Tablero.Cell.S);
                }
            }
            new Consola(tablero).DisplayBoard();
            Assert.AreEqual(Tablero.GameState.EMPATE, tablero.EstadoDeJuego);
        }
    }
}
