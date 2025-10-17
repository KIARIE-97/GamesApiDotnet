using System;

class Program
{
    static void Main(string[] args)
    {
         Console.BackgroundColor= ConsoleColor.Cyan;
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Title = "understanding console color";
        Console.WriteLine("BackgroundColor: cyan");
        Console.WriteLine("ForegroundColor: magenta");
        Console.WriteLine("Title: Understanding Console Class");

        Console.Beep();
    }
}
