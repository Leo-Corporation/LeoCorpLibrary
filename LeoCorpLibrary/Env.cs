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
        public static int GetFilesCount(string directory)
        {
            return Directory.GetFiles(directory, "*", SearchOption.TopDirectoryOnly).Length;
        }
    }
}
