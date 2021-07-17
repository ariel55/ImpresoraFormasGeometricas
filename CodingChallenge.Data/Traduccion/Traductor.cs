using CodingChallenge.Data.Traduccion;
using CodingChallenge.Data.Utilities;
using System;
using System.Collections.Generic;

namespace CodingChallenge.Data.Traduccion
{

    public sealed class Traductor
    {
        private Dictionary<string, string> traducciones;
        private Traductor() 
        {
            traducciones = new Dictionary<string, string>();
        }
        private static Traductor instance = null;
        public static Traductor Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Traductor();
                }
                return instance;
            }
        }

        public BooleanResponse<string> cargarTraducciones(int idioma)
        {
            string codIdioma = string.Empty;

            switch (idioma)
            {
                case (int)Idioma.Castellano:
                    codIdioma = "es";
                    break;
                case (int)Idioma.Ingles:
                    codIdioma = "en";
                    break;
                case (int)Idioma.Portugues:
                    codIdioma = "pt";
                    break;

            }

            if (codIdioma.Equals(string.Empty))
            {
                return new BooleanResponse<string>
                {
                    hasError = true,
                    Message = "idioma indefinido",
                    Data = null
                };
            }

            var booleanResponse = Util.leerTraduccionesDesdeJson(Util.TryGetSolutionDirectoryInfo().FullName + "/Resource/traducciones.json", codIdioma);

            if (booleanResponse.hasError)
            {
                Console.WriteLine(booleanResponse.Message);
            }
            else
            {
                if (booleanResponse.Data == null)
                {
                    return new BooleanResponse<string>
                    {
                        hasError = true,
                        Message = "traducciones.json vacia",
                        Data = null
                    };
                }
                else {
                    traducciones = booleanResponse.Data;
                }
            }


            return new BooleanResponse<string>("carga de traducciones");
        }

        public string Get(string clave)
        {
            var traduccion = "";
            if (traducciones.TryGetValue(clave, out traduccion))
            {
                return traduccion;
            }
            else
            {
                return clave;
            }
        }

    }
}
