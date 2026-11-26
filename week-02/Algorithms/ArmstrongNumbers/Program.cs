
int[] cases = { 0, 9, 10, 153, 370, 9474, 154, 9475, 9926315,
                -153, int.MinValue, int.MaxValue, 1999999999};

foreach (int n in cases)
    Console.WriteLine($"{n} -> isArmstrong: {IsArmstrongNumber(n)}");


static bool IsArmstrongNumber(int number)
{
    // Negative numbers are not Armstrong numbers
    if (number < 0) return false;
    int digitCount = CountDigits(number);
    long sum = 0;
    int remaining = number;
    while (remaining > 0)
    {
        sum += (long)Math.Pow(remaining%10,digitCount);
        remaining /= 10;
        
    }
    return number == sum;
}

static int CountDigits(int n)
{
    int digitsCount = 0;
    do
    {
        n /= 10;
        digitsCount++;
    } while (n != 0);

    return digitsCount;
}