using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.name == "45ACP Bullet_Head(Clone)")
            TakeDamage(10f);
    }

    public void TakeDamage (float amount)
    {
        health -= amount;

        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
