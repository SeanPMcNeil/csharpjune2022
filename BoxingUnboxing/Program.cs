List<object> boxedData = new List<object>();

boxedData.Add(7);
boxedData.Add(28);
boxedData.Add(-1);
boxedData.Add(7);
boxedData.Add(true);
boxedData.Add("chair");

int sum = 0;

for (int i = 0; i < boxedData.Count; i++)
{
    if (boxedData[i] is int){
        sum += (int)boxedData[i];
    }
    Console.WriteLine(boxedData[i]);
}

Console.WriteLine(sum);