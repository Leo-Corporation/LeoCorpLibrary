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
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeoCorpLibrary
{
    /// <summary>
    /// Classe regroupant des méthodes pour metttre à jour votre logiciel.
    /// </summary>
    public static class Update
    {
        /// <summary>
        /// Permet de vérifier si des mises à jour sont disponibles.
        /// </summary>
        /// <param name="version">Version actuelle du logiciel.</param>
        /// <param name="lastVersion">Dernière version du logiciel.</param>
        /// <returns>Valeur de type <see cref="bool"/>.</returns>
        public static bool IsAvailable(string version, string lastVersion)
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

        /// <summary>
        /// Permet d'obtenir la dernière version d'un logiciel, à partir d'un fichier texte (*.txt).
        /// </summary>
        /// <param name="lastVersionFileLink">Lien du fichier où se situe le numéro de la dernière version.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <returns>Valeur de type <see cref="string"/>.</returns>
        public static string GetLastVersion(string lastVersionFileLink)
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
                throw new ArgumentNullException("The parameter 'lastVersionFileLink' (string) is empty or contain only white spaces.");
            }
            return lastVersion;
        }

        public static Task<string> GetLastVersionAsync(string lastVersionFileLink)
        {
            Task<string> task = new Task<string>(() => GetLastVersion(lastVersionFileLink));
            task.Start();
            return task;
        }

        /// <summary>
        /// Permet de vérifier si des mises à jour sont disponibles pour votre logiciel.
        /// </summary>
        /// <param name="version">Version actuelle du logiciel.</param>
        /// <param name="lastVersion">Dernière version du logiciel.</param>
        /// <param name="availableUpdateForm">Fenêtre qui s'affiche si des mises à jour sont disponibles.</param>
        /// <param name="noUpdateForm">Fenêtre qui s'affiche lorsqu'aucune mises à jour n'est disponibles.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void Check(string version, string lastVersion, Form availableUpdateForm, Form noUpdateForm)
        {
            if (availableUpdateForm != null && noUpdateForm != null)
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
            else // Dans le cas où l'utilisateur ne spécifie pas de valeur pour les forms
            {
                throw new ArgumentNullException("The argument 'availableUpdateForm' and/or 'noUpdateForm' cannot be 'null'");
            }
        }

        /// <summary>
        /// Permet d'installer une mise à jour.
        /// </summary>
        /// <param name="filePath">Emplacement du fichier.</param>
        /// <param name="newVersionLink">Lien du nouveau fichier.</param>
        /// <param name="fromAppStartupPath">(facultatif) Ouvrir le fichier depuis l'emplacement du programme.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        public static void Install(string filePath, string newVersionLink, bool fromAppStartupPath = false)
        {
            if (File.Exists(filePath)) // Si fichier existe
            {
                if (fromAppStartupPath) // Depuis chemin de démarrage
                {
                    filePath = Application.StartupPath + filePath;
                }
                if (string.IsNullOrEmpty(newVersionLink) || string.IsNullOrWhiteSpace(newVersionLink)) // Si vide
                {
                    throw new ArgumentNullException("The parameter 'newVersionLink' cannot be null.");
                }
                try
                {
                    WebClient webClient = new WebClient();
                    File.Delete(filePath); // Supprime l'ancienne version
                    Console.WriteLine(filePath + " deleted!");
                    webClient.DownloadFile(newVersionLink, filePath); // Télécharge la nouvelle version
                    Console.WriteLine("Done!");
                    Process.Start(filePath); // Démarre la nouvelle version
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new FileNotFoundException("The parameter 'filePath' does not lead to a specific file."); // Erreur
            }
        }
    }
}
