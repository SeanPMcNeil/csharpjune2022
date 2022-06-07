// 1. Loop that prints all values from 1-255
for (int i = 1; i <= 255; i++)
{
    Console.WriteLine(i);
}

// 2. Loop that prints values from 1-100 divisible by 3 or 5, but not both
for (int j = 1; j <= 100; j++)
{
    if (j % 3 == 0 && j % 5 != 0)
    {
        Console.WriteLine(j);
    }
    else if (j % 5 == 0 && j % 3 != 0)
    {
        Console.WriteLine(j);
    }
}

// 3. FizzBuzz
for (int k = 1; k <= 100; k++)
{
    if (k % 3 == 0 && k % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }
    else if (k % 3 == 0 && k % 5 != 0)
    {
        Console.WriteLine("Fizz");
    }
    else if (k % 5 == 0 && k % 3 != 0)
    {
        Console.WriteLine("Buzz");
    }
}