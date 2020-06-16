using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary
{
    /// <summary>
    /// Classe regroupant des méthodes sur l'environnement de l'utilisateur.
    /// </summary>
    public static class Env
    {
        /// <summary>
        /// Obtient le nombre de fichiers dans un répertoire sans inclure les sous-répertoires.
        /// </summary>
        /// <param name="directory">Chemin du répertoire</param>
        /// <returns>Valeur de type <see cref="int"/>.</returns>
        public static int GetFilesCount(string directory)
        {
            return Directory.GetFiles(directory, "*", SearchOption.TopDirectoryOnly).Length;
        }

        /// <summary>
        /// Obtient le nombre de répertoires dans un répertoire sans inclure les sous-répertoires.
        /// </summary>
        /// <param name="directory">Chemin du répertoire.</param>
        /// <returns>Valeur de type <see cref="int"/>.</returns>
        public static int GetDirectoryCount(string directory)
        {
            return Directory.GetDirectories(directory, "*", SearchOption.TopDirectoryOnly).Length;
        }
    }
}
