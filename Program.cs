using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;

var jsonFilePath = "randomPeople.json";
List<Person>people;

if (File.Exists(jsonFilePath))
{
  string jsonContent = File.ReadAllText(jsonFilePath);
  people = JsonSerializer.Deserialize<List<Person>>(jsonContent, new JsonSerializerOptions
  {
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
  });
  Console.WriteLine("Data succesfully loaded from randomPeople.json!");
}
else
{
  Console.WriteLine($"Error: File {jsonFilePath} not found.");
  people = new List<Person>();
}

var niceList = new List<Person>();
var naughtyList = new List<Person>();

foreach (var person in people)
{
  int niceScore = 0;
  int naughtyScore = 0;

  if(person.DonatesToCharity) niceScore++;
  if(person.WashesHands) niceScore++;
  if(person.ToiletPaperOutward) naughtyScore++;

  if (niceScore > naughtyScore)
  {
    niceList.Add(person);
  }
  else
  {
    naughtyList.Add(person);
  }
}

// Create elf list
var elves = new List<Elf>
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



