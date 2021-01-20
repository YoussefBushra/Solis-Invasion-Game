using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemy : EnemyController
{
    // Start is called before the first frame update
    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, maxSpeed * Time.deltaTime);
    }

    void FixedUpdate() {
        if(this.isFacingRight == true) {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        } else {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Wall") {
            flip();
        } else if(collider.tag == "Fire") {
            flip();
        } else if(collider.tag == "Player") {
            FindObjectOfType<PlayerStats>().TakeDamage(Damage);
            flip();
        }
    }
}
