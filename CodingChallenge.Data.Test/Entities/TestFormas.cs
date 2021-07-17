using CodingChallenge.Data.Entities;
using NUnit.Framework;
using System;

namespace CodingChallenge.Data.Test
{
    [TestFixture, Order(1)]
    public class TestFormas
    {
        [Test]
        public void TestCuadrado()
        {
            var cuadrado = new Cuadrado(2m);

            Assert.IsNotNull(cuadrado);
            Assert.AreEqual(4, decimal.Round(cuadrado.GetArea(), 2));
            Assert.AreEqual(8, decimal.Round(cuadrado.GetPerimetro(), 2));
        }

        [Test]
        public void TestCirculo()
        {
            Circulo circulo = new Circulo(2m);

            Assert.IsNotNull(circulo);
            Assert.AreEqual(12.57m, decimal.Round(circulo.GetArea(), 2));
            Assert.AreEqual(12.57m, decimal.Round(circulo.GetPerimetro(), 2));
        }

        [Test]
        public void TestRectangulo()
        {
            var rectangulo = new Rectangulo(2m,2m);

            Assert.IsNotNull(rectangulo);
            Assert.AreEqual(4, decimal.Round(rectangulo.GetArea(), 2));
            Assert.AreEqual(8, decimal.Round(rectangulo.GetPerimetro(), 2));
        }

        [Test]
        public void TestTriangulo()
        {
            var triangulo = new Triangulo(2m);

            Assert.IsNotNull(triangulo);
            Assert.AreEqual(1.73m, decimal.Round(triangulo.GetArea(), 2));
            Assert.AreEqual(6m, decimal.Round(triangulo.GetPerimetro(), 2));
        }

        [Test]
        public void TestTrapecio()
        {
            Trapecio trapecio = new Trapecio(2m, 4m, 5m, 2m);

            Assert.IsNotNull(trapecio);
            Assert.AreEqual(20, decimal.Round(trapecio.GetArea(), 2));
            Assert.AreEqual(10, decimal.Round(trapecio.GetPerimetro(), 2));
        }
    }
}