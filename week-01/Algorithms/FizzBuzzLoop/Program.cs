
Console.WriteLine("Enter a positive integer:");
string? n = Console.ReadLine();
if(int.TryParse(n, out int number) && number > 0)
{
    for(int i = 1; i<= number; i++)
    {
        if(i % 3 == 0 && i % 5 == 0)
        {
            Console.WriteLine("FizzBuzz");
        } 
        else if(i % 3 == 0)
        {
            Console.WriteLine("Fizz");
        }
        else if(i % 5 == 0)
        {
            Console.WriteLine("Buzz");
        }
        else
        {
            Console.WriteLine(i);
        }
    }
}
else if(!int.TryParse(n, out number))
{
    Console.WriteLine("Invalid input. Please enter a valid integer.");
}
else if(number <= 0)
{
    Console.WriteLine("Please enter a positive integer.");
}

