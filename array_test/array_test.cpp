#include<iostream>
#include<stdlib.h>
#include<Windows.h>

using namespace std;
int main()
{
	const int N = 50;
	int array[N];
	int el = N;
	for (int i = 0; i < N; i++)
	{
		array[i] = el--;
	}
}