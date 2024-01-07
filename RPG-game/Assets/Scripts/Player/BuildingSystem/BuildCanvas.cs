using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCanvas : MonoBehaviour
{
    public GameObject houseBP;
    public GameObject watchTowerBP;
    public GameObject fenceBP;
    public GameObject torchBP;

    public void SpawnHouse()
    {
        Instantiate(houseBP);
    }

    public void SpawnWatchTower()
    {
        Instantiate(watchTowerBP);
    }

    public void SpawnFence()
    {
        Instantiate(fenceBP);
    }

    public void SpawnTorch()
    {
        Instantiate(torchBP);
    }
}
