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
using LeoCorpLibrary.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeoCorpLibrary.Core
{
	/// <summary>
	/// Class that contains method to generate passwords.
	/// </summary>
	public static class Password
	{
		/// <summary>
		/// Generates a password.
		/// </summary>
		/// <param name="length">length of the password.</param>
		/// <param name="chars">Characters that can be in the generated password.</param>
		/// <param name="separator">Separator of the characters.</param>
		/// <exception cref="Exception"></exception>
		/// <returns>A <see cref="string"/> value.</returns>
		public static string Generate(int length, string chars, string separator)
		{
			string[] usableChars = { };
			if (chars.Contains(separator)) // Si les caractères contiennent le séparateur
			{
				usableChars = chars.Split(new string[] { separator }, StringSplitOptions.None); // Séparer les valeurs dans un tableau
			}
			else
			{
				throw new Exception("The parameter 'chars' (string) does not contain the specified seperator.");
			}
			string finalPassword = ""; // Mot de passe final
			Random random = new Random(); // Nombre aléatoire
			int number = 0;
			if (length > 0)
			{
				for (int i = 1; i < length; i++) // Génération du mot de passe
				{
					number = random.Next(0, usableChars.Length); // Génération d'un nombre aléatoire
					finalPassword = finalPassword + usableChars[number];
				}
			}
			else
			{
				throw new Exception("The parameter 'length' (int) must be higher than 0.");
			}
			return finalPassword; // Retourne le mot de passe final
		}

		/// <summary>
		/// Generates a password asynchronously.
		/// </summary>
		/// <param name="length">length of the password.</param>
		/// <param name="chars">Characters that can be in the generated password.</param>
		/// <param name="separator">Separator of the characters.</param>
		/// <exception cref="Exception"></exception>
		/// <returns>A <see cref="Task{TResult}"/> value.</returns>
		public static Task<string> GenerateAsync(int length, string chars, string separator)
		{
			Task<string> task = new Task<string>(() => Generate(length, chars, separator));
			task.Start();
			return task;
		}

		/// <summary>
		/// Generates a password.
		/// </summary>
		/// <param name="length">length of the password.</param>
		/// <param name="passwordPresets">The preset used for the password.</param>
		/// <exception cref="Exception"></exception>
		/// <returns>A <see cref="string"/> value.</returns>
		public static string Generate(int length, PasswordPresets passwordPresets)
		{
			switch (passwordPresets) // For each case
			{
				case PasswordPresets.Simple: // If the preset is simple
					return Generate(length, "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,0,1,2,3,4,5,6,7,8,9", ","); // Generate password
				case PasswordPresets.Complex: // If the presete is complex
					return Generate(length, "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,0,1,2,3,4,5,6,7,8,9,/,é,&,ç,à,@,°,{,},(,),#,&", ","); // Generate password
				default:
					return "";
			}
		}

		/// <summary>
		/// Generates a password asynchronously.
		/// </summary>
		/// <param name="length">length of the password.</param>
		/// <param name="passwordPresets">The preset used for the password.</param>
		/// <exception cref="Exception"></exception>
		/// <returns>A <see cref="Task{TResult}"/> value.</returns>
		public static async Task<string> GenerateAsync(int length, PasswordPresets passwordPresets)
		{
			switch (passwordPresets) // For each case
			{
				case PasswordPresets.Simple: // If the preset is simple
					return await GenerateAsync(length, "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,0,1,2,3,4,5,6,7,8,9", ","); // Generate password
				case PasswordPresets.Complex: // If the presete is complex
					return await GenerateAsync(length, "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,0,1,2,3,4,5,6,7,8,9,/,é,&,ç,à,@,°,{,},(,),#,&", ","); // Generate password
				default:
					return "";
			}
		}

		/// <summary>
		/// Generates a specifed amount of passwords.
		/// </summary>
		/// <param name="amount">The number of passwords to generate.</param>
		/// <param name="length">The length of passwords.</param>
		/// <param name="chars">Characters that can be in the generated password.</param>
		/// <param name="separator">Separator of the characters.</param>
		/// <returns>A <see cref="List{T}"/> of <see cref="string"/>.</returns>
		public static List<string> GenerateAmount(int amount, int length, string chars, string separator)
		{
			List<string> result = new List<string>();

			for (int i = 0; i < amount; i++)
			{
				result.Add(Generate(length, chars, separator)); // Add password
			}

			return result; // Return all generated passwords
		}

		/// <summary>
		/// Generates a specified amount of passwords asynchronously.
		/// </summary>
		/// <param name="amount">The number of passwords to generate.</param>
		/// <param name="length">The length of passwords.</param>
		/// <param name="chars">Characters that can be in the generated password.</param>
		/// <param name="separator">Separator of the characters.</param>
		/// <returns>A <see cref="List{T}"/> of <see cref="string"/> (<see cref="Task{TResult}"/>).</returns>
		public static async Task<List<string>> GenerateAmountAsync(int amount, int length, string chars, string separator)
		{
			List<string> result = new List<string>();

			for (int i = 0; i < amount; i++)
			{
				result.Add(await GenerateAsync(length, chars, separator)); // Add password
			}

			return result; // Return all generated passwords
		}

		/// <summary>
		/// Generates a specified amount of passwords.
		/// </summary>
		/// <param name="amount">The number of passwords to generate.</param>
		/// <param name="length">The length of passwords.</param>
		/// <param name="passwordPresets">The preset used for the password.</param>
		/// <returns>A <see cref="List{T}"/> of <see cref="string"/>.</returns>
		public static List<string> GenerateAmount(int amount, int length, PasswordPresets passwordPresets)
		{
			List<string> result = new List<string>();

			for (int i = 0; i < amount; i++)
			{
				result.Add(Generate(length, passwordPresets)); // Add password
			}

			return result; // Return all generated passwords
		}

		/// <summary>
		/// Generates a specified amount of passwords asynchronously.
		/// </summary>
		/// <param name="amount">The number of passwords to generate.</param>
		/// <param name="length">The length of passwords.</param>
		/// <param name="passwordPresets">The preset used for the password.</param>
		/// <returns>A <see cref="List{T}"/> of <see cref="string"/> (<see cref="Task{TResult}"/>).</returns>
		public static async Task<List<string>> GenerateAmountAsync(int amount, int length, PasswordPresets passwordPresets)
		{
			List<string> result = new List<string>();

			for (int i = 0; i < amount; i++)
			{
				result.Add(await GenerateAsync(length, passwordPresets)); // Add password
			}

			return result; // Return all generated passwords
		}

		internal static string Numbers => "0,1,2,3,4,5,6,7,8,8,9";
		internal static string SpecialCaracters => ";,:,!,/,§,ù,*,$,%,µ,£,),=,+,*,-,&,é,',(,-,è,_,ç,<,>,?,^,¨";
		internal static string[] ForbidenCaracters => new string[] { "123", "456", "789", "password", "mdp", "pswr", "000", "admin", "111", "222", "333", "444", "555", "666", "777", "888", "999" };
		internal static string LowerCaseLetters => "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
		internal static string UpperCaseLetters => "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";

		/// <summary>
		/// Checks if a string contains lower cases.
		/// </summary>
		/// <param name="s"></param>
		/// <returns>A <see cref="bool"/> value.</returns>
		internal static bool ContainsLowerCases(this string s)
		{
			string[] lowerCase = LowerCaseLetters.Split(new string[] { "," }, StringSplitOptions.None); // Lower case

			for (int i = 0; i < lowerCase.Length; i++)
			{
				for (int j = 0; j < s.Length; j++)
				{
					if (s[j].ToString().Contains(lowerCase[i]))
					{
						return true; // Return
					}
				}
			}

			return false; // Return
		}

		/// <summary>
		/// Checks if a string contains upper cases.
		/// </summary>
		/// <param name="s"></param>
		/// <returns>A <see cref="bool"/> value.</returns>
		internal static bool ContainsUpperCases(this string s)
		{
			string[] upperCase = UpperCaseLetters.Split(new string[] { "," }, StringSplitOptions.None); // Upper case

			for (int i = 0; i < upperCase.Length; i++)
			{
				for (int j = 0; j < s.Length; j++)
				{
					if (s[j].ToString().Contains(upperCase[i]))
					{
						return true; // Return
					}
				}
			}

			return false; // Return
		}

		/// <summary>
		/// Gets the password strenght of a password.
		/// </summary>
		/// <param name="password">The password.</param>
		/// <returns>A <see cref="PasswordStrength"/> enum.</returns>
		public static PasswordStrength GetPasswordStrength(string password)
		{
			int lenght = password.Length; // Lenght
			int pswrScore = 0; // Score

			if (lenght == 0)
			{
				return PasswordStrength.Unknown;
			}

			if (lenght >= 0 && lenght <= 5) // If the lenght of the password is between 0 & 5
			{
				pswrScore += 1; // Add 1
			}
			else if (lenght >= 6 && lenght <= 10) // If the lenght of the password is between 6 & 10
			{
				pswrScore += 2; // Add 2
			}
			else if (lenght >= 11 && lenght <= 15) // If the lenght of the password is between 11 & 15
			{
				pswrScore += 5; // Add 5
			}
			else if (lenght > 15) // If the lenght of the password is higher than 15
			{
				pswrScore += 10; // Add 10
			}

			for (int i = 0; i < Numbers.Length; i++)
			{
				for (int j = 0; j < lenght; j++)
				{
					pswrScore += password[j].ToString().Contains(Numbers[i]) ? 1 : 0;
				}
			}

			for (int i = 0; i < SpecialCaracters.Length; i++)
			{
				for (int j = 0; j < lenght; j++)
				{
					pswrScore += password[j].ToString().Contains(SpecialCaracters[i]) ? 4 : 0;
				}
			}

			for (int i = 0; i < ForbidenCaracters.Length; i++)
			{
				pswrScore -= password.Contains(ForbidenCaracters[i]) ? 10 : 0;
			}

			if (password.ContainsLowerCases() && password.ContainsUpperCases()) // If there is upper and lower cases
			{
				pswrScore += 5; // Add 2
			}
			else
			{
				pswrScore -= 5; // Sub 5
			}

			if (password.HasRepeatedCharacters())
			{
				pswrScore -= 5; // Sub 5
			}

			if (pswrScore < 2)
			{
				return PasswordStrength.Low; // Return
			}
			else if (pswrScore >= 3 && pswrScore <= 7)
			{
				return PasswordStrength.Medium; // Return
			}
			else if (pswrScore >= 8 && pswrScore <= 12)
			{
				return PasswordStrength.Good; // Return
			}
			else if (pswrScore >= 13)
			{
				return PasswordStrength.VeryGood; // Return
			}
			else
			{
				return PasswordStrength.Good; // Return
			}
		}
	}

	/// <summary>
	/// Presets that can be used for password generation.
	/// </summary>
	public enum PasswordPresets
	{
		/// <summary>
		/// The "Simple" preset generates a password with simple characters.
		/// </summary>
		Simple,

		/// <summary>
		/// The "Complex" preset generates a password with unusual, hard and complex characters.
		/// </summary>
		Complex
	}

	/// <summary>
	/// The password strenght enum.
	/// </summary>
	public enum PasswordStrength
	{
		/// <summary>
		/// Very good password strenght.
		/// </summary>
		VeryGood,

		/// <summary>
		/// Good password strenght.
		/// </summary>
		Good,

		/// <summary>
		/// Medium password strenght.
		/// </summary>
		Medium,

		/// <summary>
		/// Low password strenght.
		/// </summary>
		Low,

		/// <summary>
		/// Unknown password strenght.
		/// </summary>
		Unknown
	}
}
