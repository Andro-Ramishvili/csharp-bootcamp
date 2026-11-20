using System.Globalization;
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
    
decimal balance = 500.0m;
string ?option;
do
{
    Console.WriteLine("Type the number of the operation you want to" +
    " perform:\n 1. Check balance\n 2. Deposit\n 3. Withdraw\n 4. OR Q to Exit");

    option = Console.ReadLine();
    if(option == "1")
    {
        Console.WriteLine($"Your balance is: {balance:N2} GEL.");
    }
    else if(option == "2")
    {
        Console.WriteLine("Enter the amount you want to deposit");
        if(decimal.TryParse(Console.ReadLine()?.Trim(), NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                 CultureInfo.InvariantCulture, out decimal depositAmount))
        {
            if(depositAmount > 0)
            {
                balance += depositAmount;
                Console.WriteLine($"You have successfully deposited {depositAmount:N2} GEL." +
                $" Your new balance is: {balance:N2} GEL.");
            }
            else
            {
                Console.WriteLine("Please enter positive amount to deposit. Try again.");
            }
        }
        else
        {
            Console.WriteLine("Invalid amount entered. Please try again.");
        }
    }
    else if(option == "3")
    {
        Console.WriteLine("Enter the amount you want to withdraw");
        if(decimal.TryParse(Console.ReadLine()?.Trim(), NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                 CultureInfo.InvariantCulture, out decimal withdrawalAmount))
        {
            if(withdrawalAmount <= balance && withdrawalAmount > 0)
            {
                balance -= withdrawalAmount;
            Console.WriteLine($"You have successfully withdrawn {withdrawalAmount:N2} GEL." +
            $" Your new balance is: {balance:N2} GEL.");
            }
            else if(withdrawalAmount > balance)
            {
                Console.WriteLine("Insufficient funds. Please try again.");
            }
            else
            {
                Console.WriteLine("Please enter positive amount to withdraw. Try again.");
            }

        }
        else
        {
            Console.WriteLine("Invalid amount entered. Please try again.");
        }
    }

     else if(option == null)
    {
        Console.WriteLine("No input detected. Exiting the program.");
        
    }

    else if(option == "4" || option.ToUpper() == "Q")
    {
        Console.WriteLine("Exiting the program. Thank you for using our services.");
        
    }
    else
    {
        Console.WriteLine("Invalid option selected. Please try again.");
    }

} while (option != null && option != "4" && option.ToUpper() != "Q");
