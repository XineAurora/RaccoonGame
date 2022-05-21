using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    private int currentHealth;

    private AudioSource takeDamageAudio;

    void Awake()
    {
        foreach (AudioSource source in gameObject.GetComponents<AudioSource>())
        {
            if (source.clip.name.Contains("takeDamage"))
            {
                takeDamageAudio = source;
            }
        }
        currentHealth = maxHealth;
    }

    public void Damage(int damage)
    {
        if (damage > 0)
        {
            currentHealth -= damage;
            takeDamageAudio.Play();
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
