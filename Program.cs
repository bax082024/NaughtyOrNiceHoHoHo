using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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
  new Elf { Name = Alvhild, Craft = Ceramic, Item = Ashtray},
  new Elf { Name = Leahlv, Craft = Glassblowing, Item = Glassballs},
  new Elf { Name = Kai-Alv, Craft = Woodwork, Item = Mini-sled},
  new Elf { Name = Alvbjørn, Craft = Artist, Item = Portret},
  new Elf { Name = Alv-Prøysen, Musician = Ceramic, Item = Banjo}
};

// Må tildele alver til personer på snillelista, og sørge for at Gryla har 10% sjanse til å naske noen fra slemmelista ...



