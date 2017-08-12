using System;

namespace Godreault.MartinDownSharp
{
    public class Program
    {
       protected static void Main(string[] args) {
            MartinDown martinDown = new MartinDown();
            Console.WriteLine(martinDown.Transform("**Hello World!**"));
        }
    }
}