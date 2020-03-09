using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary
{
    class NetworkConnection
    {
        public bool IsAvailable() // Fonction pour tester la connexion Internet
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

        public bool IsAvailableTestSite(string site)
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
                throw new Exception("The content of the parameter 'site' (string) is empty/or is not a valid URL (http://example.com)."); // Erreur
            }
            return result;
        }
    }
}
