using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace wpltom3u
{
	class Program
	{
		#region Win32 Declarations
		/// <summary>
		/// Includes all Win32 API declarations required for this application
		/// </summary>
		private class Win32
		{
			[DllImport("kernel32.dll")]
			public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName,
				string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);

			[DllImport("kernel32.dll")]
			public static extern bool WritePrivateProfileString(string lpAppName,
				string lpKeyName, IntPtr lpString, string lpFileName);

			[DllImport("WMVCore.dll", EntryPoint = "WMCreateEditor", SetLastError = true,
				 CharSet = CharSet.Unicode, ExactSpelling = true,
				 CallingConvention = CallingConvention.StdCall)]
			public static extern uint WMCreateEditor(
				[Out, MarshalAs(UnmanagedType.Interface)] out IWMMetadataEditor ppMetadataEditor);

			[Guid("96406BD9-2B2B-11d3-B36B-00C04F6108FF"),
			InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
			public interface IWMMetadataEditor
			{
				uint Open([In, MarshalAs(UnmanagedType.LPWStr)] string pwszFilename);
				uint Close();
				uint Flush();

			}

			[Guid("15CC68E3-27CC-4ecd-B222-3F5D02D80BD5"),
			InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
			public interface IWMHeaderInfo3
			{
				uint GetAttributeCount(
					[In]									ushort wStreamNum,
					[Out]									out ushort pcAttributes);

				uint GetAttributeByIndex(
					[In]									ushort wIndex,
					[Out, In]								ref ushort pwStreamNum,
					[Out, MarshalAs(UnmanagedType.LPWStr)]	string pwszName,
					[Out, In]								ref ushort pcchNameLen,
					[Out]									out WMT_ATTR_DATATYPE pType,
					[Out, MarshalAs(UnmanagedType.LPArray)]	byte[] pValue,
					[Out, In]								ref ushort pcbLength);

				//uint GetAttributeByName(
				//    [Out, In]								ref ushort pwStreamNum,
				//    [Out, MarshalAs(UnmanagedType.LPWStr)]	string pszName,
				//    [Out]									out WMT_ATTR_DATATYPE pType,
				//    [Out, MarshalAs(UnmanagedType.LPArray)]	byte[] pValue,
				//    [Out, In]								ref ushort pcbLength);

				uint GetAttributeByName(
					[Out, In]								ref ushort pwStreamNum,
					[Out, MarshalAs(UnmanagedType.LPWStr)]	string pszName,
					[Out]									out WMT_ATTR_DATATYPE pType,
					[In]									IntPtr pValue,
					[Out, In]								ref ushort pcbLength);

				//uint SetAttribute(
				//	[In]									ushort wStreamNum,
				//	[In, MarshalAs(UnmanagedType.LPWStr)]	string pszName,
				//	[In]									WMT_ATTR_DATATYPE Type,
				//	[In, MarshalAs(UnmanagedType.LPArray)]	byte[] pValue,
				//	[In]									ushort cbLength);

				uint SetAttribute(
					[In]									ushort wStreamNum,
					[In, MarshalAs(UnmanagedType.LPWStr)]	string pszName,
					[In]									WMT_ATTR_DATATYPE Type,
					[In]									IntPtr pValue,
					[In]									ushort cbLength);

				uint GetMarkerCount(
					[Out]									out ushort pcMarkers);

				uint GetMarker(
					[In]									ushort wIndex,
					[Out, MarshalAs(UnmanagedType.LPWStr)]	string pwszMarkerName,
					[Out, In]								ref ushort pcchMarkerNameLen,
					[Out]									out ulong pcnsMarkerTime);

				uint AddMarker(
					[In, MarshalAs(UnmanagedType.LPWStr)]	string pwszMarkerName,
					[In]									ulong cnsMarkerTime);

				uint RemoveMarker(
					[In]									ushort wIndex);

				uint GetScriptCount(
					[Out]									out ushort pcScripts);

				uint GetScript(
					[In]									ushort wIndex,
					[Out, MarshalAs(UnmanagedType.LPWStr)]	string pwszType,
					[Out, In]								ref ushort pcchTypeLen,
					[Out, MarshalAs(UnmanagedType.LPWStr)]	string pwszCommand,
					[Out, In]								ref ushort pcchCommandLen,
					[Out]									out ulong pcnsScriptTime);

				uint AddScript(
					[In, MarshalAs(UnmanagedType.LPWStr)]	string pwszType,
					[In, MarshalAs(UnmanagedType.LPWStr)]	string pwszCommand,
					[In]									ulong cnsScriptTime);

				uint RemoveScript(
					[In]									ushort wIndex);

				uint GetCodecInfoCount(
					[Out]									out uint pcCodecInfos);

				uint GetCodecInfo(
					[In]									uint wIndex,
					[Out, In]								ref ushort pcchName,
					[Out, MarshalAs(UnmanagedType.LPWStr)]	string pwszName,
					[Out, In]								ref ushort pcchDescription,
					[Out, MarshalAs(UnmanagedType.LPWStr)]	string pwszDescription,
					[Out]									out WMT_CODEC_INFO_TYPE pCodecType,
					[Out, In]								ref ushort pcbCodecInfo,
					[Out, MarshalAs(UnmanagedType.LPArray)]	byte[] pbCodecInfo);

				uint GetAttributeCountEx(
					[In]									ushort wStreamNum,
					[Out]									out ushort pcAttributes);

				uint GetAttributeIndices(
					[In]									ushort wStreamNum,
					[In, MarshalAs(UnmanagedType.LPWStr)]	string pwszName,
					[In]									ref ushort pwLangIndex,
					[Out, MarshalAs(UnmanagedType.LPArray)] ushort[] pwIndices,
					[Out, In]								ref ushort pwCount);

				//uint GetAttributeByIndexEx(
				//	[In]									ushort wStreamNum,
				//	[In]									ushort wIndex,
				//	[Out, MarshalAs(UnmanagedType.LPWStr)]	string pwszName,
				//	[Out, In]								ref ushort pwNameLen,
				//	[Out]									out WMT_ATTR_DATATYPE pType,
				//	[Out]									out ushort pwLangIndex,
				//	[Out, MarshalAs(UnmanagedType.LPArray)]	byte[] pValue,
				//	[Out, In]								ref uint pdwDataLength);

				uint GetAttributeByIndexEx(
					[In]									ushort wStreamNum,
					[In]									ushort wIndex,
					[Out, MarshalAs(UnmanagedType.LPWStr)]	string pwszName,
					[Out, In]								ref ushort pwNameLen,
					[Out]									out WMT_ATTR_DATATYPE pType,
					[Out]									out ushort pwLangIndex,
					[Out, In]								IntPtr pValue,
					[Out, In]								ref uint pdwDataLength);

				uint ModifyAttribute(
					[In]									ushort wStreamNum,
					[In]									ushort wIndex,
					[In]									WMT_ATTR_DATATYPE Type,
					[In]									ushort wLangIndex,
					[In, MarshalAs(UnmanagedType.LPArray)]	byte[] pValue,
					[In]									uint dwLength);

				uint AddAttribute(
					[In]									ushort wStreamNum,
					[In, MarshalAs(UnmanagedType.LPWStr)]	string pszName,
					[Out]									out ushort pwIndex,
					[In]									WMT_ATTR_DATATYPE Type,
					[In]									ushort wLangIndex,
					[In, MarshalAs(UnmanagedType.LPArray)]	byte[] pValue,
					[In]									uint dwLength);

				uint DeleteAttribute(
					[In]									ushort wStreamNum,
					[In]									ushort wIndex);

				uint AddCodecInfo(
					[In, MarshalAs(UnmanagedType.LPWStr)]	string pszName,
					[In, MarshalAs(UnmanagedType.LPWStr)]	string pwszDescription,
					[In]									WMT_CODEC_INFO_TYPE codecType,
					[In]									ushort cbCodecInfo,
					[In, MarshalAs(UnmanagedType.LPArray)]	byte[] pbCodecInfo);
			}

			[StructLayout(LayoutKind.Sequential, Pack = 1)]
			public struct WMPicture
			{
				public IntPtr pwszMIMEType;
				public byte bPictureType;
				public IntPtr pwszDescription;
				[MarshalAs(UnmanagedType.U4)]
				public int dwDataLen;
				public IntPtr pbData;
			}

			public enum WMT_ATTR_DATATYPE
			{
				WMT_TYPE_DWORD = 0,
				WMT_TYPE_STRING = 1,
				WMT_TYPE_BINARY = 2,
				WMT_TYPE_BOOL = 3,
				WMT_TYPE_QWORD = 4,
				WMT_TYPE_WORD = 5,
				WMT_TYPE_GUID = 6,
			}

			public enum WMT_CODEC_INFO_TYPE
			{
				WMT_CODECINFO_AUDIO = 0,
				WMT_CODECINFO_VIDEO = 1,
				WMT_CODECINFO_UNKNOWN = 0xffffff
			}

			public static readonly int NS_E_INVALID_REQUEST = -1072889813;
			public static readonly int NS_E_ATTRIBUTE_READ_ONLY = -1072886826;
		}

		#endregion

		static void Main(string[] args)
		{
			try
			{
				if(args.Length != 1) throw new Exception("Invalid command line");
				string source = args[0];
				string dest = Path.Combine(Path.GetDirectoryName(source), Path.GetFileNameWithoutExtension(source)) + ".m3u";
				ConvertWplToM3u(source, dest);
			}
			catch(Exception ex)
			{
				Console.WriteLine("\r\nERROR: " + ex.Message);
			}
		}

		private static void ConvertWplToM3u(string wplfile, string m3ufile)
		{
			XmlDocument			wpl;				// The WPL XML document
			XmlNodeList			wpltracks;			// All tracks in the WPL file

			wpl = new XmlDocument();
			wpl.Load(wplfile);

			using (StreamWriter sw = new StreamWriter(File.Open(m3ufile, FileMode.Create)))
			{
				sw.WriteLine("#EXTM3U");

				wpltracks = wpl.DocumentElement.SelectNodes("/smil/body/seq/media");
				foreach (XmlNode wpltrack in wpltracks)
				{
					string filename = wpltrack.Attributes["src"].InnerText;

					try
					{
						Win32.IWMMetadataEditor		editor;		// WMA editor
						Win32.IWMHeaderInfo3		header;		// WMA header

						Win32.WMCreateEditor(out editor);
						try
						{
							editor.Open(filename);
							header = (Win32.IWMHeaderInfo3)editor;
							string albumArtist = GetStringTag(header, @"WM/AlbumArtist");
							string trackTitle = GetStringTag(header, @"Title");
							long duration = GetTrackDuration(header);
							duration = duration / 10000000;

							sw.WriteLine("#EXTINF:" + duration.ToString() + "," + albumArtist + " - " + trackTitle);
						}
						finally { editor.Close(); }
					}
					catch { /* JUST DON'T WRITE AN #EXTINF FOR THIS FILE */ }

					sw.WriteLine(filename);			// Always write out the file name
				}

				sw.Flush();							// Flush the output file
			}
		}

		/// <summary>
		/// Retrieves a string from a header
		/// </summary>
		/// <param name="wma">WMA file instance being edited</param>
		private static string GetStringTag(Win32.IWMHeaderInfo3 wma, string attribute)
		{
			ushort stream = 0;						// Stream number
			IntPtr ptData;							// Data buffer pointer
			ushort cbData = 0;						// Length of data buffer
			Win32.WMT_ATTR_DATATYPE type;			// Attribute type

			// Determine the size of the buffer we need to allocate and then go get the attribute

			string ATTR = attribute + "\0";
			try { wma.GetAttributeByName(ref stream, ATTR, out type, IntPtr.Zero, ref cbData); }
			catch { return null; }

			if (type != Win32.WMT_ATTR_DATATYPE.WMT_TYPE_STRING) return null;
			ptData = Marshal.AllocCoTaskMem((int)cbData);

			try
			{
				wma.GetAttributeByName(ref stream, ATTR, out type, ptData, ref cbData);
				return Marshal.PtrToStringUni(ptData);
			}

			finally { Marshal.FreeCoTaskMem(ptData); }	// Release allocated memory
		}

		/// <summary>
		/// Retrieves the Duration from a header
		/// </summary>
		/// <param name="wma">WMA file instance being edited</param>
		private static long GetTrackDuration(Win32.IWMHeaderInfo3 wma)
		{
			ushort stream = 0;			// Stream number
			IntPtr ptData;				// Data buffer pointer
			ushort cbData = 0;			// Length of data buffer
			Win32.WMT_ATTR_DATATYPE type;				// Attribute type

			// Determine the size of the buffer we need to allocate, and of course if the
			// WM/TrackNumber attribute even exists in this header

			const string ATTR = "Duration\0";
			try { wma.GetAttributeByName(ref stream, ATTR, out type, IntPtr.Zero, ref cbData); }
			catch { return 0; }

			ptData = Marshal.AllocCoTaskMem((int)cbData);

			try
			{
				wma.GetAttributeByName(ref stream, ATTR, out type, ptData, ref cbData);

				switch (type)
				{
					case Win32.WMT_ATTR_DATATYPE.WMT_TYPE_DWORD:
						return (long)Marshal.ReadInt32(ptData);

					case Win32.WMT_ATTR_DATATYPE.WMT_TYPE_QWORD:
						return Marshal.ReadInt64(ptData);

					case Win32.WMT_ATTR_DATATYPE.WMT_TYPE_STRING:
						return Convert.ToInt64(Marshal.PtrToStringUni(ptData));

					default:
						throw new Exception("Unknown Duration data type detected");
				}
			}

			finally { Marshal.FreeCoTaskMem(ptData); }	// Release allocated memory
		}
	}
}
