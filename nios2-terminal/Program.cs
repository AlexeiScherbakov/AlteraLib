using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Altera.JtagAtlantic;

namespace nios2_terminal
{
	/// <summary>
	/// nios2-terminal like example
	/// </summary>
	internal static class Program
	{
		private static void Main( string[] args )
		{
			JtagAtlanticConnection.PreloadLibrary();

			var c = new JtagAtlanticConnection( JtagAtlanticConnection.UsbBlaster0, 0, -1, null );

			Thread t = new Thread(
				delegate()
				{
					byte[] buffer = new byte[100];
					while (true)
					{
						int readed = c.Read( buffer );
						if (readed == 0)
						{
							Thread.Sleep( 100 );
						}
						else
						{
							Console.Write( Encoding.ASCII.GetString( buffer, 0, readed ) );
						}
					}
				} );
			t.Start();

			StringBuilder str = new StringBuilder();
			while (true)
			{

				var key = Console.ReadKey( true );
				str.Append( key.KeyChar );
				if (key.Key == ConsoleKey.Enter)
				{
					str.Append( '\n' );
					c.Write( Encoding.ASCII.GetBytes( str.ToString() ) );
					str.Clear();
				}

			}

		}
	}

}
