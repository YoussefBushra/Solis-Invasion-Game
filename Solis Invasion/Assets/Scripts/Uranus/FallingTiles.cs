using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTiles : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D (Collision2D col) {
        if(col.gameObject.name.Equals("Astronaut")) {
            DropTile();
            Destroy(gameObject, 2f);
        } else {
            DropTile();
            Destroy(gameObject, 2f);
        }
    }

    void DropTile() {
        rb.isKinematic = false;
    }
}
