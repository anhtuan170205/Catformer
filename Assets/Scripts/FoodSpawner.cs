using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foodPrefabs;
    public Vector2[] spawnPoints;
    void Start()
    {
        ResetFood();
    }

    public void SpawnFood()
    {
        for (int i=0; i<spawnPoints.Length; i++)
        {
            Instantiate(foodPrefabs[i], spawnPoints[i], Quaternion.identity);
        }
    }
    public void ResetFood()
    {
        foreach (GameObject food in GameObject.FindGameObjectsWithTag("Food"))
        {
            Destroy(food);
        }
        SpawnFood();
    }
}
