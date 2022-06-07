// 1. Array to hold int values 1-9
int[] numArray = new int[10];
for (int i = 0; i < 10; i++)
{
    numArray[i] = i;
}

// 2. Array of names
string[] nameArray = {"Tim", "Martin", "Nikki", "Sara"};

// 3. Array of length 10, alternates between true & false
bool[] boolArray = new bool[10];
for (int i = 0; i < 10; i++)
{
    if (i % 2 == 0)
    {
        boolArray[i] = true;
    }
    else
    {
        boolArray[i] = false;
    }
}

// 4. List of Ice Cream Flavors
List<string> iceCream = new List<string>();

iceCream.Add("Chocolate");
iceCream.Add("Vanilla");
iceCream.Add("Coffee");
iceCream.Add("Birthday Cake");
iceCream.Add("Cookies and Cream");

// 5. Output length of the list
Console.WriteLine($"We have {iceCream.Count} flavors");

// 6. Output 3rd flavor, then remove it
Console.WriteLine(iceCream[2]);
iceCream.Remove(iceCream[2]);
Console.WriteLine(iceCream[2]);

// 7. Output new length
Console.WriteLine($"We have {iceCream.Count} flavors");

// 8. Dictionary w/ string keys and values
Dictionary<string, string> users = new Dictionary<string, string>();

// 9. Add key/value pairs from Names Array
for (int i = 0; i < 4; i++)
{
    Random rand = new Random();
    int randFlavor = rand.Next(4);
    users.Add(nameArray[i], iceCream[randFlavor]);
}

// 10. Loop through and print name + ice cream flavor
foreach (var entry in users)
{
    Console.WriteLine(entry.Key + " - " + entry.Value);
}