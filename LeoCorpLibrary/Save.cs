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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeoCorpLibrary
{
    /// <summary>
    /// Classe regroupant des méthodes sur la sauvegarde de contrôles dans des fichiers.
    /// </summary>
    public static class Save
    {
        /// <summary>
        /// Permet de sauvegarder le contenu d'une <see cref="ListView"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        /// <param name="listView"><see cref="ListView"/>.</param>
        /// <param name="filePath">Emplacement où enregistrer le contenu d'une <see cref="ListView"/>.</param>
        public static void ListViewContent(ListView listView, string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) // Si l'argument 'filePath' est vide ou null
            {
                throw new ArgumentNullException("The parameter 'filePath' can not be empty or null."); // Message d'erreur
            }
            string itemSplit = "(*E*)"; // Séparer entre les éléments => item1(*E*)item2
            string columnSplit = "(*C*)"; // Séparer entre les valeurs => item1(*E*)item2(*C*)item1(*E*)item2
            StringBuilder stringBuilder = new StringBuilder(); // Outil pour construire du string

            foreach (ListViewItem listViewItem in listView.Items) // Pour chaque élément dans la listview
            {
                for (int i = 0; i <= listView.Columns.Count - 1; i++) // Pour chaque colone dans un élément
                {
                    stringBuilder.Append(listViewItem.SubItems[i].Text); // Ajouter la valeur de la colonne
                    if (i < listView.Columns.Count - 1)
                        stringBuilder.Append(columnSplit); // Ajouter le séparateur (*C*)
                }
                stringBuilder.Append(itemSplit); // Ajouter le séparateur (*E*)
            }

            try
            {
                File.WriteAllText(filePath, stringBuilder.ToString()); // Ecrire les données dans un fichier
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured: " + ex.Message); // Afficher un message d'erreur
            }
        }

        /// <summary>
        /// Permet de sauvegarder le contenu d'une <see cref="ListView"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        /// <param name="listView"><see cref="ListView"/>.</param>
        /// <param name="filePath">Emplacement où enregistrer le contenu d'une <see cref="ListView"/>.</param>
        /// <param name="itemSplit">Séparateur d'éléments (ex: /*E*/).</param>
        /// <param name="columnSplit">Séparateur de colonnes (ex: /*C*/).</param>
        public static void ListViewContent(ListView listView, string filePath, string itemSplit, string columnSplit)
        {
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(itemSplit) || string.IsNullOrEmpty(columnSplit)) // Vérifier les paramètres
            {
                throw new ArgumentNullException("One of the specified parameters is null or empty."); // Afficher message d'erreur
            }

            StringBuilder stringBuilder = new StringBuilder(); // Outil pour construire du string

            foreach (ListViewItem listViewItem in listView.Items) // Pour chaque élément dans la listview
            {
                for (int i = 0; i <= listView.Columns.Count - 1; i++) // Pour chaque colone dans un élément
                {
                    stringBuilder.Append(listViewItem.SubItems[i].Text); // Ajouter la valeur de la colonne
                    if (i < listView.Columns.Count - 1)
                        stringBuilder.Append(columnSplit); // Ajouter le séparateur
                }
                stringBuilder.Append(itemSplit); // Ajouter le séparateur
            }

            try
            {
                File.WriteAllText(filePath, stringBuilder.ToString()); // Ecrire les données dans un fichier
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured: " + ex.Message); // Afficher un message d'erreur
            }
        }
    }
}
