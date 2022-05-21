using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    Canvas death;
    private int maxHealth;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = PlayerPrefs.GetInt(SavingKeys.MaxHealth, 10);
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        if (damage > 0)
        {
            currentHealth -= damage;
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int heal)
    {
        if (heal > 0)
        {
            currentHealth = Mathf.Min(currentHealth + heal, maxHealth);
        }
    }

    public void IncreaseMaxHealth(int value)
    {
        maxHealth += value;
        currentHealth = maxHealth;
    }

    public int CurrentHealth { get { return currentHealth; } }
    public int MaxHealth { get { return maxHealth; } }

    private void Die()
    {
        gameObject.GetComponent<MovementBehavior>().Dead();
        death.GetComponent<LoadSubMenus>().DeathMenu();
    }
}
