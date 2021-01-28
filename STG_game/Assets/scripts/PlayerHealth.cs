using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float playerHealth = 100f;

    public GameObject deadText;

    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        healthText.text = "Health: " + playerHealth;

        if(playerHealth <= 0)
        {
            Die();
        }

    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.tag == "ammo")
        {
            playerHealth -= 10;
        }
    }

    private void Die()
    {
        playerHealth = 0;
        Time.timeScale = 0;
        deadText.SetActive(true);
        GameObject.Find("Crosshair").SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }

}
