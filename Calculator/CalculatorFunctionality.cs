using CalculatorLibrary;
namespace CalculatorProgram;

internal class CalculatorFunctionality
{
    private int timesCalculatorIsUsed;

    internal void CalculatorLogic(Calculator calculatorLog, string? numInput1 = "")
    {
        bool endApp = false;

        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");

        Helpers helpers = new();
        CalculatorInterface calculatorInterface = new();

        while (!endApp)
        {
            string fullOperationFormat;
            double result;

            Enums.MathOperation mathOperation = calculatorInterface.MathOperationsMenu();

            string operationSymbol = mathOperation switch
            {
                Enums.MathOperation.Add => "+",
                Enums.MathOperation.Subtract => "-",
                Enums.MathOperation.Multiply => "*",
                Enums.MathOperation.Divide => "/",
                Enums.MathOperation.SquareRoot => "√",
                Enums.MathOperation.TakingThePower => "^",
                Enums.MathOperation.TenElevatedToX => "10x",
                Enums.MathOperation.Sin => "Sin",
                Enums.MathOperation.Cos => "Cos",
                Enums.MathOperation.Tan => "Tan",
                _ => throw new NotImplementedException()
            };

            Console.WriteLine($"Times calculator has been used: {timesCalculatorIsUsed++}\n");

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

            if ("+ - * / ^".Contains(operationSymbol))
            {
                Console.Write("Type another number, and then press Enter: ");
                string? numInput2 = Console.ReadLine();

                double cleanNum2;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not valid input. Please enter a numeric value: ");
                    numInput2 = Console.ReadLine();
                }

                result = helpers.GetResult(calculatorLog, operationSymbol, cleanNum1, cleanNum2);

                fullOperationFormat = $"{numInput1} {operationSymbol} {numInput2} = {result}";
            }
            else
            {
                result = helpers.GetResult(calculatorLog, operationSymbol, cleanNum1);

                fullOperationFormat = $"{operationSymbol} {numInput1} = {result}";
            }

            Helpers.AddToHistory((fullOperationFormat, result));

            if (endApp == false)
            {
                Console.WriteLine("------------------------\n");

                Enums.ContinueUsingOption continueUsingOption = calculatorInterface.ContinueOrExit();

                if (continueUsingOption == Enums.ContinueUsingOption.Exit) endApp = true;
            }
            else
            {
                Console.WriteLine("\nPress Enter to exit to the main menu...");
                Console.ReadLine();
            }

            Console.WriteLine("\n");

            numInput1 = "";
        }
    }       

    internal static void ShowLatestHistory(CalculatorInterface calculatorInterface, Calculator calculatorLog)
    {
        int? indexOfCalculation = calculatorInterface.LatestHistoryMenu();

        if (indexOfCalculation.HasValue)
        {
            calculatorInterface.UseOrDelete((int)indexOfCalculation, calculatorLog);
        }
    }
}
