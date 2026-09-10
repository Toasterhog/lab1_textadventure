using System.Collections.Generic; 
using System;
using System.Data;

MyProgram.GameStart();

partial class MyProgram {
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
    
    
    static int DnDice() {  
        Random random = new Random();
        int roll = random.Next(1, 7);
        return roll;
    }

    public static bool FightEvent(Monsters monster)
    {
        Console.WriteLine($"Welcome to a fight event! \n your'e fighting a {monster.Name} with {monster.Helth} helth.\n {monster.Name} is exited to hurt you with damage {monster.Damage}.");
        while (monster.Helth > 0) //rounds
        {
            //player turn
            switch (AskChoise(new string[] { "attack", "run", "do a flip" }))
            {
                case "attack":
                    //characther.Attack(monster);
                    int damage_dealing = characther.GetDamage();
                    Console.WriteLine($"You suddenly, forcfully, with no respect of the well being of the {Monster.Name}, \n attack it with a strength that in die terms is equivalent to {damage_dealing}.")
                    monster.Helth -= damage_dealing;
                    Console.WriteLine($"monster health is now {Monster.Helth}.");
                    if (monster.Helth <= 0)
                    {
                        Console.WriteLine("monster is unhealthy.")
                        return true;
                    }
                    break;
                case "run":
                    break;
                case "do a flip":
                    if (DnDice() == 6)
                    {
                        Console.WriteLine($"{monster.Name} thinks you look silly. It is dying of laugther. You have won the battle.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("You land head first on the ground. You feel the weight of your body consentrat at your neck, forming a small insignificant crack in your spie.\n"+
                                          " Sound of thin metal colliding with ground is heard, it's your coffe termos. You cannot live witout coffe.");
                        return false;
                    }
                default:
                    break;
                    
            }

            if (monster.Helth <= 0)
            {
                Console.WriteLine($"You have killed {monster.name}.");
                return true;
            }
            //monster turn
            int monsterDieRoll = DnDice();
            if (monsterDieRoll >= 4)
            {
                characther.Helth -= 1;
            }
        }
    }
    
}
