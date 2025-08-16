namespace CalculatorProgram;

internal class Helpers
{
    internal static List<(string, double)> LatestHistory { get; private set; } = [];

    internal static void AddToHistory((string, double) calculation)
    {
        if (LatestHistory.Count >= 5) LatestHistory.RemoveAt(0);

        LatestHistory.Add(calculation);
    }
}
