//---------------------------------------------------------------------------
// MainForm.cs
//
// Windows Media Player Library Cleanup Tool
//
// Copyright (C)2007 Michael Brehm
// All Rights Reserved
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace wmpclean
{
	public partial class MainForm : Form
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

		/// <summary>
		/// Instance Constructor
		/// </summary>
		public MainForm() { InitializeComponent(); }

		//-------------------------------------------------------------------------
		// Control Event Handlers
		//-------------------------------------------------------------------------

		/// <summary>
		/// Invoked when the state of "Add Album Art" has changed
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">Standard event arguments</param>
		private void OnAddArtworkChanged(object sender, EventArgs args)
		{
			m_addArtwork = m_replaceAlbumArt.Checked;
			EnableDisableClean();
		}

		/// <summary>
		/// Invoked when the user clicks on the "..." browse button
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">Standard event arguments</param>
		private void OnBrowseForLibraryLocation(object sender, EventArgs args)
		{
			if (m_folderBrowser.ShowDialog(this) == DialogResult.OK)
				m_mediaFolder.Text = m_folderBrowser.SelectedPath;
		}

		/// <summary>
		/// Invoked when the user clicks on the CLEAN button
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">Standard event arguments</param>
		private void OnClean(object sender, EventArgs args)
		{
			Thread				worker;			// The worker thread

			if (m_replaceArtists)
			{
				DialogResult res = MessageBox.Show(this, "You have selected to replace the \"Artist\" tags " +
					"of all tracks with the \"WM/AlbumArtist\" tags.  This operation cannot be undone, and " +
					"a restore from backup may be necessary to replace that information.\r\n\r\nContinue Processing?",
					"Permanent Track Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (res != DialogResult.Yes) return;
			}

			if (m_rollupGenres)
			{
				DialogResult res = MessageBox.Show(this, "You have selected to roll up the \"WM/Genre\" tags " +
					"of all tracks to a more generic level.  This operation cannot be undone, and " +
					"a restore from backup may be necessary to replace that information.\r\n\r\nContinue Processing?",
					"Permanent Track Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (res != DialogResult.Yes) return;
			}

			m_optionsGroup.Enabled = false;
			m_validationGroup.Enabled = false;
			m_replayGainGroup.Enabled = false;
			m_clean.Enabled = false;
			m_canClose = false;
			m_selectTypical.Enabled = false;
			m_selectAllValidations.Enabled = false;
			m_clearAllSafe.Enabled = false;
			m_mediaFolder.Enabled = false;
			m_browseForMediaFolder.Enabled = false;
			m_staticLibraryLocation.Enabled = false;
			m_scanGroup.Enabled = false;

			// Fire off the worker thread and get cracking here ...

			worker = new Thread(WorkerThreadProc);
			worker.IsBackground = true;
			worker.Priority = ThreadPriority.BelowNormal;
			worker.SetApartmentState(ApartmentState.STA);
			worker.Start();
		}

		private void OnClearAllOptions(object sender, LinkLabelLinkClickedEventArgs args)
		{
			foreach (Control c in this.Controls)
			{
				if (c is GroupBox)
				{
					foreach (Control gc in c.Controls)
					{
						if ((gc is CheckBox) && (gc != m_rgainPreventClip)) ((CheckBox)gc).Checked = false;
					}
				}
			}
		}

		/// <summary>
		/// Invoked when the user attempts to close the form
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">FormClosing event arguments</param>
		private void OnFormClosing(object sender, FormClosingEventArgs args)
		{
			if (args.CloseReason != CloseReason.UserClosing) return;

			// I'm not interested in making the worker thread aware enough to shut down cleanly,
			// so this is what the user gets instead ... gotta love cheesy utility apps

			if (!m_canClose) args.Cancel = (MessageBox.Show(this, "Closing Windows Media Player Cleanup " +
				"while the scanner is running can possibly result in media file corruption.\r\n\r\n" +
				"Close Windows Media Player Library Cleanup?", "Windows Media Player Library Cleanup Tool",
				 MessageBoxButtons.YesNo, MessageBoxIcon.Error) != DialogResult.Yes);
		}

		/// <summary>
		/// Invoked when the form has been loaded for the first time
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">Standard event arguments</param>
		private void OnFormLoad(object sender, EventArgs args)
		{
			Version asmVersion = this.GetType().Assembly.GetName().Version;
			this.Text = String.Format(this.Text, "v" + asmVersion.ToString(2));
		}

		/// <summary>
		/// Invoked when the state of "Generate Album Name and Artist tags" has changed
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">Standard event arguments</param>
		private void OnGenerateAlbumTagsChanged(object sender, EventArgs args)
		{
			m_generateAlbumTags = m_generateMissingAlbumTags.Checked;
			EnableDisableClean();
		}

		/// <summary>
		/// Invoked when the state of "Generate Album Name and Artist tags" has changed
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">Standard event arguments</param>
		private void OnGenerateWmTrackNumbersChanged(object sender, EventArgs args)
		{
			m_genWmTrackNumbers = m_generateMissingWMTrackNumberTags.Checked;
			EnableDisableClean();
		}

		/// <summary>
		/// Invoked when the contents of the media library location changes
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">Standard event arguments</param>
		private void OnLibraryLocationChanged(object sender, EventArgs args)
		{
			m_mediaPath = m_mediaFolder.Text;		// Save the path string
			EnableDisableClean();					// Update CLEAN button state
		}

		/// <summary>
		/// Invoked when the state of "Remove Album Art" has changed
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">Standard event arguments</param>
		private void OnRemoveArtworkChanged(object sender, EventArgs args)
		{
			m_removeArtwork = m_removeAlbumArt.Checked;
			EnableDisableClean();
		}

		/// <summary>
		/// Invoked when the state of the "Remove Tags" has changed
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">Standard event arguments</param>
		private void OnRemoveCollectionTagsChanged(object sender, EventArgs args)
		{
			m_removeTags = m_removeCollectionTags.Checked;
			EnableDisableClean();
		}

		/// <summary>
		/// Invoked when the state of "Remove Replay Gain" has changed
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">Standard event arguments</param>
		private void OnRemoveReplayGain(object sender, EventArgs args)
		{
			m_removeReplayGain = m_undoReplayGainChanges.Checked;
			EnableDisableClean();
		}

		/// <summary>
		/// Invoked when the state of "Remove Album Art" has changed
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">Standard event arguments</param>
		private void OnRemoveVolumeLevelingChanged(object sender, EventArgs args)
		{
			m_removeLeveling = m_removeVolumeLevelingTags.Checked;
			EnableDisableClean();
		}

		/// <summary>
		/// Invoked when the state of "Replace Artist with Album Artist" has changed
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">Standard event arguments</param>
		private void OnReplaceArtistTagsChanged(object sender, EventArgs args)
		{
			m_replaceArtists = m_replaceArtistWithAlbumArtist.Checked;
			EnableDisableClean();
		}

		/// <summary>
		/// Invoked when the state of "Remove Album Art" has changed
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">Standard event arguments</param>
		private void OnReplayGainChanged(object sender, EventArgs args)
		{
			m_replayGain = m_applyReplayGain.Checked;
			m_gainLowRadio.Enabled = m_replayGain;
			m_gainMediumRadio.Enabled = m_replayGain;
			m_gainHighRadio.Enabled = m_replayGain;
			m_gainVeryHighRadio.Enabled = m_replayGain;
			m_rgainPreventClip.Enabled = m_replayGain;
			m_rgainModeGroup.Enabled = m_replayGain;
			EnableDisableClean();
		}

		/// <summary>
		/// Invoked when the state of "Roll up Genres" has changed
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">Standard event arguments</param>
		private void OnRollupGenresChanged(object sender, EventArgs args)
		{
			m_rollupGenres = m_rollupGracenoteGenres.Checked;
			EnableDisableClean();
		}

		/// <summary>
		/// Invoked when the state of "Validate Audio Stream" has changed
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">Standard event arguments</param>
		private void OnScanAudioStreamChanged(object sender, EventArgs args)
		{
			m_scanAudio = m_scanAudioStream.Checked;
			EnableDisableClean();
		}

		private void OnSelectAllSafeOptions(object sender, LinkLabelLinkClickedEventArgs args)
		{
			foreach (Control c in m_optionsGroup.Controls)
			{
				// Remove track tags and replace artist are not safe
				if ((c is CheckBox) && (c != m_replaceArtistWithAlbumArtist) && 
					(c != m_undoReplayGainChanges) && (c != m_rollupGracenoteGenres))
				{
					((CheckBox)c).Checked = true;
				}
			}
			foreach (Control c in m_validationGroup.Controls)
			{
				if (c is CheckBox) ((CheckBox)c).Checked = true;
			}
		}

		private void OnSelectAllValidations(object sender, LinkLabelLinkClickedEventArgs args)
		{
			foreach (Control c in m_validationGroup.Controls)
			{
				if (c is CheckBox) ((CheckBox)c).Checked = true;
			}
		}

		/// <summary>
		/// Invoked when the state of "Validate Album Art" has changed
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">Standard event arguments</param>
		private void OnValidateAlbumArtChanged(object sender, EventArgs args)
		{
			m_verifyArt = m_verifyArtworkExists.Checked;
			EnableDisableClean();
		}

		/// <summary>
		/// Invoked when the state of "Validate Album Name and Artist tags" has changed
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">Standard event arguments</param>
		private void OnValidateAlbumTagsChanged(object sender, EventArgs args)
		{
			m_validateTags = m_validateTagsAgainstFolder.Checked;
			EnableDisableClean();
		}

		/// <summary>
		/// Invoked when the state of the "Validate author tags" has changed
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">Standard event arguments</param>
		private void OnValidateAuthorTagsChanged(object sender, EventArgs args)
		{
			m_verifyAuthors = m_verifyNoVariousArtistAuthors.Checked;
			EnableDisableClean();
		}

		/// <summary>
		/// Invoked when the state of "Validate Track Length" has changed
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">Standard event arguments</param>
		private void OnValidateTrackFileNames(object sender, EventArgs args)
		{
			m_verifyFileNames = m_checkFileNamesConformant.Checked;
			EnableDisableClean();
		}

		/// <summary>
		/// Invoked when the state of "Validate Track Genres" has changed
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">Standard event arguments</param>
		private void OnValidateTrackGenresChanged(object sender, EventArgs args)
		{
			m_verifyGenres = m_verifyGenresCDDBCompliant.Checked;
			EnableDisableClean();
		}

		/// <summary>
		/// Invoked when the state of "Validate Track Numbers" has changed
		/// </summary>
		/// <param name="sender">Object raising this event</param>
		/// <param name="args">Standard event arguments</param>
		private void OnValidateTrackNumbersChanged(object sender, EventArgs args)
		{
			m_validateTracks = m_validateTrackNumbers.Checked;
			EnableDisableClean();
		}

		//-------------------------------------------------------------------------
		// Private Member Functions
		//-------------------------------------------------------------------------

		/// <summary>
		/// Enables or disables the CLEAN button
		/// </summary>
		private void EnableDisableClean()
		{
			bool			enable = true;			// Flag to enable the button

			if (!Directory.Exists(m_mediaPath)) enable = false;
			if ((!m_removeArtwork) && (!m_addArtwork) && (!m_removeTags) && (!m_validateTags) &&
				(!m_validateTracks) && (!m_generateAlbumTags) && (!m_verifyFileNames) && (!m_verifyArt) &&
				(!m_removeLeveling) && (!m_replaceArtists) && (!m_verifyAuthors) &&
				(!m_genWmTrackNumbers) && (!m_scanAudio) && (!m_replayGain) && (!m_removeReplayGain) && 
				(!m_verifyGenres) && (!m_rollupGenres)) 
				enable = false;

			m_clean.Enabled = enable;				// Enable or disable the button
		}

		/// <summary>
		/// Allocates and initializes a WMPicture structure from a disk file image
		/// </summary>
		/// <param name="pictureType">Picture Type Code</param>
		/// <param name="mimeType">Picture MIME type string</param>
		/// <param name="description">Picture description</param>
		/// <param name="fileName">Picture source file name</param>
		/// <param name="picture">Returns the new picture structure instance</param>
		private void AllocWMPicture(byte pictureType, string mimeType, string description, 
			string fileName, out Win32.WMPicture picture)
		{
			picture = new Win32.WMPicture();		// Allocate and initialize structure

			// Go get the file and change it into an array of bytes for Marshal to munch on
			// (This is so silly - why didn't I do this in C++ and be done much faster??)

			Image image = Image.FromFile(fileName);
			byte[] imageBits = (byte[])(new ImageConverter().ConvertTo(image, typeof(byte[])));

			try
			{
				picture.bPictureType = pictureType;
				picture.dwDataLen = imageBits.Length;
				picture.pbData = Marshal.AllocCoTaskMem(imageBits.Length); ;
				Marshal.Copy(imageBits, 0, picture.pbData, imageBits.Length);
				picture.pwszDescription = Marshal.StringToCoTaskMemUni(description + "\0");
				picture.pwszMIMEType = Marshal.StringToCoTaskMemUni(mimeType + "\0");

			}
			catch { FreeWMPicture(ref picture); throw; }
		}

		/// <summary>
		/// Embeds a new piece of Album Cover Art into a WMA file
		/// </summary>
		/// <param name="wma">WMA file instance being edited</param>
		/// <param name="art">WMPicture indicating the new album art to embed</param>
		private void EmbedNewAlbumArt(Win32.IWMHeaderInfo3 wma, Win32.WMPicture art)
		{
			// Allocate some unmanaged buffer space to throw at the Media API ..

			IntPtr ptAttribute = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(Win32.WMPicture)));
			
			try
			{
				Marshal.StructureToPtr(art, ptAttribute, false);	// Convert to unmanaged
				wma.SetAttribute(0, "WM/Picture\0", Win32.WMT_ATTR_DATATYPE.WMT_TYPE_BINARY, 
					ptAttribute, (ushort)Marshal.SizeOf(typeof(Win32.WMPicture)));
			}
			
			finally { Marshal.FreeCoTaskMem(ptAttribute); }
		}

		/// <summary>
		/// Releases the contents of a WMPicture allocated with AllocWMPicture.  Note that
		/// the structure is passed by value, so don't use it after you call this :)
		/// </summary>
		/// <param name="picture">Reference to an existing WMPicture structure</param>
		private void FreeWMPicture(ref Win32.WMPicture picture)
		{
			picture.bPictureType = 0;
			picture.dwDataLen = 0;
			Marshal.FreeCoTaskMem(picture.pbData);
			Marshal.FreeCoTaskMem(picture.pwszDescription);
			Marshal.FreeCoTaskMem(picture.pwszMIMEType);
		}

		/// <summary>
		/// Retrieves a string from a header
		/// </summary>
		/// <param name="wma">WMA file instance being edited</param>
		private string GetStringTag(Win32.IWMHeaderInfo3 wma, string attribute)
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
		private long GetTrackDuration(Win32.IWMHeaderInfo3 wma)
		{
			ushort					stream = 0;			// Stream number
			IntPtr					ptData;				// Data buffer pointer
			ushort					cbData = 0;			// Length of data buffer
			Win32.WMT_ATTR_DATATYPE type;				// Attribute type

			// Determine the size of the buffer we need to allocate, and of course if the
			// WM/TrackNumber attribute even exists in this header

			const string ATTR = "Duration\0";
			try { wma.GetAttributeByName(ref stream, ATTR, out type, IntPtr.Zero, ref cbData); }
			catch { return -1; }

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

		/// <summary>
		/// Retrieves the track number from a header
		/// </summary>
		/// <param name="wma">WMA file instance being edited</param>
		private int GetTrackNumber(Win32.IWMHeaderInfo3 wma)
		{
			ushort stream = 0;			// Stream number
			IntPtr ptData;				// Data buffer pointer
			ushort cbData = 0;			// Length of data buffer
			Win32.WMT_ATTR_DATATYPE type;				// Attribute type
			string track;

			// Determine the size of the buffer we need to allocate, and of course if the
			// WM/Track attribute even exists in this header

			const string PRIMARY_ATTR = "WM/TrackNumber\0";
			const string SECONDARY_ATTR = "WM/Track\0";
			string ATTR = PRIMARY_ATTR;

			bool found = true;
			try { wma.GetAttributeByName(ref stream, ATTR, out type, IntPtr.Zero, ref cbData); }
			catch { found = false; }

			if (!found)
			{
				found = true;
				ATTR = SECONDARY_ATTR;
				try { wma.GetAttributeByName(ref stream, ATTR, out type, IntPtr.Zero, ref cbData); }
				catch { found = false; }
			}
			
			if (!found) return -1;

			ptData = Marshal.AllocCoTaskMem((int)cbData);

			try
			{
				wma.GetAttributeByName(ref stream, ATTR, out type, ptData, ref cbData);

				switch (type)
				{
					case Win32.WMT_ATTR_DATATYPE.WMT_TYPE_DWORD:
						return (int)Marshal.ReadInt32(ptData);

					case Win32.WMT_ATTR_DATATYPE.WMT_TYPE_STRING:
						// Get rid of the annoying slash
						track = Marshal.PtrToStringUni(ptData);
						if (track.Contains("/")) track = track.Substring(0, track.IndexOf('/'));
						try { return Convert.ToInt32(track); }
						catch (Exception) { return -1; }

					default:
						throw new Exception("Unknown track tag data type detected");
				}
			}

			finally { Marshal.FreeCoTaskMem(ptData); }	// Release allocated memory
		}

		/// <summary>
		/// Retrieves the track number from a header
		/// </summary>
		/// <param name="wma">WMA file instance being edited</param>
		private int GetTrackNumber_Old(Win32.IWMHeaderInfo3 wma)
		{
			ushort					stream = 0;			// Stream number
			IntPtr					ptData;				// Data buffer pointer
			ushort					cbData = 0;			// Length of data buffer
			Win32.WMT_ATTR_DATATYPE type;				// Attribute type

			// Determine the size of the buffer we need to allocate, and of course if the
			// WM/TrackNumber attribute even exists in this header

			const string ATTR = "WM/TrackNumber\0";
			try { wma.GetAttributeByName(ref stream, ATTR, out type, IntPtr.Zero, ref cbData); }
			catch { return -1; }

			ptData = Marshal.AllocCoTaskMem((int)cbData);

			try
			{
				wma.GetAttributeByName(ref stream, ATTR, out type, ptData, ref cbData);

				switch (type)
				{
					case Win32.WMT_ATTR_DATATYPE.WMT_TYPE_DWORD:
						return (int)Marshal.ReadInt32(ptData);

					case Win32.WMT_ATTR_DATATYPE.WMT_TYPE_STRING:
						try { return Convert.ToInt32(Marshal.PtrToStringUni(ptData)); }
						catch (Exception) { return -1; }

					default:
						throw new Exception("Unknown WM/TrackNumber data type detected");
				}
			}
			
			finally { Marshal.FreeCoTaskMem(ptData); }	// Release allocated memory
		}

		/// <summary>
		/// Determines if any 'author' tags have 'Various Artists' or 'Soundtrack' set
		/// </summary>
		/// <param name="wma">Header for the media file to be checked</param>
		/// <returns>True/False flag</returns>
		private bool HasVariousArtists(Win32.IWMHeaderInfo3 wma)
		{
			ushort		cAttributes;				// Attribute count
			bool		has = false;

			wma.GetAttributeCountEx(0xFFFF, out cAttributes);
			for (ushort wAttribIndex = 0; wAttribIndex < cAttributes; wAttribIndex++)
			{
				Win32.WMT_ATTR_DATATYPE wAttribType;
				ushort wLangIndex = 0;
				string pwszAttribName = null;
				IntPtr pbAttribValue = IntPtr.Zero;
				ushort wAttribNameLen = 0;
				uint dwAttribValueLen = 0;

				// Make the intial call to GetAttributeByIndexEx, which will give us the
				// data buffer sizes we need to create to call it more successfully

				wma.GetAttributeByIndexEx(0xFFFF, wAttribIndex, pwszAttribName, ref wAttribNameLen,
					  out wAttribType, out wLangIndex, pbAttribValue, ref dwAttribValueLen);

				pwszAttribName = new String((char)0, wAttribNameLen);             // Allocate managed
				pbAttribValue = Marshal.AllocCoTaskMem((int)dwAttribValueLen);    // Allocate unmanaged
				
				try
				{
					// Make the call for real now that we have some buffers to back it up.

					wma.GetAttributeByIndexEx(0xFFFF, wAttribIndex, pwszAttribName, ref wAttribNameLen,
						  out wAttribType, out wLangIndex, pbAttribValue, ref dwAttribValueLen);

					// We only care about certain attributes in this particular function
					if (String.Compare(pwszAttribName, "Author\0", StringComparison.OrdinalIgnoreCase) == 0)
					{
						string value = Marshal.PtrToStringUni(pbAttribValue);
						if ((String.Compare(value, "Various Artists", StringComparison.OrdinalIgnoreCase) == 0) ||
							  (String.Compare(value, "Soundtrack", StringComparison.OrdinalIgnoreCase) == 0))
						{
							has = true;
						}
					}
				}

				finally { Marshal.FreeCoTaskMem(pbAttribValue); }
			}

			return has;
		}

		/// <summary>
		/// Normalizes a tag string to create a valid file system name instead
		/// </summary>
		/// <param name="wmaName">String to be normalized</param>
		/// <returns>Normalized string</returns>
		private string NormalizeToFileSystemName(string wmaName)
		{
			if (String.IsNullOrEmpty(wmaName)) return null;		// NULL in, NULL out

			wmaName = wmaName.TrimEnd(new char[] { '.' });
			wmaName = wmaName.Replace('\"', '\'');
			wmaName = wmaName.Replace('>', ']');
			wmaName = wmaName.Replace('<', '[');
			foreach (char badchar in Path.GetInvalidFileNameChars()) wmaName = wmaName.Replace(badchar, '-');

			return wmaName.TrimEnd(new char[]{'.', ' '});
		}
		
		/// <summary>
		/// Invoked when the CLEAN operation has completed
		/// </summary>
		/// <param name="ex">Optional exception that stopped the scanner</param>
		/// <param name="validationFile">If not NULL, indicates a validation error file</param>
		private void OnCleanFinished(Exception ex, string validationFile)
		{
			m_canClose = true;						// App can be closed now
			m_clean.Enabled = true;					// Re-enable the button
			m_optionsGroup.Enabled = true;			// Re-enable the options group
			m_validationGroup.Enabled = true;		// Re-enable validation group
			m_replayGainGroup.Enabled = true;
			m_selectTypical.Enabled = true;
			m_selectAllValidations.Enabled = true;
			m_clearAllSafe.Enabled = true;
			m_mediaFolder.Enabled = true;
			m_browseForMediaFolder.Enabled = true;
			m_staticLibraryLocation.Enabled = true;
			m_scanGroup.Enabled = true;
			m_currentFolder.Text = String.Empty;	// Clear out the status label

			// Cheesy ...
			if (ex != null) MessageBox.Show(this, ex.Message, "Windows Media Player Library Cleanup Tool");

			// Even Cheesier ...
			if (!String.IsNullOrEmpty(validationFile))
			{
				Process notepad = new Process();
				notepad.StartInfo.Arguments = validationFile;
				notepad.StartInfo.FileName = "notepad.exe";
				notepad.StartInfo.UseShellExecute = true;
				notepad.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
				notepad.Start();
			}
		}

		/// <summary>
		/// Invoked when the CLEAN operation has a progress message for us
		/// </summary>
		/// <param name="message"></param>
		private void OnUpdateProgress(string message)
		{
			m_currentFolder.Text = message;			// Update the message
		}

		/// <summary>
		/// Processes a single folder in the media library.  Recursive.  Totally hideous.
		/// Not a production application, and I don't really care.
		/// </summary>
		/// <param name="folder">Current folder name to process</param>
		/// <param name="validationOutput">Output stream for validation issues</param>
		/// <param name="hasValidations">Boolean to indicate validation issues</param>
		private void ProcessFolder(string folder, StreamWriter validationOutput, ref bool hasValidations)
		{
			Win32.WMPicture			albumArt = new Win32.WMPicture();	// New Album Artwork
			bool					albumArtValid = false;				// Flag if albumArt is valid
			Win32.IWMMetadataEditor	editor = null;						// Editor instance
			Win32.IWMHeaderInfo3	header = null;						// Header instance
			string					current = folder;					// Current location
			bool					flush = false;						// Flush flag
			string					parentArtist = null;				// Parent artist name
			string					parentAlbum = null;					// Parent album name

			try
			{
				// First deal with all of the child folders underneath this folder
				foreach (string child in Directory.GetDirectories(folder)) 
					ProcessFolder(child, validationOutput, ref hasValidations);

				// Let the UI know what folder we're currently working with here
				this.Invoke(new UpdateProgressHandler(OnUpdateProgress), new object[] { folder });

				//
				// REMOVE MUSICBUYURL FROM DESKTOP.INI
				//

				if (m_removeTags)
				{
					string desktopIni = Path.Combine(folder, "desktop.ini");
					if (File.Exists(desktopIni) && ((File.GetAttributes(desktopIni) & FileAttributes.ReadOnly) != FileAttributes.ReadOnly))
						Win32.WritePrivateProfileString(".ShellClassInfo", "MusicBuyUrl", IntPtr.Zero, desktopIni);
				}

				//
				// LOAD ALBUMARTLARGE.JPG / FOLDER.JPG AS NEW ALBUM ARTWORK IMAGE IF AVAILABLE
				//
				if (m_addArtwork)
				{
					string folderJpg = Path.Combine(folder, "AlbumArtLarge.jpg");
					if (!File.Exists(folderJpg)) folderJpg = Path.Combine(folder, "Folder.jpg");
					if (File.Exists(folderJpg))
					{
						AllocWMPicture(3, "image/jpeg", "AlbumArt", folderJpg, out albumArt);
						albumArtValid = true;
					}
				}

				try
				{
					//
					// PROCESS EACH WINDOWS MEDIA AUDIO FILE / MP3 FILE INDIVIDUALLY
					//
					
					List<string> filesToProcess = new List<string>();
					string[] wmas = Directory.GetFiles(folder, "*.wma");
					string[] mp3s = Directory.GetFiles(folder, "*.mp3");

					filesToProcess.AddRange(wmas);
					filesToProcess.AddRange(mp3s);

					List<int> trackNumbers = new List<int>();		// Seen track numbers
					List<string> trackNames = new List<string>();	// Seen track names

					// Get the parent album and artist folder names if we found WMA/MP3 files
					// so this information can be validated below.  Note that the folders ONLY
					// COUNT if they have the necessary DESKTOP.INI (otherwise this would be
					// very dangerous to use with the "Generate Missing Album Name / Artist tags"

					if (filesToProcess.Count > 0)
					{
						//
						// VALIDATE ALBUM ART
						//
						if (m_verifyArt)
						{
							if (!File.Exists(Path.Combine(folder, "Folder.jpg")))
							{
								hasValidations = true;
								validationOutput.WriteLine(folder);
								validationOutput.WriteLine(">> Album folder does not contain a Folder.jpg album artwork file");
								validationOutput.WriteLine();
							}
						}

						try
						{
							StringBuilder sb;

							// ALBUM NAME
							string albumIni = Path.Combine(folder, "desktop.ini");
							if (!File.Exists(albumIni))
							{
								hasValidations = true;
								validationOutput.WriteLine(folder);
								validationOutput.WriteLine(">> Album folder does not contain a desktop.ini file");
								validationOutput.WriteLine();
							}

							sb = new StringBuilder(1024);
							Win32.GetPrivateProfileString(".ShellClassInfo", "FolderType", "", sb, 1024, albumIni);
							if (String.Compare(sb.ToString(), "MusicAlbum", StringComparison.OrdinalIgnoreCase) == 0)
								parentAlbum = new DirectoryInfo(folder).Name;

							// ALBUM ARTIST
							string artistIni = Path.Combine(Directory.GetParent(folder).FullName, "desktop.ini");
							if (!File.Exists(artistIni))
							{
								hasValidations = true;
								validationOutput.WriteLine(Directory.GetParent(folder).FullName);
								validationOutput.WriteLine(">> Album Artist folder does not contain a desktop.ini file");
								validationOutput.WriteLine();
							}
							sb = new StringBuilder(1024);
							Win32.GetPrivateProfileString(".ShellClassInfo", "FolderType", "", sb, 1024, artistIni);
							if (String.Compare(sb.ToString(), "MusicArtist", StringComparison.OrdinalIgnoreCase) == 0)
								parentArtist = Directory.GetParent(folder).Name;
						}

						catch { parentAlbum = null; parentArtist = null; }	// Leave NULL on error
					}

					foreach (string wmaFile in filesToProcess)
					{
						bool fixedTrack = false;
						bool fixedAlbumTitle = false;
						bool fixedAlbumArtist = false;
						bool fixedGenre = false;

						current = wmaFile;					// Save this for exception handler

						// Skip files that are read-only, mainly because we have to. Don't try to change
						// them since this allow the user to protect certain files if they want

						if ((File.GetAttributes(wmaFile) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly) continue;

						Win32.WMCreateEditor(out editor);				// Create the editor instance
						flush = false;									// Reset flush to false

						try
						{
							editor.Open(wmaFile);						// Open the WMA media file
							header = (Win32.IWMHeaderInfo3)editor;		// QI() for IWMHeaderInfo3

							try
							{
								//
								// VALIDATE FILE NAME
								//
								if (m_verifyFileNames)
								{
									int track = GetTrackNumber(header);
									if (track != -1)
									{
										string expectedFileName = track.ToString("00") + " " +
											NormalizeToFileSystemName(GetStringTag(header, "Title")) + Path.GetExtension(wmaFile);
										if (String.Compare(expectedFileName, Path.GetFileName(wmaFile), StringComparison.OrdinalIgnoreCase) != 0)
										{
											hasValidations = true;
											validationOutput.WriteLine(wmaFile);
											validationOutput.WriteLine(">> File name expected to be [" + expectedFileName + "], auto-track number generation may fail.");
											validationOutput.WriteLine();
										}

									}
								}

								//
								// REBUILD TRACK NUMBERS
								//
								if (m_genWmTrackNumbers)
								{
									int track = GetTrackNumber(header);
									if (track == -1)
									{
										// See if we can get the track number from the file name
										try { track = Convert.ToInt32(Path.GetFileName(wmaFile).Substring(0, 2)); }
										catch { track = -1; }
									}

									// If we have found one, go ahead and replace it
									if (track != -1)
									{
										// These have to be done separately
										RemoveTags(header, new string[] { "WM/Track" });
										RemoveTags(header, new string[] { "WM/TrackNumber" });

										// Changed these to DWORDs for compatibility with Acoustica
										//SetStringTag(header, "WM/Track", track.ToString());
										//SetStringTag(header, "WM/TrackNumber", track.ToString());
										SetDwordTag(header, "WM/Track", track);
										SetDwordTag(header, "WM/TrackNumber", track);

										flush = true;
										fixedTrack = true;
									}
								}

								//
								// REMOVE EXISTING ALBUM COVER ART
								//
								if (m_removeArtwork)
								{
									RemoveExistingAlbumArt(header);
									flush = true;
								}

								//
								// REMOVE PROVIDER AND WINDOWS MEDIA COLLECTION TAGS
								//
								if (m_removeTags)
								{
									RemoveTags(header, new string[] {"WM/UniqueFileIdentifier", "WM/Provider",
										"WM/ProviderCopyright", "WM/ProviderStyle", "WM/ProviderRating", "WM/WMContentID",
										"WM/WMCollectionID", "WM/WMCollectionGroupID"});
									flush = true;

									// Nuke the provider-specific album art files (the ones with the GUID)

									foreach (string providerArtFile in Directory.GetFiles(folder, "AlbumArt_{*.jpg"))
									{
										if ((File.GetAttributes(providerArtFile) & FileAttributes.ReadOnly) != FileAttributes.ReadOnly)
											File.Delete(providerArtFile);
									}
								}

								//
								// REMOVE VOLUME LEVELING TAGS
								//
								if (m_removeLeveling)
								{
									RemoveTags(header, new string[] { "PeakValue", "AverageLevel" });
									flush = true;
								}

								//
								// EMBED NEW ALBUM COVER ART
								//
								if (m_addArtwork && albumArtValid)
								{
									EmbedNewAlbumArt(header, albumArt);
									flush = true;
								}

								//
								// GENERATE MISSING ALBUM NAME AND ALBUM ARTIST TAGS
								//
								
								if (m_generateAlbumTags)
								{
									// If there is no Album Name tag, add it if possible
									if ((GetStringTag(header, "WM/AlbumTitle") == null) && (!String.IsNullOrEmpty(parentAlbum)))
									{
										SetStringTag(header, "WM/AlbumTitle", parentAlbum);
										fixedAlbumTitle = true;
										flush = true;
									}

									// If there is no Album Artist tag, add it if possible
									if ((GetStringTag(header, "WM/AlbumArtist") == null) && (!String.IsNullOrEmpty(parentArtist)))
									{
										SetStringTag(header, "WM/AlbumArtist", parentArtist);
										fixedAlbumArtist = true;
										flush = true;
									}
								}

								//
								// REPLACE ARTIST WITH ALBUM ARTIST
								//
								if (m_replaceArtists)
								{
									// I think this was the problem with blank album artists
									if (fixedAlbumArtist) editor.Flush();

									string albumartist = GetStringTag(header, "WM/AlbumArtist");

									if (!String.IsNullOrEmpty(albumartist))
									{
										if ((String.Compare(albumartist, "Various Artists", StringComparison.OrdinalIgnoreCase) != 0) &&
											(String.Compare(albumartist, "Soundtrack", StringComparison.OrdinalIgnoreCase) != 0))
										{
											RemoveTags(header, new string[] { "Author" });
											SetStringTag(header, "Author", albumartist);
											flush = true;
										}
									}
								}

								//
								// ROLL-UP GENRE
								//
								if (m_rollupGenres)
								{
									string genre = GetStringTag(header, "WM/Genre");
									if (GenreLookup.IsValidGenre(genre))
									{
										RemoveTags(header, new string[] { "WM/Genre" });
										SetStringTag(header, "WM/Genre", GenreLookup.MapGenre(genre));
										fixedGenre = true;
										flush = true;
									}
								}

								//
								// VALIDATE ALBUM NAME AND ALBUM ARTIST
								//

								if (m_validateTags)
								{
									if (!fixedAlbumTitle)
									{
										string albumName = NormalizeToFileSystemName(GetStringTag(header, "WM/AlbumTitle"));
										if ((!String.IsNullOrEmpty(albumName)) && (!String.IsNullOrEmpty(parentAlbum)))
										{
											if (String.Compare(albumName, parentAlbum, StringComparison.OrdinalIgnoreCase) != 0)
											{
												hasValidations = true;
												validationOutput.WriteLine(wmaFile);
												validationOutput.WriteLine(">> Album Name tag [" + albumName + "] does not correspond with folder layout");
												validationOutput.WriteLine();
											}
										}
									}

									if (!fixedAlbumArtist)
									{
										string albumArtist = NormalizeToFileSystemName(GetStringTag(header, "WM/AlbumArtist"));
										if (String.IsNullOrEmpty(albumArtist))
										{
											hasValidations = true;
											validationOutput.WriteLine(wmaFile);
											validationOutput.WriteLine(">> Missing Album Artist tag");
											validationOutput.WriteLine();
										}
										else if ((!String.IsNullOrEmpty(albumArtist)) && (!String.IsNullOrEmpty(parentArtist)))
										{
											if (String.Compare(albumArtist, parentArtist, StringComparison.OrdinalIgnoreCase) != 0)
											{
												hasValidations = true;
												validationOutput.WriteLine(wmaFile);
												validationOutput.WriteLine(">> Album Artist tag [" + albumArtist + "] does not correspond with folder layout");
												validationOutput.WriteLine();
											}
										}
									}
								}

								//
								// VALIDATE TRACK NUMBER
								//

								if (m_validateTracks && !fixedTrack)
								{
									int thisTrack = GetTrackNumber(header);
									if (thisTrack == 0)
									{
										hasValidations = true;
										validationOutput.WriteLine(wmaFile);
										validationOutput.WriteLine(">> Track number of zero detected -- track numbers are base-one");
										validationOutput.WriteLine();
									}
									else if (thisTrack != -1)
									{
										if (trackNumbers.Contains(thisTrack))
										{
											hasValidations = true;
											validationOutput.WriteLine(wmaFile);
											validationOutput.WriteLine(">> Duplicate Track Number [" + thisTrack + "] detected");
											validationOutput.WriteLine();
										}
										else trackNumbers.Add(thisTrack);
									}
									else
									{
										hasValidations = true;
										validationOutput.WriteLine(wmaFile);
										validationOutput.WriteLine(">> Invalid or Missing Track Number (WM/TrackNumber) detected");
										validationOutput.WriteLine();
									}
								}

								//
								// CHECK FOR DUPLICATE TRACK NAMES
								//
								if (m_validateTracks)
								{
									string trackName = GetStringTag(header, "Title");
									if (String.IsNullOrEmpty(trackName))
									{
										hasValidations = true;
										validationOutput.WriteLine(wmaFile);
										validationOutput.WriteLine(">> NULL or blank track title detected");
										validationOutput.WriteLine();
									}
									else if (trackNames.Contains(trackName.ToUpper()))
									{
										hasValidations = true;
										validationOutput.WriteLine(wmaFile);
										validationOutput.WriteLine(">> Duplicate Track Name [" + trackName + "] detected. Possible Remix or Reprise?");
										validationOutput.WriteLine();
									}
									else trackNames.Add(trackName.ToUpper());
								}

								//
								// VALIDATE MISSING / VARIOUS ARTISTS / SOUNDTRACK AUTHOR TAGS
								//
								if (m_verifyAuthors)
								{
									if (String.IsNullOrEmpty(GetStringTag(header, "Author")))
									{
										hasValidations = true;
										validationOutput.WriteLine(wmaFile);
										validationOutput.WriteLine(">> Missing Author tag(s)");
										validationOutput.WriteLine();
									}
									else if (HasVariousArtists(header))
									{
										hasValidations = true;
										validationOutput.WriteLine(wmaFile);
										validationOutput.WriteLine(">> Author tag of 'Various Artists' or 'Soundtrack' detected");
										validationOutput.WriteLine();
									}
								}

								//
								// VALIDATE GENRE
								//
								if (m_verifyGenres && !fixedGenre)
								{
									string genre = GetStringTag(header, "WM/Genre");
									if (!GenreLookup.IsValidGenre(genre))
									{
										hasValidations = true;
										validationOutput.WriteLine(wmaFile);
										validationOutput.WriteLine(">> Genre tag [" + genre + "] is not Gracenote CDDB compliant");
										validationOutput.WriteLine();
									}
								}
							}

							finally { if(flush) editor.Flush(); editor.Close(); }

							//
							// REMOVE REPLAY GAIN
							//
							if (m_removeReplayGain)
							{
								if (Path.GetExtension(wmaFile).ToLower() == ".mp3") UndoReplayGain(wmaFile);
							}

							//
							// TEST AUDIO STREAM
							//
							if (m_scanAudio)
							{
								int hResult = TestAudioStream(wmaFile);
								if(hResult != 0)
								{
									hasValidations = true;
									validationOutput.WriteLine(wmaFile);
									validationOutput.WriteLine(">> Unable to read audio data stream, that file may have been corrupted.");
									validationOutput.WriteLine();
								}
							}
						}

						finally { Marshal.ReleaseComObject(editor); }	// <-- Force release of editor instance
					}

					//
					// APPLY REPLAY GAIN TO MP3 ALBUMS/TRACKS
					//
					if ((m_replayGain) && (mp3s.Length > 0))
					{
						// TRACK MODE
						if (m_rgainTracks.Checked)
						{
							int result = ReplayGainTracks(mp3s);
							if (result != 0)
							{
								hasValidations = true;
								validationOutput.WriteLine(folder);
								validationOutput.WriteLine(">> Unable to apply ReplayGain to folder [" + folder + "], error code [" + result + "] returned from external tool.");
								validationOutput.WriteLine();
							}
						}

						// ALBUM MODE
						else if ((m_rgainAlbum.Checked) && (wmas.Length == 0))
						{
							int result = ReplayGainAlbum(mp3s);
							if (result != 0)
							{
								hasValidations = true;
								validationOutput.WriteLine(folder);
								validationOutput.WriteLine(">> Unable to apply ReplayGain to folder [" + folder + "], error code [" + result + "] returned from external tool.");
								validationOutput.WriteLine();
							}
						}
					}
				}

				finally { FreeWMPicture(ref albumArt); }				// <-- Chase and release WMPicture
			}
			
			catch (Exception ex) 
			{
				// Cheap way out of the recursive function appending each parent to the error ..

				if (ex.Message.Contains(current)) throw;
				else throw new Exception("An error occurred processing [" + current + "]:\r\n\r\n" + ex.Message); 
			}
		}

		/// <summary>
		/// Removes all existing album cover art from a WMA file
		/// </summary>
		/// <param name="wma">WMA file instance being edited</param>
		private void RemoveExistingAlbumArt(Win32.IWMHeaderInfo3 wma)
		{
			List<ushort>	attrsToRemove = new List<ushort>();		// Attributes to remove
			ushort			cAttributes;							// Attribute count

			wma.GetAttributeCountEx(0xFFFF, out cAttributes);
			for (ushort wAttribIndex = 0; wAttribIndex < cAttributes; wAttribIndex++)
			{
				Win32.WMT_ATTR_DATATYPE		wAttribType;
				ushort						wLangIndex = 0;
				string						pwszAttribName = null;
				IntPtr						pbAttribValue = IntPtr.Zero;
				ushort						wAttribNameLen = 0;
				uint						dwAttribValueLen = 0;

				// Make the intial call to GetAttributeByIndexEx, which will give us the
				// data buffer sizes we need to create to call it more successfully

				wma.GetAttributeByIndexEx(0xFFFF, wAttribIndex, pwszAttribName, ref wAttribNameLen, 
					out wAttribType, out wLangIndex, pbAttribValue, ref dwAttribValueLen);

				pwszAttribName = new String((char)0, wAttribNameLen);			// Allocate managed
				pbAttribValue = Marshal.AllocCoTaskMem((int)dwAttribValueLen);	// Allocate unmanaged

				try
				{
					// Make the call for real now that we have some buffers to back it up.

					wma.GetAttributeByIndexEx(0xFFFF, wAttribIndex, pwszAttribName, ref wAttribNameLen,
						out wAttribType, out wLangIndex, pbAttribValue, ref dwAttribValueLen);

					// We only care about WM/Picture attributes in this particular function

					if(String.Compare(pwszAttribName, "WM/Picture\0", StringComparison.OrdinalIgnoreCase) != 0) continue;

					// We don't want to nuke anything but Album Cover Art, so we have to grab the
					// WMPicture data and check for a picture type code of 3 before flagging this attribute

					Win32.WMPicture picture = (Win32.WMPicture)Marshal.PtrToStructure(pbAttribValue, typeof(Win32.WMPicture));
					if(picture.bPictureType == 3) attrsToRemove.Add(wAttribIndex);
				}

				finally { Marshal.FreeCoTaskMem(pbAttribValue); }
			}

			// Now that the nightmare code is over with (for now), remove the flagged attributes

			attrsToRemove.Sort(new Comparison<ushort>(SortUShortListDescending));
			foreach (ushort wAttribIndex in attrsToRemove) wma.DeleteAttribute(0xFFFF, wAttribIndex);
		}

		/// <summary>
		/// Removes all existing tags from a WMA file
		/// </summary>
		/// <param name="wma">WMA file instance being edited</param>
		private void RemoveTags(Win32.IWMHeaderInfo3 wma, string[] tags)
		{
			List<ushort> attrsToRemove = new List<ushort>();		// Attributes to remove
			ushort cAttributes;										// Attribute count

			wma.GetAttributeCountEx(0xFFFF, out cAttributes);
			for (ushort wAttribIndex = 0; wAttribIndex < cAttributes; wAttribIndex++)
			{
				Win32.WMT_ATTR_DATATYPE wAttribType;
				ushort wLangIndex = 0;
				string pwszAttribName = null;
				IntPtr pbAttribValue = IntPtr.Zero;
				ushort wAttribNameLen = 0;
				uint dwAttribValueLen = 0;

				// Make the intial call to GetAttributeByIndexEx, which will give us the
				// data buffer sizes we need to create to call it more successfully

				wma.GetAttributeByIndexEx(0xFFFF, wAttribIndex, pwszAttribName, ref wAttribNameLen,
					out wAttribType, out wLangIndex, pbAttribValue, ref dwAttribValueLen);

				pwszAttribName = new String((char)0, wAttribNameLen);			// Allocate managed
				pbAttribValue = Marshal.AllocCoTaskMem((int)dwAttribValueLen);	// Allocate unmanaged

				try
				{
					// Make the call for real now that we have some buffers to back it up.

					wma.GetAttributeByIndexEx(0xFFFF, wAttribIndex, pwszAttribName, ref wAttribNameLen,
						out wAttribType, out wLangIndex, pbAttribValue, ref dwAttribValueLen);

					foreach (string tag in tags)
					{
						if (String.Compare(pwszAttribName, tag + "\0", StringComparison.OrdinalIgnoreCase) == 0)
							attrsToRemove.Add(wAttribIndex);
					}
				}

				finally { Marshal.FreeCoTaskMem(pbAttribValue); }
			}

			// Now that the nightmare code is over with (for now), remove the flagged attributes

			attrsToRemove.Sort(new Comparison<ushort>(SortUShortListDescending));
			foreach (ushort wAttribIndex in attrsToRemove) wma.DeleteAttribute(0xFFFF, wAttribIndex);
		}

		/// <summary>
		/// Applies "ReplayGain" to an MP3-exclusive album
		/// </summary>
		/// <param name="albumFiles">Array of album file names</param>
		private int ReplayGainAlbum(string[] albumFiles)
		{
			if ((albumFiles == null) || (albumFiles.Length == 0)) return 0;		// Nothing to do

			Process tool = new Process();					// Process to launch
			tool.StartInfo.Arguments = "/a /c ";			// Album mode; don't warn on clipping

			// If we are to prevent clipping, add that to the command line as well

			if (m_rgainPreventClip.Checked) tool.StartInfo.Arguments += "/k ";

			// Set dB gain, which is based on the default of 89.0dB when using /D

			if (m_gainLowRadio.Checked) tool.StartInfo.Arguments += "/d 0.0 ";			// 89.0 + 0.0dB  = 89.0
			else if (m_gainMediumRadio.Checked) tool.StartInfo.Arguments += "/d 3.4 ";	// 89.0 + 3.4dB  = 92.4
			else if (m_gainHighRadio.Checked) tool.StartInfo.Arguments += "/d 6.8 ";	// 89.0 + 6.8dB  = 95.8
			else tool.StartInfo.Arguments += "/d 10.2 ";								// 89.0 + 10.2dB = 99.2

			foreach (string albumFile in albumFiles) tool.StartInfo.Arguments += "\"" + albumFile + "\" ";

			tool.StartInfo.CreateNoWindow = true;
			tool.StartInfo.FileName = Path.Combine(Application.StartupPath, "mp3gain.bin");
			tool.StartInfo.UseShellExecute = false;
			tool.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			tool.StartInfo.WorkingDirectory = Application.StartupPath;

			if (tool.Start())
			{
				tool.PriorityClass = ProcessPriorityClass.BelowNormal;
				tool.WaitForExit();
			}

			return tool.ExitCode;
		}

		/// <summary>
		/// Applies "ReplayGain" to MP3 tracks.  Uses a custom method wherein it will
		/// never over-amp a file more than the amount of gain we're adding as compared
		/// to the baseline 89.0dB
		/// </summary>
		/// <param name="albumFiles">Array of album file names</param>
		private int ReplayGainTracks(string[] albumFiles)
		{
			string		stdout = String.Empty;		// STDOUT from process
			float		dbgain;						// Overall gain, in decibels

			if ((albumFiles == null) || (albumFiles.Length == 0)) return 0;		// Nothing to do

			Process tool = new Process();					// Process to launch
			tool.StartInfo.Arguments = "/c /q /o /r ";		// No warnings; Quiet; Output; Tracks

			// If we are supposed to limit the gain to prevent clipping, set that up too

			if (m_rgainPreventClip.Checked) tool.StartInfo.Arguments += "/k ";

			// Set dB gain, which is based on the default of 89.0dB when using /D

			if (m_gainLowRadio.Checked) dbgain = 0.0F;				// 89.0 + 0.0dB  = 89.0
			else if (m_gainMediumRadio.Checked) dbgain = 3.4F;		// 89.0 + 3.4dB  = 92.4
			else if (m_gainHighRadio.Checked) dbgain = 6.8F;		// 89.0 + 6.8dB  = 95.8
			else dbgain = 10.2F;									// 89.0 + 10.2dB = 99.2

			tool.StartInfo.Arguments += "/d " + dbgain.ToString("0.0") + " ";

			foreach (string albumFile in albumFiles) tool.StartInfo.Arguments += "\"" + albumFile + "\" ";

			tool.StartInfo.CreateNoWindow = true;
			tool.StartInfo.FileName = Path.Combine(Application.StartupPath, "mp3gain.bin");
			tool.StartInfo.UseShellExecute = false;
			tool.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			tool.StartInfo.WorkingDirectory = Application.StartupPath;
			tool.StartInfo.RedirectStandardOutput = true;

			if (tool.Start())
			{
				tool.PriorityClass = ProcessPriorityClass.BelowNormal;
				stdout = tool.StandardOutput.ReadToEnd();
				tool.WaitForExit();
			}
			else throw new Exception("Unable to start external tool");

			//
			// PROCESS OUTPUT; ITERATE FILE NAMES FROM OUTPUT
			//
			// FILENAME \T MP3GAIN \T DBGAIN \T <don't care after this>
			//

			Dictionary<string, float> gainEntries = new Dictionary<string, float>();
			using (StringReader rdr = new StringReader(stdout))
			{
				string line = rdr.ReadLine();
				while(line != null)
				{
					string[] pieces = line.Split(new char[] { '\t' });
					if(File.Exists(pieces[0])) gainEntries.Add(pieces[0], Convert.ToSingle(pieces[2]));
					line = rdr.ReadLine();
				}
			}

			// Determine the average gain of all tracks

			float averageGain = 0.0F;
			foreach (KeyValuePair<string, float> gainEntry in gainEntries) averageGain += gainEntry.Value;
			averageGain = (averageGain / gainEntries.Count);

			foreach (KeyValuePair<string, float> gainEntry in gainEntries)
			{
				string filename = gainEntry.Key;
				float filegain = gainEntry.Value;

				// If the file was overgained, go back and do it again 
				// NOTE: This is completely arbitrary :)

				if (filegain > Math.Max(6.0F, dbgain))
				{
					//
					// The idea I had here was that I never want to apply more than the specified
					// gain difference to a file. So, for example, if I were applying a track gain
					// of 6.8dB, which results in a final volume of 95.8dB (89.0 + 6.8), I don't want
					// any one track to ever be pumped up more than 6.8dB to get there.  This seems
					// to work a little better than album gain for my purposes, as intentionally quiet
					// tracks will still remain quiet, but the regular tracks can still be pumped all
					// the way up to the desired baseline (unless of course they would clip).  True
					// "Album Gain" [See ReplainGainAlbum()] applies the same gain/loss to every file
					// in the album, so a lone quiet track can hold the rest of the tracks back ...
					//
					// Even that wasn't outstanding, so I'm trying an application of average
					// gain to this one track instead.  If the average gain across the whole
					// album is smaller than the selected gain, use the average instead.
					//
					// IF DECIBEL AMPLITUDE ADJUSTMENT IS GREATER THAN SELECTED GAIN:
					//
					//    DESIRED FINAL AMPLITUDE			    95.80
					//  - SUGGESTED AMPLITUDE CHANGE		  - 13.22
					//  = ORIGINAL TRACK AMPLITUDE            = 82.58
					//  + AVERAGE GAIN OR SELECTED GAIN (MIN) +  1.20
					//  = MAXIMUM TRACK AMPLITUDE             = 83.78
					//  - BASELINE REPLAYGAIN AMPLITUDE       - 89.00
					//  = NEW AMPLITUDE ADJUSTMENT            = -5.22
					//

					float newGain = 89.0F + dbgain;				// See above
					newGain -= filegain;						// See above
					newGain += Math.Min(averageGain, dbgain);	// See above
					newGain -= 89.0F;							// See above

					filegain = newGain;			// <-- NEW AMPLITUDE ADJUSTMENT

					Process tool2 = new Process();
					tool2.StartInfo = tool.StartInfo;
					tool2.StartInfo.RedirectStandardOutput = false;

					tool2.StartInfo.Arguments = "/c /r /d " + filegain.ToString("0.0") + " ";
					if (m_rgainPreventClip.Checked) tool2.StartInfo.Arguments += "/k ";
					tool2.StartInfo.Arguments += "\"" + filename + "\"";

					if (tool2.Start()) tool2.WaitForExit();
					else throw new Exception("Unable to start external tool");
				}
			}

			return 0;
		}

		/// <summary>
		/// Sets a simple string tag to a WMA/MP3 file
		/// </summary>
		/// <param name="wma">Header instance for the file to be modified</param>
		/// <param name="tag">Tag to be added (omit trailing NULL)</param>
		/// <param name="value">Value to assign to the new tag</param>
		private void SetStringTag(Win32.IWMHeaderInfo3 wma, string tag, string value)
		{
			if (String.IsNullOrEmpty(tag)) return;			// NULL tag name
			if (String.IsNullOrEmpty(value)) return;		// NULL value string

			if (!tag.EndsWith("\0")) tag = tag + "\0";		// Append trailing NULL

			// Allocate some unmanaged buffer space to throw at the Media API ..

			IntPtr ptValue = Marshal.StringToCoTaskMemUni(value);

			try { wma.SetAttribute(0, tag, Win32.WMT_ATTR_DATATYPE.WMT_TYPE_STRING, ptValue, (ushort)(value.Length * 2)); }
			finally { Marshal.FreeCoTaskMem(ptValue); }
		}

		/// <summary>
		/// Sets a simple DWORD tag to a WMA/MP3 file
		/// </summary>
		/// <param name="wma">Header instance for the file to be modified</param>
		/// <param name="tag">Tag to be added (omit trailing NULL)</param>
		/// <param name="value">Value to assign to the new tag</param>
		private void SetDwordTag(Win32.IWMHeaderInfo3 wma, string tag, int value)
		{
			if (String.IsNullOrEmpty(tag)) return;			// NULL tag name

			if (!tag.EndsWith("\0")) tag = tag + "\0";		// Append trailing NULL

			// Allocate some unmanaged buffer space to throw at the Media API ..

			IntPtr ptValue = Marshal.AllocCoTaskMem(Marshal.SizeOf(value));
			Marshal.WriteInt32(ptValue, value);

			try { wma.SetAttribute(0, tag, Win32.WMT_ATTR_DATATYPE.WMT_TYPE_DWORD, ptValue, (ushort)(Marshal.SizeOf(value))); }
			finally { Marshal.FreeCoTaskMem(ptValue); }
		}

		/// <summary>
		/// Used to sort a List<ushort> descending
		/// </summary>
		/// <param name="left">Left-hand argument</param>
		/// <param name="right">Right-hand argument</param>
		/// <returns>Standard comparison integer value</returns>
		private int SortUShortListDescending(ushort left, ushort right)
		{
			if (right > left) return 1;
			if (right == left) return 0;
			return -1;
		}

		/// <summary>
		/// Attempts to read the entire audio stream from the source file
		/// </summary>
		/// <param name="file">File to be validated</param>
		/// <returns>HRESULT from WMSyncReader.exe</returns>
		private int TestAudioStream(string file)
		{
			if (String.IsNullOrEmpty(file)) return 0;		// Nothing to do

			Process tool = new Process();					// Process to launch

			tool.StartInfo.Arguments = "-i \"" + file + "\" -a";
			tool.StartInfo.CreateNoWindow = true;
			tool.StartInfo.FileName = Path.Combine(Application.StartupPath, "wmsyncreader.bin");
			tool.StartInfo.UseShellExecute = false;
			tool.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			tool.StartInfo.WorkingDirectory = Application.StartupPath;

			if (tool.Start())
			{
				tool.PriorityClass = ProcessPriorityClass.BelowNormal;
				tool.WaitForExit();
			}
			return tool.ExitCode;
		}

		/// <summary>
		/// Removes replay gain from an MP3 file
		/// </summary>
		/// <param name="albumFiles">MP3 file name</param>
		private int UndoReplayGain(string mp3file)
		{
			if (String.IsNullOrEmpty(mp3file)) return 0;			// Nothing to do

			Process tool = new Process();							// Process to launch
			tool.StartInfo.Arguments = "/u ";						// Undo changes flag
			tool.StartInfo.Arguments += "\"" + mp3file + "\" ";		// Set the file name

			tool.StartInfo.CreateNoWindow = true;
			tool.StartInfo.FileName = Path.Combine(Application.StartupPath, "mp3gain.bin");
			tool.StartInfo.UseShellExecute = false;
			tool.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			tool.StartInfo.WorkingDirectory = Application.StartupPath;

			if (tool.Start()) tool.WaitForExit();
			else throw new Exception("Unable to launch external tool");
			return tool.ExitCode;
		}

		/// <summary>
		/// The main worker thread entry point
		/// </summary>
		private void WorkerThreadProc()
		{
			string		validationFile = null;		// Validation temp file name
			bool		hasValidation = false;		// Flag for validation errors

			CleanFinishedHandler finished = new CleanFinishedHandler(OnCleanFinished);

			try 
			{
				validationFile = Path.GetTempFileName();
				StreamWriter validationOutput = new StreamWriter(File.OpenWrite(validationFile));

				validationOutput.WriteLine("WMPCLEAN VALIDATION REPORT");
				validationOutput.WriteLine("--------------------------");
				validationOutput.WriteLine();
				validationOutput.WriteLine("LIBRARY LOCATION: " + m_mediaPath);
				validationOutput.WriteLine(DateTime.Now.ToString());
				validationOutput.WriteLine();
				validationOutput.WriteLine();

				try
				{

					// Not a lot to do other than kick things off from the root folder

					ProcessFolder(m_mediaPath, validationOutput, ref hasValidation);
					this.Invoke(finished, new object[] { null, ((hasValidation) ? validationFile : null) });
				}
				
				finally { validationOutput.Flush(); validationOutput.Close(); }
			}
			
			catch (Exception ex) { this.Invoke(finished, new object[] { ex, null }); }
		}

		//-------------------------------------------------------------------------
		// Private Data Types
		//-------------------------------------------------------------------------

		private delegate void CleanFinishedHandler(Exception ex, string validationFile);
		private delegate void UpdateProgressHandler(string message);

		//-------------------------------------------------------------------------
		// Member Variables
		//-------------------------------------------------------------------------

		private bool		m_canClose = true;				// Flag if app can be closed
		private string		m_mediaPath = String.Empty;		// Path to media library
		private bool		m_removeArtwork = false;		// Flag to remove album art
		private bool		m_addArtwork = false;			// Flag to add new album art
		private bool		m_removeTags = false;			// Flag to remove a bunch of tags
		private bool		m_validateTags = false;			// Flag to check album tags
		private bool		m_validateTracks = false;		// Flag to validate track numbers
		private bool		m_generateAlbumTags = false;	// Flag to fix album tags
		private bool		m_verifyArt = false;			// Flag to check for album art
		private bool		m_verifyFileNames = false;		// Flag to check file names
		private bool		m_removeLeveling = false;		// Flag to remove volume leveling
		private bool		m_replaceArtists = false;		// Flag to replace Artist tags
		private bool		m_verifyAuthors = false;		// Flag to check author tags
		private bool		m_genWmTrackNumbers = false;	// Flag to gen WM/TrackNumber tags
		private bool		m_scanAudio = false;			// Flag to scan audio stream
		private bool		m_replayGain = false;			// Flag to do a ReplayGain
		private bool		m_removeReplayGain = false;		// Flag to nuke ReplayGain
		private bool		m_verifyGenres = false;			// Flag to verify genres
		private bool		m_rollupGenres = false;			// Flag to roll-up genres
	}
}