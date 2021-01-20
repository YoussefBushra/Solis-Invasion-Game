using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;
    public Transform enemy;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer() {
        FindObjectOfType<PlayerController>().transform.position = currentCheckpoint.transform.position;
        //FindObjectOfType<AlienWeapon>().playerhit = false;
    }

    //newly added
    public void RespawnPlayerUranus() {
        FindObjectOfType<PlayerControllerUranus>().transform.position = currentCheckpoint.transform.position;
    }

    public void RespawnEnemy() {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
