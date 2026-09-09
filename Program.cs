using System.Collections.Generic; 
using System;
using System.Data;

MyProgram.GameStart();

class MyProgram {
    static Character character = new Character();
    static string GetAnswer()
    {
        while (true)
        {
            string response = Console.ReadLine().Trim().ToLower();
            if (response == "")
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
            Console.Write("You can choose one of the following: ");
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
                StartingArea();
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
            else if (character.Location == "mountain_peak")
            {
                MountainPeak();
            }
            else{
                Console.Error.Write($"{character.Location} is not implemented!");
            }
        }
    }
    public static void StartingArea() {
        Console.Clear();
        Console.WriteLine("Welcome to Text Adventure!");
        do{
            Console.WriteLine("What is your name, adventurer");
            character.Name = GetAnswer();
            Console.WriteLine($"So {character.Name} is truly your name?");
        }while (!AskYesOrNo());
        Console.Clear();
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
        Console.Clear();
        character.Location = "Mountain Cave";
        Console.Clear();
    }
    public static void MountainCave()
    {
        Console.WriteLine("Welcome to Mountain Cave Path!");
        if (character.Inventory.Contains("key"))
        {
            Console.WriteLine("Where do you want to go?");
            string choosen_place = AskChoise(new string[] { "deep cave", "mountain peak" });
            if (choosen_place == "deep cave")
            {
                character.Location = "Deep Cave";
            }
            else
            {
                character.Location = "mountain_peak";
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("You can only go one way");
            character.Location = ("mountain_peak");
        }
    }
    public static void DeepCave()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Deep Cave!");
        Console.ReadLine();
    }
    public static void MountainPeak()
    {
        Console.Clear();
        Console.WriteLine("The Mountain Peaks");
        Console.WriteLine("There is a dead Anjanath lying on the floor, its flesh made of dull gold.. rotted.\n" + 
                          "You can clearly see something shiny in its hand, the shine is glistening in the sun\n" +
                          "Do approach the monster or will you walk away.");
        string approach = AskChoise(new string[] { "Approach" , "Walk Away"});
        if (approach == "Approach")
        {
            Console.WriteLine("You pick up the shiny item");
            if (DnDice() >= 3){
                Console.WriteLine("You picked up the shiny item");
            }   
            
            /*when you look closer at it you notice that it's just a cactus.\n" +
            "A cactus is a plant block found in deserts and badlands. It grows over time and can sprout cactus flowers.\n" +
                "It damages mobs and destroys minecarts and dropped items that touch it.\n" +
                "While the.\n " +
                "It damages mobs and destroys minecarts and dropped items that touch it.");*/
        }
        else
        {
            
        }

    } 
    
    static int DnDice() {  
        Random random = new Random();
        int roll = random.Next(1, 7);
        return roll;
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




class Monsters 
{
    public int monsterHealth = 100;
    public string monsterName;
    public int monsterDamage = 10;  

    public Monsters(string Name, int Health, int Damage)
    {
        Name = monsterName;
        Health = monsterHealth;
        Damage = monsterDamage;
    }
}

