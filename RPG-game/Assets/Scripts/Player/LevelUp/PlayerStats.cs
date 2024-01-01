using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int currentExp, maxExp, currentLevel;
    public static int numSkillPoints;
    public Slider slider;
    public Text expText;
    public Text levelText;

    void Start()
    {
        slider.maxValue = maxExp;
        expText.text = $"{currentExp} / {maxExp}";
        ExpManager.instance.OnExperienceChange += HandleExperienceChange;
    }

    void OnEnabled()
    {
        Debug.Log("Ar trebui sa mearga");
        
    }

    // void OnDisabled()
    // {
    //     ExpManager.instance.OnExperienceChange -= HandleExperienceChange;
    // }

    void HandleExperienceChange(int newExp)
    {
        currentExp += newExp;
        expText.text = $"{currentExp} / {maxExp}";
        slider.value = currentExp;
        if(currentExp >= maxExp) LevelUp();
    }

    void LevelUp()
    {
        numSkillPoints++;
        currentLevel++;
        levelText.text = currentLevel.ToString();

        currentExp = maxExp - currentExp;
        slider.value = currentExp;
        maxExp += 300;
        slider.maxValue = maxExp;
        expText.text = $"{currentExp} / {maxExp}";
    }
}
