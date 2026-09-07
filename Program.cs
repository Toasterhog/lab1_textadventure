using System.Collections.Generic; 
MyProgram.GameStart();

class MyProgram {
    static string GetAnswer()
    {
        while (true)
        {
            string response = Console.ReadLine().Trim();
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
    static bool AskYesOrNo() {
        string response = Console.readline();
        if(response == "yes"){
            return true;
        }
        else{
            return false;
        }
    }
    public static void GameStart()
    {
        Character character = new Character();
        while (character.Location != "End"){
            if (character.Location == "StartingArea"){
                StartingArea(character);
            } 
            else if (character.Location == "ancient forest"
            {
                AncientForest();
            }
            else{ Console.Error.Write}
        }
    }
    public static void StartingArea(Character character) {
        Console.Clear();
        Console.WriteLine("Welcome to adveture!");
        do
        { character.Name = Ask("What is your name, adventurer? "); }
        while (!AskYesOrNo($"So {character.Name} is truly your name?"));

        character.Loccation = "ancient forest";

    }

    public static void AncientForest()
    {
        Console.WriteLine("Welcome to the Ancient forest");
    }
}

class Character
{
    public string Name;
    public int Health = 100;
    public List<string> Items = new List<string>();
    public string Location = "StartingArea";
}