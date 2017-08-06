using System;

namespace Godreault.MartinDown
{
    public class Program
    {

        static void Main(string[] args) {
            MarkDown markdown = new MarkDown();
            Console.WriteLine(markdown.Transform("Hello World!"));
        }
    }
}