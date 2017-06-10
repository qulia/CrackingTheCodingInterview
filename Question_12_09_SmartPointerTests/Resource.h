#include "TestTrace.h"

using namespace NativeTestUtilities;

namespace Question_12_09_SmartPointerTests
{
	class Resource
	{
	private:
		int *internalArray;
		TestTrace trace;
		std::string resourceName;

	public:
		Resource(std::string resourceName);
		void Access();
		~Resource();
	};
}
