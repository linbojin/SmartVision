using System;
using System.Runtime.InteropServices;

namespace IPCamera
{
	/// <summary>
	/// Win32API函数
	/// </summary>
	public class Win32
	{
		// GetSystemMetrics - 获取系统屏幕尺寸和配置信息
		[DllImport("user32.dll")]
		public static extern int GetSystemMetrics( [MarshalAs(UnmanagedType.I4)] SystemMetrics metric);

		// 系统屏幕信息
		public enum SystemMetrics
		{
			CXSCREEN	= 0,
			CYSCREEN	= 1,
			CYCAPTION	= 4,
			CYMENU		= 15,
			CXFRAME		= 32,
			CYFRAME		= 33
		}
	}
}
