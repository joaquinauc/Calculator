using CalculatorLibrary;

namespace CalculatorProgram;

internal class Helpers
{
    internal static List<(string, double)> LatestHistory { get; private set; } = [];

    internal static void AddToHistory((string, double) calculation)
    {
        if (LatestHistory.Count >= 5) LatestHistory.RemoveAt(0);

        LatestHistory.Add(calculation);
    }

    internal static void DeleteOfHistory(int index)
    {
        LatestHistory.RemoveAt(index);
    }

    internal double GetResult(Calculator calculator, string operationSymbol, double cleanNum1, double cleanNum2 = 0)
    {
        double result = Math.Round(calculator.DoOperation(operationSymbol, cleanNum1, cleanNum2), 2);
        if (double.IsNaN(result))
            Console.WriteLine("This operation will result in a mathematical error.\n");
        else
            Console.WriteLine($"Your result: {result}");

        return result;
    }
}
