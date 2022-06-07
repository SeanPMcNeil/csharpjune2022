class Wizard : Human
{
    public Wizard(string name) : base(name)
    {
        Intelligence = 25;
        Health = 50;
    }

    public Wizard(string name, int str, int intel, int dex, int hp) : base(name, str, intel, dex, hp)
    {}

    public override int Attack(Human target)
    {
        int damage = 5 * Intelligence;
        Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");
        target.Health -= damage;
        Console.WriteLine($"{target.Name} has {target.Health} HP!");
        Health += damage;
        Console.WriteLine($"{Name} healed themself for {damage} HP!");
        Console.WriteLine($"{Name} has {Health} HP!");
        return target.Health;
    }

    public int Heal(Human target)
    {
        int heal = 10 * Intelligence;
        Console.WriteLine($"{Name} heals {target.Name} for {heal} HP!");
        target.Health += heal;
        Console.WriteLine($"{target.Name} has {target.Health} HP!");
        return target.Health;
    }
}