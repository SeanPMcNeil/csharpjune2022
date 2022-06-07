class Mammal : Animal
{
    public bool hasFur = true;

    // Mammal inherits all of the attributes from the Animal class
    public Mammal(string sp, double w, string d) : base(sp, w, d)
    {

    }
}