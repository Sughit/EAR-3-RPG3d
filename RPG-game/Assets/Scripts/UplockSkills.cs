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

    public void UnlockSkill()
    {
        if(canUnlockCurrentSkill)
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
        }
    }
}
