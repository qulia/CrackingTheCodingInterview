// Question_12_01_LastKLines.cpp : Defines the exported functions for the DLL application.
//

// Order is important
#include "stdafx.h"
#include "Solution.h"

#include <string>
#include <fstream>
#include <iostream>


using namespace std;

namespace Question_12_01_LastKLines
{
	Solution::Solution(ITrace& trace)
		:traceUtility(trace)
	{
	}

	// When there are a,b,c,d,e,f,g,h,i,j in the array
	// if k is read it will be k,b,c,d,e,f,g,h,i,j
	void Solution::PrintLastKLines(const char* fileName)
	{
		const int k = 10;
		string lines[k];
		ifstream file(fileName);
		if (!file.is_open())
		{
			traceUtility.Write("error while opening the file");
			return;
		}

		int startIndex = 0;
		int endIndex = 0;
		bool startMoves = false;
		while (getline(file, lines[endIndex]))
		{
			if (startMoves == true)
			{
				startIndex++;
				startIndex = startIndex % k;
			}

			endIndex++;

			if (endIndex == k) startMoves = true;
			endIndex = endIndex % k;
		}

		int count = startMoves ? k : endIndex + 1;
		for (int i = 0; i < count; i++)
		{
			string string = lines[(i + startIndex) % k];
			traceUtility.WriteLine(string.c_str());
		}
	}
}

