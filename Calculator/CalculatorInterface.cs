using Spectre.Console;
using static CalculatorProgram.Enums;

namespace CalculatorProgram;

internal static class CalculatorInterface
{
    internal static void CalculatorMenu()
    {
        CalculatorOption? calculatorOption;
        bool exitProgram = false;

        do
        {
            CalculatorFunctionality calculatorFunctionality = new();

            Console.Clear();

            calculatorOption = AnsiConsole.Prompt(
            new SelectionPrompt<CalculatorOption>()
            .Title("Select which action you wish to do: ")
            .AddChoices(Enum.GetValues<CalculatorOption>())
            );

            if (calculatorOption == CalculatorOption.Exit)
            {
                exitProgram = true;
            }
            else if (calculatorOption == CalculatorOption.LatestCalculations)
            {
                calculatorFunctionality.ShowLatestHistory();
            }
            else
            {
                calculatorFunctionality.CalculatorLogic();
            }

        } while (exitProgram == false);
    }

    internal static int LatestHistoryMenu()
    {
        Console.Clear();

        (string, double) calculationOption;

        try 
        {
            calculationOption = AnsiConsole.Prompt(
            new SelectionPrompt<(string, double)>()
            .Title("Select a calculation which you want to use the result for another calculation, or delete it: ")
            .AddChoices(Helpers.LatestHistory)
            );
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Try again when you have some calculations in your pocket kiddo!\n");
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
            return -1;
        }

        return Helpers.LatestHistory.IndexOf(calculationOption);
        }
}
