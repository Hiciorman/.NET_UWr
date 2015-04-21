#include <Windows.h>
#include <CommCtrl.h>

LRESULT CALLBACK WindowProcedure(HWND, UINT, WPARAM, LPARAM);

char windowName[] = "Common Controls";
#define NUM 3
#define ID_FILE_NEW 1010
#define ID_FILE_OPEN 40002
#define ID_FILE_SAVE 1012
HINSTANCE hInst;

int WINAPI WinMain(HINSTANCE hInstance,
	HINSTANCE hPrevInstance,
	LPSTR lpCmdLine,
	int nShowCmd)
{
	HWND hwnd;
	MSG messages;
	WNDCLASSEX wincl;
	hInst = hInstance;

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
		"Common Controls",
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

int xSize, ySize, p = 0;

LRESULT CALLBACK WindowProcedure(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	static HWND hStatus;
	static HWND hTool;
	static HWND hProgress;
	RECT r;
	TBBUTTON tbb[NUM];
	TBADDBITMAP tbab;
	int statWidths[] = { 100, 200, 300, -1 };

	switch (message)
	{
	case WM_SIZE:
		xSize = LOWORD(lParam);
		ySize = HIWORD(lParam);

		SendMessage(hStatus, WM_SIZE, 0, 0);
		SendMessage(hTool, WM_SIZE, 0, 0);

		GetClientRect(hwnd, &r);
		InvalidateRect(hwnd, &r, 1);
		break;
	case WM_CREATE:
		// Status Bar
		hStatus = CreateWindowEx(0, STATUSCLASSNAME, NULL, WS_CHILD | WS_VISIBLE | SBARS_SIZEGRIP, 0, 0, 0, 0, hwnd, (HMENU)message, GetModuleHandle(NULL), NULL);
		SendMessage(hStatus, SB_SETPARTS, sizeof statWidths / sizeof *statWidths, statWidths);
		SendMessage(hStatus, SB_SETTEXT, 0, (LPARAM)"Hi there :)");
		SendMessage(hStatus, SB_SETTEXT, 1, (LPARAM)"Next part");
		SendMessage(hStatus, SB_SETTEXT, 2, (LPARAM)"And again");
		SendMessage(hStatus, SB_SETTEXT, 3, (LPARAM)"One more!");

		//Tool Bar
		hTool = CreateWindowEx(0, TOOLBARCLASSNAME, NULL, WS_CHILD | WS_VISIBLE, 0, 0, 0, 0, hwnd, (HMENU)message, GetModuleHandle(NULL), NULL);
		SendMessage(hTool, TB_BUTTONSTRUCTSIZE, (WPARAM)sizeof(TBBUTTON), 0);
		
		tbab.hInst = HINST_COMMCTRL;
		tbab.nID = IDB_STD_SMALL_COLOR;
		SendMessage(hTool, TB_ADDBITMAP, 0, (WPARAM)&tbab);
		
		ZeroMemory(tbb, sizeof(tbb));
		tbb[0].iBitmap = STD_FILENEW;
		tbb[0].fsState = TBSTATE_ENABLED;
		tbb[0].fsStyle = TBSTYLE_BUTTON;
		tbb[0].idCommand = ID_FILE_NEW;

		tbb[1].iBitmap = STD_FILEOPEN;
		tbb[1].fsState = TBSTATE_ENABLED;
		tbb[1].fsStyle = TBSTYLE_BUTTON;
		tbb[1].idCommand = ID_FILE_OPEN;

		tbb[2].iBitmap = STD_FILESAVE;
		tbb[2].fsState = TBSTATE_ENABLED;
		tbb[2].fsStyle = TBSTYLE_BUTTON;
		tbb[2].idCommand = ID_FILE_SAVE;
		SendMessage(hTool, TB_ADDBUTTONS, NUM, (LPARAM)&tbb);
		
		//Progress Bar
		hProgress = CreateWindowEx(0, PROGRESS_CLASS, NULL, WS_CHILD | PBS_SMOOTH | WS_VISIBLE, 150, 100, 200, 20, hwnd, (HMENU)message, GetModuleHandle(NULL), NULL);


		SendMessage(hProgress, PBM_SETRANGE, 0, MAKELPARAM(0, 2048));
		SendMessage(hProgress, PBM_SETSTEP, (WPARAM)1, 0);
		break;
	case WM_COMMAND:
		switch (LOWORD(wParam)){
		case ID_FILE_NEW:
			MessageBox(hwnd, "Tworzenie nowego pliku!", "OK", MB_OK);
			break;
		case ID_FILE_OPEN:
			MessageBox(hwnd, "Otwieranie istniej¹cego pliku!", "OK", MB_OK);
			break;
		case ID_FILE_SAVE:
			MessageBox(hwnd, "Zapisywanie pliku!", "OK", MB_OK);
			break;
		}
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		if (p == 2048){
			DestroyWindow(hProgress);
		}
		else{
			p++;
			SendMessage(hProgress, PBM_STEPIT, 0, 0);
		}
		return DefWindowProc(hwnd, message, wParam, lParam);
	}

	return 0;
}
