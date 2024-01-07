using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsLink : MonoBehaviour
{
    public string license;
    public string page;

    public void CreatorLicense()
    {
        Application.OpenURL(license);
    }

    public void PageCredits()
    {
        Application.OpenURL(page);
    }
}
