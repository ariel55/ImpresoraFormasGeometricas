using System;

namespace CodingChallenge.Data.Entities
{
    public class Circulo : FormaGeometrica
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="radio">radio</param>
        public Circulo(decimal radio)
        {
            this.lado = radio;
        }
        /// <summary>
        /// Calcula el área del círculo
        /// </summary>
        /// <returns></returns>
        public override decimal GetArea()
        {
            return (decimal)Math.PI * (decimal)Math.Pow((double)this.lado, 2);
        }

        /// <summary>
        /// Calcula el perímetro del círculo
        /// </summary>
        /// <returns></returns>
        public override decimal GetPerimetro()
        {
            return 2*(decimal)Math.PI * this.lado;
        }
    }
}
