using System.Globalization;


string? firstNumberInput;
string? operatorInput = "";
string? secondNumberInput;
string? continueInput;
bool isValid;

double firstNumber = 0;
double secondNumber = 0;

do
{
    isValid = true;
    // Enter the first number:
    while (isValid)
    {
        Console.Write("Enter the first number: ");
        firstNumberInput = (Console.ReadLine() ?? "").Trim();

        if (double.TryParse(firstNumberInput, NumberStyles.Float, CultureInfo.InvariantCulture, out firstNumber))
        {
            isValid = false;
        }
        else 
        {
            Console.WriteLine("Invalid input. Please enter valid number..");
        }

    }


    // Enter the operator:
    isValid = true;
    while (isValid)
    {
        Console.Write("Enter the operator (+, -, *, /): ");
        operatorInput = (Console.ReadLine() ?? "").Trim();

        if (operatorInput != "+" && operatorInput != "-" && operatorInput != "*" && operatorInput != "/")
        {
            Console.WriteLine("Invalid input. Please enter valid operator..");
        }
        else
        {
            isValid = false;
        }

    }

    // Enter the second number:

    isValid = true;
    while (isValid)
    {
        Console.Write("Enter the second number: ");
        secondNumberInput = (Console.ReadLine() ?? "").Trim();
        if (double.TryParse(secondNumberInput, NumberStyles.Float, CultureInfo.InvariantCulture, out secondNumber))
        {
            if (operatorInput == "/" && secondNumber == 0)
            {
                Console.WriteLine("Division by zero is not allowed.");
            }
            else
            {
                isValid = false;
            }
        }
        else 
        {
            Console.WriteLine("Invalid input. Please enter valid number..");

        }
    }



    // Perform the calculation based on the operator
    switch (operatorInput)
    {
        case "+":
            Console.WriteLine($"{firstNumber} + {secondNumber} = {firstNumber + secondNumber}");
            break;
 
        case "-":
            Console.WriteLine($"{firstNumber} - {secondNumber} = {firstNumber - secondNumber}");
            break;

        case "*":
            Console.WriteLine($"{firstNumber} * {secondNumber} = {firstNumber * secondNumber}");
            break;

        case "/":
            Console.WriteLine($"{firstNumber} / {secondNumber} = {firstNumber / secondNumber}");
            break;

    }



    do
    {
        Console.Write("Do you want to perform another calculation? (y/n):");
        continueInput = (Console.ReadLine() ?? "").Trim();
        if (string.IsNullOrWhiteSpace(continueInput))
        {
            Console.WriteLine("Invalid input. Please enter y or n.");
        }
        else if (continueInput.ToUpper() != "Y" && continueInput.ToUpper() != "N")
        {
            Console.WriteLine("Wrong input. Enter y or n.");
        }
    } while (continueInput.ToUpper() != "N" && continueInput.ToUpper() != "Y");

} while (continueInput.ToUpper() == "Y");
