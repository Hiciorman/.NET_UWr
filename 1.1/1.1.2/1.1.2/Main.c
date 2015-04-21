#include <Windows.h>

LRESULT CALLBACK WindowProcedure(HWND, UINT, WPARAM, LPARAM);

char windowName[] = "Poruszaj¹ce siê kó³ko";
int i = 0;
BOOL go = FALSE;
int change = 0;
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
		"Poruszaj¹ce siê kó³ko",
		WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT,
		CW_USEDEFAULT,
		150,
		170,
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
	HBRUSH hBrush;
	int x, y;
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
		hBrush = CreateSolidBrush(RGB(255, 0, 0));
		SelectObject(hdc, hBrush);
		FillRect(hdc, &ps.rcPaint, (HBRUSH)(COLOR_WINDOW + 1));
		if (change > 3){
			change = 0;
		}
		if (i < 0){
			go = FALSE;
			change++;
		}
		if (i > xSize - 50 || i > ySize - 50){
			go = TRUE;
			change++;
		}
		if (go == TRUE){
			i--;
		}
		else{
			i++;
		}
		switch (change)
		{
		case 0:
			Ellipse(hdc, i, 0, 50 + i, 50); // i = sizeX
			break;
		case 1:
			Ellipse(hdc, i, 0, 50 + i, 50); // i = 0
			break;
		case 2:
			Ellipse(hdc, i, i, 50 + i, 50 + i); // i = sizeX
			break;
		case 3:
			Ellipse(hdc, i, i, 50 + i, 50 + i);
			break;
		}
		Sleep(5);
		DeleteObject(hBrush);
		EndPaint(hwnd, &ps);
		break;
	default:
		GetClientRect(hwnd, &r);
		InvalidateRect(hwnd, &r, 1);
		return DefWindowProc(hwnd, message, wParam, lParam);
	}

	return 0;
}