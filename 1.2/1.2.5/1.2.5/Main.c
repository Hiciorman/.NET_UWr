//Nie działa wyciąganie stringów z rejestru czyli:
//	-ProcessorName
//	-Wersja .NET
//	-Wersja Word
//	-Wersja IE

#include <Windows.h>
#include <stdio.h>
#include <powrprof.h>
#include <VersionHelpers.h>

#define UNLEN 256

int main(void)
{
	//TODO: Get information about processor
	//Information are in "HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0"
	DWORD BufSize = _MAX_PATH*sizeof(TCHAR);
	DWORD dwMHz = _MAX_PATH;
	TCHAR buffer[_MAX_PATH] = { 0 };
	HKEY hKey;
	RegOpenKeyEx(HKEY_LOCAL_MACHINE,
		"HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0",
		0,
		KEY_QUERY_VALUE,
		&hKey);
	RegQueryValueEx(hKey, "~MHz", NULL, NULL, (LPBYTE)&dwMHz, &BufSize);
	printf("Processor speed: %.2fGHz\n", (float)dwMHz/100);
	RegQueryValueEx(hKey, "ProcessorNameString", NULL, NULL, (unsigned char*)buffer, &BufSize);
	printf("Processor name: %s\n", buffer);

	//Pamięc RAM
	MEMORYSTATUSEX memInfo;
	memInfo.dwLength = sizeof(MEMORYSTATUSEX);
	GlobalMemoryStatusEx(&memInfo);
	DWORDLONG totalVirtualMem = memInfo.ullTotalPageFile;
	DWORDLONG totalPhysMem = memInfo.ullTotalPhys/1000000;
	DWORDLONG physMemUsed = (memInfo.ullTotalPhys - memInfo.ullAvailPhys)/1000000;
	DWORDLONG physMemFree = totalPhysMem - physMemUsed;

	printf("Ram memory: %dMB\n", totalPhysMem);
	printf("Ram memory used: %dMB\n", physMemUsed);
	printf("Ram memory free: %dMB\n", physMemFree);

	//Wersja systemu
	if (IsWindows8Point1OrGreater){
		printf("System Version: 6.3\n");
	}
	else if (IsWindows8OrGreater){
		printf("System Version: 6.2\n");
	}
	else if (IsWindowsXPOrGreater)
	{
		OSVERSIONINFO osvi;
		ZeroMemory(&osvi, sizeof(OSVERSIONINFO));
		osvi.dwOSVersionInfoSize = sizeof(OSVERSIONINFO);
		//GetVersionEx(&osvi);
		printf("System Version: %d.%d\n", osvi.dwMajorVersion, osvi.dwMinorVersion);
	}

	//Nazwa komputera
	TCHAR computerName[MAX_COMPUTERNAME_LENGTH + 1];
	DWORD size = sizeof(computerName) / sizeof(computerName[0]);
	GetComputerName(computerName, &size);
	printf("Computer name: %ws\n", computerName);

	//Nazwa użytkownika 
	TCHAR userName[UNLEN + 1];
	size = sizeof(userName) / sizeof(userName[0]);
	GetUserName(userName, &size);
	printf("User name: %ws\n", userName);

	//Rozdzielczość ekranu
	RECT desktop;
	const HWND hDesktop = GetDesktopWindow();
	GetWindowRect(hDesktop, &desktop);
	printf("Horizontal: %d\n", desktop.right);
	printf("Vertical: %d\n", desktop.bottom);

	//Głębia koloru
	HDC dc = GetDC(NULL);
	int bitsPerPixel = GetDeviceCaps(dc, BITSPIXEL);
	ReleaseDC(NULL, dc);
	printf("Color depth: %d\n", bitsPerPixel);

	//Drukarki
	PRINTER_INFO_2* prninfo = NULL;
	DWORD needed, returned;

	EnumPrinters(PRINTER_ENUM_LOCAL, NULL, 2, NULL, 0, &needed, &returned);
	prninfo = (PRINTER_INFO_2*)GlobalAlloc(GPTR, needed);
	if (!EnumPrinters(PRINTER_ENUM_LOCAL, NULL, 2, (LPBYTE)prninfo, needed, &needed, &returned)){
		printf("No printers\n");
	}
	else{
		printf("Printer name: %s\n", prninfo[0].pPrinterName);
	}
	GlobalFree(prninfo);

	//CPU

	//TODO: .NET
	/*HKEY hKey;
	LPCSTR subKey = "SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4.0\\Client";
	DWORD type = REG_SZ;
	LPCSTR ver;
	DWORD size_ver = sizeof(ver);
	RegOpenKeyEx(HKEY_LOCAL_MACHINE, subKey, 0, KEY_READ, &hKey);
	RegQueryValueEx(hKey, "Version", NULL, &type, (LPBYTE)&ver, &size_ver);
	printf(".NET Framework version: %ws\n", ver);*/
	//TODO: WORD
	// subkey="SOFTWARE\\Microsoft\\Office\\15.0\\Word\\InstallRoot\\Path"
	//TODO: IE
	// subkey="SOFTWARE\\Microsoft\\InternetExplorer\\Version
	getchar();
	return 0;
}
