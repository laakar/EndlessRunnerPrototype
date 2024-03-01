using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenerateManager : MonoBehaviour
{
    public GameObject[] floors;
    private GameObject lastFloor;
    public float tileSpace;
    private int lastIndex = -1;
    private int maxFloor = 300;
    
    public Vector3 currentSpawnPosition;

    private void Start()
    {
        for (int i = 0; i < maxFloor; i++)
        {
            int selectedIndex;
            do
            {
                selectedIndex = Random.Range(0, floors.Length);
            } while (selectedIndex == lastIndex);

            var selectedFloor = floors[selectedIndex];
            lastIndex = selectedIndex;
            lastFloor = Instantiate(selectedFloor, currentSpawnPosition, Quaternion.identity);
            currentSpawnPosition = new Vector3(currentSpawnPosition.x + tileSpace, Random.Range(-5, -2), 0);
        }
    }
}
