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
using LeoCorpLibrary.Enums;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
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
		public static bool IsAvailable()
		{
			return GetWebPageStatusCode("https://www.bing.com") != 400;
		}

		/// <summary>
		/// Allows you to check if the user is connected to Internet.
		/// </summary>
		/// <param name="url">The URL of the website where the connection is going to be tested.</param>
		/// <returns>A <see cref="bool"/> value.</returns>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="WebException"></exception>
		public static bool IsAvailable(string url)
		{
			if (string.IsNullOrEmpty(url))
			{
				throw new ArgumentNullException("url", "Please provide a valid URL such as http://example.com.");
			}

			return GetWebPageStatusCode(url) != 400;
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
		/// Allows you to check if the user is connected to Internet asynchronously.
		/// </summary>
		/// <param name="url">The URL of the website where the connection is going to be tested.</param>
		/// <returns>A <see cref="Task{TResult}"/> value.</returns>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="WebException"></exception>
		public static Task<bool> IsAvailableAsync(string url)
		{
			Task<bool> task = new Task<bool>(() => IsAvailable(url));
			task.Start();
			return task;
		}

		/// <summary>
		/// <para>Allows you to know if the user is connected to Internet.
		/// The connection is tested on the specified website.</para>
		/// This method is obsolete, please use IsAvailable(url) instead.
		/// </summary>
		/// <param name="site">Website where the connection is tested.</param>
		/// <exception cref="System.ArgumentNullException"></exception>
		/// <returns>A <see cref="bool"/> value.</returns>
		[Obsolete("This method is obsolete, please use IsAvailable(url) instead.")]
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
		/// <para>Allows you to know if the user is connected to Internet asynchronously.
		/// The connection is tested on the specified website.</para>
		/// This method is obsolete, please use IsAvailableAsync(url) instead.
		/// </summary>
		/// <param name="site">Website where the connection is tested.</param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <returns>A <see cref="Task{TResult}"/> value.</returns>
		[Obsolete("This method is obsolete, please use IsAvailableAsync(url) instead.")]
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
		[Obsolete("This method is obsolete and will be removed in a future version of LeoCorpLibrary. Please use the GetWebPageStatusCode() method instead.")]
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
		/// Gets the status code of a specified website asynchronously.
		/// </summary>
		/// <param name="url">The URL of the website.</param>
		/// <returns>An <see cref="int"/> value, the status code of the URL.</returns>
		public static async Task<int> GetWebPageStatusCodeAsync(string url)
		{
			var httpMessage = await new HttpClient().GetAsync(url); // Send a request to the specified website
			return (int)httpMessage.StatusCode; // Return the status code returned by the website
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

		/// <summary>
		/// Gets the <see cref="StatusCodeType"/> of a specified website.
		/// </summary>
		/// <param name="url">The URL of the website.</param>
		/// <returns>A <see cref="StatusCodeType"/> value.</returns>
		/// <exception cref="WebException"></exception>
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

		/// <summary>
		/// Downloads a file asynchronously using the <see cref="System.Net.Http.HttpClient"/> class.
		/// </summary>
		/// <param name="uri">The URI of the file to download.</param>
		/// <param name="filePath">The path where to store the file once downloaded.</param>
		/// <returns>A <see cref="Task"/> value (<see cref="void"/>).</returns>
		public static async Task DownloadFileAsync(Uri uri, string filePath)
		{
			using (var s = await new System.Net.Http.HttpClient().GetStreamAsync(uri))
			{
				using (var fs = new FileStream(filePath, FileMode.CreateNew))
				{
					await s.CopyToAsync(fs);
				}
			}
		}
	}
}
