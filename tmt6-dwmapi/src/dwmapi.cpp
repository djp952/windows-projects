//-----------------------------------------------------------------------------
// dwmapi.cpp
//
// ArcSoft TotalMedia Theatre 6 Composition (Aero) Fix
//
// This module, when placed in the same directory as the TMT6 applications, will
// falsely report that Desktop Composition (Aero) is disabled.  This prevents
// the application from requesting it to be shut down and eliminates a tearing
// problem with DVD content on some systems.  The original 32-bit dwmapi.dll file
// must be copied into the directory as well, and renamed as "dwmapi32.dll".
//
// The original concept for this fix was provided by "DSP_Tom", a user on the
// ArcSoft support forums (http://www.arcsoft.com/forum/default.asp).  The original
// concept used function stubs rather than function forwarders.
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

#include "stdafx.h"						// Include project pre-compiled headers
#pragma warning(push, 4)				// Enable maximum compiler warnings

//-----------------------------------------------------------------------------
// DllMain
//
// Library Entry Point
//
// Arguments:
//
//	hModule			- Module handle
//	dwReason		- Reason that DllMain is being invoked
//	pvReserved		- Reserved in Win32

BOOL APIENTRY DllMain(HMODULE hModule, DWORD dwReason, LPVOID pvReserved)
{
	(hModule);							// Unreferenced argument
	(dwReason);							// Unreferenced argument
	(pvReserved);						// Unreferenced argument

	return TRUE;
}

//-----------------------------------------------------------------------------
// DwmIsCompositionEnabled (Ordinal 144)
//
// askdjs
//
// Arguments:
//
//	pfEnabled		- Pointer to receive the composition enabled flag

HRESULT WINAPI DwmIsCompositionEnabled(BOOL *pfEnabled)
{
	if(pfEnabled) *pfEnabled = FALSE;
	return S_OK;
}

//-----------------------------------------------------------------------------

#pragma warning(pop)