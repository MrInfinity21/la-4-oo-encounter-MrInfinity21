public class Character
{
    public string Name { get; set; }
    public int Health { get; set; } = 100;
    public Weapon Weapon { get; set; }
    
    public Character(string name, Weapon weapon)
    {
        Name = name;
        Weapon = weapon;
    }
}