using Spectre.Console;
using static CalculatorProgram.Enums;

namespace CalculatorProgram;

internal class CalculatorInterface
{
    internal static void CalculatorMenu()
    {
        CalculatorOption? calculatorOption;

        do
        {
            Console.Clear();

            calculatorOption = AnsiConsole.Prompt(
            new SelectionPrompt<CalculatorOption>()
            .Title("Select which action you wish to do: ")
            .AddChoices(Enum.GetValues<CalculatorOption>())
            );


        } while (calculatorOption != CalculatorOption.Exit);
    }
}
