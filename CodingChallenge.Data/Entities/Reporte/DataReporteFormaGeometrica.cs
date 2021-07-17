
using System.Collections.Generic;

namespace CodingChallenge.Data.Entities
{
    /// <summary>
    /// Clase que tiene la <c>Data</c> y <c>DataTotalizada</c> del reporte 
    /// </summary>
    public class DataReporteFormaGeometrica
    {
        public List<DataFilaReporteFormaGeometrica>   Data { get; set; }
        public DataFilaReporteFormaGeometrica         DataTotalizada { get; set; }

        public DataReporteFormaGeometrica()
        {
            Data = new List<DataFilaReporteFormaGeometrica>();
            DataTotalizada = new DataFilaReporteFormaGeometrica();
        }
    }
}
