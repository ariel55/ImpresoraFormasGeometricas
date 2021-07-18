using System.IO;
using System.Linq;

namespace CodingChallenge.Data.Utilities
{
    public static class Util
    {
        private const string FILENAME_TRADUCCIONES = "traducciones.json";

        public static string getRutaFisicaDeTraducciones()
        {
            return Util.TryGetSolutionDirectoryInfo().FullName + "/Resource/" + FILENAME_TRADUCCIONES;
        }

        public static bool existeRutaFisicaDeTraducciones()
        {
            return File.Exists ( getRutaFisicaDeTraducciones() );
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
