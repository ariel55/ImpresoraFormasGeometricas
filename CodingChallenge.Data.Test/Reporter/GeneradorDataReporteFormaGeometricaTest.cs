using CodingChallenge.Data.Entities;
using CodingChallenge.Data.Reporter;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge.Data.Test
{
    [TestFixture, Order(2)]
    public class GeneradorDataReporteFormaGeometricaTest
    {
        [TestCase]
        public void TestDataReporteVacio()
        {
            //Assert
            Assert.IsEmpty(GeneradorDataReporteFormaGeometrica.generarData(new List<FormaGeometrica>()).Data);
        }

        [TestCase]
        public void TestDataReporteNoVacio()
        {
            //Arrange
            Cuadrado cuadrado = new Cuadrado(lado: 1);

            var listaDeFormas = new List<FormaGeometrica>();
            listaDeFormas.Add(cuadrado);

            //Act
            var cuadradoReporte = GeneradorDataReporteFormaGeometrica.generarData(listaDeFormas).Data;

            //Assert
            Assert.AreEqual(1, cuadradoReporte.Count());
        }

        [TestCase]
        public void TestDataReporteNoVacio_version2()
        {
            //Arrange
            Cuadrado    forma_1    = new Cuadrado(10);
            Circulo     forma_2 = new Circulo(5);
            Rectangulo  forma_3 = new Rectangulo(18, 5);
            Triangulo   forma_4 = new Triangulo(12);
            Trapecio    forma_5 = new Trapecio(2, 4, 5, 2);

            List<FormaGeometrica> listaDeFormas = new List<FormaGeometrica>();
            listaDeFormas.Add(forma_1);
            listaDeFormas.Add(forma_2);
            listaDeFormas.Add(forma_3);
            listaDeFormas.Add(forma_4);
            listaDeFormas.Add(forma_5);

            //Act
            var cuadradoReporte = GeneradorDataReporteFormaGeometrica.generarData(listaDeFormas).Data;

            //Assert
            Assert.AreEqual(5, cuadradoReporte.Count());
        }

        [TestCase]
        public void TestDataReporteUnCuadrado()
        {
            //Arrange
            Cuadrado cuadrado = new Cuadrado(lado: 1);

            var listaDeFormas = new List<FormaGeometrica>();
            listaDeFormas.Add(cuadrado);

            //Act
            var cuadradoReporte = GeneradorDataReporteFormaGeometrica.generarData(listaDeFormas);

            //Assert
            Assert.AreEqual(1, cuadradoReporte.Data.Count());
        }

    }
}
