using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Altera.Quartus
{
	/// <summary>
	/// Конфигурация quartus на компьютере
	/// </summary>
	internal static class QuartusConfig
	{
		private static string _currentProcessQuartusBin;


		/// <summary>
		/// Бинарная директория Quartus (bin для 32-битного процесса, bin64 для 64-битного)
		/// </summary>
		public static string BinDirectory
		{
			get { return _currentProcessQuartusBin;}
		}

		/// <summary>
		/// Путь до файла jtag_atlantic.dll
		/// </summary>
		internal static string JtagAtlanticLibrary
		{
			get { return Path.Combine( _currentProcessQuartusBin, "jtag_atlantic.dll" ); }
		}


		/// <summary>
		/// Инициализация (Автоматически находит директорию Quartus из переменной окружения)
		/// </summary>
		public static bool Initialize()
		{
			var quartusRoot = Environment.GetEnvironmentVariable("QUARTUS_ROOTDIR");
			if (string.IsNullOrWhiteSpace( quartusRoot ))
			{
				return false;
			}
			return Initialize( quartusRoot );
		}

		/// <summary>
		/// Инициализация (необходимо указать директорию Quartus)
		/// </summary>
		/// <param name="quartusRoot"></param>
		public static bool Initialize( string quartusRoot )
		{
			var binDir= Path.Combine(quartusRoot, Environment.Is64BitProcess ? "bin64" : "bin");
			if (!Directory.Exists( binDir ))
			{
				return false;
			}
			_currentProcessQuartusBin = binDir;
			
			var path = Environment.GetEnvironmentVariable("PATH");
			if (path == null)
			{
				// некогда такого не бывало, но всё же
				path = _currentProcessQuartusBin;
				Environment.SetEnvironmentVariable( "PATH", path );
			}
			else
			{
				if (path.IndexOf( _currentProcessQuartusBin, StringComparison.CurrentCultureIgnoreCase ) < 0)
				{
					path += ";" + _currentProcessQuartusBin;
					Environment.SetEnvironmentVariable( "PATH", path );
				}
			}
			return true;
		}
	}
}
