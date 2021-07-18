using CodingChallenge.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge.Data.Reporter
{
    public class GeneradorDataReporteFormaGeometrica
    {
        public static DataReporteFormaGeometrica generarData(List<FormaGeometrica> formas)
        {
            if ( formas == null || !formas.Any())
            {
                return new DataReporteFormaGeometrica();
            }

            Dictionary<string, DataFilaReporteFormaGeometrica> data = new Dictionary<string, DataFilaReporteFormaGeometrica>();

            var dataTotalizada = new DataFilaReporteFormaGeometrica
            {
                nombre = "Forma",
                cantidad = 0,
                areaTotal = 0.0m,
                perimetroTotal = 0.0m,
                orden = 9999,
            };

            int orden = 1;
            foreach (FormaGeometrica forma in formas)
            {
                string nombre = forma.GetType().Name;
                decimal area = forma.GetArea();
                decimal perimetro = forma.GetPerimetro();

                if (data.ContainsKey(nombre))
                {
                    data[nombre].nombre = nombre;
                    data[nombre].cantidad += 1;
                    data[nombre].areaTotal += area;
                    data[nombre].perimetroTotal += perimetro;
                }
                else
                {
                    data.Add(nombre, new DataFilaReporteFormaGeometrica
                    {
                        nombre = nombre,
                        cantidad = 1,
                        areaTotal = area,
                        perimetroTotal = perimetro,
                        orden = orden++
                    });
                }

                // Totalizar
                dataTotalizada.cantidad += 1;
                dataTotalizada.areaTotal += area;
                dataTotalizada.perimetroTotal += perimetro;
            }

            // lo paso a una list porque son pocas las formas geometricas disponibles

            return new DataReporteFormaGeometrica
            {
                Data = data.Values.ToList().OrderBy(r => r.orden).ToList(),
                DataTotalizada = dataTotalizada
            };

        }
    }
}
