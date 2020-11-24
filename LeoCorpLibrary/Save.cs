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
using System.Xml.Serialization;

#if NETCOREAPP3_1 || NET5_0
using System.Text.Json;
#endif

namespace LeoCorpLibrary
{
    /// <summary>
    /// Class containing methods to save files.
    /// </summary>
    public static class Save
    {
        /// <summary>
        /// Allows you to save the content of a <see cref="ListView"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        /// <param name="listView"><see cref="ListView"/>.</param>
        /// <param name="filePath">Location where to save the content of a <see cref="ListView"/>.</param>
        [Obsolete("Use ListViewContentCustom instead.")]
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
        /// Allows you to save the content of a <see cref="ListView"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        /// <param name="listView"><see cref="ListView"/>.</param>
        /// <param name="filePath">Location where to save the content of a <see cref="ListView"/>.</param>
        /// <param name="itemSplit">Elements separator (ex: /*E*/).</param>
        /// <param name="columnSplit">Columns separator (ex: /*C*/).</param>
        [Obsolete("Use ListViewContentCustom instead.")]
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


        /// <summary>
        /// Allows you to save the content of a <see cref="ListView"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        /// <param name="listView"><see cref="ListView"/>.</param>
        /// <param name="filePath">Location where to save the content of a <see cref="ListView"/>.</param>
        public static void ListViewContentCustom(ListView listView, string filePath)
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
        /// Allows you to save the content of a <see cref="ListView"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        /// <param name="listView"><see cref="ListView"/>.</param>
        /// <param name="filePath">Location where to save the content of a <see cref="ListView"/>.</param>
        /// <param name="itemSplit">Elements separator (ex: /*E*/).</param>
        /// <param name="columnSplit">Columns separator (ex: /*C*/).</param>
        public static void ListViewContentCustom(ListView listView, string filePath, string itemSplit, string columnSplit)
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

        /// <summary>
        /// Allows you to save the content of a <see cref="ListView"/> in a XML file.
        /// </summary>
        /// <param name="listView"><see cref="ListView"/>.</param>
        /// <param name="filePath">Where to save the file.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ListViewContentXML(ListView listView, string filePath)
        {
            if (listView.Items.Count > 0) // If the listview isn't empty
            {
                List<string[]> items = new List<string[]>(); // Items

                for (int i = 0; i < listView.Items.Count; i++) // For each item
                {
                    string[] a = new string[listView.Items[i].SubItems.Count]; // Subitems

                    for (int j = 0; j < listView.Items[i].SubItems.Count; j++) // For each subitem
                    {
                        a[j] = listView.Items[i].SubItems[j].Text; // Add the subitem to the Subitems array
                    }

                    items.Add(a); // Add the subitems
                }

                XmlSerializer xmlSerializer = new XmlSerializer(items.GetType()); // Create XML Serializer
                StreamWriter streamWriter = new StreamWriter(filePath); // Where to save

                xmlSerializer.Serialize(streamWriter, items); // Save
                streamWriter.Dispose(); // Free used resources
            }
            else
            {
                throw new ArgumentNullException("The 'listView' argument must have items."); // Error
            }
        }

#if NETCOREAPP3_1 || NET5_0
        /// <summary>
        /// Allows you to save the content of a <see cref="ListView"/> in a JSON file.
        /// </summary>
        /// <param name="listView"><see cref="ListView"/>.</param>
        /// <param name="filePath">Where to save the file.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <remarks>Only available in .NET Core 3.1 or .NET 5.</remarks>
        public static void ListViewContentJSON(ListView listView, string filePath)
        {
            if (listView.Items.Count > 0)
            {
                List<string[]> items = new List<string[]>(); // Items

                for (int i = 0; i < listView.Items.Count; i++) // For each item
                {
                    string[] a = new string[listView.Items[i].SubItems.Count]; // Subitems

                    for (int j = 0; j < listView.Items[i].SubItems.Count; j++) // For each subitem
                    {
                        a[j] = listView.Items[i].SubItems[j].Text; // Add the subitem to the Subitems array
                    }

                    items.Add(a); // Add the subitems
                }

                string json = JsonSerializer.Serialize(items); // Serialize
                File.WriteAllText(filePath, json); // Save
            }
            else
            {
                throw new ArgumentNullException("The 'listView' argument must have items."); // Error
            }
        }
#endif
    }
}
