using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary
{
    public class Password
    {
        public string Generate(int lenght, string chars, string separator)
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
