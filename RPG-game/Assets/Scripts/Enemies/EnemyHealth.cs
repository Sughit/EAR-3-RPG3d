using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth;
    public int expAmmount = 50;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void TakeDamage(float damageAmmount)
    {
        currentHealth -= damageAmmount;
        if(currentHealth <= 0) Die();
    }

    void Heal(float healAmmount)
    {
        if(currentHealth + healAmmount >= maxHealth) currentHealth = maxHealth;
        else currentHealth += healAmmount;
    }

    void Die()
    {
        ExpManager.instance.AddExp(expAmmount);
        Destroy(this.gameObject);
    }
}
