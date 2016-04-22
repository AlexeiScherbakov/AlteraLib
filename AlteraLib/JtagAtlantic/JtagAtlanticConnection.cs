using System;
using System.Runtime.InteropServices;
using System.Threading;
using Altera.Quartus;

namespace Altera.JtagAtlantic
{
	/// <summary>
	/// 
	/// </summary>
	public class JtagAtlanticConnection
		: IDisposable
	{
		public const string UsbBlaster0 = "USB-Blaster [USB-0]";


		private IntPtr _handle;

		public JtagAtlanticConnection(string chain, int deviceIndex, int linkInstance, string appName)
		{
			_handle = JtagAtlanticNativeMethods.jtagatlantic_open(chain, deviceIndex, linkInstance, appName);

			if (_handle == IntPtr.Zero)
			{
				throw new Exception(
					string.Format("Cannot open {0} index={1} instance={2}", chain, deviceIndex, linkInstance));
			}
			JtagAtlanticNativeMethods.jtagatlantic_wait_open(_handle);
		}

		~JtagAtlanticConnection()
		{
			Close();
		}

		public void Dispose()
		{
			Close();
			GC.SuppressFinalize(this);
		}

		public void Close()
		{
			var handle = Interlocked.Exchange(ref _handle, IntPtr.Zero);
			if (handle != IntPtr.Zero)
			{
				JtagAtlanticNativeMethods.jtagatlantic_close(handle);
			}
		}

		public int Read(byte[] buffer)
		{
			return JtagAtlanticNativeMethods.jtagatlantic_read(_handle, buffer, buffer.Length);
		}

		public int Write(byte[] buffer)
		{
			return JtagAtlanticNativeMethods.jtagatlantic_write(_handle, buffer, buffer.Length);
		}

		public int Write(byte[] buffer, int count)
		{
			return JtagAtlanticNativeMethods.jtagatlantic_write(_handle, buffer, count);
		}

		public int BytesAvaliable()
		{
			return JtagAtlanticNativeMethods.jtagatlantic_bytes_available(_handle);
		}

		public int Flush()
		{
			return JtagAtlanticNativeMethods.jtagatlantic_flush(_handle);
		}

		public void GetInfo(out string chain, out int device_index, out int link_instance)
		{
			IntPtr param = IntPtr.Zero;
			JtagAtlanticNativeMethods.jtagatlantic_get_info(_handle, ref param, out device_index, out link_instance);
			chain = Marshal.PtrToStringAnsi(param);
		}

		public static int GetError(out string error)
		{
			IntPtr buffer = IntPtr.Zero;
			int ret = JtagAtlanticNativeMethods.jtagatlantic_get_error(ref buffer);
			error = Marshal.PtrToStringAnsi(buffer);
			return ret;
		}

		public static void PreloadLibrary()
		{
			NativeMethods.LoadLibrary(QuartusConfig.JtagAtlanticLibrary);
		}
	}
}