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
        public static int GetDirectoriesCount(string directory, bool includeSubDirectories)
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

        public static double GetDiskAvailableFreeSpace(string drive, SizeType sizeType)
        {
            double res = 0; // Résulat final

            if (string.IsNullOrEmpty(drive))
            {
                throw new ArgumentNullException("The parameter 'disk' is empty."); // Retourner une erreur
            }
            
            if (!Directory.Exists(drive))
            {
                throw new DriveNotFoundException("The specified drive does not exist."); // Retourner une erreur
            }

            double size = new DriveInfo(drive).AvailableFreeSpace;
            switch (sizeType)
            {
                case SizeType.Byte: // Si l'unité sélectionnée est le Byte
                    res = size;
                    break;
                case SizeType.Kilobyte: // Si l'unité sélectionnée est le Kilobyte
                    res = size / 1000;
                    break;
                case SizeType.Megabyte: // Si l'unité sélectionnée est le Megabyte
                    res = size / 1000000;
                    break;
                case SizeType.Gigabyte: // Si l'unité sélectionnée est le Gigabyte
                    res = size / 1000000000;
                    break;
                case SizeType.Terabyte: // Si l'unité sélectionnée est le Terabyte
                    res = size / 1000000000000;
                    break;
                case SizeType.Petabyte: // Si l'unité sélectionnée est le Petabyte
                    res = size / 1000000000000000;
                    break;
            }
            return res;
        }
    }

    /// <summary>
    /// Type de taille de fichiers/répertoires.
    /// </summary>
    public enum SizeType
    {
        /// <summary>
        /// Unité Byte.
        /// </summary>
        Byte,
        /// <summary>
        /// Unité Kilobyte.
        /// </summary>
        Kilobyte,
        /// <summary>
        /// Unité Megabyte.
        /// </summary>
        Megabyte,
        /// <summary>
        /// Unité Gigabyte.
        /// </summary>
        Gigabyte,
        /// <summary>
        /// Unité Terabyte.
        /// </summary>
        Terabyte,
        /// <summary>
        /// Unité Petabyte.
        /// </summary>
        Petabyte
    }
}
