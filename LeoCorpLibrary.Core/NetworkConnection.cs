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
using System.Net;
using System.Threading.Tasks;

namespace LeoCorpLibrary.Core
{
	/// <summary>
	/// Class that contains methods to get and test the user's Internet connection.
	/// </summary>
	public static class NetworkConnection
	{
		/// <summary>
		/// <para>Allows you to know if the user is connected to Internet.</para>
		/// <para>The connection is tested by default on https://bing.com.</para>
		/// </summary>
		/// <returns>A <see cref="bool"/> value.</returns>
		public static bool IsAvailable() // Fonction pour tester la connexion Internet
		{
			try
			{
				using (var client = new WebClient()) // Navigateur Internet
				using (var stream = client.OpenRead("https://www.bing.com")) // Ouvrir bing.com
				{
					return true; // Si la page s'ouvre = connexion OK
				}
			}
			catch
			{
				return false; // Si la page ne s'ouvre pas = connexion down
			}
		}

		/// <summary>
		/// <para>Allows you to know if the user is connected to Internet asynchronously.</para>
		/// <para>The connection is tested by default on https://bing.com.</para>
		/// </summary>
		/// <returns>A <see cref="Task{TResult}"/> value.</returns>
		public static Task<bool> IsAvailableAsync()
		{
			Task<bool> task = new Task<bool>(IsAvailable);
			task.Start();
			return task;
		}

		/// <summary>
		/// <para>Allows you to know if the user is connected to Internet.</para>
		/// <para>The connection is tested on the specified website.</para>
		/// </summary>
		/// <param name="site">Website where the connection is tested.</param>
		/// <exception cref="System.ArgumentNullException"></exception>
		/// <returns>A <see cref="bool"/> value.</returns>
		public static bool IsAvailableTestSite(string site)
		{
			bool result = true;
			if (!string.IsNullOrEmpty(site)) // Vérification de la validité de l'URL
			{
				try
				{
					using (var client = new WebClient()) // Navigateur Internet
					using (var stream = client.OpenRead(site)) // Ouvrir site
					{
						result = true; // Si la page s'ouvre = connexion OK
					}
				}
				catch
				{
					result = false; // Si la page ne s'ouvre pas = connexion down
				}
			}
			else
			{
				throw new ArgumentNullException("The content of the parameter 'site' (string) is empty/or is not a valid URL (http://example.com)."); // Erreur
			}
			return result;
		}

		/// <summary>
		/// <para>Allows you to know if the user is connected to Internet asynchronously.</para>
		/// <para>The connection is tested on the specified website.</para>
		/// </summary>
		/// <param name="site">Website where the connection is tested.</param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <returns>A <see cref="Task{TResult}"/> value.</returns>
		public static Task<bool> IsAvailableTestSiteAsync(string site)
		{
			Task<bool> task = new Task<bool>(() => IsAvailableTestSite(site));
			task.Start();
			return task;
		}

		
	}
}
