// 1. Print 1-255
static void PrintNumbers()
{
    for (int i = 1; i <= 255; i++)
    {
        Console.WriteLine(i);
    }
}

PrintNumbers();

// 2. Print Odd Numbers 1-255
static void PrintOdds()
{
    for (int i = 1; i <= 255; i++)
    {
        if (i % 2 != 0)
        {
            Console.WriteLine(i);
        }
    }
}

PrintOdds();


// 3. Print Sum
static void PrintSum()
{
    int counter = 0;
    for (int i = 0; i <= 255; i++)
    {
        int sum = counter + i;
        Console.WriteLine($"Current value: {i} Current sum: {sum}");
        counter = sum;
    }
}

PrintSum();

// 4. Iterate Through Array
static void LoopArray(int[] numbers)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        Console.WriteLine(numbers[i]);
    }
}

int[] sampleArray = {1, 3, 2, 5, 4, 6};
LoopArray(sampleArray);

// 5. Find Max
static int FindMax(int[] numbers)
{
    int max = numbers[0];
    for (int i = 1; i < numbers.Length; i++)
    {
        if (numbers[i] > max)
        {
            max = numbers[i];
        }
    }
    return max;
}

int[] testArray = {14, 25, 9, 4, 33, -1, 0};
// int[] testArray = {-4, -10, -3, -7};
Console.WriteLine(FindMax(testArray));

// 6. Get Average
static void GetAverage(int[] numbers)
{
    int total = 0;
    for (int i = 0; i < numbers.Length; i++)
    {
        total += numbers[i];
    }
    Console.WriteLine(total / numbers.Length);
}

int[] newArr = new int[]{2, 10, 3};
GetAverage(newArr);

// 7. Array w/ Odd Numbers
static int[] OddArray()
{
    int[] numArray = new int[128];
    int counter = 0;
    for (int i = 1; i <= 255; i++)
    {
        if (i % 2 != 0)
        {
            numArray[counter] = i;
            Console.WriteLine(numArray[counter]);
            counter++;
        }
    }
    return numArray;
}

OddArray();

// 8. Greater than Y
int[] array = {1, 3, 5, 7};
static int GreaterThanY(int[] numbers, int y)
{
    int count = 0;
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] > y)
        {
            count++;
        }
    }
    return count;
}

Console.WriteLine(GreaterThanY(array, 3));

// 9. Square the Values
static void SquareArrayValues(int[] numbers)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = numbers[i] * numbers[i];
        Console.WriteLine(numbers[i]);
    }
}

int[] newArray = {1, 5, 10, -10};
SquareArrayValues(newArray);

// 10. Eliminate Negative Numbers
static void EliminateNegatives(int[] numbers)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] < 0)
        {
            numbers[i] = 0;
        }
        Console.WriteLine(numbers[i]);
    }
}

int[] numArray = {1, 5, 10, -2};
EliminateNegatives(numArray);

// 11. Min, Max, & Average
static void MinMaxAverage(int[] numbers)
{
    int max = numbers[0];
    int min = numbers[0];
    int sum = 0;

    for (int i = 1; i < numbers.Length; i++)
    {
        if (numbers[i] > max)
        {
            max = numbers[i];
        }
        if (numbers[i] < min)
        {
            min = numbers[i];
        }
        sum += numbers[i];
    }
    Console.WriteLine($"The maximum value is {max}");
    Console.WriteLine($"The mininimum value is {min}");
    Console.WriteLine($"The average is {sum / numbers.Length}");
}

int[] mmaArray = {1, 5, 10, -2};
MinMaxAverage(mmaArray);

// 12. Shifting Values in an Array
static void ShiftValues(int[] numbers)
{
    for (int i = 0; i < numbers.Length-1; i++)
    {
        // Console.WriteLine($"Old Value: {numbers[i]}");
        numbers[i] = numbers[i+1];
        Console.WriteLine($"New Value: {numbers[i]}");
    }
    // Console.WriteLine($"Old Value: {numbers[numbers.Length-1]}");
    numbers[numbers.Length-1] = 0;
    Console.WriteLine($"New Value: {numbers[numbers.Length-1]}");
}

int[] sV = {1, 5, 10, 7, -2};
ShiftValues(sV);

// 13. Numbers to String
static object[] NumToString(int[] numbers)
{
    // Write a function that takes an integer array and returns an object array 
    // that replaces any negative number with the string 'Dojo'.
    // For example, if array "numbers" is initially [-1, -3, 2] 
    // your function should return an array with values ['Dojo', 'Dojo', 2].
    object[] finalArray = new object[numbers.Length];
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] < 0)
        {
            finalArray[i] = "Dojo";
            Console.WriteLine(finalArray[i]);
        }
        else
        {
            finalArray[i] = numbers[i];
            Console.WriteLine(finalArray[i]);
        }
    }
    return finalArray;
}

int[] nTS = {-1, -3, 2};
NumToString(nTS);