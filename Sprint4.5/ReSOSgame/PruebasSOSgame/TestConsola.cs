using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReSOSgame;
using System;
using System.Security.Permissions;

namespace PruebasSOSgame
{
    [TestClass]
    public class TestTableroConsola
    {
        static readonly int tamanio = 4;
        private Tablero tablero;
        [TestInitialize]
        public void Init()
        {
            tablero = new Tablero(tamanio);
        }
        [TestMethod]
        public void TestEmptyBoard()
        {
            new ReSOSgame.Consola(tablero).DisplayBoard();
        }
        [TestMethod]
        public void TestNonEmptyBoard()
        {
            tablero.MakeMove(0, 0, 'S');
            tablero.MakeMove(2, 3, 'O');
            new Consola(tablero).DisplayBoard();
        }
    }
}