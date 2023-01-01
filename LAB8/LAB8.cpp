#include<iostream>
#include<cmath>
#include<stdlib.h>
#include<Windows.h>
#include <ctime>

using namespace std;

short const MAX_SIZE_ROWS = 10;
short const MAX_SIZE_COLUMNS = 10;

short input_from_zero_to_max(short max_value, const char fail_message[]);
short input_short();
void rand_array(short mas[][MAX_SIZE_COLUMNS], short size_rows, short size_columns);
void manual_array(short mas[][MAX_SIZE_COLUMNS], short size_rows, short size_columns);
int chooseYesOrNo();
void output_matrix(short mas[][MAX_SIZE_COLUMNS], short size_rows, short size_columns);
void change_to_zero(short mas[][MAX_SIZE_COLUMNS], short size_rows, short size_columns);


int main()
{
	SetConsoleOutputCP(1251);

	const int YES = 1;
	const int NO = 0;

	int repeatCalculations = 0;
	short size_columns;
	short size_rows;
	short mas[MAX_SIZE_ROWS][MAX_SIZE_COLUMNS];

	do
	{
		cout << "Введіть кількість рядків, до 10 елементів включно.--> ";
		size_rows = input_from_zero_to_max(MAX_SIZE_ROWS, "    Некоректно задано кількість рядків масиву. Спробуйту ще--> ");
		
		cout << "Введіть кількість стовпців, до 10 елементів включно.--> ";
		size_columns = input_from_zero_to_max(MAX_SIZE_COLUMNS, "    Некоректно задано кількість стовпців масиву. Спробуйте ще--> ");
		
		cout << "Бажаєте ввести елементи вручну?" << endl;
		int inputArrayManually = chooseYesOrNo();
		if (inputArrayManually == NO)
		{
			rand_array(mas, size_rows, size_columns);
		}
		else
		{
			manual_array(mas,size_rows, size_columns);
		}
		output_matrix(mas, size_rows, size_columns);

		change_to_zero(mas, size_rows, size_columns);
		output_matrix(mas, size_rows, size_columns);

		cout << "Бажаєте повторити обчислення?" << endl;
		repeatCalculations= chooseYesOrNo();

		system("CLS");
	} while (repeatCalculations == YES);

}

short input_from_zero_to_max(short max_value, const char fail_message[])
{
	short value;
	cin >> value;
	while (value <= 0 || value > MAX_SIZE_ROWS)
	{
		cout << fail_message;
		cin >> value;
	}
	return value;
}

short input_short()
{
	double temp;
	cin >> temp;
	while (temp < SHRT_MIN || temp > SHRT_MAX)
	{
		cout << "    Ви ввели недопустиме значення (тип short), спробуйте ще раз: ";
		cin >> temp;
	}

	short input = (short)temp;
	return input;
}
void change_to_zero(short mas[][MAX_SIZE_COLUMNS], short size_rows, short size_columns)
{
	if (size_rows != size_columns)
	{
		cout << "Задана матриця не є квадратною. Заміну елементів на нуль не проведено." << endl;
		return;
	}

	cout << "Задана матриця є квадратною. Проведено заміну елементів на нуль." << endl;
	for (int i = 0; i < size_rows; i++)
	{
		for (int j = i; j < size_columns; j++)
		{
			mas[i][j] = 0;
		}
	}
}

void output_matrix(short mas[][MAX_SIZE_COLUMNS], short size_rows, short size_columns)
{
	cout << endl;
	for (int i = 0; i < size_rows; i++) 
	{
		for (int j = 0; j < size_columns; j++)
		{
			cout << mas[i][j] << "\t";
		}
		cout << endl;
	}
	cout << endl;
}

int chooseYesOrNo()
{
	int temp;

	cout << "Так-->1\tНі-->0: ";
	cin >> temp;

	while (temp != 0 && temp != 1)
	{
		cout << "Дана функція вибору відсутня. Спробуйте знов: ";
		cin >> temp;
	}

	return temp;
}

void rand_array(short mas[][MAX_SIZE_COLUMNS], short size_rows, short size_columns)
{
	srand(time(NULL));
	for (int i = 0; i < size_rows; i++)
	{
		for (int j = 0; j < size_columns; j++)
		{
			mas[i][j] = rand() - INT16_MAX / 2;
			cout << mas[i][j] << endl;
		}
	}
}

void manual_array(short mas[][MAX_SIZE_COLUMNS], short size_rows, short size_columns)
{
	for (int i = 0; i < size_rows; i++)
	{
		for (int j = 0; j < size_columns; j++)
		{
			cout << "Введіть [" << i << "][" << j << "] елемент масиву--> ";
			mas[i][j] = input_short();
		}
	}
}