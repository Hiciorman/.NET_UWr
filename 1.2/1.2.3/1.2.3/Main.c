#include <Windows.h>
#include <stdio.h>
#include <stdlib.h>

#define THREAD_MAX 6
#define CLIENTS_MAX 5
DWORD WINAPI ThreadGolibroda(LPVOID* theArg);
DWORD WINAPI ThreadKlient(LPVOID* theArg);
int customersNumber = 5;
int isBusy = 0; // 1 - busy, 0 - free

int main()
{
	HANDLE hMutex, hTread[THREAD_MAX];
	DWORD threadGolibroda, threadKlient;
	int i;
	
	hMutex = CreateMutex(NULL, FALSE, "Gabinet");
	for (i = 0; i < THREAD_MAX/2; i++){
		hTread[2*i+1] = CreateThread(NULL, 0, ThreadGolibroda, &hMutex, 0, &threadGolibroda);
		hTread[2*i] = CreateThread(NULL, 0, ThreadKlient, &hMutex, 0, &threadKlient);
	}
	WaitForMultipleObjects(THREAD_MAX, hTread, TRUE, INFINITE);
	CloseHandle(hMutex);
	for (i = 0; i < THREAD_MAX; i++){
		CloseHandle(hTread[i]);
	}
	getchar();
}

DWORD WINAPI ThreadGolibroda(LPVOID* theArg)
{
	HANDLE hMutex = (HANDLE)*theArg;
	WaitForSingleObject(hMutex, INFINITE);
	printf("Golibroda sprawdza liczbe klientow: %d.\n", customersNumber);
	if (customersNumber > 0){
		customersNumber--;
		printf("Golibroda obsluguje klienta. Pozostalo %d osob w poczekalni.\n", customersNumber);
		isBusy = 1;
	}
	else
	{
		printf("Golibroda wraca do gabinetu i zasypia.\n");
		isBusy = 0;
	}
	ReleaseMutex(hMutex);
	return TRUE;
}
DWORD WINAPI ThreadKlient(LPVOID* theArg)
{
	HANDLE hMutex = (HANDLE)*theArg;
	WaitForSingleObject(hMutex, INFINITE);
	printf("Nowy klient wchodzi do salonu.\n");
	if (customersNumber == CLIENTS_MAX){
		printf("Klient wychodzi.\n");
	}
	else if (isBusy == 1){
		customersNumber++;
		printf("Klient siada w poczekalni. Klientow w poczekalni %d.\n", customersNumber);
	}
	else{
		printf("Klient budzi Golibrode i siada na krzesle.\n");
	}

	ReleaseMutex(hMutex);
	return TRUE;
}