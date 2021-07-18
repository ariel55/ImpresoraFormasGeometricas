﻿using CodingChallenge.Data.Entities;
using CodingChallenge.Data.Reporter;
using CodingChallenge.Data.Traduccion;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodingChallenge.Data.Test
{
    [TestFixture, Order(3)]
    public class ImpresoraAppTest
    {
        [TestCase]
        public void TestImpresoraSinFormasIngles()
        {
            //Assert
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                ImpresoraApp.Imprimir(new List<FormaGeometrica>(), (int)Idioma.Ingles));

            Assert.AreEqual("<h1>Empty list of shapes!</h1>", 
                ImpresoraApp.Imprimir(null, (int)Idioma.Ingles));
        }

        [TestCase]
        public void TestImpresoraSinFormasCastellano()
        {
            //Assert
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                ImpresoraApp.Imprimir(new List<FormaGeometrica>(), (int)Idioma.Castellano));

            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
               ImpresoraApp.Imprimir(new List<FormaGeometrica>(), (int)Idioma.Castellano));
        }

        [TestCase]
        public void TestImpresoraSinFormasPortugues()
        {
            //Assert
            Assert.AreEqual("<h1>Lista vazia de formas!</h1>",
                ImpresoraApp.Imprimir(new List<FormaGeometrica>(), (int)Idioma.Portugues));

            Assert.AreEqual("<h1>Lista vazia de formas!</h1>",
                ImpresoraApp.Imprimir(null, (int)Idioma.Portugues));
        }

        [TestCase]
        public void TestImpresoraConUnCuadradoEnCastellano()
        {
            //Arrange
            Cuadrado cuadrado = new Cuadrado(1);
            List<FormaGeometrica> listaDeFormas = new List<FormaGeometrica>();
            listaDeFormas.Add(cuadrado);

            //Act
            var resumen = ImpresoraApp.Imprimir(listaDeFormas, (int)Idioma.Castellano);

            //Assert
            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Área 1 | Perímetro 4 <br/>TOTAL :<br/>1 Forma Perímetro 4 Área 1", resumen);
        }

        [TestCase]
        public void TestImpresoraConUnCirculoEnIngles()
        {
            //Arrange
            Circulo circulo = new Circulo(1);
            List<FormaGeometrica> listaDeFormas = new List<FormaGeometrica>();
            listaDeFormas.Add(circulo);

            //Act
            var resumen = ImpresoraApp.Imprimir(listaDeFormas, (int)Idioma.Ingles);

            //Assert
            Assert.AreEqual("<h1>Shapes report</h1>1 Circle | Area 3,14 | Perimeter 6,28 <br/>TOTAL :<br/>1 Shape Perimeter 6,28 Area 3,14", resumen);
        }

        [TestCase]
        public void TestImpresoraConMasCuadradosEnIngles()
        {
            //Arrange
            Cuadrado cuadrado = new Cuadrado(1);
            Cuadrado segundoCuadrado = new Cuadrado(2);
            Cuadrado tercerCuadrado = new Cuadrado(15);
            Cuadrado cuartoCuadrado = new Cuadrado(1);

            List<FormaGeometrica> listaDeFormas = new List<FormaGeometrica>();
            listaDeFormas.Add(cuadrado);
            listaDeFormas.Add(segundoCuadrado);
            listaDeFormas.Add(tercerCuadrado);
            listaDeFormas.Add(cuartoCuadrado);

            //Act
            var resumen = ImpresoraApp.Imprimir(listaDeFormas, (int)Idioma.Ingles);

            //Assert
            Assert.AreEqual("<h1>Shapes report</h1>4 Shares | Area 231 | Perimeter 76 <br/>TOTAL :<br/>4 Shapes Perimeter 76 Area 231", resumen);
        }

        [TestCase]
        public void TestImpresoraConMasTiposEnPortugues()
        {
            //Arrange
            Cuadrado cuadrado = new Cuadrado(17);
            Circulo circulo = new Circulo(5);
            Rectangulo rectangulo = new Rectangulo(1, 1);
            Triangulo triangulo = new Triangulo(12);
            Trapecio trapecio = new Trapecio(1, 2, 5, 2);

            List<FormaGeometrica> listaDeFormas = new List<FormaGeometrica>();
            listaDeFormas.Add(cuadrado);
            listaDeFormas.Add(circulo);
            listaDeFormas.Add(rectangulo);
            listaDeFormas.Add(triangulo);
            listaDeFormas.Add(trapecio);

            var resumen = ImpresoraApp.Imprimir(listaDeFormas, (int)Idioma.Portugues);

            Assert.AreEqual("<h1>Relatório de Formulários</h1>1 Quadrado | Área 289 | Perímetro 68 <br/>1 Círculo | Área 78,54 | Perímetro 31,42 <br/>1 Retângulo | Área 1 | Perímetro 4 <br/>1 Triângulo | Área 62,35 | Perímetro 36 <br/>1 Trapézio | Área 5 | Perímetro 7 <br/>TOTAL :<br/>5 Formas Perímetro 146,42 Área 435,89", resumen);
        }
    }
}
