using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnMeteor : MonoBehaviour
{
    public Transform enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RespawnEnemy() {
        Instantiate(enemy, transform.position, transform.rotation);
        Instantiate(enemy, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), transform.rotation);
        Instantiate(enemy, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), transform.rotation);
        Instantiate(enemy, GameObject.Find("RespawnMeteor2").transform.position, transform.rotation); 
        Instantiate(enemy, new Vector3(GameObject.Find("RespawnMeteor2").transform.position.x + 1, GameObject.Find("RespawnMeteor2").transform.position.y, GameObject.Find("RespawnMeteor2").transform.position.z), transform.rotation);
        Instantiate(enemy, new Vector3(GameObject.Find("RespawnMeteor2").transform.position.x + 2, GameObject.Find("RespawnMeteor2").transform.position.y, GameObject.Find("RespawnMeteor2").transform.position.z), transform.rotation);
    }
}
