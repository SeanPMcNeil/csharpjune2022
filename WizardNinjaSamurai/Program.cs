Wizard Dumbledore = new Wizard("Dumbledore");
Ninja Dudley = new Ninja("Dudley");
Samurai tomCruise = new Samurai("Tom Cruise");

Dumbledore.Attack(Dudley);
Dumbledore.Heal(Dudley);
Dudley.Steal(Dumbledore);
Dudley.Attack(Dumbledore);
Dumbledore.Heal(Dumbledore);
Dumbledore.Heal(Dumbledore);
Dumbledore.Attack(tomCruise);
tomCruise.Meditate();
tomCruise.Attack(Dumbledore);