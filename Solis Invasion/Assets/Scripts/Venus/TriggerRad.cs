using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string NameOfFirstPoint;
    public string NameOfSecondPoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Astronaut")
        {
            FindObjectOfType<radiation>().setPlayerHit(true);
            FindObjectOfType<radiation>().setRadientPoints(NameOfFirstPoint, NameOfSecondPoint);
        }
    }
}
