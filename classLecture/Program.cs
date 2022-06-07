// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// First instance of an animal
Animal Dog = new Animal("Dog", 60.3, "Omnivore");
Animal Cat = new Animal("Cat", 10.24, "Carnivore");
Animal Bear = new Animal("Bear", 160.38, "Omnivore");

Console.WriteLine(Dog.Species);
Console.WriteLine(Cat.Weight);
Console.WriteLine(Bear.Diet);

Animal Coyote = new Animal("Coyote", 56.2);
Console.WriteLine(Coyote.Diet);

Dog.makeNoise("Bark");

Mammal Lion = new Mammal("Lion", 300.6, "Carnivore");
Console.WriteLine(Lion.Species);
Console.WriteLine(Lion.hasFur);
Lion.makeNoise("Roar");