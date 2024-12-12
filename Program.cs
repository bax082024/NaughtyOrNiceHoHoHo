using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;

var jsonFilePath = "randomPeople.json";
List<Person> people = new List<Person>();

class Program
{
  static void Main()
  { 
    var jsonFilePath = "randomPeople.json";
    List<Person>people;
    
    if (File.Exists(jsonFilePath))
    {
      string jsonContent = File.ReadAllText(jsonFilePath);
      people = JsonSerializer.Deserialize<List<Person>>(jsonContent, new JsonSerializerOptions
      {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        }) ?? new List<Person>();

      Console.WriteLine("Data succesfully loaded from randomPeople.json!");
      }
      else
      {
        Console.WriteLine($"Error: File {jsonFilePath} not found.");
        people = new List<Person>();
        }

        var niceList = new List<Person>();
        var naughtyList = new List<Person>();

        //Implementert SortPeople for sortering av folk basert på poengsummen
        SortPeople(people, niceList, naughtyList);

        
        AssignElves(niceList); // kaller fra AssignElves for å tildele alver basert på snille-listen

        HandleGryla(naughtyList); // Sørger for at Gryla spiser et barn "10% sjanse"
}

static void SortPeople(List<Person> people, List<Person> niceList, List<Person> naughtyList)
{

  foreach (var person in people)
  {
    int score = CalculateScore(person);
    // Legg til personen i snillelista om poengsum er høyere enn 0, hvis 0 eller lavere så blir det slemmelista
    if (score >= 0)
    {
      niceList.Add(person);
    }
    else
    {
      naughtyList.Add(person);
    }
  }

}


var niceList = new List<Person>();
var naughtyList = new List<Person>();


foreach (var person in people)
{
  int niceScore = 0;
  int naughtyScore = 0;

  if(person.DonatesToCharity) naughtyScore++;
  if(person.WashedHands) niceScore++;
  if(person.ToiletPaperOutward) niceScore++;

  if(person.HomeAdress) niceScore++;



  else
  {
    score -= 1;
  }
  
  if (person.WashedHands)
  {
    score += 1;
  }
  
  else
  {
    score -= 1;
  }


  if (person.ToiletPaperOutward)
  {
    score += 1;
}

else
{
  score -= 1;
}

return score;
}

static void AssignElves(List<Person> niceList) // Kalte på denne funksjonen tidligere, funksjonen er selvforklarende..
{

  new Elf { Name = "Alvhild", Craft = "Ceramic", Item = "Ashtray" },
  new Elf { Name = "Leahlv", Craft = "Glassblowing", Item = "Glassball" },
  new Elf { Name = "Kai-Alv", Craft = "Woodwork", Item = "Mini-sled" },
  new Elf { Name = "Alvbjørn", Craft = "Artist", Item = "Portret" },
  new Elf { Name = "Alv-Prøysen", Craft = "Musician", Item = "Banjo" }
};

static void AssignElves(List<Person> niceList, List<Elf> elves)
{
  int elfIndex = 0;
  foreach (var person in niceList)
  {
    var elf = elves[elfIndex];
    Console.WriteLine
    ($"Yey! {elf.Name} is assigned to {person.Name}! {elf.Name} will gift them a {elf.Item}!");
    elfIndex = (elfIndex + 1) % elves.Count;
  }
}

static void HandleNaughtyList(List<Person> naughtyList)
{
  Random rand = new Random();
  foreach(var person in naughtyList)
  {
    if(rand.Next(1, 101) <= 10) //10% chance Gryla eats you
    {
      Console.WriteLine($"Oh, this is unfortunate. {person.Name} is taken by Gryla and eaten.");
    }
    else
    {
      Console.WriteLine
      ($"Looks like someone has been naughty this year. {person.Name} is getting a coal");
    }
  }
}

// Må tildele alver til personer på snillelista, og sørge for at Gryla har 10% sjanse til å naske noen fra slemmelista ...
      Console.WriteLine($"\nList over nice kids with their assigned elves: ");
for (int i = 0; i < niceList.Count; i++)
{
  var elf = elves[i % elves.Count];
  Console.WriteLine($"{elf.Name} is assigned to {niceList[i].Name} and gives a {elf.Item}.");
}
}

static void HandleGryla(List<Person> naughtyList) // Brukte Gryla-funksjonen tidligere via denne funksjonen
{
  var random = new Random();
      Console.WriteLine($"\nList over naughty kids: ");
  foreach (var naughtyChild in naughtyList)
  {
      Console.WriteLine($"{naughtyChild.Name}");
    if (random.Next(1, 101) <= 10) //10% sjanse for at Gryla the grudge spiser te barn fra slemmelista
    {
      Console.WriteLine($"God damn! Gryla has eaten {naughtyChild.Name}!");
      naughtyList.Remove(naughtyChild); // Fjerner eventuellt barnet som blir spist.
      break;
    }
  }
}
}

