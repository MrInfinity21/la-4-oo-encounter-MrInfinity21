public class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    private Random random = new Random();
    
    public Enemy(string name, int health)
    {
        Name = name;
        Health = health;
    }
    
    public int Attack()
    {
        return random.Next(1, 9);
    }
}