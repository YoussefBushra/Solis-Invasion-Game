using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radiationBeam : EnemyController
{
    public float speed = 20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = (transform.up * 1) * speed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(Damage);
            flip();
        }
    }
}
