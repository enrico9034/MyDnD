namespace DnD;

public class Health
{
    public int MaxHealth { get; set; }

    public int CurrentHealth { get; set; }


    public Health(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }

    public Health(int maxHealth, int currentHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = currentHealth;
    }

}
