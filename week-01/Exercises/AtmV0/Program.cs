
decimal balance = 500m;

Console.WriteLine("1. Balance");
Console.WriteLine("2. Deposit");
Console.WriteLine("3. Withdraw");
Console.WriteLine("4. Exit");
Console.Write("Select an option: ");

string? choice = Console.ReadLine();

switch (choice)
{
    case "1":
        Console.WriteLine($"Your balance is: {balance:N2} GEL");
        break;

    case "2":
        Console.Write("Please Enter the amount to deposit: ");
        string? depositInput = Console.ReadLine();
        decimal depositAmount = decimal.Parse(depositInput!);
        if (depositAmount > 0)
        {
            balance += depositAmount;
            Console.WriteLine($"Your new balance is: {balance:N2} GEL");
        }
        else Console.WriteLine("Amount must be positive.");
        break;

    case "3":
        Console.Write("Withdraw desired amount: ");
        string? withdrawInput = Console.ReadLine();
        decimal withdrawAmount = decimal.Parse(withdrawInput!);
        if (withdrawAmount > 0 && withdrawAmount <= balance)
        {
            balance -= withdrawAmount;
            Console.WriteLine($"Your new balance is: {balance:N2} GEL");
        }
        else if (withdrawAmount > balance)
        {
            Console.WriteLine("Insufficient balance.");
        }
        else Console.WriteLine("Amount must be positive.");
        break;

    case "4":
    case "q":
        Console.WriteLine("Goodbye!");
        break;

    default:
        Console.WriteLine("Invalid option.");
        break;
}
