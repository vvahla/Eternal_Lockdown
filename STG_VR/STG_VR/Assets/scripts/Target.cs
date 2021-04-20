using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public Rigidbody rb;

    public Animator anim;

    public GameObject roundSystemObj;

    private RoundSystem rs;

    private void Start()
    {
        roundSystemObj = GameObject.Find("Quad");
        rs = roundSystemObj.GetComponent<RoundSystem>();
    }

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
        rs.score += 10;
        StartCoroutine(DeathAnimation());
    }

    IEnumerator DeathAnimation()
    {
        rb.velocity = new Vector3(0, 0, 0);
        anim.SetBool("isDying", true);
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
