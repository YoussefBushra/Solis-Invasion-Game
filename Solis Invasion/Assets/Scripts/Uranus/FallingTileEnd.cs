using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTileEnd : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;

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
            GetComponent<Collider2D>().enabled = false;
        } 
    }

    void DropTile() {
        rb.isKinematic = false;
    }
}
