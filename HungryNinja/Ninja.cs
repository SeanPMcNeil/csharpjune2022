class Ninja
{
    private int calorieIntake;
    public List<Food> FoodHistory;

    // add a constructor
    public Ninja ()
    {
        calorieIntake = 0;
        FoodHistory = new List<Food>();
    }
    // add a public "getter" property called "IsFull"
    public bool IsFull
    {
        get
        {
            if (calorieIntake > 1200)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    // build out the Eat method
    public void Eat(Buffet item)
    {
        while (!IsFull)
        {
            Food Serving = item.Serve();
            calorieIntake += Serving.Calories;
            FoodHistory.Add(Serving);
            Console.WriteLine(Serving.Name);
            if (Serving.IsSpicy)
            {
                Console.WriteLine("It's Spicy!");
            }
            else if (Serving.IsSweet)
            {
                Console.WriteLine("It's Sweet!");
            }
        }
        if (IsFull)
        {
            Console.WriteLine("WARNING: The Ninja is Full");
        }
    }
}

