decimal balance = 500m;

Console.WriteLine("1. Balance");
Console.WriteLine("2. Deposit");
Console.WriteLine("3. Withdraw");
Console.WriteLine("4. Exit");
Console.Write("Select an option: ");

string? choice = Console.ReadLine();

switch(choice)
{
    

    case "1":
        Console.WriteLine($"Your balance is: {balance:N2} GEL");
        break;

    case "2":
        Console.WriteLine("Deposit..");
        break;
        
    case "3":
        Console.WriteLine("Withdraw..");
        break;
        
    case "4":
    case "q":
        Console.WriteLine("Goodbye!");
        break;

    default:
        Console.WriteLine("Invalid option. Please try again.");
        break;
}
