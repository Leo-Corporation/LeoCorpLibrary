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
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <returns>Valeur de type <see cref="int"/>.</returns>
        public static int GetFilesCount(string directory)
        {
            int result;
            if (Directory.Exists(directory))
            {
                result = Directory.GetFiles(directory, "*", SearchOption.TopDirectoryOnly).Length;
            }
            else
            {
                throw new DirectoryNotFoundException("The specified directory does not exist.");
            }
            return result;
        }

        /// <summary>
        /// Obtient le nombre de fichiers dans un répertoire en offrant la possibilité d'inclure les sous-répertoires.
        /// </summary>
        /// <param name="directory">Chemin du répertoire.</param>
        /// <param name="includeSubDirectories">Inclure ou non les sous-répertoires.</param>
        /// <exception cref="FileNotFoundException"></exception>
        /// <returns>Valeur de type <see cref="int"/>.</returns>
        public static int GetFilesCount(string directory, bool includeSubDirectories)
        {
            int result;
            if (Directory.Exists(directory))
            {
                if (includeSubDirectories)
                {
                    result = Directory.GetFiles(directory, "*", SearchOption.AllDirectories).Length;
                }
                else
                {
                    result = Directory.GetFiles(directory, "*", SearchOption.TopDirectoryOnly).Length;
                }
            }
            else
            {
                throw new DirectoryNotFoundException("The specified directory does not exist.");
            }
            return result;
        }

        /// <summary>
        /// Obtient le nombre de répertoires dans un répertoire sans inclure les sous-répertoires.
        /// </summary>
        /// <param name="directory">Chemin du répertoire.</param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <returns>Valeur de type <see cref="int"/>.</returns>
        public static int GetDirectoriesCount(string directory)
        {
            int result;
            if (Directory.Exists(directory))
            {
                result = Directory.GetDirectories(directory, "*", SearchOption.TopDirectoryOnly).Length;
            }
            else
            {
                throw new DirectoryNotFoundException("The specified directory does not exist.");
            }
            return result;
        }

        /// <summary>
        /// Obtient le nombre de répertoires dans un répertoire en offrant la possibilité d'inclure les sous-répertoires.
        /// </summary>
        /// <param name="directory">Chemin du répertoire.</param>
        /// <param name="includeSubDirectories">Inclure ou non les sous-répertoires.</param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <returns>Valeur de type <see cref="int"/>.</returns>
        public static int GetDirectoryCount(string directory, bool includeSubDirectories)
        {
            int result;
            if (Directory.Exists(directory))
            {
                if (includeSubDirectories)
                {
                    result = Directory.GetDirectories(directory, "*", SearchOption.AllDirectories).Length;
                }
                else
                {
                    result = Directory.GetDirectories(directory, "*", SearchOption.TopDirectoryOnly).Length;
                }
            }
            else
            {
                throw new DirectoryNotFoundException("The specified directory does not exist.");
            }
            return result;
        }
    }
}
