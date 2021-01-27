using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyScript1 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount;
    public int allowedEnemyCount;

    public Vector3[] spawnPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        int allowedPositions = spawnPosition.Length;

        if(enemyCount < allowedEnemyCount){
            GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition[Random.Range(0, allowedPositions)], transform.rotation);
        }
    }
}
