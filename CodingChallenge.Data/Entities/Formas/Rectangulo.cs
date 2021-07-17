
namespace CodingChallenge.Data.Entities
{
    public class Rectangulo : FormaGeometrica
    {
        private decimal ladoMayor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lado">lado menor</param>
        /// <param name="ladoMayor">lado mayor</param>
        public Rectangulo(decimal lado, decimal ladoMayor)
        {
            this.lado = lado;
            this.ladoMayor = ladoMayor;
        }

        /// <summary>
        /// Calcula el área del rectángulo
        /// </summary>
        /// <returns></returns>
        public override decimal GetArea()
        {
            return this.lado * this.ladoMayor;
        }

        /// <summary>
        /// Calcula el perímetro del rectángulo
        /// </summary>
        /// <returns></returns>
        public override decimal GetPerimetro()
        {
            return 2 * (this.lado + this.ladoMayor);
        }
    }
}
