using System;
using System.Collections.Generic;
using System.Linq;

using dbConsole.API;

namespace CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter command: ");
                var command = Console.ReadLine();
                var parts = command.Split(' ');
                var result = Engine.Execute(parts);
                foreach (var line in result)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
