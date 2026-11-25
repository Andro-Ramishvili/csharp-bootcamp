using System.Globalization;

/*
string?[] cases = { null, "", "   ", "abc", "-5", "0", "100", " 100 ",
                    "0.01", "0.001", "10000", "10000.01", "5,5", "1e3", "+5" };


RunChecks(cases);
*/


while (true)
{
    Console.WriteLine("Enter amount (0.01–10000): ");
    string input = (Console.ReadLine() ?? "").Trim();
    if (TryReadAmount(input, out decimal amount))
    {
        Console.WriteLine($"The amount: {amount}");
        break;
    }
    Console.WriteLine("Invalid amount. Try again: ");

}


static void RunChecks(string?[] cases)
{
    foreach (string? c in cases)
{
    bool ok = TryReadAmount(c, out decimal a);
    Console.WriteLine($"[{c ?? "null"}] -> {ok}, {a}");
}
}


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
    if (amount != Math.Round(amount, 2))
    {
        amount = 0m;
        return false;
    }
    if (amount > 10_000)
    {
        amount = 0m;
        return false;
    }

    return true;

}

