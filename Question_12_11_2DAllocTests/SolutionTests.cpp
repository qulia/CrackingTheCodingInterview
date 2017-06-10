#include "stdafx.h"
#include "CppUnitTest.h"
#include "Solution.h"
#include "TestTrace.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace Question_12_11_2DAlloc;
using namespace NativeTestUtilities;
using namespace std;

namespace Question_12_11_2DAllocTests
{		
	TEST_CLASS(SolutionTests)
	{
	public:
		
		TEST_METHOD(Get2DAllocTest)
		{
			TestTrace trace;
			Solution solution(trace);
			int** result = solution.Get2DAlloc(4, 3);

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					result[i][j] = i * j;
				}
			}

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					trace.Write(to_string(result[i][j]).c_str());
					trace.Write(" ");
				}

				trace.WriteLine("");
			}
			
			solution.Free2DAlloc();
		}
	};
}