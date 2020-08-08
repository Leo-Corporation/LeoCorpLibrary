using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
            int result; // Résulat final
            if (Directory.Exists(directory)) // Si le répertoire existe
            {
                result = Directory.GetFiles(directory, "*", SearchOption.TopDirectoryOnly).Length; // Obtenir le nombre de fichiers
            }
            else
            {
                throw new DirectoryNotFoundException("The specified directory does not exist."); // Retourner une erreur
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
            int result; // Résulat final
            if (Directory.Exists(directory)) // Si le répertoire existe
            {
                if (includeSubDirectories) // Si les sous répertoires sont inclus
                {
                    result = Directory.GetFiles(directory, "*", SearchOption.AllDirectories).Length; // Obtenir le nombre de fichiers
                }
                else
                {
                    result = Directory.GetFiles(directory, "*", SearchOption.TopDirectoryOnly).Length; // Obtenir le nombre de fichiers
                }
            }
            else
            {
                throw new DirectoryNotFoundException("The specified directory does not exist."); // Retourner une erreur
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
            int result; // Résulat final
            if (Directory.Exists(directory)) // Si le répertoire existe
            {
                result = Directory.GetDirectories(directory, "*", SearchOption.TopDirectoryOnly).Length; // Obtenir le nombre de répertoires
            }
            else
            {
                throw new DirectoryNotFoundException("The specified directory does not exist."); // Retourner une erreur
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
            int result; // Résulat final
            if (Directory.Exists(directory)) // Si le répertoire existe
            {
                if (includeSubDirectories) // Si les sous répertoires sont inclus
                {
                    result = Directory.GetDirectories(directory, "*", SearchOption.AllDirectories).Length; // Obtenir le nombre de répertoires
                }
                else
                {
                    result = Directory.GetDirectories(directory, "*", SearchOption.TopDirectoryOnly).Length; // Obtenir le nombre de répertoires
                }
            }
            else
            {
                throw new DirectoryNotFoundException("The specified directory does not exist."); // Retourner une erreur
            }
            return result;
        }

        /// <summary>
        /// Permet d'obtenir l'espace du lecteur disponible.
        /// </summary>
        /// <param name="drive">Lecteur.</param>
        /// <param name="unitType">Type de valeur retournée (MB, GB...)</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="DriveNotFoundException"></exception>
        /// <returns>Valeur de type <see cref="double"/>.</returns>
        public static double GetDriveAvailableFreeSpace(string drive, UnitType unitType)
        {
            double res = 0; // Résulat final

            if (string.IsNullOrEmpty(drive))
            {
                throw new ArgumentNullException("The parameter 'drive' is empty."); // Retourner une erreur
            }
            
            if (!Directory.Exists(drive))
            {
                throw new DriveNotFoundException("The specified drive does not exist."); // Retourner une erreur
            }

            double size = new DriveInfo(drive).AvailableFreeSpace;

            switch (unitType)
            {
                case UnitType.Byte: // Si l'unité sélectionnée est le Byte
                    res = size; // Retourner la conversion de Byte en Byte
                    break;
                case UnitType.Kilobyte: // Si l'unité sélectionnée est le Kilobyte
                    res = size / 1000; // Retourner la conversion de Byte en kilobyte
                    break;
                case UnitType.Megabyte: // Si l'unité sélectionnée est le Megabyte
                    res = size / 1000000; // Retourner la conversion de Byte en Megabyte
                    break;
                case UnitType.Gigabyte: // Si l'unité sélectionnée est le Gigabyte
                    res = size / 1000000000; // Retourner la conversion de Byte en Gigabyte
                    break;
                case UnitType.Terabyte: // Si l'unité sélectionnée est le Terabyte
                    res = size / 1000000000000; // Retourner la conversion de Byte en Terabyte
                    break;
                case UnitType.Petabyte: // Si l'unité sélectionnée est le Petabyte
                    res = size / 1000000000000000; // Retourner la conversion de Byte en Petabyte
                    break;
            }
            return res;
        }

        /// <summary>
        /// Permet d'obtenir l'espace libre du lecteur.
        /// </summary>
        /// <param name="drive">Lecteur.</param>
        /// <param name="unitType">Type de valeur retournée (MB, GB...)</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="DriveNotFoundException"></exception>
        /// <returns>Retourne une valeur de type <see cref="double"/>.</returns>
        public static double GetTotalDriveSpace(string drive, UnitType unitType)
        {
            double res = 0; // Résulat final

            if (string.IsNullOrEmpty(drive))
            {
                throw new ArgumentNullException("The parameter 'drive' is empty."); // Retourner une erreur
            }

            if (!Directory.Exists(drive))
            {
                throw new DriveNotFoundException("The specified drive does not exist."); // Retourner une erreur
            }

            double size = new DriveInfo(drive).TotalSize; // Espace total du lecteur

            switch (unitType)
            {
                case UnitType.Byte: // Si l'unité sélectionnée est le Byte
                    res = size;// Retourner la conversion de Byte en Byte
                    break;
                case UnitType.Kilobyte: // Si l'unité sélectionnée est le Kilobyte
                    res = size / 1000; // Retourner la conversion de Byte en Kilobyte
                    break;
                case UnitType.Megabyte: // Si l'unité sélectionnée est le Megabyte
                    res = size / 1000000; // Retourner la conversion de Byte en Megabyte
                    break;
                case UnitType.Gigabyte: // Si l'unité sélectionnée est le Gigabyte
                    res = size / 1000000000; // Retourner la conversion de Byte en Gigabyte
                    break;
                case UnitType.Terabyte: // Si l'unité sélectionnée est le Terabyte
                    res = size / 1000000000000; // Retourner la conversion de Byte en Terabyte
                    break;
                case UnitType.Petabyte: // Si l'unité sélectionnée est le Petabyte
                    res = size / 1000000000000000; // Retourner la conversion de Byte en Petabyte
                    break;
            }

            return res;
        }

        /// <summary>
        /// Permet d'obtenir l'espace occupé du lecteur.
        /// </summary>
        /// <param name="drive">Lecteur.</param>
        /// <param name="unitType">Type de valeur retournée (MB, GB...)</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="DriveNotFoundException"></exception>
        /// <returns>Retourne une valeur de type <see cref="double"/>.</returns>
        public static double GetOccupiedDriveSpace(string drive, UnitType unitType)
        {
            double res;
            if (string.IsNullOrEmpty(drive)) // Si le paramètre est vide
            {
                throw new ArgumentNullException("The parameter 'drive' is empty."); // Retourner une erreur
            }

            if (!Directory.Exists(drive)) // Si le lecteur n'existe pas
            {
                throw new DriveNotFoundException("The specified drive does not exist."); // Retourner une erreur
            }

            res = GetTotalDriveSpace(drive, unitType) - GetDriveAvailableFreeSpace(drive, unitType); // Obtenir l'espace occupé
            return res;
        }

        /// <summary>
        /// Permet d'obtenir la version de Windows.
        /// </summary>
        /// <returns>Retourne une valeur de type <see cref="WindowsVersion"/>.</returns>
        public static WindowsVersion GetWindowsVersion()
        {
            WindowsVersion res = WindowsVersion.Unknown; // Résultat
            switch (Environment.OSVersion.Version.Major)
            {
                case 6: // Si la version majeure est 6
                    switch (Environment.OSVersion.Version.Minor)
                    {
                        case 1: // Si Windows 7 (6.1)
                            res = WindowsVersion.Windows7; // Windows 7
                            break;
                        case 2: // Si Windows 8 (6.2)
                            res = WindowsVersion.Windows8; // Windows 8
                            break;
                        case 3: // Si Windows 8.1 (6.3)
                            res = WindowsVersion.Windows81; // Windows 8.1
                            break;
                    }
                    break;
                case 10: // Si Windows 10
                    res = WindowsVersion.Windows10; // Windows 10
                    break;
            }
            return res;
        }
    }

    /// <summary>
    /// Type de taille de fichiers/répertoires.
    /// </summary>
    public enum UnitType
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

    /// <summary>
    /// Systèmes d'exploitations.
    /// </summary>
    public enum WindowsVersion
    {
        /// <summary>
        /// Windows 7 (Version 6.1).
        /// </summary>
        Windows7,
        /// <summary>
        /// Windows 8 (Version 6.2).
        /// </summary>
        Windows8,
        /// <summary>
        /// Windows 8.1 (Version 6.3).
        /// </summary>
        Windows81,
        /// <summary>
        /// Windows 10 (Version 10.0)
        /// </summary>
        Windows10,
        /// <summary>
        /// Système d'exploitation inconnu.
        /// </summary>
        Unknown
    }
}
