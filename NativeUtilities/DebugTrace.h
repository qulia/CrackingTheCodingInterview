#pragma once

#include "ITrace.h"

namespace NativeUtilities
{
	class DebugTrace : public ITrace
	{
	public:
		const NATIVEUTILITIES_API void  Write(const char* message);
		const NATIVEUTILITIES_API void  WriteLine(const char* message);
	};
}
