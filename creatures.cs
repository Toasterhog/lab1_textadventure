class Character
{
    public string Name;
    public int Health = 100;
    public List<string> Inventory = new List<string>();
    public string Location = "StartingArea";

    public int GetDamage()
    {
        int damage = 1; //fist idk
        if (Inventory.contains("knife"))
        {
            damage += 5;
        }
        else if (Inventory.contains("wood sword"))
        {
            damage += 2;
        }
        return damage;
    }

    public bool Attack(Monster monsterBeingAttacked)
    {
        int damage_dealing = GetDamage();
        Console.WriteLine($"You suddenly, forcfully, with no respect of the well being of the {monsterBeingAttacked.monsterName}, \n attack it with a strength that in die terms is equivalent to {damage_dealing}.")
        monsterBeingAttacked.monsterHealth -= damage_dealing;
        Console.WriteLine($"monster health is now {monsterBeingAttacked.monsterHealth}.");
    }

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
        monsterName = Name;
        Health = monsterHealth;
        Damage = monsterDamage;
    }

    public int GetDamage()
    {
        return MyProgram.DnDice();
    }
    public bool Attack(Characther charactherBeingAttacked)
    {
        
    }
}