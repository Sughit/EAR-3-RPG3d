using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 20;
    public float currentHealth;
    GameObject sliderGO, fillGO, heartGO;
    Slider slider;
    public Gradient grad;
    Image fill, heart;
    public Sprite[] Images;
    void Start()
    {
        sliderGO = GameObject.Find("MainCanvas/healthBar");
        fillGO = GameObject.Find("MainCanvas/healthBar/Fill Area/Fill");
        heartGO = GameObject.Find("MainCanvas/healthBar/heart");
        slider = sliderGO.GetComponent<Slider>();
        fill = fillGO.GetComponent<Image>();
        heart = heartGO.GetComponent<Image>();
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        heart.sprite = Images[0];
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
    void Update()
    {
        slider.value = currentHealth;
        fill.color = grad.Evaluate(slider.normalizedValue);

        if(currentHealth/maxHealth > 66.6)
        {
            heart.sprite = Images[0];
        }
        else if(currentHealth/maxHealth < 66.6/100 && currentHealth/maxHealth > 33.3/100)
        {
            heart.sprite = Images[1];
        }
        else
        if(currentHealth/maxHealth < 33.3/100)
        {
            heart.sprite = Images[2];
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(4);
        }
    }
}
