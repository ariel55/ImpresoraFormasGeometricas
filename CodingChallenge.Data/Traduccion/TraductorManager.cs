using CodingChallenge.Data.Entities;
using CodingChallenge.Data.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CodingChallenge.Data.Traduccion
{
    public class TraductorManager
    {
        public static BooleanResponse<Dictionary<string, string>> cargarTraduccionesDesdeJson(string filename, string idioma)
        {
            // TODO cargarlo desde db o json

            Dictionary<string, string> traducciones = new Dictionary<string, string>();

            var myJsonString = File.ReadAllText(filename);
            var myJObject = JObject.Parse(myJsonString);

            var traduccionesResult = JsonConvert.DeserializeObject<Traducciones>(myJObject.ToString());

            var br = new BooleanResponse<Dictionary<string, string>>();

            try
            {
                foreach (Entities.Traduccion parClaveTraduccion in traduccionesResult.traducciones)
                {
                    Type magicType = typeof(Entities.Traduccion);

                    MethodInfo magicMethod = magicType.GetMethod("get_" + idioma);

                    if (magicMethod == null)
                    {
                        throw new ExceptionIdiomaNoValido(string.Format("Idioma {0} no valido", idioma));
                    }

                    string traduccion = magicMethod.Invoke(parClaveTraduccion, null).ToString();

                    traducciones.Add(parClaveTraduccion.clave, traduccion);
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
    }
}
