using Newtonsoft.Json;

namespace CalculatorLibrary;

public class Calculator
{
    JsonWriter writer;

    public Calculator()
    {
        StreamWriter logFile = File.CreateText("calculatorlog.json");
        logFile.AutoFlush = true;
        writer = new JsonTextWriter(logFile);
        writer.Formatting = Formatting.Indented;
        writer.WriteStartObject();
        writer.WritePropertyName("Operations");
        writer.WriteStartArray();
    }

    public double DoOperation(string op, double num1, double num2)
    {
        double result = double.NaN;
        writer.WriteStartObject();
        writer.WritePropertyName("Operand1");
        writer.WriteValue(num1);
        writer.WritePropertyName("Operand2");
        writer.WriteValue(num2);
        writer.WritePropertyName("Operation");

        switch (op)
        {
            case "+":
                result = num1 + num2;
                writer.WriteValue("Add");
                break;
            case "-":
                result = num1 - num2;
                writer.WriteValue("Subtract");
                break;
            case "*":
                result = num1 * num2;
                writer.WriteValue("Multiply");
                break;
            case "/":
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                writer.WriteValue("Divide");
                break;
            case "√":
                result = Math.Sqrt(num1);
                writer.WriteValue("Square Root");
                break;
            case "^":
                result = Math.Pow(num1, num2);
                writer.WriteValue("Power");
                break;
            case "10x":
                result = Math.Pow(10, num1);
                writer.WriteValue("10x");
                break;
            case "Sin":
                result = Math.Sin(num1);
                writer.WriteValue("Sin");
                break;
            case "Cos":
                result = Math.Cos(num1);
                writer.WriteValue("Cos");
                break;
            case "Tan":
                result = Math.Tan(num1);
                writer.WriteValue("Tan");
                break;
            default:
                break;
        }
        writer.WritePropertyName("Result");
        writer.WriteValue(result);
        writer.WriteEndObject();

        return result;
    }

    public void Finish()
    {
        writer.WriteEndArray();
        writer.WriteEndObject();
        writer.Close();
    }
}
