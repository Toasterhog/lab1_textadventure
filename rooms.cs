partial class MyProgram
{
    public static void StartingArea()
    {
        Console.Clear();
        Console.WriteLine("Welcome to Text Adventure!");
        do
        {
            Console.WriteLine("What is your name, adventurer");
            character.Name = GetAnswer();
            Console.WriteLine($"So {character.Name} is truly your name?");
        } while (!AskYesOrNo());

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
        string item_picked_upp = AskChoise(new string[] { "knife", "key" });
        character.AddItemToInventory(item_picked_upp);
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
        string approach = AskChoise(new string[] { "Approach", "Walk Away" });
        if (approach == "Approach")
        {
            if (DnDice() >= 3)
            {
                Console.WriteLine("You picked up the shiny item");
                Console.WriteLine("when you look closer at it you notice that it's just a cactus.\n" +
                                  "A cactus is a plant found in deserts and badlands. It grows over time and can sprout cactus flowers.\n" +
                                  "It damages mobs and destroys minecarts and dropped items that touch it.");
                character.AddItemToInventory("cactus");
            }
            else
            {
                Console.WriteLine("You'r hands are slippery and your attempt att picking upp the item unluckly fails");
            }
        }
        else
        {

        }

    }
}