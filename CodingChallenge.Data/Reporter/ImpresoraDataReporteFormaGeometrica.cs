using CodingChallenge.Data.Entities;
using CodingChallenge.Data.Traduccion;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Reporter
{
    public class ImpresoraDataReporteFormaGeometrica
    {
        public static string imprimir ( DataReporteFormaGeometrica data ) 
        {
            if ( data == null || !data.Data.Any() )
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("<h1>{0}</h1>", Traductor.Instance.Get("Reporte de Formas")));

            data.Data.ForEach( reporteFila => sb.Append(lineaImprimible(reporteFila)) );

            // data totalizada
            sb.Append(string.Format("{0} :<br/>", Traductor.Instance.Get("total").ToUpper()));

            sb.Append(lineaImprimible(data.DataTotalizada, true));

            return sb.ToString();
        }


        private static string lineaImprimible(DataFilaReporteFormaGeometrica filaReporte, bool esDataTotalizada = false)
        {
            return string.Format(esDataTotalizada ? "{0} {1} {4} {5} {2} {3}" : "{0} {1} | {2} {3} | {4} {5} <br/>",
                             filaReporte.cantidad,
                             filaReporte.cantidad > 1 ? Traductor.Instance.Get(filaReporte.nombre) + "s" : Traductor.Instance.Get(filaReporte.nombre),
                             Traductor.Instance.Get("Area"),
                             filaReporte.areaTotal.ToString("#.##"),
                             Traductor.Instance.Get("Perimetro"),
                             filaReporte.perimetroTotal.ToString("#.##")
             );
        }

    }
}
