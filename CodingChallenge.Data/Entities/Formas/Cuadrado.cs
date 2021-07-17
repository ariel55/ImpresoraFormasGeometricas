
namespace CodingChallenge.Data.Entities
{
    public class Cuadrado : FormaGeometrica
    {
        public Cuadrado(decimal lado)
        {
            this.lado = lado;
        }

        /// <summary>
        /// Calcula el área del cuadrado
        /// </summary>
        /// <returns></returns>
        public override decimal GetArea()
        {
            return this.lado * this.lado;
        }

        /// <summary>
        /// Calcula el perímetro del cuadrado
        /// </summary>
        /// <returns></returns>
        public override decimal GetPerimetro()
        {
            return this.lado*4;
        }
    }
}
