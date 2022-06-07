Human Cloud = new Human("Cloud");
Human Sephiroth = new Human("Sephiroth", 15, 20, 20, 2000);

Console.WriteLine($"Sephiroth has {Cloud.Attack(Sephiroth)} HP remaining");
Console.WriteLine($"Cloud has {Sephiroth.Attack(Cloud)} HP remaining");