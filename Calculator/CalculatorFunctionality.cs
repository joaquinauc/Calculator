using CalculatorLibrary;
using System.Runtime.Serialization;

namespace CalculatorProgram;

internal static class CalculatorFunctionality
{
    internal static void CalculatorLogic(string? numInput1 = "")
    {
        bool endApp = false;
        int timesCalculatorIsUsed = 0;

        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");

        Calculator calculator = new();

        while (!endApp)
        {
            double result = 0;
            string operationSymbol = "";

            timesCalculatorIsUsed = calculator.CalculatorUsed(timesCalculatorIsUsed);

            Console.WriteLine($"Times calculator has been used: {timesCalculatorIsUsed}\n");

            if (numInput1 == "")
            {
                Console.Write("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Your first number is: {numInput1}");
                endApp = true;
            }

            double cleanNum1;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput1 = Console.ReadLine();
            }


            Console.Write("Type another number, and then press Enter: ");

            string? numInput2 = Console.ReadLine();

            double cleanNum2;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput2 = Console.ReadLine();
            }

            // T0D0: Move the calling of the MathOperationsMenu method to the start of the loop to make it easier to implement the other operations.

            Enums.MathOperation mathOperation = CalculatorInterface.MathOperationsMenu();
            operationSymbol = mathOperation switch
            {
                Enums.MathOperation.Add => "+",
                Enums.MathOperation.Subtract => "-",
                Enums.MathOperation.Multiply => "*",
                Enums.MathOperation.Divide => "/",
                _ => throw new NotImplementedException()
            };

            result = Math.Round(calculator.DoOperation(cleanNum1, cleanNum2, operationSymbol), 2);
            if (double.IsNaN(result))
            {
                Console.WriteLine("This operation will result in a mathematical error.\n");
            }
            else Console.WriteLine($"Your result: {result}");

            string fullOperationFormat = $"{numInput1} {operationSymbol} {numInput2} = {result}";

            Helpers.AddToHistory((fullOperationFormat, result));

            if (endApp == false)
            {
                Console.WriteLine("------------------------\n");
                Console.Write("Press 'n' and Enter to return to the calculator menu, or press any other key or Enter to continue: ");

                if (Console.ReadLine() == "n") endApp = true;
            }
            else
            {
                Console.WriteLine("\nPress Enter to exit to the main menu...");
                Console.ReadLine();
            }

            Console.WriteLine("\n");

            numInput1 = "";
        }
        calculator.Finish();
    }
            

    internal static void ShowLatestHistory()
    {
        int indexOfCalculation = CalculatorInterface.LatestHistoryMenu();

        CalculatorInterface.UseOrDelete(indexOfCalculation);
    }
}
