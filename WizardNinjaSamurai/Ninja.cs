class Ninja : Human
{
    public Ninja (string name) : base(name)
    {
        Dexterity = 175;
    }

    public override int Attack(Human target)
    {
        int damage = 5 * Dexterity;
        Random rand = new Random();
        int chance = rand.Next(0, 5);
        if (chance == 0)
        {
            damage += 10;
        }
        Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");
        target.Health -= damage;
        Console.WriteLine($"{target.Name} has {target.Health} HP!");
        return target.Health;
    }

    public int Steal(Human target)
    {
        Console.WriteLine($"{Name} steals 5 HP from {target.Name}");
        target.Health = target.Health - 5;
        Health = Health + 5;
        Console.WriteLine($"{Name} has {Health} HP!");
        return Health;
    }
}