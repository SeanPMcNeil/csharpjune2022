class Animal
{
    // Establish the attributes of the class - words you use to desctibe the class
    public string Species;
    public double Weight;
    public string Diet;

    // this is our constructor
    public Animal(string sp, double w, string d)
    {
        // Attributes first, values second
        Species = sp;
        Weight = w;
        Diet = d;
    }

    // a second constructor that takes only 2 attributes and auto fills the last one
    public Animal(string sp, double w)
    {
        // Attributes first, values second
        Species = sp;
        Weight = w;
        Diet = "Onmivore";
    }

    // Methods (functions) - these are the things an animal can do
    // need to also establish a return type with a function
    public void makeNoise(string sound)
    {
        Console.WriteLine(sound);
    }
}