using System;
using University.Lists;
using University.Structures;

namespace University
{
    class Program
    {
        static void Main()
        {
            University.Structures.Stack<string> stack = new University.Structures.Stack<string>();

            stack.Push("Minecraft");
            Console.WriteLine(stack.Empty());
        }
    }
}