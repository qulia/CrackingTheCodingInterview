#include "stdafx.h"
#include "DebugTrace.h"

namespace NativeUtilities
{
	const void DebugTrace::Write(const char * message)
	{
		::OutputDebugString(LPCWSTR(message));
	}

	const void DebugTrace::WriteLine(const char * message)
	{
		Write(message);
		::OutputDebugString(LPCWSTR("\n"));
	}
}
