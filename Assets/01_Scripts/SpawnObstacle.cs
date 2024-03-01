using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject[] spiles;
    private int totalObs;
    void Start()
    {
        totalObs = Random.Range(0, 4);
        for (int i = 0; i < totalObs; i++)
        {
            var selectedSpike = spiles[Random.Range(0, spiles.Length)];
            selectedSpike.SetActive(true);
        }
    }
}
