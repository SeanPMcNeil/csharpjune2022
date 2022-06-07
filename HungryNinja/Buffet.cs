class Buffet
{
    public List<Food> Menu;

    //constructor
    public Buffet()
    {
        Menu = new List<Food>()
        {
            new Food("Pepperoni Pizza Slice", 475, false, false),
            new Food("Mac & Cheese", 545, false, false),
            new Food("Chicken", 236, false, false),
            new Food("Spicy Chicken", 243, true, false),
            new Food("Chocolate Cake", 480, false, true),
            new Food("Snickerdoodle Cookie", 375, false, true),
            new Food("Jambalaya", 570, true, false),
        };
    }

    public Food Serve()
    {
        Random rand = new Random();
        int num = rand.Next(Menu.Count);

        return Menu[num];
    }
}

