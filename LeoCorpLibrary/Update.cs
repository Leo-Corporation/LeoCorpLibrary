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
	/// Class that contains methods to help you implement an update system to your product.
	/// </summary>
	public static class Update
	{
		/// <summary>
		/// Allows you to verify if updates are available.
		/// </summary>
		/// <param name="version">Current software version.</param>
		/// <param name="lastVersion">Latest software version.</param>
		/// <returns>A <see cref="bool"/> value.</returns>
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
		/// Allows you to get the latest version of the software from a .txt file.
		/// </summary>
		/// <param name="lastVersionFileLink">Link of the file where the lastest version is stocked.</param>
		/// <exception cref="System.ArgumentNullException"></exception>
		/// <exception cref="System.Exception"></exception>
		/// <returns>A <see cref="string"/> value.</returns>
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

		/// <summary>
		/// Allows you to get the lastest version of the software from a .txt file asynchronously.
		/// </summary>
		/// <param name="lastVersionFileLink">Link of the file where the lastest version is stocked.</param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="Exception"></exception>
		/// <returns>A <see cref="Task{TResult}"/> value.</returns>
		public static Task<string> GetLastVersionAsync(string lastVersionFileLink)
		{
			Task<string> task = new Task<string>(() => GetLastVersion(lastVersionFileLink));
			task.Start();
			return task;
		}

		/// <summary>
		/// Allows you to check if updates are available and open a <see cref="Form"/> depending on the result.
		/// </summary>
		/// <param name="version">Current software version.</param>
		/// <param name="lastVersion">Latest software version.</param>
		/// <param name="availableUpdateForm"><see cref="Form"/> that opens if updates are available.</param>
		/// <param name="noUpdateForm"><see cref="Form"/> that opens if updates aren't available.</param>
		/// <exception cref="System.ArgumentNullException"></exception>
		public static void Check(string version, string lastVersion, Form availableUpdateForm, Form noUpdateForm)
		{
			if (availableUpdateForm != null && noUpdateForm != null) // If the forms are not null
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
			else // If there is no value for the forms
			{
				throw new ArgumentNullException("The argument 'availableUpdateForm' and/or 'noUpdateForm' cannot be 'null'");
			}
		}

		/// <summary>
		/// Allows you to check if updates are available and open a <see cref="System.Windows.Window"/> depending on the result.
		/// </summary>
		/// <param name="version">Current software version.</param>
		/// <param name="lastVersion">Latest software version.</param>
		/// <param name="availableUpdateWindow"><see cref="System.Windows.Window"/> that opens if updates are available.</param>
		/// <param name="noUpdateWindow"><see cref="System.Windows.Window"/> that opens if updates aren't available.</param>
		public static void CheckWPF(string version, string lastVersion, System.Windows.Window availableUpdateWindow, System.Windows.Window noUpdateWindow)
		{
			if (availableUpdateWindow != null && noUpdateWindow != null) // If the windows aren't null
			{
				if (version == lastVersion) // If there is no updates
				{
					noUpdateWindow.Show(); // Show the correct window
				}
				else // If there is updates
				{
					availableUpdateWindow.Show(); // Show the correct window
				}
			}
			else
			{
				throw new ArgumentNullException("The argument 'availableUpdateWindow' and/or 'noUpdateWindow' cannot be 'null'"); // Error
			}
		}

		/// <summary>
		/// Allows you to install an update.
		/// </summary>
		/// <param name="filePath">File location.</param>
		/// <param name="newVersionLink">Link of the new file.</param>
		/// <param name="fromAppStartupPath">(optionnal) Open the file from the <see cref="Application.StartupPath"/>.</param>
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
