using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    protected int health;
    [SerializeField] int damage;
    [SerializeField] int defence;
    [SerializeField] int energy;

    protected virtual void OnEnable()
    {
        health = maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }
    
    public virtual void Die()
    {
        health = 0;
    }

    public virtual void RestoreHealth(int value)
    {
        if (health == maxHealth) return;

        health = Mathf.Clamp(health + value, 0 , maxHealth);
    }
}
