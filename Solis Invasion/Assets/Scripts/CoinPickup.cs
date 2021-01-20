using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Astronaut") {
            FindObjectOfType<PlayerStats>().CollectCoin(value);
            Destroy(this.gameObject);
        }
    }
}
