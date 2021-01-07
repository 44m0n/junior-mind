using System;
using Json;

namespace MainProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No arguments were given. Please insert the json file path!");
                return;
            }

            var value = new Value();
            string jsonData = System.IO.File.ReadAllText(args[0]);

            var result = value.Match(jsonData);

            Console.WriteLine(
                result.Success()
                ? "Json is valid!"
                : $"Json is invalid! \n\n {result.RemainingText()}");
        }
    }
}
