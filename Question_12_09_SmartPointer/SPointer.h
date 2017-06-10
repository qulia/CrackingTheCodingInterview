#pragma once

// https://msdn.microsoft.com/en-us/library/7ac5szsk.aspx

#include "DebugTrace.h"
using namespace NativeUtilities;

namespace Question_12_09_SmartPointer
{
	// Do not use EXPORT macros for template classes
	// Include the functionality in the header and add to the header file in a separate project to use it
    // http://stackoverflow.com/questions/362822/how-do-i-export-templated-classes-from-a-dll-without-explicit-specification
	template <typename T>
	class SPointer
	{
	public:
		SPointer(ITrace& trace, T * objectPtr)
		{
			this->trace = &trace;
			ref = objectPtr;
			refCounter = (int *)malloc(sizeof(int));
			*refCounter = 0;
			AddRef();
		}

		SPointer(ITrace& trace, SPointer<T> & fromSPointer)
		{
			this->trace = &trace;
			ref = fromSPointer.ref;
			refCounter = fromSPointer.refCounter;

			AddRef();
		}

		SPointer(ITrace& trace, SPointer<T> && fromSPointer)
		{
			this->trace = &trace;
			ref = fromSPointer.ref;
			refCounter = fromSPointer.refCounter;

			fromSPointer.ref = nullptr;
			fromSPointer.refCounter = nullptr;
		}

		SPointer<T> & operator=(SPointer<T> & fromSPointer)
		{
			if (this != &fromSPointer)
			{
				RemoveRef();
				ref = fromSPointer.ref;
				refCounter = fromSPointer.refCounter;
				AddRef();
			}

			return *this;
		}

		//https://msdn.microsoft.com/en-us/library/dd293665.aspx
		SPointer<T> & operator=(SPointer<T> && fromSPointer)
		{
			if (this != &fromSPointer)
			{
				RemoveRef();
				ref = fromSPointer.ref;
				refCounter = fromSPointer.refCounter;
				fromSPointer.ref = nullptr;
				fromSPointer.refCounter = nullptr;
			}

			return *this;
		}

		T* operator->() {
			return ref;
		}

		~SPointer()
		{
			RemoveRef();
		}

	private:
		ITrace* trace;
		T* ref;
		int* refCounter;

		void AddRef()
		{
			std::string refCounterString = std::to_string(*refCounter);
			std::string message = "AddRef: ";
			message.append(refCounterString);
			trace->WriteLine(message.c_str());

			(*refCounter)++;
		}

		void RemoveRef()
		{
			if (ref == nullptr)
			{
				// Does not own anything
				return;
			}

			std::string refCounterString = std::to_string(*refCounter);
			std::string message = "RemoveRef: ";
			message.append(refCounterString);
			trace->WriteLine(message.c_str());

			if (--(*refCounter) == 0)
			{
				trace->WriteLine("Delete ref, free refCounter");
				delete ref;
				ref = nullptr;

				free(refCounter);
				refCounter = nullptr;
			}
		}
	};
}

