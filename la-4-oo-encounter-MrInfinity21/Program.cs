public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter your Warrior's name:");
        string characterName = Console.ReadLine();
        
        Console.WriteLine("\nChoose your weapon:");
        Console.WriteLine("1. Zeus Gauntlet (Damage: 9)");
        Console.WriteLine("2. Blades of Chaos (Damage: 13)");
        Console.WriteLine("3. Nemesis Whip (Damage: 7)");
        Console.WriteLine("4. Bare Fists (Damage: 2)");
        
        int weaponChoice = int.Parse(Console.ReadLine());
        Weapon chosenWeapon;
        switch (weaponChoice)
        {
            case 1:
                chosenWeapon = new Weapon("Zeus Gauntlet", 9);
                break;
            case 2:
                chosenWeapon = new Weapon("Blades of Chaos", 13);
                break;
            case 3:
                chosenWeapon = new Weapon("Nemesis Whip", 7);
                break;
            case 4:
                chosenWeapon = new Weapon("Bare Fists", 2);
                break;
            default:
                Console.WriteLine("Invalid choice! Defaulting to Bare Fists.");
                chosenWeapon = new Weapon("Bare Fists", 2);
                break;
        }
        
        Character hero = new Character(characterName, chosenWeapon);
        Enemy Hades = new Enemy("Hades", 90);
        
        int potions = 3;
        
        Console.WriteLine("You enter into Halls of Hades as you search to loot treasures and weapons.");
        Console.WriteLine("As you presume into the room you sense darkness looming in a room and you approach towards it.");
        Console.WriteLine("As you you enter the room you can hear murmurs across the dark room trying to distract you.");
        Console.WriteLine("A light burning hot red emerges Hades himself swinging his weapon as comes out of the darkness.");
        Console.WriteLine("The Whole room burns in hot red with hatred and fear but you take your stance to battle.");
        Console.WriteLine($"You pull out your {hero.Weapon.Name} and hold it tightly.");
        
        while (hero.Health > 0 && Hades.Health > 0)
        {
            Console.WriteLine($"\n{hero.Name} Health: {hero.Health}, Hades Health: {Hades.Health}");
            Console.WriteLine($"Health Potions left: {potions}");
            
            Console.WriteLine("\nWhat will your Warrior do now? :");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Run Away");
            Console.WriteLine("3. Drink a Potion");

            string choice = Console.ReadLine();
            
            if (choice == "1")
            {
                int heroDamage = hero.Weapon.Attack();
                Hades.Health -= heroDamage;
                if (Hades.Health < 0)
                    Hades.Health = 0;
                Console.WriteLine($"{hero.Name} attacks to deal {heroDamage} damage. Hades health has dropped to {Hades.Health}.");
                
                if (Hades.Health > 0)
                {
                    int HadesDamage = Hades.Attack();
                    hero.Health -= HadesDamage;
                    Console.WriteLine($"Hades attacks to deal {HadesDamage} damage. {hero.Name}'s health has fallen to {hero.Health}.");
                }
            }
             else if (choice == "2")
             {
                 Console.WriteLine($"{hero.Name} decides to run away. The battle is finished. (Coward mortal...) ");
                 break;
             }
             else if (choice == "3" && potions > 0)
             {
                 int healAmount = new Random().Next(1, 11);
                 hero.Health += healAmount;
                 
                 if (hero.Health > 100)
                 {
                     hero.Health = 100;
                 }
 
                 potions--;
                 Console.WriteLine($"{hero.Name} drinks a health potion and heals for {healAmount} health. {hero.Name}'s health has risen to {hero.Health}.");
             }
             else if (choice == "3" && potions <= 0)
             {
                 Console.WriteLine($"{hero.Name} tries to drink health potion (NO HEALTH POTION LEFT)!");
             }
             else
             {
                 Console.WriteLine("Invalid choice! Please select options 1, 2, or 3 to proceed.");
             }
         }
         
         if (hero.Health <= 0)
         {
             Console.WriteLine($"{hero.Name} has been defeated by Hades. Your soul belongs to the underworld");
         }
         else if (Hades.Health <= 0)
         {
             Console.WriteLine($"{hero.Name} has defeated Hades!");
         }
     }
 }