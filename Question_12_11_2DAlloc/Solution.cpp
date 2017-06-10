// Question_12_11_2DAlloc.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "malloc.h"
#include "Solution.h"

namespace Question_12_11_2DAlloc
{
	Solution::Solution(ITrace& trace)
		:traceUtility(trace)
	{
	}

	int** Solution::Get2DAlloc(int numberOfRows, int numberOfColumns)
	{
		int ** start = (int **)malloc(numberOfRows * sizeof(int *));
		for (int i = 0; i < numberOfRows; i++)
		{
			start[i] = (int *)malloc(numberOfColumns * sizeof(int));
		}

		location = start;
		this->numberOfRows = numberOfRows;
		this->numberOfColumns = numberOfColumns;
		return start;
	}

	void Solution::Free2DAlloc()
	{
		if (location == NULL)
		{
			traceUtility.WriteLine("Nothing has been allocated yet.");
			return;
		}

		for (int i = 0; i < numberOfRows; i++)
		{
			free(location[i]);
		}

		free(location);
		location = NULL;
	}
}