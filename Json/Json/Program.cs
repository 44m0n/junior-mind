using System;
using Json;

namespace MainProgram
{
    class Program
    {
        static void Main(string[] args)
        {
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
