// // Random Array
// Console.WriteLine("================= Random Array =================");
// static int[] RandomArray()
// {
//     int[] array = new int[10];
//     Random rand = new Random();
//     int max = 0;
//     int min = 0;
//     int sum = 0;

//     for (int i = 0; i < array.Length; i++)
//     {
//         array[i] = rand.Next(5, 25);
//         Console.WriteLine($"The value at index {i} is: {array[i]}");
//         if (i == 0)
//         {
//             max = array[i];
//             min = array[i];
//         }
//         if (array[i] > max)
//         {
//             max = array[i];
//         }
//         if (array[i] < min)
//         {
//             min = array[i];
//         }
//         sum += array[i];
//     }
//     Console.WriteLine($"The minimum value in the array is: {min}");
//     Console.WriteLine($"The maximum value in the array is: {max}");
//     Console.WriteLine($"The sum of all values in the array is: {sum}");

//     return(array);
// }

// RandomArray();

// Coin Flip
Console.WriteLine("================= Single Coin Flip =================");
static string CoinFlip()
{
    Console.WriteLine("Tossing a Coin!");

    Random rand = new Random();
    int toss = rand.Next(0, 2);
    if (toss == 0)
    {
        return("Heads");
    }
    else
    {
        return("Tails");
    }
}

Console.WriteLine(CoinFlip());

// Multiple Tosses
Console.WriteLine("================= Multiple Coin Flips =================");
static double TossMultipleCoins(int num)
{
    Random rand = new Random();
    double tosses = 0;
    double heads = 0;

    for (int i = 0; i < num; i++)
    {
        string toss = CoinFlip();
        if (toss == "Heads")
        {
            tosses ++;
            heads ++;
        }
        else
        {
            tosses++;
        }
    }
    Console.WriteLine($"Number of heads: {heads}");
    Console.WriteLine($"Number of tosses: {tosses}");
    double ratio = heads / tosses;
    return ratio;
}

Random rand = new Random();
int totalTosses = rand.Next(2, 20);
Console.WriteLine($"Ratio of Heads to Tosses: {TossMultipleCoins(totalTosses)}");

// Names
Console.WriteLine("================= List of Names > 5 Characters =================");
static List<string> Names()
{
    List<string> names = new List<string>();
    names.Add("Todd");
    names.Add("Tiffany");
    names.Add("Charlie");
    names.Add("Geneva");
    names.Add("Sydney");

    List<string> longerNames = new List<string>();
    foreach (string name in names)
    {
        if (name.Length > 5)
        {
            longerNames.Add(name);
            Console.WriteLine(name);
        }
    }

    return longerNames;
}

List<string> listOfNames = Names();

// Shuffled Names List
Console.WriteLine("================= Shuffled List of Names =================");

static List<string> ShuffledNames(List<string> list)
{
    Random rnd = new Random();
    for (int i = 0; i < list.Count; i++)
    {
        int j = rnd.Next(i, list.Count);
        string temp = list[i];
        list[i] = list[j];
        list[j] = temp;
        Console.WriteLine(list[i]);
    }
    return(list);
}

ShuffledNames(listOfNames);