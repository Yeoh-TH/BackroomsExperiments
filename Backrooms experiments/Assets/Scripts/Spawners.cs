using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    public List<GameObject> listOfEnemies = new List<GameObject>();

    void Start()
    {
        InvokeRepeating("SpawnEnemies", 10f, 180f);
    }

    void SpawnEnemies()
    {
        GameObject goToSpawn = listOfEnemies[Random.Range(0, listOfEnemies.Count)];
        Instantiate(goToSpawn, transform.position, Quaternion.identity);
    }
}
