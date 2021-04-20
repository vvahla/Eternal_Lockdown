using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSystem : MonoBehaviour
{

    public int roundNumber = 1;

    public int score = 0;

    public bool roundInProgress;

    public TextMesh roundNumberText;
    public TextMesh scoreText;

    public GameObject enemySpawnerObj;

    private EnemySpawner en;

    private void Start()
    {
        roundInProgress = true;
        roundNumberText = roundNumberText.GetComponent<TextMesh>();
        en = enemySpawnerObj.GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        roundNumberText.text = "ROUND: " + roundNumber;
        scoreText.text = "SCORE: " + score;
        UpdateRound();
    }

    void UpdateRound()
    {
        switch (roundNumber)
        {
            case 1:
                if (en.spawnedEnemies >= 5 && en.numberOfaliveEnemies == 0)
                {
                    //Wait for next round
                    StartCoroutine(WaitForNewRound());
                    //Reset enemy amount
                    en.spawnedEnemies = 0;
                    //Update round text
                    roundNumberText.text = "Round: " + roundNumber;
                } 
                break;
            case 2:
                en.numberOfEnemiesToSpawn = 15;
                if (en.spawnedEnemies >= 15 && en.numberOfaliveEnemies == 0)
                {
                    StartCoroutine(WaitForNewRound());
                    en.spawnedEnemies = 0;
                    roundNumberText.text = "Round: " + roundNumber;
                }
                break;
            case 3:
                en.numberOfEnemiesToSpawn = 30;
                if (en.spawnedEnemies >= 30 && en.numberOfaliveEnemies == 0)
                {
                    StartCoroutine(WaitForNewRound());
                    en.spawnedEnemies = 0;
                    roundNumberText.text = "Round: " + roundNumber;
                }
                break;
            case 4:
                en.numberOfEnemiesToSpawn = 40;
                if (en.spawnedEnemies >= 40 && en.numberOfaliveEnemies == 0)
                {
                    StartCoroutine(WaitForNewRound());
                    en.spawnedEnemies = 0;
                    roundNumberText.text = "Round: " + roundNumber;
                }
                break;
            case 5:
                en.numberOfEnemiesToSpawn = 50;
                if (en.spawnedEnemies >= 50 && en.numberOfaliveEnemies == 0)
                {
                    StartCoroutine(WaitForNewRound());
                    en.spawnedEnemies = 0;
                    roundNumberText.text = "Round: " + roundNumber;
                }
                break;
            case 6:
                en.numberOfEnemiesToSpawn = 60;
                if (en.spawnedEnemies >= 60 && en.numberOfaliveEnemies == 0)
                {
                    StartCoroutine(WaitForNewRound());
                    en.spawnedEnemies = 0;
                    roundNumberText.text = "Round: " + roundNumber;
                }
                break;
        }
    }

    IEnumerator WaitForNewRound()
    {
        roundInProgress = false;
        yield return new WaitForSeconds(10);
        roundNumber++;
        roundInProgress = true;
    }

}
