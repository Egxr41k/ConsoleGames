global using System;

namespace ConsoleChess;

public class Program
{
    public static void Main(string[] args)
    {
        //entery point
        Console.ForegroundColor = ConsoleColor.Green;
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Matrix.ToDefault();
        Matrix.Print();
    }
}