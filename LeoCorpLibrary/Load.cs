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
using System.Windows.Forms;
using System.Xml.Serialization;

#if NETCOREAPP3_1 || NET5_0_OR_GREATER
using System.Text.Json;
#endif

namespace LeoCorpLibrary
{
	/// <summary>
	/// Class containing methods to load saved file using the methods in <see cref="Save"/>.
	/// </summary>
	public static class Load
	{
		/// <summary>
		/// Allows you to load a saved file in a <see cref="ListView"/>.
		/// </summary>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="Exception"></exception>
		/// <exception cref="FileNotFoundException"></exception>
		/// <param name="listView"><see cref="ListView"/>.</param>
		/// <param name="filePath">Location of the file to load in a <see cref="ListView"/>.</param>
		[Obsolete("Use ListViewContentCustom instead.")]
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
				string[] elements = data.Split(new string[] { itemSplit }, StringSplitOptions.RemoveEmptyEntries); // Séparer avec itemSplit

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
		/// Allows you to load a saved file in a <see cref="ListView"/>.
		/// </summary>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="Exception"></exception>
		/// <exception cref="FileNotFoundException"></exception>
		/// <param name="listView"><see cref="ListView"/>.</param>
		/// <param name="filePath">Location of the file to load in a <see cref="ListView"/>.</param>
		/// <param name="itemSplit">Elements separator used during saving.</param>
		/// <param name="columnSplit">Columns separator used during saving.</param>
		[Obsolete("Use ListViewContentCustom instead.")]
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

		/// <summary>
		/// Allows you to load a saved file in a <see cref="ListView"/>.
		/// </summary>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="Exception"></exception>
		/// <exception cref="FileNotFoundException"></exception>
		/// <param name="listView"><see cref="ListView"/>.</param>
		/// <param name="filePath">Location of the file to load in a <see cref="ListView"/>.</param>
		public static void ListViewContentCustom(ListView listView, string filePath)
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
				string[] elements = data.Split(new string[] { itemSplit }, StringSplitOptions.RemoveEmptyEntries); // Séparer avec itemSplit

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
		/// Allows you to load a saved file in a <see cref="ListView"/>.
		/// </summary>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="Exception"></exception>
		/// <exception cref="FileNotFoundException"></exception>
		/// <param name="listView"><see cref="ListView"/>.</param>
		/// <param name="filePath">Location of the file to load in a <see cref="ListView"/>.</param>
		/// <param name="itemSplit">Elements separator used during saving.</param>
		/// <param name="columnSplit">Columns separator used during saving.</param>
		public static void ListViewContentCustom(ListView listView, string filePath, string itemSplit, string columnSplit)
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

		/// <summary>
		/// Allows you to load a saved file in a <see cref="ListView"/>.
		/// </summary>
		/// <param name="listView"><see cref="ListView"/>.</param>
		/// <param name="filePath">The location of the file where the items are.</param>
		/// <exception cref="FileNotFoundException"></exception>
		public static void ListViewContentXML(ListView listView, string filePath)
		{
			if (!File.Exists(filePath)) // If the file doesn't exist
			{
				throw new FileNotFoundException("The 'filePath' argument led to a file that does not exist."); // Error
			}

			List<string[]> items = new List<string[]>(); // Items of the listview

			XmlSerializer xmlSerializer = new XmlSerializer(items.GetType()); // Create XML Serializer
			StreamReader streamReader = new StreamReader(filePath); // Where is the specified file

			items = (List<string[]>)xmlSerializer.Deserialize(streamReader); // Open and deserialize
			streamReader.Dispose(); // Free used resources

			for (int i = 0; i < items.Count; i++) // For each item
			{
				listView.Items.Add(new ListViewItem(items[i])); // Add the item
			}
		}

#if NETCOREAPP3_1 || NET5_0_OR_GREATER
		/// <summary>
		/// Allows you to load a saved file in a <see cref="ListView"/>.
		/// </summary>
		/// <param name="listView"><see cref="ListView"/>.</param>
		/// <param name="filePath">The location of the file where the items are.</param>
		/// <exception cref="FileNotFoundException"></exception>
		/// <remarks>Only works in .NET Core 3.1 or .NET 5.</remarks>
		public static void ListViewContentJSON(ListView listView, string filePath)
		{
			if (!File.Exists(filePath)) // If the file doesn't exist
			{
				throw new FileNotFoundException("The 'filePath' argument led to a file that does not exist."); // Error
			}

			List<string[]> items; // Items of the listview
			string json = File.ReadAllText(filePath); // Read the file

			items = JsonSerializer.Deserialize<List<string[]>>(json); // Deserialize

			for (int i = 0; i < items.Count; i++) // For each item
			{
				listView.Items.Add(new ListViewItem(items[i])); // Add the items
			}
		}
#endif
	}
}
