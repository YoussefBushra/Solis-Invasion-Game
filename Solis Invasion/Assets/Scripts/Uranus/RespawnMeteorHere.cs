using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnMeteorHere : MonoBehaviour
{
    public Transform Asteroid;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnAsteriod() {
        Instantiate(Asteroid, transform.position, transform.rotation);
        Instantiate(Asteroid, GameObject.Find("RespawnMeteorHere2").transform.position, transform.rotation); 
        Instantiate(Asteroid, GameObject.Find("RespawnMeteorHere3").transform.position, transform.rotation); 
        Instantiate(Asteroid, GameObject.Find("RespawnMeteorHere4").transform.position, transform.rotation); 
        Instantiate(Asteroid, GameObject.Find("RespawnMeteorHere5").transform.position, transform.rotation);
    }
}
