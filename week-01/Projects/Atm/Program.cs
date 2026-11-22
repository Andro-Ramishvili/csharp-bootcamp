using System.Globalization;
CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

NumberStyles styles = NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint;

decimal balance = 1000m;
string? depositAmountInput;
string? withdrawAmountInput;
bool isOpened = true;
string? option;
Console.WriteLine("Welcome to the ATM!");


do
{
    Console.Write("1. Balance\n2. Deposit\n3. Withdraw\n4. Exit\nChoose an option: ");
    option = Console.ReadLine()?.Trim();

    switch (option)
    {
        case "1":
            Console.WriteLine($"Your balance: {balance:F2} GEL");
            break;

        case "2":

            while (true)
            {
                Console.Write("Enter amount to deposit or enter 'cancel' to go back: ");
                depositAmountInput = (Console.ReadLine() ?? "").Trim();
                if (depositAmountInput.ToLower() == "cancel")
                {
                    break;
                }
                else
                {
                    if (decimal.TryParse(depositAmountInput, styles, CultureInfo.InvariantCulture, out decimal depositAmount))
                    {

                        if (depositAmount <= 0)
                        {
                            Console.WriteLine("Amount must be positive.");

                            continue; // Continue the loop to prompt for deposit amount again

                        }

                        else
                        {
                            balance += depositAmount;
                            Console.WriteLine($"Deposited {depositAmount:F2} GEL. New balance: {balance:F2} GEL");
                            break; // Exit the deposit loop after a successful deposit
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid amount.");

                        continue; // Continue the loop to prompt for deposit amount again

                    }
                }
            }

            break;


        case "3":
            while (true)
            {
                Console.Write("Enter amount to withdraw or enter 'cancel' to go back: ");
                withdrawAmountInput = (Console.ReadLine() ?? "").Trim();

                if (withdrawAmountInput.ToLower() == "cancel")
                {
                    break;
                }

                else
                {
                    if (decimal.TryParse(withdrawAmountInput, styles, CultureInfo.InvariantCulture, out decimal withdrawAmount))
                    {

                        if (withdrawAmount <= 0)
                        {
                            Console.WriteLine("Amount must be positive.");

                            continue;

                        }

                        else if (withdrawAmount <= balance)
                        {
                            balance -= withdrawAmount;
                            Console.WriteLine($"Withdrew {withdrawAmount:F2} GEL. New balance: {balance:F2} GEL");
                            break;
                        }

                        else
                        {
                            Console.WriteLine($"Insufficient funds. Your balance: {balance:F2} GEL.");


                            continue;

                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid amount.");
                        continue;
                    }
                }
            }
            break;

        case "4":
            Console.WriteLine("Goodbye!");
            isOpened = false;
            break;

        case null:
            Console.WriteLine("Session expired. Goodbye!");
            isOpened = false;
            break;

        default:
            Console.WriteLine("Invalid option. Please choose 1-4.");
            break;

    }
} while (isOpened);
