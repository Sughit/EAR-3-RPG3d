using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpManager : MonoBehaviour
{
    public static ExpManager instance;

    public delegate void ExperienceChangeHandler(int exp);
    public event ExperienceChangeHandler OnExperienceChange;

    void Awake()
    {
        if(instance != null && instance != this) Destroy(this);
        else instance = this;
    }

    public void AddExp(int exp)
    {
        Debug.Log("Exp added");
        OnExperienceChange?.Invoke(exp);
    }
}
