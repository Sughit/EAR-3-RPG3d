using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UplockSkills : MonoBehaviour
{
    public Button nextSkill;
    public GameObject inactive;
    bool canUnlockCurrentSkill=true;
    public Image usedBtnImage;

    public void UnlockSkill()
    {
        if(canUnlockCurrentSkill)
        {
            if(nextSkill != null) 
            {
                nextSkill.gameObject.SetActive(true);
                inactive.SetActive(false);
            }
            usedBtnImage.gameObject.SetActive(true);
            Debug.Log("Skill unlocked");
            canUnlockCurrentSkill=false;
        }
    }
}
