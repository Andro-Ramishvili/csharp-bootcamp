using System.Globalization;

decimal balance = 1000m;
const decimal MaxTransactionAmount = 10_000m;
bool isOpened = true;
string? option;
Console.WriteLine("Welcome to the ATM!");


do
{
    ShowMenu();
    option = Console.ReadLine()?.Trim();

    switch (option)
    {
        case "1":
            PrintBalance(balance);
            break;

        case "2":

            while (true)
            {
                Console.Write("Enter amount to deposit or enter 'cancel' to go back: ");
                string input = (Console.ReadLine() ?? "").Trim();
                if (IsCancel(input)) break;
                if(!TryReadAmount(input, out decimal amount))
                {
                    Console.WriteLine($"Invalid amount. Enter 0.01–{MaxTransactionAmount}.");
                    continue;
                }

                balance = Deposit(balance, amount);
                Console.Write($"Deposited {amount:F2} GEL. ");
                PrintBalance(balance);
                break; // Exit the deposit loop after a successful deposit


            }

            break;

        case "3":
            while (true)
            {
                Console.Write("Enter amount to withdraw or enter 'cancel' to go back: ");
                string input = (Console.ReadLine() ?? "").Trim();

                if (IsCancel(input)) break;
                if(!TryReadAmount(input, out decimal amount))
                {
                    Console.WriteLine($"Invalid amount. Enter 0.01–{MaxTransactionAmount}.");
                    continue;
                }

                if (amount > balance)
                {
                    Console.Write($"Insufficient funds. ");
                    PrintBalance(balance);
                    continue;
                }


                balance = Withdraw(balance, amount);
                Console.Write($"Withdrew {amount:F2} GEL. ");
                PrintBalance(balance);
                break;
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



static void ShowMenu()
{
    Console.Write("1. Balance\n2. Deposit\n3. Withdraw\n4. Exit\nChoose an option: ");
}

static void PrintBalance(decimal balance)
{
    Console.WriteLine($"Your balance: {balance:F2} GEL.");
}

static decimal Deposit(decimal balance, decimal amount)
{
    balance += amount;
    return balance;
}

static decimal Withdraw(decimal balance, decimal amount)
{
    balance -= amount;
    return balance;
}

static bool IsCancel(string input) => input.ToLower() == "cancel";

static bool HasValidPrecision(decimal amount) => amount == Math.Round(amount, 2);


//TryReadAmount method from week 2

static bool TryReadAmount(string? input, out decimal amount)
{
    NumberStyles styles = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite;
    if (!decimal.TryParse(input, styles, CultureInfo.InvariantCulture, out amount))
    {
        amount = 0m;
        return false;
    }
    if (amount <= 0)
    {
        amount = 0m;
        return false;
    }
    if (!HasValidPrecision(amount))
    {
        amount = 0m;
        return false;
    }
    if (amount > MaxTransactionAmount)
    {
        amount = 0m;
        return false;
    }

    return true;

}

// Test IO
static void RunChecks(string?[] cases)
{
foreach (string? c in cases)
{
    bool ok = TryReadAmount(c, out decimal a);
    Console.WriteLine($"[{c ?? "null"}] -> {ok}, {a}");
}
}
