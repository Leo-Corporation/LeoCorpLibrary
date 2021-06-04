/*
MIT License

Copyright (c) Léo Corporation

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE. 
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary
{
    /// <summary>
    /// Class that contains methods for the user's environnement.
    /// </summary>
    public static class Env
    {
        /// <summary>
        /// Allows you to get the number of files in a directory without including subdirectories.
        /// </summary>
        /// <param name="directory">Path of the directory</param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <returns>A <see cref="int"/> value.</returns>
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
        /// Allows you to get the number of files in a directory offering the possibility to include subdirectories.
        /// </summary>
        /// <param name="directory">Path of the directory.</param>
        /// <param name="includeSubDirectories">Include or not subdirectories.</param>
        /// <exception cref="FileNotFoundException"></exception>
        /// <returns>A <see cref="int"/> value.</returns>
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
        /// Allows you to get number of directories in a directory without including subdirectories.
        /// </summary>
        /// <param name="directory">Path of the directory.</param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <returns>A <see cref="int"/> value.</returns>
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
        /// Allows you to get the number of directories in a directory offering the possibility to include subdirectories.
        /// </summary>
        /// <param name="directory">Path of the directory.</param>
        /// <param name="includeSubDirectories">Include or not subdirectories.</param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <returns>A <see cref="int"/> value.</returns>
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
        /// Allows you to get the available space on a specified drive.
        /// </summary>
        /// <param name="drive">Drive.</param>
        /// <param name="unitType">The unit of the value returned (MB, GB...).</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="DriveNotFoundException"></exception>
        /// <returns>A <see cref="double"/> value.</returns>
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
        /// Allows you to get the total space of a drive.
        /// </summary>
        /// <param name="drive">Drive.</param>
        /// <param name="unitType">The unit of the value returned (MB, GB...).</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="DriveNotFoundException"></exception>
        /// <returns>A <see cref="double"/> value.</returns>
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
        /// Allows you to get the occupied space of a drive.
        /// </summary>
        /// <param name="drive">Drive.</param>
        /// <param name="unitType">The unit of the value returned (MB, GB...).</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="DriveNotFoundException"></exception>
        /// <returns>A <see cref="double"/> value.</returns>
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
        /// Allows you to get the Windows version of the user.
        /// </summary>
        /// <remarks>You can now use the <see cref="WindowsVersion"/> property instead of this method.</remarks>
        /// <returns>A <see cref="WindowsVersion"/> value.</returns>
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

        /// <summary>
        /// Allows you to get the Windows version of the user.
        /// </summary>
        public static WindowsVersion WindowsVersion { get => GetWindowsVersion(); }

        /// <summary>
        /// Allows you to launch a program in administrator mode.
        /// </summary>
        /// <param name="process">Process to launch as admin.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        /// <remarks>The 'process' parameter must have a valid path to the programm to launch in admin mode in <see cref="Process.StartInfo"/>.</remarks>
        public static void ExecuteAsAdmin(Process process)
        {
            if (string.IsNullOrEmpty(process.StartInfo.FileName)) // Si l'argument est vide
            {
                throw new ArgumentNullException("The parameter 'process' has a 'FileName' that is null or empty."); // Message d'erreur
            }

            if (!File.Exists(process.StartInfo.FileName)) // Si le ficher n'existe pas
            {
                throw new FileNotFoundException("The parameter 'process' has a 'FileName' that does not lead to an existing file."); // Message d'erreur
            }

            process.StartInfo.UseShellExecute = true; 
            process.StartInfo.Verb = "runas"; // Mettre en mode administrateur
            process.Start(); // Démarrer
        }

        /// <summary>
        /// Allows you to launch a program in administrator mode.
        /// </summary>
        /// <param name="filename">Path to the program to launch in admin mode.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        public static void ExecuteAsAdmin(string filename)
        {
            if (string.IsNullOrEmpty(filename)) // Si l'argument est vide
            {
                throw new ArgumentNullException("The parameter 'filename' is null or empty."); // Message d'erreur
            }

            if (!File.Exists(filename)) // Si le fichier n'existe pas
            {
                throw new FileNotFoundException("The parameter 'filename' does not lead to an existing file."); // Message d'erreur
            }
            Process process = new Process(); // Nouveau processus
            process.StartInfo.FileName = filename; // Mettre le fichier à ouvrir
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.Verb = "runas"; // Mettre le mode administrateur
            process.Start(); // Démarrer
        }

        /// <summary>
        /// Allows you to count the number of characters in a specified file.
        /// </summary>
        /// <param name="fileName">Location of the file.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        /// <returns>A <see cref="Task{TResult}"/> value.</returns>
        public static int CountFileCharacters(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) // Si l'argument est vide ou null
            {
                throw new ArgumentNullException("The parameter 'fileName' is null or empty."); // Erreur
            }

            if (!File.Exists(fileName)) // Si le fichier n'existe pas
            {
                throw new FileNotFoundException("The parameter 'fileName' does not lead to a specific file name."); // Erreur
            }

            return File.ReadAllText(fileName).Length; // Compter
        }

        /// <summary>
        /// Allows you to count the number of characters in specified file asynchronously.
        /// </summary>
        /// <param name="fileName">Location of the file.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        /// <returns>A <see cref="Task{TResult}"/> value.</returns>
        public static Task<int> CountFileCharactersAsync(string fileName)
        {
            Task<int> task = new Task<int>(() => CountFileCharacters(fileName)); // Tâche
            task.Start(); // Démarrage de la tâche
            return task; // Retourne le résultat de manière aynchrone
        }

        /// <summary>
        /// Allows you to get the current UnixTime.
        /// </summary>
        /// <remarks>You can now use the <see cref="UnixTime"/> property instead of this method.</remarks>
        /// <returns>A <see cref="int"/> value.</returns>
        public static int GetUnixTime()
        {
            return (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds; // Calculer Unix Time
        }

        /// <summary>
        /// Allows you to get the UnixTime from a specific <see cref="DateTime"/>.
        /// </summary>
        /// <param name="date">Date.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>A <see cref="int"/> value.</returns>
        public static int GetUnixTime(DateTime date)
        {
            if (date == null) // Si l'argument est null
            {
                throw new ArgumentNullException(""); // Erreur
            }
            return (int)date.Subtract(new DateTime(1970, 1, 1)).TotalSeconds; // Calculer Unix Time
        }

        /// <summary>
        /// Allows you to get the current UnixTime.
        /// </summary>
        public static int UnixTime { get => GetUnixTime(); }

        /// <summary>
        /// Allows you to get the <c>%APPDATA%</c> path.
        /// </summary>
        /// <remarks>You can now use the <see cref="AppDataPath"/> property instead of this method.</remarks>
        /// <returns>A <see cref="string"/> value.</returns>
        public static string GetAppDataPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); // Return the path
        }

        /// <summary>
        /// Allows you to get the <c>%APPDATA%</c> path.
        /// </summary>
        public static string AppDataPath { get => GetAppDataPath(); }

        /// <summary>
        /// Allows you to get the current Operating system.
        /// </summary>
        public static OperatingSystems CurrentOperatingSystem
        {
            get
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) // If the OS is Windows
                {
                    return OperatingSystems.Windows; // Return Windows
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) // If the OS is macOS
                {
                    return OperatingSystems.macOS; // Return macOS
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    return OperatingSystems.Linux; // Return Linux
                }
                else
                {
                    return OperatingSystems.Unknown; // Return unknown
                }
            }
        }

        /// <summary>
        /// Gets the curent mouse cursor position on screen for <see cref="System.Windows.Forms"/>.
        /// </summary>
        /// <returns>A <see cref="System.Drawing.Point"/> value.</returns>
        public static System.Drawing.Point GetMouseCursorPosition() => System.Windows.Forms.Cursor.Position;

        /// <summary>
        /// Gets the curent mouse cursor position on screen for WPF.
        /// </summary>
        /// <returns>A <see cref="System.Windows.Point"/> value.</returns>
        public static System.Windows.Point GetMouseCursorPositionWPF() => new System.Windows.Point(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y);

        /// <summary>
        /// Allows you to get the system drive (<see cref="DriveInfo"/>).
        /// </summary>
        /// <remarks>Works only on Windows.</remarks>
        public static DriveInfo SystemDrive { get => (CurrentOperatingSystem == OperatingSystems.Windows) ? new DriveInfo(Environment.SystemDirectory) : DriveInfo.GetDrives()[0]; }

        /// <summary>
        /// Converts Unix Time to a <see cref="DateTime"/>.
        /// </summary>
        /// <param name="unixTime">The Unix Time.</param>
        /// <returns>A <see cref="DateTime"/> value.</returns>
        public static DateTime UnixTimeToDateTime(int unixTime)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc); // Create a date
            dtDateTime = dtDateTime.AddSeconds(unixTime).ToLocalTime(); // Add the seconds
            return dtDateTime; // Return the result
        }

        /// <summary>
        /// Gets if a specified process name is currently running.
        /// </summary>
        /// <param name="processName">The process name to find.</param>
        /// <returns>A <see cref="bool"/> value.</returns>
        public static bool IsProcessRunning(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName); // Get the process(es) that match the name

            if (processes.Length == 0) // If the process is not running
            {
                return false; // Return false
            }
            else // If the process is running
            {
                return true; // Return true
            }
        }

        /// <summary>
        /// Checks if your program has the permission to write a specific directory.
        /// </summary>
        /// <param name="filePath">The path to the directory.</param>
        /// <returns>A <see cref="bool"/> value.</returns>
        public static bool IsDirectoryHasPermission(string filePath)
		{
            if (!Directory.Exists(filePath))
			{
                throw new DirectoryNotFoundException("The directory does not exist or is invalid.");
			}

            try
			{
                Directory.CreateDirectory($@"{filePath}\LeoCorpLibraryTest");
                Directory.Delete($@"{filePath}\LeoCorpLibraryTest");
			}
            catch
			{
                return false;
			}

            return true;
		}
    }

    /// <summary>
    /// Operating systems.
    /// </summary>
    public enum OperatingSystems
    {
        /// <summary>
        /// The Windows Operating system.
        /// </summary>
        Windows,

        /// <summary>
        /// The macOS Operating system.
        /// </summary>
        macOS,

        /// <summary>
        /// The Linux Operating system.
        /// </summary>
        Linux,

        /// <summary>
        /// An unknown Operating system.
        /// </summary>
        Unknown
    }

    /// <summary>
    /// Size of files/directories.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// Byte Unit.
        /// </summary>
        Byte,
        /// <summary>
        /// Kilobyte Unit.
        /// </summary>
        Kilobyte,
        /// <summary>
        /// Megabyte Unit.
        /// </summary>
        Megabyte,
        /// <summary>
        /// Gigabyte Unit.
        /// </summary>
        Gigabyte,
        /// <summary>
        /// Terabyte Unit.
        /// </summary>
        Terabyte,
        /// <summary>
        /// Petabyte Unit.
        /// </summary>
        Petabyte
    }

    /// <summary>
    /// Windows Operating Systems.
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
        /// Unknown operating system.
        /// </summary>
        Unknown
    }
}
