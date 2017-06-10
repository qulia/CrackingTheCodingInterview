#include "stdafx.h"
#include "Resource.h"
#include "SPointer.h"

namespace Question_12_09_SmartPointerTests
{
	void Resource::Access()
	{
		std::string message = "Resource.Access";
		message.append(resourceName);
		trace.WriteLine(message.c_str());
	}

	Resource::Resource(std::string resourceName)
	{
		internalArray = new int[100];
		this->resourceName = resourceName;
	}

	Resource::~Resource()
	{
		std::string message = "Resource.Destructor";
		message.append(resourceName);
		trace.WriteLine(message.c_str()); 
		
		delete internalArray;
	}
}