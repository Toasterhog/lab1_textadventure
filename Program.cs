using System.Collections.Generic; 
using System;
MyProgram.GameStart();

class MyProgram {
    static Character character = new Character();
    static string GetAnswer()
    {
        while (true)
        {
            string response = Console.ReadLine().Trim().ToLower();
            if (response == "" || response == "har inte bestämt mig")
            {
                continue;
            }
            else
            {
                return response;
            }
        }
    }

    static string AskChoise(string[] choises)
    {
        while (true)
        {
            Console.Write("You can choose one of the folowing: ");
            for (int i = 0; i < choises.Length; i++)
            {
                if (i != 0) { Console.Write(", ");}
                Console.Write($"{choises[i]}");
            }
            Console.WriteLine(" ");
            string answer = GetAnswer();
            for (int i = 0; i < choises.Length; i++)
            {
                if (choises[i] == answer)
                {
                    Console.WriteLine($"You choose {answer}.");
                    return answer;
                }
            }
        }
    }
    static bool AskYesOrNo()
    {
        string response = GetAnswer();
        if(response == "yes"){
            return true;
        }
        else{
            return false;
        }
    }
    public static void GameStart()
    {
        
        while (character.Location != "End")
        {
            if (character.Location == "StartingArea"){
                StartingArea(character);
            } 
            else if (character.Location == "ancient forest")
            {
                AncientForest();
            }
            else if (character.Location == "Mountain Cave")
            {
                MountainCave();
            }
            else if (character.Location == "Deep Cave")
            {
                DeepCave();
            }
            else if (character.Location == "Mountain Peak")
            {
                MountainPeak();
            }
            else{
                Console.Error.Write($"{character.Location} is not implemented!");
            }
        }
    }
    public static void StartingArea(Character character) {
        Console.Clear();
        Console.WriteLine("Welcome to advetnure!");
        do{
            Console.WriteLine("What is your name, adventurer");
            character.Name = GetAnswer();
            Console.WriteLine($"So {character.Name} is truly your name?");
        }while (!AskYesOrNo());
        character.Location = "ancient forest";
    }

    public static void AncientForest()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Ancient forest");
        character.AddItemToInventory("wooden sword");
        Console.WriteLine(
            "You are equipped with one wooden sword, and your task " +
            "is to slay the monster at the end of the adventure. " +
            "" +
            "In front of you is a stone table with two items on it, " +
            "a knife and a key." +
            "" +
            "You can only pick up one of these items."
        );
        string it = AskChoise(new string[] {"knife","key"});
        character.AddItemToInventory(it);
        character.Location = "Mountain Cave";

    }

    public static void MountainCave()
    {
        Console.WriteLine("Welcome to Mountain Cave!");
        if (character.Inventory.Contains("key"))
        {
            Console.WriteLine("Where do you want to go?");
            string place_to_go = AskChoise(new string[] { "deep_cave", "mountain peak" });
            if (place_to_go == "deep_cave")
            {
                character.Location = "deep_cave";
                Console.WriteLine("Welcom to the Deep Cave!");
            }
            else
            {
                character.Location = "Mountain Peak";
            }
        }
        else
        {
            Console.WriteLine("You can only go one way");
            character.Location = ("Mountain Peak");
        }
    }

    public static void DeepCave()
    {
        
    }

    public static void MountainPeak()
    {
        
    }
}

class Character
{
    public string Name;
    public int Health = 100;
    public List<string> Inventory = new List<string>();
    public string Location = "StartingArea";

    public void AddItemToInventory(string itemToAdd)
    {
        Inventory.Add(itemToAdd);
        Console.WriteLine($"You picked up {itemToAdd}.");
    }
}