public class Weapon
{
    public string Name { get; set; }
    public int Damage { get; set; }
    private Random random = new Random();
    
    public Weapon(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }
    
    public int Attack()
    {
        return random.Next(1, Damage + 1);
    }
}