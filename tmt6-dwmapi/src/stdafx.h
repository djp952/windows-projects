//-----------------------------------------------------------------------------
// stdafx.cpp
//
// ArcSoft TotalMedia Theatre 6 Composition (Aero) Fix
//
// The use and distribution terms for this software are covered by the
// Common Public License 1.0 (http://opensource.org/licenses/cpl.php)
// which can be found in the file CPL.TXT at the root of this distribution.
// By using this software in any fashion, you are agreeing to be bound by
// the terms of this license. You must not remove this notice, or any other,
// from this software.
//
// Contributor(s):
//        Michael G. Brehm (original author)
//---------------------------------------------------------------------------

#pragma once

//-----------------------------------------------------------------------------
// Windows Declarations

#define _WINVER			0x0601			// Windows 7
#define _WIN32_WINNT	0x0601			// Windows 7
#define WIN32_LEAN_AND_MEAN             // Exclude rarely-used stuff from Windows headers
#include <windows.h>					// Include Win32 API declarations

//-----------------------------------------------------------------------------