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

namespace LeoCorpLibrary.Core.Enums
{
	/// <summary>
	/// Time units such as milliseconds, seconds, minutes, etc...
	/// </summary>
	public enum TimeUnits
	{
		/// <summary>
		/// Milliseconds.
		/// </summary>
		Milliseconds,

		/// <summary>
		/// Seconds.
		/// </summary>
		Seconds,

		/// <summary>
		/// Minutes.
		/// </summary>
		Minutes,

		/// <summary>
		/// Hours.
		/// </summary>
		Hours,

		/// <summary>
		/// Days.
		/// </summary>
		Days
	}

	/// <summary>
	/// Available themes on Windows.
	/// </summary>
	public enum SystemThemes
	{
		/// <summary>
		/// Dark theme.
		/// </summary>
		Dark,

		/// <summary>
		/// Light theme.
		/// </summary>
		Light,

		/// <summary>
		/// Unknown theme/OS not supported.
		/// </summary>
		Unknown
	}

	/// <summary>
	/// Operating systems.
	/// </summary>
	public enum OperatingSystems
	{
		/// <summary>
		/// The Windows Operating system.
		/// </summary>
		Windows,

		/// <summary>
		/// The macOS Operating system.
		/// </summary>
		macOS,

		/// <summary>
		/// The Linux Operating system.
		/// </summary>
		Linux,

		/// <summary>
		/// An unknown Operating system.
		/// </summary>
		Unknown
	}

	/// <summary>
	/// Size of files/directories.
	/// </summary>
	public enum UnitType
	{
		/// <summary>
		/// Byte Unit.
		/// </summary>
		Byte,
		/// <summary>
		/// Kilobyte Unit.
		/// </summary>
		Kilobyte,
		/// <summary>
		/// Megabyte Unit.
		/// </summary>
		Megabyte,
		/// <summary>
		/// Gigabyte Unit.
		/// </summary>
		Gigabyte,
		/// <summary>
		/// Terabyte Unit.
		/// </summary>
		Terabyte,
		/// <summary>
		/// Petabyte Unit.
		/// </summary>
		Petabyte
	}

	/// <summary>
	/// Windows Operating Systems.
	/// </summary>
	public enum WindowsVersion
	{
		/// <summary>
		/// Windows 7 (Version 6.1).
		/// </summary>
		Windows7,

		/// <summary>
		/// Windows 8 (Version 6.2).
		/// </summary>
		Windows8,

		/// <summary>
		/// Windows 8.1 (Version 6.3).
		/// </summary>
		Windows81,

		/// <summary>
		/// Windows 10 (Version 10.0).
		/// </summary>
		Windows10,

		/// <summary>
		/// Windows 11 (Version 10.0.22XXX+).
		/// </summary>
		Windows11,

		/// <summary>
		/// Unknown operating system.
		/// </summary>
		Unknown
	}

	/// <summary>
	/// Status Code type of a request to a website.
	/// </summary>
	public enum StatusCodeType
	{
		/// <summary>
		/// Informational (1xx).
		/// </summary>
		Informational,

		/// <summary>
		/// Success (2xx).
		/// </summary>
		Success,

		/// <summary>
		/// Redirection (3xx).
		/// </summary>
		Redirection,

		/// <summary>
		/// Client error (4xx).
		/// </summary>
		ClientError,

		/// <summary>
		/// Server error (5xx).
		/// </summary>
		ServerError
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
