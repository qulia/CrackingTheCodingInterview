#pragma once

#ifdef  NATIVEUTILITIES_EXPORTS 
#define NATIVEUTILITIES_API __declspec(dllexport)
#else  
#define NATIVEUTILITIES_API __declspec(dllimport)
#endif //  NATIVEUTILITIES_EXPORTS 

namespace NativeUtilities
{
	__interface ITrace
	{
	public:
		const NATIVEUTILITIES_API void Write(const char* message);
		const NATIVEUTILITIES_API void WriteLine(const char* message);
	};
}