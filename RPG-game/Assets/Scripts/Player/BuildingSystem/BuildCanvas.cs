using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCanvas : MonoBehaviour
{
    public GameObject buildTest;

    public void SpawnBuildTest()
    {
        Instantiate(buildTest);
    }
}
