using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth;
    public int expAmmount = 50;

    Color origionalColor;
    public MeshRenderer mRenderer;

    void Awake()
    {
        currentHealth = maxHealth;
        origionalColor = mRenderer.material.color;
    }

    public void TakeDamage(float damageAmmount, GameObject hitFromGO)
    {
        SetTarget(hitFromGO.transform);
        currentHealth -= damageAmmount;
        HitEffect();
        if(currentHealth <= 0) Die();
    }

    public void Heal(float healAmmount)
    {
        if(currentHealth + healAmmount >= maxHealth) currentHealth = maxHealth;
        else currentHealth += healAmmount;
    }

    void Die()
    {
        ExpManager.instance.AddExp(expAmmount);
        Destroy(this.gameObject);
    }

    void HitEffect()
    {
        mRenderer.material.color = Color.white;
        Invoke("ResetColor", 0.05f);
    }

    void ResetColor()
    {
        mRenderer.material.color = origionalColor;
    }

    void SetTarget(Transform target)
    {
        switch(this.gameObject.tag)
        {
            case "Wolf":
            if(GetComponent<WolfPack>()) GetComponent<WolfPack>().walkPoint = target.position;
            if(GetComponent<NormalWolf>()) GetComponent<NormalWolf>().walkPoint = target.position;
            break;

            default:
            Debug.Log("Enemy not found");
            break;
        }
    }
}
