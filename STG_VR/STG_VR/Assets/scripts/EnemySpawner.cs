using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    public int spawnedEnemies = 0;
    public int numberOfaliveEnemies = 0;
    public int numberOfEnemiesToSpawn;

    public GameObject roundSystemObj;

    private RoundSystem rs;

    void Start()
    {
        rs = roundSystemObj.GetComponent<RoundSystem>();
        numberOfEnemiesToSpawn = 5;
        StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
        numberOfaliveEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (rs.roundInProgress && spawnedEnemies < numberOfEnemiesToSpawn)
            {
                    Instantiate(enemy);
                    spawnedEnemies += 1;
                    yield return new WaitForSeconds(7f);
            }
            else
            {
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
