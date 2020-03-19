using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeoCorpLibrary
{
    public class Update
    {
        public bool IsAvailable(string version, string lastVersion)
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
        public string GetLastVersion(string lastVersionFileLink)
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
                throw new Exception("The parameter 'lastVersionFileLink' (string) is empty or contain only white spaces.");
            }
            return lastVersion;
        }
        public void Check(string version, string lastVersion, Form availableUpdateForm, Form noUpdateForm)
        {
            if (version == lastVersion)
            {
                noUpdateForm.Show();
            }
            else
            {
                availableUpdateForm.Show();
            }
        }
    }
}
