
using System.Diagnostics;


//1) Проверь, что среди запущенных программ есть калькулятор

Console.WriteLine("IfCalcEnable");
string programName = "calc.exe";
try
{
    var resCalc = Process.GetProcessesByName(programName).FirstOrDefault();

    if (resCalc == null)
    {
        Console.WriteLine($"Process with name {programName} has not been found!");
    }
    else
    {
        Console.WriteLine($"yes, process with name {programName} has been found");
    }

}
catch (Exception ex)
{
    Console.WriteLine($"Error with finding proccess {ex.Message}");
}

Console.WriteLine("\n\n");


//2) Проверить, что среди программ запущенных на пк есть та, что введет пользователь

Console.WriteLine("UserInput");
Console.Write($"Enter name of program to check if it`s running : ");
string userInput = Console.ReadLine();

try
{
    var resUserInput = Process.GetProcessesByName(userInput).FirstOrDefault();

    if(resUserInput == null)
    {
        Console.WriteLine($"Process with name {userInput} has not been found!");
    }
    else 
    { 
        Console.WriteLine($"yes, process with name {userInput} has been found"); 
    }

} catch(Exception ex)
{ 
    Console.WriteLine($"Error with finding proccess {ex.Message}"); 
}


Console.WriteLine("\n\n");


//3) Вывести список программ с приоритетом выполнения выше 7
Console.WriteLine("Priority");
Console.WriteLine($"Running programs with priority more than 7 : ");

foreach (var item in Process.GetProcesses())
{
    if (item.BasePriority > 7)
    {
        Console.WriteLine($"{item.ProcessName}\t{item.BasePriority}");
    }
}
Console.WriteLine("\n\n");



//4) Закрыть все копии ГуглХрома

Console.WriteLine("\n\n");



//5) Вывести список имен программ. Запросить у пользователя ид той, что нужно закрыть и сделать это
Console.WriteLine("CloseProgrammeById");
Console.Write($"This is list of running programs: ");

foreach (var item in Process.GetProcesses())
{
    Console.WriteLine($" ProcessName :{item.ProcessName}, ProcessId :{item.Id}; ");
}
Console.WriteLine($"Which programme do you want to close? ");
string idToCloseProg = Console.ReadLine();

try
{
    if (!int.TryParse(idToCloseProg, out int idToClose))
    {
        Console.WriteLine($"Invalid input! Enter a valid process id!");
        return;
    }
    var resProcessToClose = Process.GetProcessById(idToClose);

    if (resProcessToClose == null)
    {
        Console.WriteLine($"Process with id : {idToClose} has not been found!");
    }
    else
    {
        resProcessToClose.Kill();
        Console.WriteLine($"Process with id {idToClose} has been killed successfully!");
    }


}
catch (Exception ex)
{
    Console.WriteLine($"Error with finding proccess {ex.Message}");
}


Console.WriteLine("\n\n");


//6) Запретить запуск ГуглХрома
Console.WriteLine("\n\n");
