using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDecending : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string firePointName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Astronaut") {
            FindObjectOfType<AlienWeapon>().setPlayerHit(true);
            FindObjectOfType<AlienWeapon>().setFirePoint(firePointName);
        }
    }
}
