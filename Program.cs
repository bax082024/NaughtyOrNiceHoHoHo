using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.VisualBasic;
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

        //lager en instans av klassen med nissens godkjente lister
        var SantaApproved = new SantasApprovedLists();

        // Sortere folk
        SortPeople(people, niceList, naughtyList, SantaApproved);

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
    static void SortPeople(List<Person> people, List<Person> niceList, List<Person> naughtyList, SantasApprovedLists SantaApproved)
    {
        foreach (var person in people)
        {
            int score = 0;

            if (person.DonatesToCharity) score++;
            if (person.WashedHands) score++;
            if (person.ToiletPaperOutward) score++;
            if (!string.IsNullOrEmpty(person.HomeAdress)) score++;
            if (SantaApproved.NiceCarModel.Contains(person.CarModel)) score++;

            foreach (var genre in person.MusicGenres)
            {
                if (SantaApproved.NiceMusicGenre.Contains(genre)) score++;
            }

            if (score > 2)
            {
                niceList.Add(person);
                Console.WriteLine($"Sweet! {person.Name} is added to the Nice List.");
            }
            else
            {
                naughtyList.Add(person);
                Console.WriteLine($"Ooh, looks like {person.Name} is added to the Naughty List.");
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
            Console.WriteLine
            ($"{elf.Name} is assigned to {person.Name}! {elf.Name}'s speciality is {elf.Craft} and gifts you a {elf.Item}.");
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
                Console.WriteLine
                ($"Oh no, this is unfortunate. Looks like {person.Name} will be eaten by Gryla\n");
            }
            else
            {
                Console.WriteLine
                ($"Someones not been a very good person this year. {person.Name} gets a coal.\n");
            }
        }
    }
}