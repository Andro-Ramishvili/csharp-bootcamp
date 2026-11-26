

decimal[] transactions = [1m, 5m, 100m, -22m, 9m, 50m, -107m, 199m, -200m];

decimal total = Statement.NetTotal(transactions);
int expenseCount = Statement.CountExpenses(transactions);
bool hasExpenses = Statement.TryGetLargestExpense(transactions, out decimal largest);
int countHighExpenses = Statement.CountExpenses(transactions, 0m);
decimal[] newArray = Statement.Reversed(transactions);

foreach (decimal n in newArray)
{
    Console.WriteLine(n);
}

Console.WriteLine($"Total: {total}");
Console.WriteLine($"Total expenses: {expenseCount}");
if (hasExpenses)
{
    Console.WriteLine($"Largest expense: {largest:N2}");
}
else Console.WriteLine("No Expenses");
Console.WriteLine($"total expenses more than 100 are : {countHighExpenses}");



static class Statement
{
    public static decimal NetTotal(decimal[] transactions)
    {
        decimal sum = 0m;
        foreach (decimal t in transactions)
        {
            sum += t;
        }
        return sum;
    }

    public static int CountExpenses(decimal[] transactions, decimal minAmount)
    {
        int countExpenses = 0;
        // PO decision: negative minAmount is treated as its absolute value
        minAmount = Math.Abs(minAmount);
        foreach (decimal t in transactions)
        {
            bool isExpense = t < 0;
            bool isBigEnough = Math.Abs(t) >= minAmount;
            if (isExpense && isBigEnough) countExpenses++;

        }
        return countExpenses;

    }


    public static int CountExpenses(decimal[] transactions)
    {
        int countExpenses = CountExpenses(transactions, 0m);
        return countExpenses;
    }
    public static bool TryGetLargestExpense(decimal[] transactions, out decimal largest)
    {
        decimal biggestExpense = 0m;
        foreach (decimal t in transactions)
        {
            if (t < biggestExpense)
            {
                biggestExpense = t;
            }
        }
        if (biggestExpense == 0)
        {
            largest = 0m;
            return false;
        }
        largest = biggestExpense;
        return true;
    }

    public static decimal[] Reversed(decimal[] transactions)
    {
        decimal[] reversedTransactions = new decimal[transactions.Length];
        for (int i = transactions.Length; i > 0; i--)
        {
            reversedTransactions[transactions.Length - i] = transactions[i-1];
        }
        return reversedTransactions;
    }
}
