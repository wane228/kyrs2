#include <iostream>
#include<string>
#include<fstream>

using namespace std;

class config
{
private:
	static config* single;
	string pass, login, ip;
public:
	static config* getInstance()
	{
		if (single == nullptr)
		{
			single = new config();
			single->pass = "";
			single->login = "";
			single->ip = "";
		}
		return single;
	}

	bool readFromfile()
	{
		ifstream file1("config.conf");
		string temp;
		while (getline(file1, temp))
		{
			int i = 0;
			while (temp[i] != ':')
			{
				i++;
			}
			i += 2;
			while (temp[i] == ' ')
			{
				i++;
			}
			if (temp[0] == 'I')
			{
				while (temp[i] != '\0')
				{
					this->ip += temp[i];
					i++;
				}
			}
			else if (temp[0] == 'P')
			{
				while (temp[i] != '\0')
				{
					this->pass += temp[i];
					i++;
				}
			}
			else if (temp[0] == 'L')
			{
				while (temp[i] != '\0')
				{
					this->login += temp[i];
					i++;
				}
			}
		}
		if (single->ip == "" && single->login == "" && single->pass == "")
		{
			return 0;
		}
		else
		{
			return 1;
		}
	}
	void updateLogin()
	{
		string temp;
		cout << "Введите новый логин: ";
		cin >> temp;
		cout << endl;
		single->login = temp;
	}
	void updatePassword()
	{
		string temp;
		cout << "Введите новый пароль: ";
		cin >> temp;
		cout << endl;
		single->pass = temp;
	}
	void updateIp()
	{
		string temp;
		cout << "Введите новый IP адрес: ";
		cin >> temp;
		cout << endl;
		single->ip = temp;
	}
	void saveTofile()
	{
		ofstream file2("config.conf");
		file2 << "IP: " << single->ip << endl;
		file2 << "LOGIN: " << single->login << endl;
		file2 << "PASSWORD: " << single->pass << endl;
		single->ip.clear();
		single->login.clear();
		single->pass.clear();
	}
	void print()
	{
		if (readFromfile() == 0)
		{
			cout << "Файл пуст" << endl;
		}
		else
		{
			cout << "                 Данные внутри файла" << endl << "IP: " << single->ip << endl << "LOGIN: " << single->login << endl << "PASSWORD: " << single->pass << endl;
		}
	}
};

config* config::single = nullptr;


int main()
{
	setlocale(LC_ALL, "Russian");
	auto a = config::getInstance();
	while (1)
	{
		a->print();
		cout << "Меню:" << endl << "1) Изменить данные файла" << endl << "2) Выйти из программы" << endl;
		int x;
		cin >> x;
		if (x == 1)
		{
			cout << "1) Изменить IP" << endl << "2) Изменить логин" << endl << "3) Изменить пароль" << endl << "4) Выйти из программы" << endl;
			int y;
			cin >> y;
			if (y == 1)
			{
				a->updateIp();
				a->saveTofile();
			}
			else if (y == 2)
			{
				a->updateLogin();
				a->saveTofile();
			}
			else if (y == 3)
			{
				a->updatePassword();
				a->saveTofile();
			}

			else if (y == 4)
			{
				return 0;
			}
		}

		else if (x == 2)
		{
			return 0;
		}
	}
}
