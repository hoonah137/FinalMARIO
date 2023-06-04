using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemiesToSpawn;

    //public Transform[] spawnPositions = new Transform[5];
    public Transform[] spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy",2f,1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesToSpawn == 0)
        {
            CancelInvoke();
        }
    }

    void SpawnEnemy()
    {
    //Transform selectedSpawn = spawnPosition[Random.Range(0,spawnPosition.Length)];
    //Instantiate (enemyPrefab, selectedSpawn.position, selectedSpawn.rotation);

    /*  Ejemplo de foreach */
        foreach (Transform spawn in spawnPosition)
        {
            Instantiate (enemyPrefab, spawn.position, spawn.rotation);
        }
    

    /* Ejemplo de for
    for (int i = 0; i < spawnPosition.Length; i++)
    {
        Instantiate(enemyPrefab, spawnPosition[i].position, spawnPosition[i].rotation);
    }*/

    /* Ejemplo de while
    int i = 0;
    while (i < spawnPosition.Length)
    {
        Instantiate(enemyPrefab, spawnPosition[i].position, spawnPosition[i].rotation);
        i++;
    }*/

    /*Ejemplo de Do While
    int i = 0;
    do
        {
            Instantiate(enemyPrefab, spawnPosition[i].position, spawnPosition[i].rotation);
            i++;
        } while(i < spawnPosition.Length);*/

        enemiesToSpawn--;
    }
}
