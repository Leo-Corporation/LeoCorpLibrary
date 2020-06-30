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
    /// Classe regroupant des méthodes sur le chargement de fichiers dans des contrôles.
    /// </summary>
    public static class Load
    {
        /// <summary>
        /// Permet de charger un fichier de sauvegarde dans une <see cref="ListView"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        /// <param name="listView"><see cref="ListView"/>.</param>
        /// <param name="filePath">Emplacement du fichier à charger dans la <see cref="ListView"/>.</param>
        public static void ListViewContent(ListView listView, string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) // Si l'argument 'filePath' est vide ou null
            {
                throw new ArgumentNullException("The parameter 'filePath' can not be empty or null."); // Message d'erreur
            }

            if (!File.Exists(filePath)) // Si le fichier n'existe pas
            {
                throw new FileNotFoundException("The specified file in 'filePath' does not exist."); // Message d'erreur
            }
            string itemSplit = "(*E*)"; // Séparer entre les éléments => item1(*E*)item2
            string columnSplit = "(*C*)"; // Séparer entre les valeurs => item1(*E*)item2(*C*)item1(*E*)item2

            try
            {
                string data = File.ReadAllText(filePath); // Données
                string[] elements = data.Split(new string[] { itemSplit }, StringSplitOptions.None); // Séparer avec itemSplit
                
                foreach (string element in elements) // Pour chaque élément dans 'elements'
                {
                    string[] values = element.Split(new string[] { columnSplit }, StringSplitOptions.None); // Séparer avec 'columnSplit'
                    ListViewItem listViewItem = new ListViewItem(); // Nouvel élément à ajouter dans la ListView

                    for (int i = 0; i <= values.Length - 1; i++) // Pour chaque valeur dans 'values[]'
                    {
                        if (i == 0)
                            listViewItem.Text = values[i]; // Ajouer la valeur dans la première colonne
                        else
                            listViewItem.SubItems.Add(values[i]); // Si i = 1 c'est la deuxième colonne, etc...
                    }

                    listView.Items.Add(listViewItem); // Ajouter l'élement à la ListView
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured: " + ex.Message); // Message d'erreur
            }
        }

        /// <summary>
        /// Permet de charger un fichier de sauvegarde dans une <see cref="ListView"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        /// <param name="listView"><see cref="ListView"/>.</param>
        /// <param name="filePath">Emplacement du fichier à charger dans la <see cref="ListView"/>.</param>
        /// <param name="itemSplit">Séparateur d'éléments utilisé lors de la sauvegarde.</param>
        /// <param name="columnSplit">Séparateur de colonnes utilisé lors de la sauvegarde.</param>
        public static void ListViewContent(ListView listView, string filePath, string itemSplit, string columnSplit)
        {
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(itemSplit) || string.IsNullOrEmpty(columnSplit)) // Si les paramètres sont vides ou null
            {
                throw new ArgumentNullException("One of the specified parameters is null or empty."); // Message d'erreur
            }

            if (!File.Exists(filePath)) // Si le fichier n'existe pas
            {
                throw new FileNotFoundException("The specified file in 'filePath' does not exist."); // Message d'erreur
            }

            try
            {
                string data = File.ReadAllText(filePath); // Données
                string[] elements = data.Split(new string[] { itemSplit }, StringSplitOptions.None); // Séparer avec itemSplit

                foreach (string element in elements) // Pour chaque élément dans 'elements'
                {
                    string[] values = element.Split(new string[] { columnSplit }, StringSplitOptions.None); // Séparer avec 'columnSplit'
                    ListViewItem listViewItem = new ListViewItem(); // Nouvel élément à ajouter dans la ListView

                    for (int i = 0; i <= values.Length - 1; i++) // Pour chaque valeur dans 'values[]'
                    {
                        if (i == 0)
                            listViewItem.Text = values[i]; // Ajouer la valeur dans la première colonne
                        else
                            listViewItem.SubItems.Add(values[i]); // Si i = 1 c'est la deuxième colonne, etc...
                    }

                    listView.Items.Add(listViewItem); // Ajouter l'élement à la ListView
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured: " + ex.Message); // Message d'erreur
            }
        }
    }
}
