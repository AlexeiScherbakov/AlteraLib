using System;
using System.Runtime.InteropServices;

namespace Altera.JtagAtlantic
{
	internal static class JtagAtlanticNativeMethods
	{
		#region jtagatlantic_open

		//struct JTAGATLANTIC * __cdecl jtagatlantic_open(char const *,int,int,char const *)

		[DllImport("jtag_atlantic.dll",
			EntryPoint = "?jtagatlantic_open@@YAPAUJTAGATLANTIC@@PBDHH0@Z", ExactSpelling = true,
			CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr jtagatlantic_open(string chain, int device_index, int link_instance, string app_name);

		#endregion

		//struct JTAGATLANTIC * __cdecl jtagatlantic_open(char const *,int,int,char const *,class LOCK_HANDLER *)
		//TODO

		#region jtagatlantic_close

		//void __cdecl jtagatlantic_close(struct JTAGATLANTIC *)

		[DllImport("jtag_atlantic.dll",
			EntryPoint = "?jtagatlantic_close@@YAXPAUJTAGATLANTIC@@@Z", ExactSpelling = true,
			CallingConvention = CallingConvention.Cdecl)]
		internal static extern void jtagatlantic_close(IntPtr link);

		#endregion

		#region jtagatlantic_read

		//int __cdecl jtagatlantic_read(struct JTAGATLANTIC *,char *,unsigned int)

		[DllImport("jtag_atlantic.dll",
			EntryPoint = "?jtagatlantic_read@@YAHPAUJTAGATLANTIC@@PADI@Z", ExactSpelling = true,
			CallingConvention = CallingConvention.Cdecl)]
		internal static extern int jtagatlantic_read(IntPtr link, byte[] buffer, int bufferSize);

		#endregion

		#region jtagatlantic_wait_open
		//int __cdecl jtagatlantic_wait_open(struct JTAGATLANTIC *)

		[DllImport("jtag_atlantic.dll",
			EntryPoint = "?jtagatlantic_wait_open@@YAHPAUJTAGATLANTIC@@@Z", ExactSpelling = true,
			CallingConvention = CallingConvention.Cdecl)]
		internal static extern void jtagatlantic_wait_open(IntPtr link);

		#endregion

		#region jtagatlantic_bytes_available
		//int __cdecl jtagatlantic_bytes_available(struct JTAGATLANTIC *)

		[DllImport("jtag_atlantic.dll",
			EntryPoint = "?jtagatlantic_bytes_available@@YAHPAUJTAGATLANTIC@@@Z", ExactSpelling = true,
			CallingConvention = CallingConvention.Cdecl)]
		internal static extern int jtagatlantic_bytes_available(IntPtr link);

		#endregion

		#region jtagatlantic_close

		//int __cdecl jtagatlantic_flush(struct JTAGATLANTIC *)

		[DllImport("jtag_atlantic.dll",
			EntryPoint = "?jtagatlantic_flush@@YAHPAUJTAGATLANTIC@@@Z", ExactSpelling = true,
			CallingConvention = CallingConvention.Cdecl)]
		internal static extern int jtagatlantic_flush(IntPtr link);

		#endregion

		#region jtagatlantic_cable_warning
		//int __cdecl jtagatlantic_cable_warning(struct JTAGATLANTIC *)

		[DllImport("jtag_atlantic.dll",
			EntryPoint = "?jtagatlantic_cable_warning@@YAHPAUJTAGATLANTIC@@@Z", ExactSpelling = true,
			CallingConvention = CallingConvention.Cdecl)]
		internal static extern int jtagatlantic_cable_warning(IntPtr link);

		#endregion

		#region jtagatlantic_get_info
		//void __cdecl jtagatlantic_get_info(struct JTAGATLANTIC *,char const * *,int *,int *)

		[DllImport("jtag_atlantic.dll",
			EntryPoint = "?jtagatlantic_get_info@@YAXPAUJTAGATLANTIC@@PAPBDPAH2@Z", ExactSpelling = true,
			CallingConvention = CallingConvention.Cdecl)]
		internal static extern void jtagatlantic_get_info(IntPtr link, ref IntPtr chain, out int device_index, out int link_instance);

		#endregion

		#region jtagatlantic_scan_thread
		//void __cdecl jtagatlantic_scan_thread(struct JTAGATLANTIC *)

		[DllImport("jtag_atlantic.dll",
			EntryPoint = "?jtagatlantic_scan_thread@@YAXPAUJTAGATLANTIC@@@Z", ExactSpelling = true,
			CallingConvention = CallingConvention.Cdecl)]
		internal static extern void jtagatlantic_scan_thread(IntPtr link);

		#endregion

		#region jtagatlantic_get_error
		//enum JATL_ERROR __cdecl jtagatlantic_get_error(char const * *)

		[DllImport("jtag_atlantic.dll",
			EntryPoint = "?jtagatlantic_get_error@@YA?AW4JATL_ERROR@@PAPBD@Z", ExactSpelling = true,
			CallingConvention = CallingConvention.Cdecl)]
		internal static extern int jtagatlantic_get_error(ref IntPtr info);

		#endregion

		#region jtagatlantic_write

		//int __cdecl jtagatlantic_write(struct JTAGATLANTIC *,char const *,unsigned int)

		[DllImport("jtag_atlantic.dll",
			EntryPoint = "?jtagatlantic_write@@YAHPAUJTAGATLANTIC@@PBDI@Z", ExactSpelling = true,
			CallingConvention = CallingConvention.Cdecl)]
		internal static extern int jtagatlantic_write(IntPtr link, byte[] buffer, int bufferSize);

		#endregion
	}
}