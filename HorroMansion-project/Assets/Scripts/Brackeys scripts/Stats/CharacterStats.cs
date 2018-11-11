using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public int MaxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    public event System.Action<int, int> onHealthChanged;

    private void Awake()
    {
        {
            currentHealth = MaxHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        Debug.Log(transform.name + "  takes" + damage + " damage.");

        if(onHealthChanged != null)
        {
            onHealthChanged(MaxHealth, currentHealth);
        }

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //Die in some way
        Debug.Log(transform.name + " died");
    }
}
