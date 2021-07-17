using CodingChallenge.Data.Entities;
using CodingChallenge.Data.Traduccion;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge.Data.Reporter
{
    public class ImpresoraApp
    {
        /// <summary>
        /// Genera un reporte de formas en el idioma especificado
        /// </summary>
        /// <param name="formas">Lista de formas</param>
        /// <param name="idioma">Idioma</param>
        /// <returns></returns>
        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            try
            {
                Traductor.Instance.cargarTraducciones(idioma);

                if (!formas.Any())
                {
                    return string.Format("<h1>{0}</h1>", Traductor.Instance.Get("Lista vacía de formas!"));
                }

                var dataReporte = GeneradorDataReporteFormaGeometrica.generarData(formas);

                return ImpresoraDataReporteFormaGeometrica.imprimir(dataReporte);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
