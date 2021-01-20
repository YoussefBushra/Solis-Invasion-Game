using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : EnemyController
{
    private Animator anim;
    private bool grounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public AudioClip explosion;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;
    }

    void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            FindObjectOfType<LevelManager>().RespawnPlayer();
            FindObjectOfType<PlayerStats>().TakeDamage(Damage);
        }
    }
}
