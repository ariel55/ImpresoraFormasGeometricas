using System;

namespace CodingChallenge.Data.Entities
{
    /// <summary>
    /// Triángulo equilátero
    /// </summary>
    public class Triangulo : FormaGeometrica
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lado">lado</param>
        public Triangulo(decimal lado)
        {
            this.lado = lado;
        }

        /// <summary>
        /// Calcula el área del triángulo
        /// </summary>
        /// <returns></returns>
        public override decimal GetArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * this.lado * this.lado;
        }

        /// <summary>
        /// Calcula el perímetro del triángulo
        /// </summary>
        /// <returns></returns>
        public override decimal GetPerimetro()
        {
            return this.lado * 3;
        }
    }
}
