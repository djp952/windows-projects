//-----------------------------------------------------------------------------
// forwards.cpp
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

#include "stdafx.h"						// Include project pre-compiled headers
#pragma warning(push, 4)				// Enable maximum compiler warnings

//-----------------------------------------------------------------------------
// FORWARDED FUNCTIONS
//-----------------------------------------------------------------------------

#pragma comment(linker, "/export:Func100=dwmapi32.#100,@100,NONAME")
#pragma comment(linker, "/export:Func101=dwmapi32.#101,@101,NONAME")
#pragma comment(linker, "/export:DwmEnableComposition=dwmapi32.DwmEnableComposition,@102")
#pragma comment(linker, "/export:Func103=dwmapi32.#103,@103,NONAME")
#pragma comment(linker, "/export:Func104=dwmapi32.#104,@104,NONAME")
#pragma comment(linker, "/export:Func105=dwmapi32.#105,@105,NONAME")
#pragma comment(linker, "/export:Func106=dwmapi32.#106,@106,NONAME")
#pragma comment(linker, "/export:Func107=dwmapi32.#107,@107,NONAME")
#pragma comment(linker, "/export:Func108=dwmapi32.#108,@108,NONAME")
#pragma comment(linker, "/export:Func109=dwmapi32.#109,@109,NONAME")
#pragma comment(linker, "/export:Func110=dwmapi32.#110,@110,NONAME")
#pragma comment(linker, "/export:DwmAttachMilContent=dwmapi32.DwmAttachMilContent,@111")
#pragma comment(linker, "/export:Func112=dwmapi32.#112,@112,NONAME")
#pragma comment(linker, "/export:Func113=dwmapi32.#113,@113,NONAME")
#pragma comment(linker, "/export:Func114=dwmapi32.#114,@114,NONAME")
#pragma comment(linker, "/export:Func115=dwmapi32.#115,@115,NONAME")
#pragma comment(linker, "/export:DwmDefWindowProc=dwmapi32.DwmDefWindowProc,@116")
#pragma comment(linker, "/export:DwmDetachMilContent=dwmapi32.DwmDetachMilContent,@117")
#pragma comment(linker, "/export:Func118=dwmapi32.#118,@118,NONAME")
#pragma comment(linker, "/export:Func119=dwmapi32.#119,@119,NONAME")
#pragma comment(linker, "/export:Func120=dwmapi32.#120,@120,NONAME")
#pragma comment(linker, "/export:Func121=dwmapi32.#121,@121,NONAME")
#pragma comment(linker, "/export:DwmEnableBlurBehindWindow=dwmapi32.DwmEnableBlurBehindWindow,@122")
#pragma comment(linker, "/export:DwmEnableMMCSS=dwmapi32.DwmEnableMMCSS,@123")
#pragma comment(linker, "/export:Func124=dwmapi32.#124,@124,NONAME")
#pragma comment(linker, "/export:Func125=dwmapi32.#125,@125,NONAME")
#pragma comment(linker, "/export:Func126=dwmapi32.#126,@126,NONAME")
#pragma comment(linker, "/export:Func127=dwmapi32.#127,@127,NONAME")
#pragma comment(linker, "/export:Func128=dwmapi32.#128,@128,NONAME")
#pragma comment(linker, "/export:Func129=dwmapi32.#129,@129,NONAME")
#pragma comment(linker, "/export:Func130=dwmapi32.#130,@130,NONAME")
#pragma comment(linker, "/export:Func131=dwmapi32.#131,@131,NONAME")
#pragma comment(linker, "/export:Func132=dwmapi32.#132,@132,NONAME")
#pragma comment(linker, "/export:Func133=dwmapi32.#133,@133,NONAME")
#pragma comment(linker, "/export:Func134=dwmapi32.#134,@134,NONAME")
#pragma comment(linker, "/export:DwmExtendFrameIntoClientArea=dwmapi32.DwmExtendFrameIntoClientArea,@135")
#pragma comment(linker, "/export:DwmFlush=dwmapi32.DwmFlush,@136")
#pragma comment(linker, "/export:DwmGetColorizationColor=dwmapi32.DwmGetColorizationColor,@137")
#pragma comment(linker, "/export:DwmGetCompositionTimingInfo=dwmapi32.DwmGetCompositionTimingInfo,@138")
#pragma comment(linker, "/export:DwmGetGraphicsStreamClient=dwmapi32.DwmGetGraphicsStreamClient,@139")
#pragma comment(linker, "/export:DwmGetGraphicsStreamTransformHint=dwmapi32.DwmGetGraphicsStreamTransformHint,@140")
#pragma comment(linker, "/export:DwmGetTransportAttributes=dwmapi32.DwmGetTransportAttributes,@141")
#pragma comment(linker, "/export:DwmGetWindowAttribute=dwmapi32.DwmGetWindowAttribute,@142")
#pragma comment(linker, "/export:DwmInvalidateIconicBitmaps=dwmapi32.DwmInvalidateIconicBitmaps,@143")
#pragma comment(linker, "/export:DwmModifyPreviousDxFrameDuration=dwmapi32.DwmModifyPreviousDxFrameDuration,@145")
#pragma comment(linker, "/export:DwmQueryThumbnailSourceSize=dwmapi32.DwmQueryThumbnailSourceSize,@146")
#pragma comment(linker, "/export:DwmRegisterThumbnail=dwmapi32.DwmRegisterThumbnail,@147")
#pragma comment(linker, "/export:DwmSetDxFrameDuration=dwmapi32.DwmSetDxFrameDuration,@148")
#pragma comment(linker, "/export:DwmSetIconicLivePreviewBitmap=dwmapi32.DwmSetIconicLivePreviewBitmap,@149")
#pragma comment(linker, "/export:DwmSetIconicThumbnail=dwmapi32.DwmSetIconicThumbnail,@150")
#pragma comment(linker, "/export:DwmSetPresentParameters=dwmapi32.DwmSetPresentParameters,@151")
#pragma comment(linker, "/export:DwmSetWindowAttribute=dwmapi32.DwmSetWindowAttribute,@152")
#pragma comment(linker, "/export:DwmUnregisterThumbnail=dwmapi32.DwmUnregisterThumbnail,@153")
#pragma comment(linker, "/export:DwmUpdateThumbnailProperties=dwmapi32.DwmUpdateThumbnailProperties,@154")

//-----------------------------------------------------------------------------

#pragma warning(pop)