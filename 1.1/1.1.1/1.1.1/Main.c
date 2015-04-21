#include <Windows.h>

LRESULT CALLBACK WindowProcedure(HWND, UINT, WPARAM, LPARAM);

char windowName[] = "Wykresy funkcji";

int WINAPI WinMain(HINSTANCE hInstance,
	HINSTANCE hPrevInstance,
	LPSTR lpCmdLine,
	int nShowCmd)
{
	HWND hwnd;
	MSG messages;
	WNDCLASSEX wincl;

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
		"Wykresy funkcji",
		WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT,
		CW_USEDEFAULT,
		512,
		512,
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

int xSize, ySize;

LRESULT CALLBACK WindowProcedure(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	HDC hdc;
	PAINTSTRUCT ps;
	RECT r;
	HPEN hPen, hPen2, hPen3;

	int x, y, i;
	x = xSize / 20;
	y = ySize / 20;

	switch (message)
	{
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_SIZE:
		xSize = LOWORD(lParam);
		ySize = HIWORD(lParam);

		GetClientRect(hwnd, &r);
		InvalidateRect(hwnd, &r, 1);
		break;
	case WM_PAINT:
		hdc = BeginPaint(hwnd, &ps);
		hPen = CreatePen(PS_SOLID, 3, RGB(255, 0, 0));
		hPen2 = CreatePen(PS_SOLID, 3, RGB(0, 255, 0));
		hPen3 = CreatePen(PS_SOLID, 3, RGB(0, 0, 255));

		SelectObject(hdc, hPen);
		//Osie X i Y
		MoveToEx(hdc, xSize / 2, 0, NULL);
		LineTo(hdc, xSize / 2, ySize);
		MoveToEx(hdc, 0, ySize / 2, NULL);
		LineTo(hdc, xSize, ySize / 2);
		//znaczniki
		for (i = 0; i < 11; i++){
			MoveToEx(hdc, xSize / 2 - x*i, ySize / 2 - 5, NULL);
			LineTo(hdc, xSize / 2 - x*i, ySize / 2 + 5);
			MoveToEx(hdc, xSize / 2 + x*i, ySize / 2 - 5, NULL);
			LineTo(hdc, xSize / 2 + x*i, ySize / 2 + 5);
			MoveToEx(hdc, xSize / 2 - 5, ySize / 2 - y*i, NULL);
			LineTo(hdc, xSize / 2 + 5, ySize / 2 - y*i);
			MoveToEx(hdc, xSize / 2 - 5, ySize / 2 + y*i, NULL);
			LineTo(hdc, xSize / 2 + 5, ySize / 2 + y*i);
		}
		// wykres f(x) = |x|
		SelectObject(hdc, hPen2);
		for (i = 0; i < 11; i++)
		{
			MoveToEx(hdc, xSize / 2 - x*i, ySize / 2 - y*i, NULL);
			LineTo(hdc, xSize / 2 - x*(i + 1), ySize / 2 - y*(i + 1));
			MoveToEx(hdc, xSize / 2 + x*i, ySize / 2 - y*i, NULL);
			LineTo(hdc, xSize / 2 + x*(i + 1), ySize / 2 - y*(i + 1));
		}
		//wykres f(x) = x^2
		SelectObject(hdc, hPen3);
		for (i = 0; i < 20; i++){
			MoveToEx(hdc, xSize / 2 - x*i, ySize / 2 - (y*i)*(y*i) / 40, NULL);
			LineTo(hdc, xSize / 2 - x*(i + 1), ySize / 2 - (y*(i + 1))*(y*(i + 1)) / 40);
			MoveToEx(hdc, xSize / 2 + x*i, ySize / 2 - (y*i)*(y*i) / 40, NULL);
			LineTo(hdc, xSize / 2 + x*(i + 1), ySize / 2 - (y*(i + 1))*(y*(i + 1)) / 40);
		}

		EndPaint(hwnd, &ps);
		break;
	default:
		return DefWindowProc(hwnd, message, wParam, lParam);
	}

	return 0;
}