using System.Text.RegularExpressions;

/* requirements:
 * 1. take user input - done
 * 2. ensure user input is a number - done
 * 3. perform chosen calculation - done
 * 4. display output - done
 * 5. option to exit or loop - done
 */

// this class handles the actual operations
class Calculator
{
    public static double PerformCalc(double num1, double num2, string operation)
    {
        double result = double.NaN;

        switch (operation)
        {
            case "a":
                result = num1 + num2;
                break;
            case "s":
                result = num1 - num2;
                break;
            case "m":
                result = num1 * num2;
                break;
            case "d":
                if (num2 == 0)
                {
                    Console.WriteLine("enter a non zero divisor m8");
                }
                result = num1 / num2;
                break;
        }
        return result;
    }
}

// this class is the actual calculator, has all the logic
class CalcProcess
{
    static void Main(string[] args)
    {
        // initialise the loop
        bool run = false;

        while (!run)
        {
            // initialise all the values
            string? num1input = "";
            string? num2input = "";
            double result = 0;

            Console.Write("enter first number: ");
            num1input = Console.ReadLine();

            // check that the user inputs an actual number
            double parsedNum1 = 0;
            while (!double.TryParse(num1input, out parsedNum1))
            {
                Console.WriteLine("enter a valid number m8");
                num1input = Console.ReadLine();
            }

            
            Console.Write("enter second number: ");
            num2input = Console.ReadLine();

            // check that the user inputs an actual number pt 2
            double parsedNum2 = 0;
            while (!double.TryParse(num2input, out parsedNum2))
            {
                Console.WriteLine("enter a valid number m8");
                num2input = Console.ReadLine();
            }

            // options for calculation
            Console.WriteLine("choose an option:");
            Console.WriteLine("\ta - add");
            Console.WriteLine("\ts - subtract");
            Console.WriteLine("\tm - multiply");
            Console.WriteLine("\td - divide");
            Console.Write("type letter for choice: ");

            string? operation = Console.ReadLine();

            // ensure option isn't null or something other than the above options
            if (operation == null || !Regex.IsMatch(operation, "[a|s|m|d]"))
            {
                Console.WriteLine("unrecognised input m8 read the options");
            }
            else
            {
                try
                {
                    result = Calculator.PerformCalc(parsedNum1, parsedNum2, operation);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("this aint gonna work bro");
                    }
                    else
                    {
                        Console.WriteLine("{0:0.##}\n", result);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("idk bro but here's the details: " + e.Message);
                }
            }

            Console.Write("press e to exit, press any other key to continue");
            if (Console.ReadLine() == "e")
            {
                Environment.Exit(0);
            }
        }
        return;
    }
}




