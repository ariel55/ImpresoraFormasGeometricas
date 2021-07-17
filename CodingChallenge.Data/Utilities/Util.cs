using CodingChallenge.Data.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CodingChallenge.Data.Utilities
{
    public static class Util
    {
        public static BooleanResponse<Dictionary<string, string>> leerTraduccionesDesdeJson(string filename, string idioma)
        {
            // TODO cargarlo desde db o json

            Dictionary<string, string> traducciones = new Dictionary<string, string>();

            var myJsonString = File.ReadAllText(filename);
            var myJObject = JObject.Parse(myJsonString);

            var traduccionesResult = JsonConvert.DeserializeObject<Traducciones>(myJObject.ToString());

            var br = new BooleanResponse<Dictionary<string, string>>();

            try
            {
                foreach (Entities.Traduccion unaTraduccion in traduccionesResult.traducciones)
                {
                    Type magicType = typeof(Entities.Traduccion);

                    MethodInfo magicMethod = magicType.GetMethod("get_" + idioma);

                    if (magicMethod == null)
                    {
                        throw new ExceptionIdiomaNoValido(string.Format("Idioma {0} no valido", idioma));
                    }

                    string texto_idioma = magicMethod.Invoke(unaTraduccion, null).ToString();

                    traducciones.Add(unaTraduccion.texto, texto_idioma);
                }

            }
            catch (ExceptionIdiomaNoValido ex1)
            {
                br.hasError = true;
                br.Message = ex1.Message;
            }
            catch (Exception ex)
            {
                br.hasError = true;
                br.Message = ex.Message;
            }
            finally
            {
                br.Data = traducciones;
            }

            return br;
        }

        public static void imprimirDicccionario(Dictionary<string, string> traducciones)
        {
            foreach (KeyValuePair<string, string> entry in traducciones)
            {
                Console.WriteLine(entry.Key + " | " + entry.Value);
            }

        }


        /// <summary>
        /// Getting path to the parent folder of the solution file
        /// </summary>

        public static DirectoryInfo TryGetSolutionDirectoryInfo(string currentPath = null)
        {
            var directory = new DirectoryInfo(
                currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            return directory;
        }

    }
}
