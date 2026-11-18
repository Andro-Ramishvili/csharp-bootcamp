int n = 9;

if(n < 1) Console.WriteLine("n must be positive");
else if(n % 3 == 0 && n % 5 == 0) Console.WriteLine("FizzBuzz");
else if(n % 3 == 0) Console.WriteLine("Fizz");
else if(n % 5 == 0) Console.WriteLine("Buzz");
else Console.WriteLine(n);
