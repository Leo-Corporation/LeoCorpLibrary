using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary
{
    /// <summary>
    /// Classe regroupant des méthodes pour générer un mot de passe.
    /// </summary>
    public static class Password
    {
        /// <summary>
        /// Permet générer un mot de passe.
        /// </summary>
        /// <param name="lenght">Longueur du mot de passe.</param>
        /// <param name="chars">Caractères utilisés pour générer un mot de passe.</param>
        /// <param name="separator">Séparateur.</param>
        /// <exception cref="System.Exception"></exception>
        /// <returns>Valeur de type <see cref="string"/>.</returns>
        public static string Generate(int lenght, string chars, string separator)
        {
            string[] usableChars = { };
            if (chars.Contains(separator)) // Si les caractères contiennent le séparateur
            {
                usableChars = chars.Split(new string[] { separator }, StringSplitOptions.None); // Séparer les valeurs dans un tableau
            }
            else
            {
                throw new Exception("The parameter 'chars' (string) does not contain the specified seperator.");
            }
            string finalPassword = ""; // Mot de passe final
            Random random = new Random(); // Nombre aléatoire
            int number = 0;
            if (lenght > 0)
            {
                for (int i = 1; i < lenght; i++) // Génération du mot de passe
                {
                    number = random.Next(0, usableChars.Length); // Génération d'un nombre aléatoire
                    finalPassword = finalPassword + usableChars[number];
                }
            }
            else
            {
                throw new Exception("The parameter 'lenght' (int) must be higher than 0.");
            }
            return finalPassword; // Retourne le mot de passe final
        }
    }
}
