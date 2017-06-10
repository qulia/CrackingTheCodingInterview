#include "stdafx.h"
#include "CppUnitTest.h"
#include "Solution.h"
#include "TestTrace.h"
#include <string>

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace Question_12_01_LastKLines;
using namespace NativeTestUtilities;
using namespace std;

//Returns my solution's directory
#define TEST_CASE_DIRECTORY GetDirectoryName(__FILE__)

namespace Question_12_01_LastKLineTests
{
	TEST_CLASS(SolutionTests)
	{
	public:

		TEST_METHOD(PrintLastKLinesTest)
		{
			TestTrace trace;
			Solution solution(trace);

			string filename = string(TEST_CASE_DIRECTORY) + "Readme.txt";

			trace.WriteLine(filename.c_str());
			solution.PrintLastKLines(filename.c_str());
		}

	private:
		//http ://stackoverflow.com/questions/15874723/how-to-open-a-file-from-the-project-in-a-native-c-unit-test-visual-studio
		string GetDirectoryName(string path) {
			const size_t last_slash_idx = path.rfind('\\');
			if (std::string::npos != last_slash_idx)
			{
				return path.substr(0, last_slash_idx + 1);
			}
			return "";
		}

	};
}