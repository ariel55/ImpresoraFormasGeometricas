using NUnit.Framework;
using CodingChallenge.Data.Traduccion;
using CodingChallenge.Data.Utilities;

namespace CodingChallenge.Data.Test
{
    [TestFixture, Order(0)]
    public class TraductorTest
    {
        [TestCase, Order(0)]
        public void TestRecursoDeTraduccionesExiste()
        {
            Assert.AreEqual(true, Util.existeRutaFisicaDeTraducciones() );
        }

        [TestCase]
        public void TestCargaTraduccionesConIdiomaInvalido()
        {
            var traduccciones = Traductor.Instance.cargarTraducciones((int)Idioma.Indefnido);

            Assert.AreEqual(true, traduccciones.hasError);
        }

        [TestCase]
        public void TestCargaTraduccionesIdiomaInlgles()
        {
            var traduccciones = Traductor.Instance.cargarTraducciones((int)Idioma.Ingles);

            Assert.AreEqual(false, traduccciones.hasError);
            Assert.AreNotEqual(null, traduccciones.Data);
            Assert.IsNotEmpty(traduccciones.Data);
        }

        [TestCase]
        public void TestCargaTraduccionesIdiomaCastellano()
        {
            var traduccciones = Traductor.Instance.cargarTraducciones((int)Idioma.Castellano);

            Assert.AreEqual(false, traduccciones.hasError);
            Assert.AreNotEqual(null, traduccciones.Data);
            Assert.IsNotEmpty(traduccciones.Data);
        }

        [TestCase]
        public void TestTraducirIdiomaIngles()
        {
            Traductor.Instance.cargarTraducciones((int)Idioma.Ingles);

            Assert.AreEqual("Perimeter", Traductor.Instance.Get("Perimetro"));
            Assert.AreEqual("Shapes report", Traductor.Instance.Get("Reporte de Formas"));
        }

        [TestCase]
        public void TestTraducirIdiomaPortugues()
        {
            Traductor.Instance.cargarTraducciones((int)Idioma.Portugues);

            Assert.AreEqual("Relatório de Formulários", Traductor.Instance.Get("Reporte de Formas"));
            Assert.AreEqual("Lista vazia de formas!", Traductor.Instance.Get("Lista vacía de formas!"));
        }
    }
}
