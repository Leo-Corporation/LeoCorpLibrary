using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeoCorpLibrary
{
    public static class Save
    {
        public static void ListViewContent(ListView listView, string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) // Si l'argument 'filePath' est vide ou null
            {
                throw new ArgumentNullException("The parameter 'filePath' can not be empty or null."); // Message d'erreur
            }
            string itemSplit = "(*E*)"; // Séparer entre les éléments => item1(*E*)item2
            string columnSplit = "(*C*)"; // Séparer entre les valeurs => item1(*E*)item2(*C*)item1(*E*)item2
            StringBuilder stringBuilder = new StringBuilder(); // Outil pour construire du string
            int elementNumber = listView.Items.Count; // Nombre d'élément dans la listview

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
    }
}
