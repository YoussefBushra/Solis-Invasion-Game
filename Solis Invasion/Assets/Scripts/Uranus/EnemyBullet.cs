using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        flip();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            FindObjectOfType<PlayerStats>().TakeDamage(3);
            Destroy(gameObject);
        }
        Destroy(gameObject, 1f);
    }

    void flip() {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
}
