using System;
using System.Collections.Generic;
using CodingChallenge.Data.Entities;
using CodingChallenge.Data.Reporter;
using CodingChallenge.Data.Traduccion;

namespace ConsoleApp
{
    public class App
    {
        static void Main(string[] args)
        {

            Console.Title = "Formas geometricas";
            try
            {
                Cuadrado cuadrado = new Cuadrado(17);
                Circulo circulo = new Circulo(5);
                Rectangulo rectangulo = new Rectangulo(1, 1);
                Triangulo triangulo = new Triangulo(12);
                Trapecio trapecio = new Trapecio(1, 2, 5, 2);

                List<FormaGeometrica> listaDeFormas = new List<FormaGeometrica>();
                listaDeFormas.Add(cuadrado);
                listaDeFormas.Add(circulo);
                listaDeFormas.Add(rectangulo);
                listaDeFormas.Add(triangulo);
                listaDeFormas.Add(trapecio);

                var resumen = ImpresoraApp.Imprimir(listaDeFormas, (int)Idioma.Portugues);
               

                Console.WriteLine(resumen);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Read();

        }
    }


}
