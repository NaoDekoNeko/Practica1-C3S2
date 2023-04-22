using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Sprint0;

namespace UnitTestSprint0
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Origen()
        {
                var distancia = new Distancia();
                var punto = new Coordenada(0, 0);
                var resultado = distancia.CalcularDistancia(punto);
                Assert.AreEqual(resultado, 0.0);
            
        }
        [TestMethod]
        public void PrimerCuadrante()
        {
            var distancia = new Distancia();
            var punto = new Coordenada(3, 4);
            var resultado = distancia.CalcularDistancia(punto);
            Assert.AreEqual(resultado, 5.0);
        }

        [TestMethod]
        public void SegundoCuadrante()
        {
            var distancia = new Distancia();
            var punto = new Coordenada(-6, 8);
            var resultado = distancia.CalcularDistancia(punto);
            Assert.AreEqual(resultado, 10.0);
        }

        [TestMethod]
        public void TercerCuadrante()
        {
            var distancia = new Distancia();
            var punto = new Coordenada(-12, -5);
            var resultado = distancia.CalcularDistancia(punto);
            Assert.AreEqual(resultado, 13.0);
        }

        [TestMethod]
        public void CuartoCuadrante()
        {
            var distancia = new Distancia();
            var punto = new Coordenada(1, -1);
            var resultado = distancia.CalcularDistancia(punto);
            Assert.AreEqual(resultado, 1.4142, 0.0001);
        }
    }

}
