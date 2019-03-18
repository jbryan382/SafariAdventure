using System;
using System.Linq;

namespace SafariAdventure
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Wild Animals!!!");

      var db = new SafariVacationContext();

      var monkey = new Animal
      {
        Species = "Chimpanzee",
        CountOfTimesSeen = 4,
        LocationOfLastSeen = "Jungle"
      };

      var lion = new Animal
      {
        Species = "Lion",
        CountOfTimesSeen = 6,
        LocationOfLastSeen = "Savannah"
      };

      var tiger = new Animal
      {
        Species = "Tiger",
        CountOfTimesSeen = 3,
        LocationOfLastSeen = "Jungle"
      };

      var bear = new Animal
      {
        Species = "Bear",
        CountOfTimesSeen = 2,
        LocationOfLastSeen = "Forrest"
      };

      var lizard = new Animal
      {
        Species = "Lizard",
        CountOfTimesSeen = 1,
        LocationOfLastSeen = "Desert"
      };

      var hippo = new Animal
      {
        Species = "Hippopotamus",
        CountOfTimesSeen = 2,
        LocationOfLastSeen = "River"
      };

      //   db.Animals.Add(monkey);
      //   db.Animals.Add(lion);
      //   db.Animals.Add(tiger);
      //   db.Animals.Add(bear);
      //   db.Animals.Add(lizard);
      //   db.Animals.Add(hippo);
      db.SaveChanges();

      var allAnimals = db.Animals;
      foreach (var animal in allAnimals)
      {
        Console.WriteLine("Crikey! its a " + animal.Species + ".");
      }

      var lions = db.Animals.FirstOrDefault(animal => animal.Species == "Lion");
      if (lions != null)
      {
        lions.CountOfTimesSeen = 10;
        lions.LocationOfLastSeen = "Pride Rock";
      }
      db.SaveChanges();

      Console.WriteLine("You're now approaching the jungle... be careful!");
      var allJungleAnimals = db.Animals.Where(animal => animal.LocationOfLastSeen == "Jungle");
      foreach (var animal in allJungleAnimals)
      {
        Console.WriteLine("Crikey! there's a " + animal.Species + " in this Jungle.");
      }

      var allDesertAnimals = db.Animals.FirstOrDefault(animal => animal.LocationOfLastSeen == "Desert");
      db.Animals.Remove(allDesertAnimals);
      db.SaveChanges();

      var count = 0;
      var allAnimalsCount = db.Animals;
      foreach (var animal in allAnimals)
      {
        count = count + animal.CountOfTimesSeen;
      }
      Console.WriteLine("Crikey! we saw " + count + " animals.");

      var count2 = 0;
      var countLTB = db.Animals.Where(animal => animal.Species == "Lion" || animal.Species == "Tiger" || animal.Species == "Bear");
      foreach (var animal in countLTB)
      {
        count2 = count2 + animal.CountOfTimesSeen;
      }
      Console.WriteLine("Crikey! there were " + count2 + " Lions, Tigers, and Bears..... Oh My.");
    }
  }
}
