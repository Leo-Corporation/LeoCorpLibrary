using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary.Core
{
    /// <summary>
    /// Class that contains methods to help you implement an update system to your product.
    /// </summary>
    public static class Update
    {
        /// <summary>
        /// Allows you to verify if updates are available.
        /// </summary>
        /// <param name="version">Current software version.</param>
        /// <param name="lastVersion">Latest software version.</param>
        /// <returns>A <see cref="bool"/> value.</returns>
        public static bool IsAvailable(string version, string lastVersion)
        {
            bool res;
            if (version == lastVersion) // Si la version du logiciel = a la dernière version, alors le logiciel est à jour
            {
                res = false; // False : Aucune MAJs Disonibles
            }
            else
            {
                res = true; // True : MAJs Disponibles
            }
            return res; // Retourne la valeur finale
        }

        /// <summary>
        /// Allows you to get the latest version of the software from a .txt file.
        /// </summary>
        /// <param name="lastVersionFileLink">Link of the file where the lastest version is stocked.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <returns>A <see cref="string"/> value.</returns>
        public static string GetLastVersion(string lastVersionFileLink)
        {
            string lastVersion = "";
            if (!string.IsNullOrWhiteSpace(lastVersionFileLink)) // Vérification que la valeur n'est pas 'null' ou remplie d'espaces blancs.
            {
                try
                {
                    WebClient webClient = new WebClient(); // Création d'un nouveau WebClient
                    lastVersion = webClient.DownloadString(lastVersionFileLink); // Télécharge le texte de la page spécifiée et l'assigne à 'lastVersion'.
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message); // Affiche l'erreur qui s'est produite
                }
            }
            else
            {
                throw new ArgumentNullException("The parameter 'lastVersionFileLink' (string) is empty or contain only white spaces.");
            }
            return lastVersion;
        }

        /// <summary>
        /// Allows you to get the lastest version of the software from a .txt file asynchronously.
        /// </summary>
        /// <param name="lastVersionFileLink">Link of the file where the lastest version is stocked.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>A <see cref="Task{TResult}"/> value.</returns>
        public static Task<string> GetLastVersionAsync(string lastVersionFileLink)
        {
            Task<string> task = new Task<string>(() => GetLastVersion(lastVersionFileLink));
            task.Start();
            return task;
        }
    }
}
