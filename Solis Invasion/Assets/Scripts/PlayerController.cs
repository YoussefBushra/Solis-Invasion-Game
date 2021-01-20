using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpHeight;
    public bool isFacingRight;

    public KeyCode Spacebar;
    public KeyCode L;
    public KeyCode R;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private Animator anim;

    public KeyCode Fire;
    public Transform firePoint;
    public GameObject SpikeyBullet;

    public bool shootCond = false;

    public AudioClip jump;
    public AudioClip shot;
    
    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(Spacebar) && grounded) {
            Jump();
        }
        anim.SetBool("Grounded", grounded);

        if(Input.GetKey(L)) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if(isFacingRight) {
                flip();
                isFacingRight = false;
            }

        }

        if(Input.GetKey(R)) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if(!isFacingRight) {
                flip();
                isFacingRight = true;
            }
        }
	
	   anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        bool cond = FindObjectOfType<PlayerStats>().bullets;
        if(Input.GetKeyDown(Fire) && cond) {
            shoot();
            anim.Play("Shoot");
            //shootCond = true;
            //Invoke("SetBoolBack", 2);           
        }
        anim.SetBool("shoot", shootCond);
    }

    void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void flip() {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    void Jump() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
        AudioManager.instance.RandomizeSfx(jump);
    }

    void shoot() {
        Instantiate(SpikeyBullet, firePoint.position, firePoint.rotation);
        AudioManager.instance.RandomizeSfx(shot);
    }

    /*private void SetBoolBack(){
        shootCond = false;
    }*/
    
}
