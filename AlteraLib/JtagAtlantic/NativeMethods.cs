using System;
using System.Runtime.InteropServices;

namespace Altera.JtagAtlantic
{
	internal static class NativeMethods
	{
		[DllImport("kernel32.dll", EntryPoint = "LoadLibraryW",
			CallingConvention = CallingConvention.StdCall,
			CharSet = CharSet.Unicode)]
		internal static extern IntPtr LoadLibrary(string fileName);
	}
}