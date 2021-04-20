using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{

    public TextMesh score;
    public TextMesh highscore;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "SCORE: " + PlayerPrefs.GetInt("score");
        highscore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("highscore");
    }
}
