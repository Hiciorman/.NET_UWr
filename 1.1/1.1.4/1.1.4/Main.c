#include <Windows.h>
#include <CommCtrl.h>
#include <tchar.h>
#include "resource.h"
#include<Shlwapi.h>

//#pragma comment(linker, \
//  "\"/manifestdependency:type='Win32' "\
//  "name='Microsoft.Windows.Common-Controls' "\
//  "version='6.0.0.0' "\
//  "processorArchitecture='*' "\
//  "publicKeyToken='6595b64144ccf1df' "\
//  "language='*'\"")

#pragma comment(lib, "ComCtl32.lib")

INT_PTR CALLBACK DialogProc(HWND hDlg, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	const char *ComboBoxItems[] = { "3-letnie", "4-letnie", "5-letnie", "6-letnie" };
	int i;
	char buffer[160];
	char buffer2[80];

	switch (uMsg)
	{
	case WM_INITDIALOG:
		SendDlgItemMessage(hDlg, IDC_COMBO1, CB_RESETCONTENT, 0, 0);
		for (i = 0; i < (sizeof ComboBoxItems / sizeof *ComboBoxItems); i++){
			SendDlgItemMessage(hDlg, IDC_COMBO1, CB_ADDSTRING, 0, (LPARAM)ComboBoxItems[i]);
		}
		SendDlgItemMessage(hDlg, IDC_COMBO1, CB_SETCURSEL, 0, 0);
		break;
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case ID_CANCEL:
			DestroyWindow(hDlg);
			break;
		case ID_ACCEPT:
			SendDlgItemMessage(hDlg, IDC_EDIT1, WM_GETTEXT, sizeof buffer / sizeof *buffer, (LPARAM)buffer);
			SendDlgItemMessage(hDlg, IDC_EDIT2, WM_GETTEXT, sizeof buffer2 / sizeof *buffer2, (LPARAM)buffer2);
			StrCat(buffer, "\n");
			StrCat(buffer, buffer2);
			SendDlgItemMessage(hDlg, IDC_COMBO1, WM_GETTEXT, sizeof buffer2 / sizeof *buffer2, (LPARAM)buffer2);
			StrCat(buffer, "\n");
			StrCat(buffer, buffer2);
			StrCat(buffer, "\n");
			LRESULT chkState = SendDlgItemMessage(hDlg, IDC_CHECK1, BM_GETCHECK, 0, 0);
			LRESULT chkState2 = SendDlgItemMessage(hDlg, IDC_CHECK2, BM_GETCHECK, 0, 0);
			if (chkState == BST_CHECKED){
				SendDlgItemMessage(hDlg, IDC_CHECK1, WM_GETTEXT, sizeof(buffer2) / sizeof(buffer2[0]), (LPARAM)(buffer2));
				StrCat(buffer, buffer2);
				StrCat(buffer, " ");
			}
			if (chkState2 == BST_CHECKED){
				SendDlgItemMessage(hDlg, IDC_CHECK2, WM_GETTEXT, sizeof(buffer2) / sizeof(buffer2[0]), (LPARAM)(buffer2));
				StrCat(buffer, buffer2);
			}
			MessageBox(NULL, buffer, "OK", MB_OK);
			break;
		}
		break;
	case WM_CLOSE:
		DestroyWindow(hDlg);
		return TRUE;
	case WM_DESTROY:
		PostQuitMessage(0);
		return TRUE;
	}

	return FALSE;
}

int WINAPI _tWinMain(HINSTANCE hInst, HINSTANCE h0, LPTSTR lpCmdLine, int nCmdShow)
{
	HWND hDlg;
	MSG msg;
	BOOL ret;

	InitCommonControls();
	hDlg = CreateDialogParam(hInst, MAKEINTRESOURCE(IDD_DIALOG1), 0, DialogProc, 0);
	ShowWindow(hDlg, nCmdShow);

	while ((ret = GetMessage(&msg, 0, 0, 0)) != 0) {
		if (ret == -1)
			return -1;

		if (!IsDialogMessage(hDlg, &msg)) {
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}

	return 0;
}