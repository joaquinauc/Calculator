namespace CalculatorProgram;

internal class Helpers
{
    internal static List<(string, double)> LatestHistory { get; private set; } = [];

    internal static void AddToHistory((string, double) calculation)
    {
        LatestHistory.Add(calculation);
    }
}
