using Microsoft.AspNetCore.Builder;
using System;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//������ �� �������

//1.
app.MapGet("/", () => DateTime.Now.ToString());

//2.
app.MapGet("/new_year", GetNumberDaysUntilNewYear);

string GetNumberDaysUntilNewYear()
{
    DateTime startDate = DateTime.Now;
    DateTime endDate = new DateTime(DateTime.Today.Year, 12, 31);

    int countDays = (endDate - startDate).Days;

    return $"�� ������ ���� �������� {countDays} ����!";
}



//�������� �������

//1.
//���������� ������� ��� ���������� �� ��������� (/customs_duty), 
//������� ����� ��������� ������ ���������� �������: � ��������� price ���������� ��������� �������.
//������� ����������� ��� ���������� 200�, � �� ������ ����� 15% �� ����� ����������.

app.MapGet("/customs_duty", GetAmountCustomsDuty);

string GetAmountCustomsDuty( double price)
{
    double amount = 0;

    if (price > 200)
    {
        amount = (price - 200) / 100 * 15;

    }
    else
    {
        amount = 0;
    }

    return $"������� ���������� {amount} $";
    
}
//https://localhost/customs_duty?price=400 - �����, �� �������� ������������ ������ �������. 400 - ��������� ������� (����� ��������)


//2.
//*���������� ��������, ������� ����� ���������� ������� ���� � ����� 
//� ������ ������� (������� �������� ��� ������ � ������), �� �����, 
//���������� � ��������� language. �������� language ���������� � ������� ISO 639-1 (ru, en, fr, cn � �. �.).

app.MapGet("/today", GetDateToday);

string GetDateToday(string language)
{
    return $"{DateTime.Now.ToString("dddd dd MMMM yyyy HH:mm:ss", CultureInfo.GetCultureInfo(language))}";
}

//https://localhost/today?language=ru
//en - ����������
//fi - �������
//fr - �����������
//de - ��������
//be - �����������
//https://translated.turbopages.org/proxy_u/en-ru.ru.be36cb6a-64750e84-7a975dbd-74722d776562/https/en.wikipedia.org/wiki/List_of_ISO_639-1_codes - ������ �� ������ ����� ISO 639-1

app.Run();
