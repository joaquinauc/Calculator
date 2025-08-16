using CalculatorLibrary;
using System.Text.RegularExpressions;

namespace CalculatorProgram;

internal static class CalculatorFunctionality
{
    internal static void CalculatorLogic()
    {
        bool endApp = false;
        int timesCalculatorIsUsed = 0;

        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");

        Calculator calculator = new();

        while (!endApp)
        {
            string? numInput1 = "";
            string? numInput2 = "";
            double result = 0;
            string operationSymbol = "";

            timesCalculatorIsUsed = calculator.CalculatorUsed(timesCalculatorIsUsed);

            Console.WriteLine($"Times calculator has been used: {timesCalculatorIsUsed}\n");

            Console.Write("Type a number, and then press Enter: ");
            numInput1 = Console.ReadLine();

            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput1 = Console.ReadLine();
            }

            Console.Write("Type another number, and then press Enter: ");
            numInput2 = Console.ReadLine();

            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput2 = Console.ReadLine();
            }

            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.Write("Your option? ");

            string? op = Console.ReadLine();

            if (op == null || !Regex.IsMatch(op, "[a|s|m|d]"))
            {
                Console.WriteLine("Error: Unrecognized input.");
            }
            else
            {
                try
                {
                    operationSymbol = op switch
                    {
                        "a" => "+",
                        "s" => "-",
                        "m" => "*",
                        "d" => "/",
                        _ => throw new NotImplementedException()
                    };

                    result = Math.Round(calculator.DoOperation(cleanNum1, cleanNum2, op), 2);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine($"Your result: {result}");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }
            }

            string fullOperationFormat = $"{numInput1} {operationSymbol} {numInput2} = {result}";

            Helpers.AddToHistory((fullOperationFormat, result));

            Console.WriteLine("------------------------\n");

            Console.Write("Press 'n' and Enter to return to the calculator menu, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("\n");

        }

        calculator.Finish();
    }

    internal static void ShowLatestHistory()
    {
        int result = CalculatorInterface.LatestHistoryMenu();

        Console.WriteLine(result);
        Console.ReadLine();
    }
}
