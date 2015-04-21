#include <Windows.h>
#include<Shlwapi.h>

#define BTN_CANCEL 100
#define BTN_ACCEPT 101
LRESULT CALLBACK WindowProcedure(HWND, UINT, WPARAM, LPARAM);

char windowName[] = "Wybór uczelni";

struct
{
	TCHAR * szClass;
	int iStyle;
	TCHAR *szText;
}button[] =
{
	"BUTTON", BS_GROUPBOX, "Uczelnia",
	"BUTTON", BS_GROUPBOX, "Rodzaj studiów",
	"EDIT", WS_BORDER, "",
	"EDIT", WS_BORDER, "",
	"BUTTON", BS_AUTOCHECKBOX, "dzienne",
	"BUTTON", BS_AUTOCHECKBOX, "uzupe³niaj¹ce",
	"BUTTON", BS_PUSHBUTTON, "Akceptuj",
	"BUTTON", BS_PUSHBUTTON, "Anuluj",
	"COMBOBOX", WS_EX_STATICEDGE, "",
};

#define NUM (sizeof button/sizeof button[0])
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
		"Wybór uczelni",
		WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT,
		CW_USEDEFAULT,
		500,
		280,
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
	static HWND hwndButton[NUM];
	static int cxChar, cyChar;
	static RECT r;
	PAINTSTRUCT ps;
	HDC hdc;
	int i;
	const char *ComboBoxItems[] = { "3-letnie", "4-letnie", "5-letnie",
		"6-letnie" };
	switch (message)
	{
	case WM_CREATE:
		cxChar = LOWORD(GetDialogBaseUnits());
		cyChar = HIWORD(GetDialogBaseUnits());
		hwndButton[0] = CreateWindow(button[0].szClass,
			button[0].szText,
			WS_CHILD | WS_VISIBLE | button[0].iStyle,
			cxChar, cyChar, cxChar * 58, cyChar * 6, hwnd, (HMENU)0, ((LPCREATESTRUCT)lParam)->hInstance, NULL);
		hwndButton[1] = CreateWindow(button[1].szClass,
			button[1].szText,
			WS_CHILD | WS_VISIBLE | button[1].iStyle,
			cxChar, cyChar * 7, cxChar * 58, cyChar * 5.5, hwnd, (HMENU)1, ((LPCREATESTRUCT)lParam)->hInstance, NULL);
		hwndButton[2] = CreateWindow(button[2].szClass,
			button[2].szText,
			WS_CHILD | WS_VISIBLE | button[2].iStyle,
			cxChar * 12, cyChar * 3, cxChar * 46, cyChar, hwnd, (HMENU)2, ((LPCREATESTRUCT)lParam)->hInstance, NULL);
		hwndButton[3] = CreateWindow(button[3].szClass,
			button[3].szText,
			WS_CHILD | WS_VISIBLE | button[3].iStyle,
			cxChar * 12, cyChar * 5, cxChar * 46, cyChar, hwnd, (HMENU)3, ((LPCREATESTRUCT)lParam)->hInstance, NULL);
		hwndButton[4] = CreateWindow(button[4].szClass,
			button[4].szText,
			WS_CHILD | WS_VISIBLE | button[4].iStyle,
			cxChar * 12, cyChar * 11, cxChar * 9, cyChar, hwnd, (HMENU)4, ((LPCREATESTRUCT)lParam)->hInstance, NULL);
		hwndButton[5] = CreateWindow(button[5].szClass,
			button[5].szText,
			WS_CHILD | WS_VISIBLE | button[5].iStyle,
			cxChar * 22, cyChar * 11, cxChar * 15, cyChar, hwnd, (HMENU)5, ((LPCREATESTRUCT)lParam)->hInstance, NULL);
		hwndButton[6] = CreateWindow(button[6].szClass,
			button[6].szText,
			WS_CHILD | WS_VISIBLE | button[6].iStyle,
			cxChar, cyChar * 13, cxChar * 10, cyChar*1.5, hwnd, (HMENU)BTN_ACCEPT, ((LPCREATESTRUCT)lParam)->hInstance, NULL);
		hwndButton[7] = CreateWindow(button[7].szClass,
			button[7].szText,
			WS_CHILD | WS_VISIBLE | button[7].iStyle,
			cxChar * 49, cyChar * 13, cxChar * 10, cyChar*1.5, hwnd, (HMENU)BTN_CANCEL, ((LPCREATESTRUCT)lParam)->hInstance, NULL);
		hwndButton[8] = CreateWindow(button[8].szClass,
			NULL,
			CBS_DROPDOWNLIST | WS_CHILD | WS_VISIBLE | button[8].iStyle,
			cxChar * 12, cyChar * 9, cxChar * 46, 200, hwnd, (HMENU)8, NULL, NULL);
		for (i = 0; i <(sizeof ComboBoxItems / sizeof *ComboBoxItems); i++)
		{
			SendMessage(hwndButton[8], CB_ADDSTRING, 0, ComboBoxItems[i]);
		}
		SendMessage(hwndButton[8], CB_SETCURSEL, 0, 0);

		break;
	case WM_PAINT:
		hdc = BeginPaint(hwnd, &ps);
		SetBkMode(hdc, TRANSPARENT);
		TextOut(hdc, cxChar * 2, cyChar * 3, "Nazwa:", strlen("Nazwa:"));
		TextOut(hdc, cxChar * 2, cyChar * 5, "Adres:", strlen("Adres:"));
		TextOut(hdc, cxChar * 2, cyChar * 9, "Cykl nauki:", strlen("Cykl nauki:"));
		EndPaint(hwnd, &ps);
		break;
	case WM_COMMAND: {
		if (LOWORD(wParam) == BTN_ACCEPT) {
			char buffer[160];
			char buffer2[80];
			SendMessage(hwndButton[2], WM_GETTEXT, sizeof(buffer) / sizeof(buffer[0]), (LPARAM)(buffer));
			SendMessage(hwndButton[3], WM_GETTEXT, sizeof(buffer2) / sizeof(buffer2[0]), (LPARAM)(buffer2));
			StrCat(buffer, "\n");
			StrCat(buffer, buffer2);
			SendMessage(hwndButton[8], WM_GETTEXT, sizeof(buffer2) / sizeof(buffer2[0]), (LPARAM)(buffer2));
			StrCat(buffer, "\n");
			StrCat(buffer, buffer2);
			StrCat(buffer, "\n");
			LRESULT chkState = SendMessage((HWND)hwndButton[4], BM_GETCHECK, 0, 0);
			LRESULT chkState2 = SendMessage((HWND)hwndButton[5], BM_GETCHECK, 0, 0);
			if (chkState == BST_CHECKED){
				SendMessage(hwndButton[4], WM_GETTEXT, sizeof(buffer2) / sizeof(buffer2[0]), (LPARAM)(buffer2));
				StrCat(buffer, buffer2);
				StrCat(buffer, " ");
			}
			if (chkState2 == BST_CHECKED){
				SendMessage(hwndButton[5], WM_GETTEXT, sizeof(buffer2) / sizeof(buffer2[0]), (LPARAM)(buffer2));
				StrCat(buffer, buffer2);
			}
			MessageBox(NULL, buffer, "OK", MB_OK);
		}
		if (LOWORD(wParam) == BTN_CANCEL){
			PostQuitMessage(0);
		}
		break;
	}
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hwnd, message, wParam, lParam);
	}

	return 0;
}