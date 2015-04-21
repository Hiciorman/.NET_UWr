#include <Windows.h>
#include <stdio.h>
LRESULT CALLBACK WindowProcedure(HWND, UINT, WPARAM, LPARAM);

DWORD xSize, ySize;
LPCSTR subKey = "Software\\Programowanie pod Windows";
DWORD dwDisposition;
HKEY hKey;
DWORD type = REG_DWORD;
int x, y;
char windowName[] = "Rejestr";

int WINAPI WinMain(HINSTANCE hInstance,
	HINSTANCE hPrevInstance,
	LPSTR lpCmdLine,
	int nShowCmd)
{
	HWND hwnd;
	MSG messages;
	WNDCLASSEX wincl;

	//RegCreateKeyEx(HKEY_CURRENT_USER, subKey, 0, NULL, 0, 0, NULL, &hKey, &dwDisposition);
	RegOpenKey(HKEY_CURRENT_USER, subKey, &hKey);
	DWORD cbDataX = sizeof(xSize);
	DWORD cbDataY = sizeof(ySize);
	RegQueryValueEx(hKey, "SizeX", NULL, &type, (LPBYTE)&xSize, &cbDataX);
	RegQueryValueEx(hKey, "SizeY", NULL, &type, (LPBYTE)&ySize, &cbDataY);

	wincl.hInstance = hInstance;
	wincl.lpszClassName = windowName;
	wincl.lpfnWndProc = WindowProcedure;
	wincl.style = CS_DBLCLKS;
	wincl.cbSize = sizeof(WNDCLASSEX);

	wincl.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	wincl.hIconSm = LoadIcon(NULL, IDI_APPLICATION);
	wincl.hCursor = LoadCursor(NULL, IDC_ARROW);
	wincl.lpszMenuName = NULL;
	wincl.cbClsExtra = 0;
	wincl.cbWndExtra = 0;

	wincl.hbrBackground = (HBRUSH)GetStockObject(LTGRAY_BRUSH);

	if (!RegisterClassEx(&wincl))
		return 0;

	hwnd = CreateWindowEx(0,
		windowName,
		"Rejestr",
		WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT,
		CW_USEDEFAULT,
		xSize,
		ySize,
		HWND_DESKTOP,
		NULL,
		hInstance,
		NULL);

	ShowWindow(hwnd, nShowCmd);

	while (GetMessage(&messages, NULL, 0, 0))
	{
		TranslateMessage(&messages);
		DispatchMessage(&messages);
	}

	return messages.wParam;
}

LRESULT CALLBACK WindowProcedure(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch (message)
	{
	case WM_DESTROY:
		RegOpenKey(HKEY_CURRENT_USER, subKey, &hKey);
		RegSetValueEx(hKey, "SizeX", NULL, REG_DWORD, (LPBYTE)&xSize, sizeof(xSize));
		RegSetValueEx(hKey, "SizeY", NULL, REG_DWORD, (LPBYTE)&ySize, sizeof(ySize));
		RegCloseKey(hKey);
		PostQuitMessage(0);
		break;
	case WM_SIZE:
		x = LOWORD(lParam);
		y = HIWORD(lParam);
		xSize = (DWORD)x;
		ySize = (DWORD)y;
		break;
	default:
		return DefWindowProc(hwnd, message, wParam, lParam);
	}

	return 0;
}