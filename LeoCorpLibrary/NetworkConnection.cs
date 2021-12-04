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

namespace LeoCorpLibrary
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

		/// <summary>
		/// Gets the status code of a specified website.
		/// </summary>
		/// <param name="url">The URL of the website.</param>
		/// <returns>An <see cref="int"/> value.</returns>
		/// <exception cref="WebException"></exception>
		public static int GetWebPageStatusCode(string url)
		{
			try
			{
				HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url); // Create a web request

				HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse(); // Get the response of the request
				myHttpWebResponse.Close(); // Close the request

				return 200; // The request was successfull with no warnings nor errors, so return code 200 - OK.
			}
			catch (WebException e)
			{
				if (e.Status == WebExceptionStatus.ProtocolError)
				{
					return (int)((HttpWebResponse)e.Response).StatusCode;
				}
			}
			return 400; // An unknown error has occured.
		}

		/// <summary>
		/// Gets the status description of a specified website. (ex: <c>"OK"</c>, for status code <c>200</c>)
		/// </summary>
		/// <param name="url">The URL of the website.</param>
		/// <returns>A <see cref="string"/> value.</returns>
		/// <exception cref="WebException"></exception>
		public static string GetWebPageStatusDescription(string url)
		{
			try
			{
				HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url); // Create a web request

				HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse(); // Get the response of the request
				myHttpWebResponse.Close(); // Close the request

				return "OK"; // The request was successfull with no warnings nor errors, so return code 200 - OK.
			}
			catch (WebException e)
			{
				if (e.Status == WebExceptionStatus.ProtocolError)
				{
					return ((HttpWebResponse)e.Response).StatusDescription;
				}
			}
			return "Bad Request"; // An unknown error has occured.
		}

		public static StatusCodeType GetStatusCodeType(string url)
		{
			int statusCode = GetWebPageStatusCode(url); // Get the status code

			if (statusCode >= 100 && statusCode <= 199)
			{
				return StatusCodeType.Informational; // Return Informational
			}
			else if (statusCode >= 200 && statusCode <= 299)
			{
				return StatusCodeType.Success; // Return Success
			}
			else if (statusCode >= 300 && statusCode <= 399)
			{
				return StatusCodeType.Redirection; // Return Redirection
			}
			else if (statusCode >= 400 && statusCode <= 499)
			{
				return StatusCodeType.ClientError; // Return ClientError
			}
			else if (statusCode >= 500 && statusCode <= 599)
			{
				return StatusCodeType.ServerError; // Return ServerError
			}
			else
			{
				return StatusCodeType.ClientError; // Return ClientError
			}
		}

		public enum StatusCodeType
		{
			Informational,
			Success,
			Redirection,
			ClientError,
			ServerError
		}
	}
}
