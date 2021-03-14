using System;
namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] mathGrades = { 9, 9, 10 };
            double[] historyGrades = { 10, 10, 10 };
            double[] englishGrades = { 8, 8, 9 };
            double[] averages = new double[3];
            averages[0] = Average(mathGrades);
            averages[1] = Average(historyGrades);
            averages[2] = Average(englishGrades);
            PrintAverages(averages);
            Console.Read();
        }

        static void PrintAverages(double[] averages)
        {
            string text = "";
            for (int i = 0; i < averages.Length; i++)
                text += string.Format("{0:F2} ", averages[i]);
            Console.WriteLine(text);
            Console.Write("Media generala: ");
            text = string.Format("{0:F2}", Average(averages));
            Console.WriteLine(text);
        }

        static double Average(double[] grades)
        {
            double sum = 0;
            for (int i = 0; i < grades.Length; i++)
                sum += grades[i];
            return sum / grades.Length;
        }

    }
}