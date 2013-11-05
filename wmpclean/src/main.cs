//---------------------------------------------------------------------------
// main.cs
//
// Windows Media Player Library Cleanup Tool
//
// Copyright (C)2007 Michael Brehm
// All Rights Reserved
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace wmpclean
{
	/// <summary>
	/// Implements Main(), the application entry point
	/// </summary>
	static class main
	{
		/// <summary>
		/// The main entry point for the application
		/// </summary>
		[STAThread()]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}