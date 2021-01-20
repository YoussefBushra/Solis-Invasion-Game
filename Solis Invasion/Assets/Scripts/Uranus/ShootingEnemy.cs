using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : EnemyController
{
    public Transform firePoint;
    public GameObject SpikeyBullet;
    public AudioClip shot;

    private Animator anim;

    private bool playSound = false;

    private bool cond = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!cond)
        {
            StartCoroutine(HandleIt());
        }
    }
    void FixedUpdate() {
        if(this.isFacingRight == true) {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        } else {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
            flip();
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Wall") {
            flip();
        } else if(collider.tag == "Fire") {
            flip();
        } else if(collider.tag == "Player") {
            FindObjectOfType<PlayerStats>().TakeDamage(Damage);
            flip();
        }

        if(collider.name == "Main Camera") {
            playSound = true;
        } else if(collider.name == "StopSound") {
            playSound = false;
        }
    }

    void shoot() {
        Instantiate(SpikeyBullet, firePoint.position, firePoint.rotation); 
        AudioManager.instance.RandomizeSfx(shot);
        //AudioSource.PlayClipAtPoint(shot, Camera.main.transform.position);
    }

    private IEnumerator HandleIt()
{
    cond = true;
    // process pre-yield
    if(playSound) {
        shoot();
        anim.Play("EnemyShoot");
    }
    yield return new WaitForSeconds(1.0f);
    // process post-yield
    cond = false;
}
}
