using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoalScript : MonoBehaviour
{

    public GameObject cart;
    public GameObject roundFinished;
    public GameObject crossHair;
    public Text goldCollectedText;

    // Update is called once per frame
    void Update()
    {
        
        if(cart.transform.position.z <= -50)
        {
            finishRound();
        }

    }

    void finishRound()
    {
        Time.timeScale = 0;
        crossHair.SetActive(false);
        roundFinished.SetActive(true);
        goldCollectedText.text = "Gold collected: " + cart.GetComponent<CartScript>().cartGoldAmount;
    }

}
