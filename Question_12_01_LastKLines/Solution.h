#pragma once

#ifdef QUESTION_12_01_LASTKLINES_EXPORTS
#define QUESTION_12_01_LASTKLINES_API __declspec(dllexport)
#else
#define QUESTION_12_01_LASTKLINES_API __declspec(dllimport)
#endif

#include "ITrace.h"
using namespace NativeUtilities;

namespace Question_12_01_LastKLines
{
	class Solution
	{
	private:
		ITrace& traceUtility;
	public:
		QUESTION_12_01_LASTKLINES_API Solution(ITrace& trace);
		QUESTION_12_01_LASTKLINES_API void PrintLastKLines(const char* fileName);
	};
}
