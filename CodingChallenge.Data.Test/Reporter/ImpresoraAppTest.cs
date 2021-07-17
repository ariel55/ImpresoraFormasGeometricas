using CodingChallenge.Data.Entities;
using CodingChallenge.Data.Reporter;
using CodingChallenge.Data.Traduccion;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodingChallenge.Data.Test
{
    [TestFixture, Order(4)]
    public class ImpresoraAppTest
    {
        [TestCase]
        public void TestResumenListaVaciaIngles()
        {
            //Assert
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                ImpresoraApp.Imprimir(new List<FormaGeometrica>(), (int)Idioma.Ingles));
        }

        [TestCase]
        public void TestResumenListaVaciaEspaniol()
        {
            //Assert
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                ImpresoraApp.Imprimir(new List<FormaGeometrica>(), (int)Idioma.Castellano));
        }

        [TestCase]
        public void TestResumenListaVaciaPortugues()
        {
            //Assert
            Assert.AreEqual("<h1>Lista vazia de formas!</h1>",
                ImpresoraApp.Imprimir(new List<FormaGeometrica>(), (int)Idioma.Portugues));
        }
    }
}
