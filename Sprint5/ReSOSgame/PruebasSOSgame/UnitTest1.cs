using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReSOSGame;
using System;
using System.IO;
using System.Threading;

namespace PruebasSOSgame
// HU :Historia de Usuario
{
    [TestClass] // Clase de Codigo de Prueba HU.1
    public class TestEmptyBoard
    {
        private const int PreferredSize = 7;

        private Tablero tablero = new Tablero(PreferredSize);
        //Criterio de aceptacion 1.1
        [TestMethod]
        public void NewTablero()
        {
            
            // Refactorizable - Comprueba que todas las celdas del tablero estén vacías
            for (int row = 0; row < tablero.Tamanio; row++)
            {
                for (int column = 0; column < tablero.Tamanio; column++)
                {
                    Assert.AreEqual(tablero[row, column], Tablero.Cell.VACIA);
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
        private const int PreferredSize = 6;
        private Tablero tablero = new Tablero(PreferredSize);
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
        private const int PreferredSize = 6;
        private Tablero tablero = new Tablero(PreferredSize);
        
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
        private Player player1, player2;
        private const int PreferredSize = 3;
        [TestInitialize]
        public void SetUp()
        {
            tablero = new Tablero(PreferredSize);
            juego = new JuegoSimple(tablero);
            player1 = new Human(Tablero.Jugador.JAZUL);
            player2 = new Human(Tablero.Jugador.JROJO);
            tablero.InitBoard();
        }
        //Criterio de aceptacion 4.1
        [TestMethod]
        public void MakeBlueMoveS_SimpleGame()
        {
            player1.MakeMove(1, 1, Tablero.Cell.S,juego);
            Assert.AreEqual(Tablero.Cell.S, tablero[1, 1]);
            Assert.AreEqual(Tablero.Jugador.JROJO, tablero.Turno);
        }
        //Criterio de aceptacion 4.2
        [TestMethod]
        public void MakeRedMoveO_SimpleGame()
        {
            juego.MakeMove(0, 0, Tablero.Cell.S);
            juego.MakeMove(2, 2, Tablero.Cell.O);
            Assert.AreEqual(Tablero.Cell.O,tablero[2, 2]);
            Assert.AreEqual(Tablero.Jugador.JAZUL, tablero.Turno);
        }
    }

    [TestClass] // Clase de Codigo de Prueba HU.5
    public class TestSimpleGameVictory
    {
        private Tablero tablero;
        private JuegoSimple juego;
        private const int PreferredSize = 3;
        [TestInitialize]
        public void SetUp()
        {
            tablero = new Tablero(PreferredSize);
            juego = new JuegoSimple(tablero);
            tablero.InitBoard();
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
            Assert.AreEqual(Tablero.Jugador.JAZUL, tablero.Turno);
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
            Assert.AreEqual(Tablero.Jugador.JROJO, tablero.Turno);
            Assert.AreEqual(Tablero.Cell.O, tablero.Ficha);
            Assert.AreEqual(Tablero.GameState.GANOROJO, tablero.EstadoDeJuego);
        }
    }
    [TestClass]// Clase de Codigo de Prueba HU.6
    public class TestMakeMoveGeneral
    {
        private Tablero tablero;
        private Juego juego;
        private const int PreferredSize = 3;
        [TestInitialize]
        public void SetUp()
        {
            tablero = new Tablero(PreferredSize);
            juego = new JuegoGeneral(tablero);
            tablero.InitBoard();
        }
        [TestMethod]//Criterio de aceptacion 6.1
        public void MakeBlueMoveO_GeneralGame()
        {
            juego.MakeMove(0, 2, Tablero.Cell.O);
            Assert.AreEqual(Tablero.Cell.O, tablero[0, 2]);
            Assert.AreEqual(Tablero.Jugador.JROJO, tablero.Turno);

        }
        [TestMethod]//Criterio de aceptacion 6.2
        public void MakeRedMoveS_GeneralGame()
        {
            juego.MakeMove(0, 0, Tablero.Cell.O);
            juego.MakeMove(2, 2, Tablero.Cell.S);
            Assert.AreEqual(Tablero.Cell.S, tablero[2, 2]);
            Assert.AreEqual(Tablero.Jugador.JAZUL, tablero.Turno);
        }
    }
    [TestClass] // Clase de Codigo de Prueba HU.7
    public class TestGeneralGameVictory
    {
        private Tablero tablero;
        private JuegoGeneral juego;
        private const int PreferredSize = 3;
        [TestInitialize]
        public void SetUp()
        {
            tablero = new Tablero(PreferredSize);
            juego = new JuegoGeneral(tablero);
            tablero.InitBoard();
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
            Assert.IsTrue(juego.Validator.FullBoard());
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

    [TestClass] // Clase de Codigo de Prueba HU.8
    public class TestSelectTypePlayer
    {
        private Player player1 = new Computer(Tablero.Jugador.JAZUL);
        private Player player2 = new Computer(Tablero.Jugador.JROJO);
        //Criterio de aceptacion 8.1
        [TestMethod]
        public void SelectBlueComputerPlayer()
        {
            Assert.IsTrue(player1 is Computer);
            Assert.AreEqual(player1.Jugador, Tablero.Jugador.JAZUL);
        }
        //Criterio de aceptacion 8.2
        [TestMethod]
        public void SelectRedComputerPlayer()
        {
            Assert.IsTrue(player2 is Computer);
            Assert.AreEqual(player2.Jugador, Tablero.Jugador.JROJO);
        }
    }

    [TestClass] //Clase de Codigo de Prueba HU.9
    public class TestPlayAgainstComputer 
    {
        private Controller controller;
        private const int PreferredSize = 3;

        [TestInitialize]
        public void SetUp()
        {
            controller = new Controller();
            controller.Tablero = new Tablero(PreferredSize);
            controller.Juego = new JuegoSimple(controller.Tablero);
        }
        //Criterio de aceptacion 9.1
        [TestMethod]
        public void ComputerMakesFirstMove()
        {
            controller.Player1 = new Computer(Tablero.Jugador.JAZUL);
            controller.Player2 = new Human(Tablero.Jugador.JROJO);
            controller.InitTurn();
            controller.Player1.MakeMove(0, 0, Tablero.Cell.S, controller.Juego);
            Assert.IsTrue(controller.CurrentPlayer is Computer);
            Assert.IsTrue(controller.Tablero.ValidMove);
            controller.ChangeTurn(); // hace el cambio de turno
            Assert.IsTrue(controller.CurrentPlayer is Human);// valida que se ha hecho el cambio de turno
            new Consola(controller.Tablero).DisplayBoard();
        }
        //Criterio de aceptacion 9.2
        [TestMethod]
        public void ComputerMakesSecondMove()
        {
            controller.Player1 = new Human(Tablero.Jugador.JAZUL);
            controller.Player2 = new Computer(Tablero.Jugador.JROJO);
            controller.InitTurn();
            controller.Player1.MakeMove(0, 0, Tablero.Cell.S, controller.Juego);
            controller.ChangeTurn();
            Assert.IsTrue(controller.CurrentPlayer is Computer);
            controller.Player2.MakeMove(0, 0, Tablero.Cell.S, controller.Juego);
            controller.ChangeTurn();
            Assert.IsTrue(controller.CurrentPlayer is Human);
            new Consola(controller.Tablero).DisplayBoard();
        }
        //Criterio de aceptacion 9.3
        //Termina cuando haya ganador o empate
        [TestMethod]
        public void ComputerVsComputer()
        {
            controller.Player1 = new Computer(Tablero.Jugador.JAZUL);
            controller.Player2 = new Computer(Tablero.Jugador.JROJO);
            while(controller.Tablero.EstadoDeJuego == Tablero.GameState.JUGANDO)
            {
                controller.Player1.MakeMove(0, 0, Tablero.Cell.S, controller.Juego);
                controller.Player2.MakeMove(0, 0, Tablero.Cell.O, controller.Juego);
            }
            new Consola(controller.Tablero).DisplayBoard();
            Assert.IsTrue(controller.Tablero.EstadoDeJuego != Tablero.GameState.JUGANDO);
        }
    }

    [TestClass] //Clase de código de prueba HU 20
    public  class TestGameToText
    {
        private Controller controller;
        private GameRecorder gameRecorder;
        private const int PreferredSize = 3;
        [TestInitialize]
        public void Setup()
        {
            controller = new Controller();
            controller.Tablero = new Tablero(PreferredSize);
        }

        [TestCleanup]
        public void TearDown()
        {
            if (!File.Exists(gameRecorder.FilePath)) return;
            //quitamos el atributo de solo lectura
            File.SetAttributes(gameRecorder.FilePath, FileAttributes.Normal);
            //borramos la partida para que los test no lo acumulen
            File.Delete(gameRecorder.FilePath);
        }
        private static bool FileCompare(string file1, string file2)
        {
            int file1Byte;
            int file2Byte;
            FileStream fs1;
            FileStream fs2;

            // Verifica si los tamaños de los archivos son iguales
            if (new FileInfo(file1).Length != new FileInfo(file2).Length)
            {
                return false;
            }

            // Abre los archivos en modo lectura binaria
            fs1 = new FileStream(file1, FileMode.Open, FileAccess.Read);
            fs2 = new FileStream(file2, FileMode.Open, FileAccess.Read);

            // Compara byte a byte
            do
            {
                // Lee un byte de cada archivo
                file1Byte = fs1.ReadByte();
                file2Byte = fs2.ReadByte();
            }
            while ((file1Byte == file2Byte) && (file1Byte != -1));

            // Cierra los archivos
            fs1.Close();
            fs2.Close();

            // Si los bytes leídos son iguales, los archivos son iguales
            return (file1Byte - file2Byte) == 0;
        }
        //Criterio de aceptación 20.1
        [TestMethod]
        public void SaveSimpleHumanVHumanGame()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            controller.Juego = new JuegoSimple(controller.Tablero);
            controller.Player1 = new Human(Tablero.Jugador.JAZUL);
            controller.Player2 = new Human(Tablero.Jugador.JROJO);
            gameRecorder = new GameRecorder(controller.Juego);
            gameRecorder.SaveGame();
            controller.InitTurn();
            // Para que no sobreescriba el archivo de la prueba anterior
            // Al retrasar un segundo su ejecución, se crea un nuevo archivo por el segundo de diferencia
            // Las pruebas deben ser ejecutadas en paralelo para que no ocurran problemas durante su ejecución
            controller.CurrentPlayer.MakeMove(0, 0, Tablero.Cell.S, controller.Juego);
            gameRecorder.PrintGame();
            controller.CurrentPlayer.MakeMove(0, 2, Tablero.Cell.S, controller.Juego);
            gameRecorder.PrintGame();
            controller.CurrentPlayer.MakeMove(2, 2, Tablero.Cell.S, controller.Juego);
            gameRecorder.PrintGame();
            controller.CurrentPlayer.MakeMove(0, 1, Tablero.Cell.O, controller.Juego);
            gameRecorder.PrintGame();
            //Console.WriteLine(gameRecorder.FilePath);
            Assert.IsTrue(FileCompare(gameRecorder.FilePath, @"C:\Users\Ademar\OneDrive\Desktop\Practica1-C3S2\Sprint5\TestTxt\TestSimpleHumanVHuman.txt"));
            
        }
        //Criterio de aceptación 20.2
        [TestMethod]
        public void SaveSimpleComputerVComputerGame()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            controller.Juego = new JuegoSimple(controller.Tablero);
            controller.Player1 = new Computer(Tablero.Jugador.JAZUL);
            controller.Player2 = new Computer(Tablero.Jugador.JROJO);
            gameRecorder = new GameRecorder(controller.Juego);
            gameRecorder.SaveGame();
            controller.InitTurn();
            while (controller.Tablero.EstadoDeJuego == Tablero.GameState.JUGANDO)
            {
                controller.CurrentPlayer.MakeMove(0, 0, (Tablero.Cell)1, controller.Juego);
                gameRecorder.PrintGame();
            }
            Assert.IsTrue(File.Exists(gameRecorder.FilePath));
        }
        [TestMethod]
        public void SaveGeneralHumanVHuman()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            controller.Juego = new JuegoGeneral(controller.Tablero);
            controller.Player1 = new Human(Tablero.Jugador.JAZUL);
            controller.Player2 = new Human(Tablero.Jugador.JROJO);
            gameRecorder = new GameRecorder(controller.Juego);
            gameRecorder.SaveGame();
            controller.InitTurn();
            controller.CurrentPlayer.MakeMove(0, 0, Tablero.Cell.S, controller.Juego); 
            gameRecorder.PrintGame();
            controller.CurrentPlayer.MakeMove(1, 1, Tablero.Cell.O, controller.Juego);
            gameRecorder.PrintGame();
            controller.CurrentPlayer.MakeMove(2, 2, Tablero.Cell.S, controller.Juego);
            gameRecorder.PrintGame();
            controller.CurrentPlayer.MakeMove(1, 0, Tablero.Cell.S, controller.Juego);
            gameRecorder.PrintGame();
            controller.CurrentPlayer.MakeMove(0, 1, Tablero.Cell.S, controller.Juego);
            gameRecorder.PrintGame();
            controller.CurrentPlayer.MakeMove(1, 2, Tablero.Cell.O, controller.Juego);
            gameRecorder.PrintGame();
            controller.CurrentPlayer.MakeMove(2, 1, Tablero.Cell.O, controller.Juego);
            gameRecorder.PrintGame();
            controller.CurrentPlayer.MakeMove(0, 2, Tablero.Cell.O, controller.Juego);
            gameRecorder.PrintGame();
            controller.CurrentPlayer.MakeMove(2, 0, Tablero.Cell.S, controller.Juego);
            gameRecorder.PrintGame();
            //Console.WriteLine(gameRecorder.FilePath);
            Assert.IsTrue(FileCompare(gameRecorder.FilePath, @"C:\Users\Ademar\OneDrive\Desktop\Practica1-C3S2\Sprint5\TestTxt\TestGeneralHumanVHuman.txt"));
        }

        [TestMethod]
        public void SaveGeneralComputerVComputer()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            controller.Juego = new JuegoGeneral(controller.Tablero);
            controller.Player1 = new Computer(Tablero.Jugador.JAZUL);
            controller.Player2 = new Computer(Tablero.Jugador.JROJO);
            gameRecorder = new GameRecorder(controller.Juego);
            gameRecorder.SaveGame();
            controller.InitTurn();
            while (controller.Tablero.EstadoDeJuego == Tablero.GameState.JUGANDO)
            {
                controller.CurrentPlayer.MakeMove(0, 0, (Tablero.Cell)1, controller.Juego);
                gameRecorder.PrintGame();
            }
            //Console.WriteLine(gameRecorder.FilePath);
            Assert.IsTrue(File.Exists(gameRecorder.FilePath));
        }
    }
}
