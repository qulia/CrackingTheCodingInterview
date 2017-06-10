#include "stdafx.h"
#include "TestTrace.h"
#include "CppUnitTest.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace NativeTestUtilities
{
	const void TestTrace::Write(const char * message)
	{
		Logger::WriteMessage(message);
	}

	const void TestTrace::WriteLine(const char * message)
	{
		Write(message);
		Logger::WriteMessage("\n"); // TODO make this environment specific
	}
}
