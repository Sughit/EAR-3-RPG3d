using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UplockSkills : MonoBehaviour
{
    public Button[] nextSkills;
    public GameObject[] inactives;
    bool canUnlockCurrentSkill=true;
    public Image usedBtnImage;
    public int cost = 1;
    public Text costText;
    public Text skillPointsText;

    void Start()
    {
        costText.text = $"Cost: {cost}";
        skillPointsText.text = $"Skill Points: {PlayerStats.numSkillPoints}";
    }

    void Update()
    {
        skillPointsText.text = $"Skill Points: {PlayerStats.numSkillPoints}";
    }

    public void UnlockSkill()
    {
        if(canUnlockCurrentSkill && cost <= PlayerStats.numSkillPoints)
        {
            if(nextSkills.Length > 0) 
            {
                foreach(var nextSkill in nextSkills)
                {
                    nextSkill.gameObject.SetActive(true);
                }
                foreach(var inactive in inactives)
                {
                    inactive.SetActive(false);
                }
            }
            usedBtnImage.gameObject.SetActive(true);
            Debug.Log("Skill unlocked");
            canUnlockCurrentSkill=false;
            PlayerStats.numSkillPoints -= cost;
            skillPointsText.text = $"Skill Points: {PlayerStats.numSkillPoints}";
        }
    }
}
