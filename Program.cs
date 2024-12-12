using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;

class Program
{
    static void Main()
    {
        var jsonFilePath = "randomPeople.json";
        List<Person> people;

        // Laste inn json fil med personer
        people = LoadPeopleFromJson(jsonFilePath);

        // initialisere lister
        var niceList = new List<Person>();
        var naughtyList = new List<Person>();

        // Sortere folk
        SortPeople(people, niceList, naughtyList);

        // tildele alver til nice list
        var elves = InitializeElves();
        AssignElves(niceList, elves);

        // gryla funskjon naughtylist
        HandleGryla(naughtyList);
    }


    // Laste inn folk fra json
    static List<Person> LoadPeopleFromJson(string jsonFilePath)
    {
        if (File.Exists(jsonFilePath))
        {
            string jsonContent = File.ReadAllText(jsonFilePath);
            var people = JsonSerializer.Deserialize<List<Person>>(jsonContent, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }) ?? new List<Person>();
            Console.WriteLine("Data successfully loaded from randomPeople.json!");
            return people;
        }
        else
        {
            Console.WriteLine($"Error: File {jsonFilePath} not found.");
            return new List<Person>();
        }
    }

    // Sortere Folk
    static void SortPeople(List<Person> people, List<Person> niceList, List<Person> naughtyList)
    {
        foreach (var person in people)
        {
            int score = 0;

            if (person.DonatesToCharity) score++;
            if (person.WashedHands) score++;
            if (person.ToiletPaperOutward) score++;
            if (!string.IsNullOrEmpty(person.HomeAdress)) score++;

            if (score > 2)
            {
                niceList.Add(person);
                Console.WriteLine($"{person.Name} added to the Nice List.");
            }
            else
            {
                naughtyList.Add(person);
                Console.WriteLine($"{person.Name} added to the Naughty List.");
            }
        }
    }

    // Lage alver
    static List<Elf> InitializeElves()
    {
        return new List<Elf>
        {
            new Elf { Name = "Alvhild", Craft = "Ceramic", Item = "Ashtray" },
            new Elf { Name = "Leahlv", Craft = "Glassblowing", Item = "Glassball" },
            new Elf { Name = "Kai-Alv", Craft = "Woodwork", Item = "Mini-sled" },
            new Elf { Name = "Alvbjørn", Craft = "Artist", Item = "Portrait" },
            new Elf { Name = "Alv-Prøysen", Craft = "Musician", Item = "Banjo" }
        };
    }

    // Tildele alver
    static void AssignElves(List<Person> niceList, List<Elf> elves)
    {
        int elfIndex = 0;
        foreach (var person in niceList)
        {
            var elf = elves[elfIndex];
            Console.WriteLine($"{elf.Name} is assigned to {person.Name} and gifts a {elf.Item}.");
            elfIndex = (elfIndex + 1) % elves.Count;
        }
    }

    // Gryla 
    static void HandleGryla(List<Person> naughtyList)
    {
        var random = new Random();
        foreach (var person in naughtyList)
        {
            if (random.Next(1, 101) <= 10) 
            {
                Console.WriteLine($"Gryla has eaten {person.Name}!");
            }
            else
            {
                Console.WriteLine($"{person.Name} gets coal.");
            }
        }
    }
}