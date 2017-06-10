#pragma once
#ifdef QUESTION_12_11_2DALLOC_EXPORTS
#define QUESTION_12_11_2DALLOC_API __declspec(dllexport)
#else
#define QUESTION_12_11_2DALLOC_API __declspec(dllimport)
#endif // QUESTION_12_11_2DALLOC_EXPORTS

#include "ITrace.h"
using namespace NativeUtilities;

namespace Question_12_11_2DAlloc
{
	class Solution
	{
	public:
		QUESTION_12_11_2DALLOC_API Solution(ITrace & trace);
		QUESTION_12_11_2DALLOC_API int** Get2DAlloc(int numberOfRows, int numberOfColumns);
		QUESTION_12_11_2DALLOC_API void Free2DAlloc();

	private:
		ITrace& traceUtility;
		int** location;
		int numberOfRows;
		int numberOfColumns;
	};
}
