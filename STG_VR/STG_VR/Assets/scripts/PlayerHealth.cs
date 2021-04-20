using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public float playerHealth = 100f;

    public GameObject rsObj;

    private RoundSystem rs;

    private void Start()
    {
        rs = rsObj.GetComponent<RoundSystem>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Health: " + playerHealth); 

        if(playerHealth <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        playerHealth = 0;

        PlayerPrefs.SetInt("score", rs.score);

        if (rs.score > PlayerPrefs.GetInt("highscore", 0))
            PlayerPrefs.SetInt("highscore", rs.score);

        SceneManager.LoadScene(1);
    }

}
