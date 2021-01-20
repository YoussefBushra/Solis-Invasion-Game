using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienWeapon : MonoBehaviour
{
    public Transform target; 
    public Transform weaponMuzzle; 
    public GameObject bullet; 
    public float fireRate = 50f; 
    public float shootingPower = 20f; 

    public bool playerhit = false;
 
    private float shootingTime;

    private string FirePoint;

    public void setFirePoint(string fp) {
        FirePoint = fp;
    }

    public void setPlayerHit(bool ph) {
        playerhit = ph;
    }

    private void Update()
    {
        if (playerhit) {
            Fire(); 
        }
        
    }
 
    private void Fire()
    {
        if (Time.time > shootingTime)
        {
            shootingTime = Time.time + fireRate / 1000; 
            Vector2 myPos = new Vector2(GameObject.Find(FirePoint).transform.position.x, GameObject.Find(FirePoint).transform.position.y); 
            GameObject projectile = Instantiate(bullet, myPos, Quaternion.identity); 
            Vector2 direction = myPos - (Vector2)target.position; 
            projectile.GetComponent<Rigidbody2D>().velocity = direction * shootingPower; 
        }
    }
}
