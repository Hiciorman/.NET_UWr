#include <Windows.h>
#include <stdio.h>
#include <Shlobj.h>
#include "Shlwapi.h"

void main(void)
{
	char sTime[32];
	SYSTEMTIME time;
	wchar_t sFileName[128];
	
	GetLocalTime(&time);
	GetTimeFormat(LOCALE_SYSTEM_DEFAULT, 0, &time, NULL, sTime, 15);

	SHGetFolderPath(NULL, CSIDL_DESKTOPDIRECTORY, NULL, 0, sFileName);
	PathAppend(sFileName, TEXT("test.txt"));

	HANDLE hFile = CreateFile(sFileName, GENERIC_WRITE, 0, NULL, CREATE_NEW, FILE_ATTRIBUTE_NORMAL, NULL);
	WriteFile(hFile, sTime, 15, 0, NULL);

	//ShellExecute(NULL, L"print", L"C:\\Users\\Szymon\\Desktop\\test.txt", NULL, NULL, SW_SHOWNORMAL);
	ShellExecute(NULL, L"print", sFileName, NULL, NULL, SW_SHOWNORMAL);
	CloseHandle(hFile);
}