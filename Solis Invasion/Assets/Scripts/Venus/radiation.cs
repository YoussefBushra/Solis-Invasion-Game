using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radiation : MonoBehaviour
{
    public Transform target; //where we want to shoot(player? mouse?)
    public GameObject bullet; //Your set-up prefab
    public float fireRate = 3000f; //Fire every 3 seconds
    public float shootingPower = 20f; //force of projection

    public bool playerhit = false; 
    private float shootingTime; //local to store last time we shot so we can make sure its done every 3s

    private string firstRadientPoint;
    private string secondRadientPoint;

    public void setRadientPoints(string first, string second) {
        firstRadientPoint = first;
        secondRadientPoint = second;
    }

    public void setPlayerHit(bool ph) {
        playerhit = ph;
    }

    private void Update()
    {
        if(playerhit)
            Fire(); //Constantly fire
    }

    private void Fire()
    {
        if (Time.time > shootingTime)
        {
            shootingTime = Time.time + fireRate / 1000; //set the local var. to current time of shooting
            Vector2 myPos = new Vector2(GameObject.Find(firstRadientPoint).transform.position.x, GameObject.Find(firstRadientPoint).transform.position.y); 
            GameObject projectile = Instantiate(bullet, myPos, Quaternion.identity); //create our bullet
            Vector2 direction = myPos - (Vector2)target.position; //get the direction to the target
            projectile.GetComponent<Rigidbody2D>().velocity = direction * shootingPower; //shoot the bullet

            
            Vector2 myPos2 = new Vector2(GameObject.Find(secondRadientPoint).transform.position.x, GameObject.Find(secondRadientPoint).transform.position.y);
            GameObject projectile2 = Instantiate(bullet, myPos2, Quaternion.identity); //create our bullet
            Vector2 direction2 = myPos2 - (Vector2)target.position; //get the direction to the target
            projectile2.GetComponent<Rigidbody2D>().velocity = direction2 * shootingPower; //shoot the bullet

        }
    }

}
