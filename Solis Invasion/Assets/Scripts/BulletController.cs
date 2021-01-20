using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        if(player.transform.localScale.x < 0) {
            speed = -speed;
            flip();
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            Destroy(other.gameObject);
            Destroy(gameObject);
            FindObjectOfType<PlayerStats>().CollectCoin(10);
        }
        Destroy(gameObject, 1f);

        if(other.tag == "EvilCheif")
        {
            FindObjectOfType<EvilCheif>().TakeDamageEnemy(3);
        }
    }
     void flip() {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
}
