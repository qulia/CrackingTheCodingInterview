#pragma once

#ifdef NATIVETESTUTILITIES_EXPORTS 
#define NATIVETESTUTILITIES_API __declspec(dllexport)
#else  
#define NATIVETESTUTILITIES_API __declspec(dllimport)
#endif //  NATIVEUTILITIES_EXPORTS 

#include "ITrace.h"

using namespace NativeUtilities;

namespace NativeTestUtilities
{
	class TestTrace : public ITrace
	{
	public:
		const NATIVETESTUTILITIES_API void  Write(const char* message);
		const NATIVETESTUTILITIES_API void  WriteLine(const char* message);
	};
}