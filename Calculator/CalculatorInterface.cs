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
            Console.Clear();

            calculatorOption = AnsiConsole.Prompt(
                new SelectionPrompt<CalculatorOption>()
                .Title("Select which action you wish to do: ")
                .AddChoices(Enum.GetValues<CalculatorOption>())
                .UseConverter(option =>
                {
                    return option switch
                    {
                        CalculatorOption.Calculator => "Use the calculator",
                        CalculatorOption.LatestCalculations => "See your calculations history",
                        CalculatorOption.Exit => "Exit the program",
                        _ => option.ToString()
                    };
                })
            );

            if (calculatorOption == CalculatorOption.Exit)
            {
                exitProgram = true;
            }
            else if (calculatorOption == CalculatorOption.LatestCalculations)
            {
                CalculatorFunctionality.ShowLatestHistory();
            }
            else
            {
                CalculatorFunctionality.CalculatorLogic();
            }

        } while (!exitProgram);
    }

    internal static MathOperation MathOperationsMenu()
    {
        Console.Clear();

        var mathOperation = AnsiConsole.Prompt(
            new SelectionPrompt<MathOperation>()
            .Title("Select which math operation you wish to do: ")
            .AddChoices(Enum.GetValues<MathOperation>())
        );

        return mathOperation;
    }

    internal static int? LatestHistoryMenu()
    {
        Console.Clear();

        (string, double) calculationOption;

        try
        {
            calculationOption = AnsiConsole.Prompt(
                new SelectionPrompt<(string, double)>()
                .Title("Select a calculation which you want to use the result for another calculation, or delete it: ")
                .AddChoices(Helpers.LatestHistory)
                .UseConverter(option => option.Item1)
            );
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Try again when you have some calculations in your pocket kiddo!\n");
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
            return null;
        }
        return Helpers.LatestHistory.IndexOf(calculationOption);
    }

    internal static void UseOrDelete(int indexOfCalculation)
    {
        Console.Clear();

        var useOrDeleteOption = AnsiConsole.Prompt(
            new SelectionPrompt<DeleteOrUseResult>()
            .Title("Select an option: ")
            .AddChoices(Enum.GetValues<DeleteOrUseResult>())
            .UseConverter(option =>
            {
                return option switch
                {
                    DeleteOrUseResult.UseResult => "Continue with this result",
                    DeleteOrUseResult.Delete => "Delete from history",
                    _ => option.ToString()
                };
            })
        );

        if (useOrDeleteOption == DeleteOrUseResult.UseResult)
        {
            string resultOfCalculation = String.Format("{0}", Helpers.LatestHistory[indexOfCalculation].Item2);
            CalculatorFunctionality.CalculatorLogic(resultOfCalculation);
        }
        else
        {
            Helpers.DeleteOfHistory(indexOfCalculation);
        }
    }

    internal static ContinueUsingOption ContinueOrExit()
    {
        var useOrDeleteOption = AnsiConsole.Prompt(
            new SelectionPrompt<ContinueUsingOption>()
            .Title("Do you want to continue using or exit the program? ")
            .AddChoices(Enum.GetValues<ContinueUsingOption>())
        );

        return useOrDeleteOption;
    }
}
