#include "stdafx.h"
#include "Resource.h"
#include "CppUnitTest.h"
#include "SPointer.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace Question_12_09_SmartPointer;

namespace Question_12_09_SmartPointerTests
{		
	TEST_CLASS(SmartPointerTests)
	{
	public:
		
		TEST_METHOD(BasicTest)
		{
			TestTrace trace;
			Resource* resourcePtr = new Resource("1");
			SPointer<Resource> resourceSPointer(trace, resourcePtr);
			resourceSPointer->Access();

			// Create another smartPointer, copy from the previous
			SPointer<Resource> resourceSPointer2(trace, resourceSPointer);
			resourceSPointer2->Access();

			// Create another smartPointer, move from the previous
			SPointer<Resource> resourceSPointer3(trace, std::move(resourceSPointer));
			resourceSPointer3->Access();

		    // Test copy assignment
			resourceSPointer = resourceSPointer3;
			resourceSPointer->Access();

			Resource* resource2Ptr = new Resource("2");
			SPointer<Resource> resource2SPointer(trace, resource2Ptr);
			resource2SPointer->Access();

			resourceSPointer2 = resource2SPointer;
			resourceSPointer2->Access();

			// Test move assignment
			Resource* resource3Ptr = new Resource("3");
			SPointer<Resource> resource3SPointer(trace, resource3Ptr);

			resource2SPointer = std::move(resource3SPointer);
			resource2SPointer->Access();

			resourceSPointer2 = std::move(resourceSPointer3);
			resourceSPointer2->Access();
		}
	};
}