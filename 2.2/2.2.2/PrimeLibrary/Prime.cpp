#include <stdbool.h>


extern "C"
{
	__declspec(dllexport) bool _stdcall IsPrimeC(int x){
		int c = 2;

		for (c = 2; c <= x - 1; c++)
		{
			if (x%c == 0)
			{
				return false;
			}
		}
		if (c == x)
			return true;

		return 0;
	}
}