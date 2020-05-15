using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary
{
    /// <summary>
    /// Classe regroupant des méthodes pour vérifier la connexion Internet de l'utilisateur.
    /// </summary>
    public static class NetworkConnection
    {
        /// <summary>
        /// <para>Cette fonction permet de savoir si l'utilisateur a une connexion à Internet.</para>
        /// <para>La connexion est testée sur le site https://bing.com.</para>
        /// </summary>
        /// <returns>Retourne une valeur <c>bool</c>.</returns>
        public static bool IsAvailable() // Fonction pour tester la connexion Internet
        {
            try
            {
                using (var client = new WebClient()) // Navigateur Internet
                using (var stream = client.OpenRead("https://www.bing.com")) // Ouvrir bing.com
                {
                    return true; // Si la page s'ouvre = connexion OK
                }
            }
            catch
            {
                return false; // Si la page ne s'ouvre pas = connexion down
            }
        }

        /// <summary>
        /// <para>Permet de savoir si l'utilisateur a une connexion à Internet.</para>
        /// <para>La connexion est testée sur le site spécifié.</para>
        /// </summary>
        /// <param name="site">Site sur lequel al connexion est testée.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <returns>Retourne une valeur <c>bool</c>.</returns>
        public static bool IsAvailableTestSite(string site)
        {
            bool result = true;
            if (!string.IsNullOrEmpty(site)) // Vérification de la validité de l'URL
            {
                try
                {
                    using (var client = new WebClient()) // Navigateur Internet
                    using (var stream = client.OpenRead(site)) // Ouvrir site
                    {
                        result = true; // Si la page s'ouvre = connexion OK
                    }
                }
                catch
                {
                    result = false; // Si la page ne s'ouvre pas = connexion down
                }
            }
            else
            {
                throw new ArgumentNullException("The content of the parameter 'site' (string) is empty/or is not a valid URL (http://example.com)."); // Erreur
            }
            return result;
        }
    }
}
