using Microsoft.AspNetCore.Builder;
using System;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Работа на занятии

//1.
app.MapGet("/", () => DateTime.Now.ToString());

//2.
app.MapGet("/new_year", GetNumberDaysUntilNewYear);

string GetNumberDaysUntilNewYear()
{
    DateTime startDate = DateTime.Now;
    DateTime endDate = new DateTime(DateTime.Today.Year, 12, 31);

    int countDays = (endDate - startDate).Days;

    return $"До Нового Года осталось {countDays} дней!";
}



//Домашнее задание

//1.
//Необходимо создать веб приложение со страницей (/customs_duty), 
//которая будет вычислять размер таможенной пошлины: в параметре price передается стоимость посылки.
//Пошлина начисляется при превышении 200€, а ее размер равен 15% от суммы превышения.

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

    return $"Пошлина составляет {amount} $";
    
}
//https://localhost/customs_duty?price=400 - адрес, по которому отображается размер пошлины. 400 - стоимость посылки (можем изменить)


//2.
//*Реализуйте страницу, которая будет показывать текущую дату и время 
//в полном формате (включая название дня недели и месяца), на языке, 
//переданном в параметре language. Параметр language передается в формате ISO 639-1 (ru, en, fr, cn и т. д.).

app.MapGet("/today", GetDateToday);

string GetDateToday(string language)
{
    return $"{DateTime.Now.ToString("dddd dd MMMM yyyy HH:mm:ss", CultureInfo.GetCultureInfo(language))}";
}

//https://localhost/today?language=ru
//en - английский
//fi - финский
//fr - французский
//de - Немецкий
//be - Белорусский
//https://translated.turbopages.org/proxy_u/en-ru.ru.be36cb6a-64750e84-7a975dbd-74722d776562/https/en.wikipedia.org/wiki/List_of_ISO_639-1_codes - ссылка на список кодов ISO 639-1

app.Run();
