using NUnit.Framework;
using CodingChallenge.Data.Traduccion;

namespace CodingChallenge.Data.Test
{
    [TestFixture, Order(0)]
    public class TraductorTest
    {
        [Test]
        public void TestCargadeTraduccionesConIdiomaInvalido()
        {
            var traduccciones = Traductor.Instance.cargarTraducciones(-1);

            Assert.AreEqual(true, traduccciones.hasError);
        }

        [Test]
        public void TestCargaTraduccionesIdiomaInlgles()
        {
            var traduccciones = Traductor.Instance.cargarTraducciones((int)Idioma.Ingles);

            Assert.AreEqual(false, traduccciones.hasError);
            Assert.AreNotEqual(null, traduccciones.Data);
            Assert.IsNotEmpty(traduccciones.Data);
        }

        [Test]
        public void TestCargaTraduccionesIdiomaCastellano()
        {
            var traduccciones = Traductor.Instance.cargarTraducciones((int)Idioma.Castellano);

            Assert.AreEqual(false, traduccciones.hasError);
            Assert.AreNotEqual(null, traduccciones.Data);
            Assert.IsNotEmpty(traduccciones.Data);
        }

        [Test]
        public void TestTraducirIdiomaIngles()
        {
            Traductor.Instance.cargarTraducciones((int)Idioma.Ingles);

            Assert.AreEqual("Perimeter", Traductor.Instance.Get("Perimetro"));
            Assert.AreEqual("Shapes report", Traductor.Instance.Get("Reporte de Formas"));

        }
    }
}
