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
        public void TestListaDeFormasNull()
        {
            //Assert
            Assert.IsEmpty(GeneradorDataReporteFormaGeometrica.generarData(null).Data);
        }

        [TestCase]
        public void TestGeneradoDataReporteVacio()
        {
            //Assert
            Assert.IsEmpty(GeneradorDataReporteFormaGeometrica.generarData(new List<FormaGeometrica>()).Data);
        }

        [TestCase]
        public void TestGeneradorDataReporteNoVacio()
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
        public void TestDataReporteConUnCuadrado()
        {
            //Arrange
            Cuadrado cuadrado = new Cuadrado(2);
            Cuadrado otroCuadrado = new Cuadrado(2);
            Rectangulo rectangulo = new Rectangulo(1, 1);
            Triangulo triangulo = new Triangulo(12);

            var formas = new List<FormaGeometrica>();
            formas.Add(cuadrado);
            formas.Add(otroCuadrado);
            formas.Add(rectangulo);
            formas.Add(triangulo);

            //Act
            var dataReporte = GeneradorDataReporteFormaGeometrica.generarData(formas);

            var cantidadDeCuadrados = dataReporte.Data.Where(r => r.nombre == "Cuadrado").Select(c => c.cantidad).ToList().FirstOrDefault();
            var areaTotalCuadrados = dataReporte.Data.Where(r => r.nombre == "Cuadrado").Sum(a => a.areaTotal);
            var perimetroTotalCuadrados = dataReporte.Data.Where(r => r.nombre == "Cuadrado").Sum(a => a.perimetroTotal);

            Assert.AreEqual(2, cantidadDeCuadrados);
            Assert.AreEqual(8, areaTotalCuadrados);
            Assert.AreEqual(16, perimetroTotalCuadrados);
        }

        [TestCase]
        public void TestDataReporteTotalizadaConUnCuadrado()
        {
            //Arrange
            Cuadrado cuadrado = new Cuadrado(2);
            var formas = new List<FormaGeometrica>();
            formas.Add(cuadrado);

            //Act
            var dataReporte = GeneradorDataReporteFormaGeometrica.generarData(formas);

            Assert.AreEqual("Forma", dataReporte.DataTotalizada.nombre);
            Assert.AreEqual(1, dataReporte.DataTotalizada.cantidad);
            Assert.AreEqual(4, dataReporte.DataTotalizada.areaTotal);
            Assert.AreEqual(8, dataReporte.DataTotalizada.perimetroTotal);
        }

        [TestCase]
        public void TestDataReporteTotalizadaConMasCuadrados()
        {
            Cuadrado cuadrado = new Cuadrado(1);
            Cuadrado segundoCuadrado = new Cuadrado(2);
            Cuadrado tercerCuadrado = new Cuadrado(15);
            Cuadrado cuartoCuadrado = new Cuadrado(1);

            var formas = new List<FormaGeometrica>();
            formas.Add(cuadrado);
            formas.Add(segundoCuadrado);
            formas.Add(tercerCuadrado);
            formas.Add(cuartoCuadrado);

            //Act
            var dataReporte = GeneradorDataReporteFormaGeometrica.generarData(formas);

            Assert.AreEqual("Forma", dataReporte.DataTotalizada.nombre);
            Assert.AreEqual(4, dataReporte.DataTotalizada.cantidad);
            Assert.AreEqual(231, dataReporte.DataTotalizada.areaTotal);
            Assert.AreEqual(76, dataReporte.DataTotalizada.perimetroTotal);
        }

        [TestCase]
        public void TestDataReporteTotalizadaConMasFormas()
        {
            //Arrange
            Cuadrado cuadrado = new Cuadrado(17);
            Circulo circulo = new Circulo(5);
            Rectangulo rectangulo = new Rectangulo(1, 1);
            Triangulo triangulo = new Triangulo(12);
            Trapecio trapecio = new Trapecio(1, 2, 5, 2);

            var formas = new List<FormaGeometrica>();
            formas.Add(cuadrado);
            formas.Add(circulo);
            formas.Add(rectangulo);
            formas.Add(triangulo);
            formas.Add(trapecio);

            var dataReporte = GeneradorDataReporteFormaGeometrica.generarData(formas);

            Assert.AreEqual("Forma", dataReporte.DataTotalizada.nombre);
            Assert.AreEqual(5, dataReporte.DataTotalizada.cantidad);
            Assert.AreEqual("435,89", dataReporte.DataTotalizada.areaTotal.ToString("#.##"));
            Assert.AreEqual("146,42", dataReporte.DataTotalizada.perimetroTotal.ToString("#.##"));
        }

    }
}
