using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 20;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Heal(float healAmmount)
    {
        if(currentHealth + healAmmount > maxHealth) currentHealth += healAmmount;
        else currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmmount)
    {
        currentHealth -= damageAmmount;

        if(currentHealth <= 0) Die();
    }

    void Die()
    {
        Debug.Log("Player is dead");
    }
}
