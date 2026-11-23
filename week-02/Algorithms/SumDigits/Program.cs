
do
{
    Console.Write("Enter the number: ");
    string? input = Console.ReadLine();


    if(input == null)
    {
        Console.WriteLine("Goodbye.."); 
        break;
    }
    if (!int.TryParse(input.Trim(), out int number))
    {
        Console.WriteLine("Please Enter the valid number.");
        continue;
    }

    int sum = SumDigits(number);
    Console.WriteLine($"The sum of digits in: {number} is {sum}.");
    break;
} while (true);



static int SumDigits(int number)
{
    int sum = 0;
    while (number != 0)
    {
        sum += number % 10;
        number /= 10;
    }
    return sum;

}
