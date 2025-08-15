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
                continue;
            }

            calculatorFunctionality.CalculatorLogic();

        } while (exitProgram == false);
    }
}
