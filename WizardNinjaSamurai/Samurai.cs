class Samurai : Human
{
    public Samurai (string name) : base(name)
    {
        Health = 200;
    }

    public override int Attack(Human target)
    {
        if (target.Health < 50)
        {
            Console.WriteLine($"{Name} delivers a deathblow to {target.Name}");
            target.Health = 0;
        }
        else
        {
            base.Attack(target);
        }
        return target.Health;
    }

    public void Meditate()
    {
        Console.WriteLine($"{Name} meditates and regains full HP");
        Health = 200;
    }
}