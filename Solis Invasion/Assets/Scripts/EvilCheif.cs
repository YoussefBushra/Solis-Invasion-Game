using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilCheif : MonoBehaviour
{
    public bool isFacingRight=false;
    public int damage = 1;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public int Health = 6;
    public int Lives = 3;
    public float FlickerTime = 0f;
    public float FlickerDuration = 0.1f;

    private SpriteRenderer spriteRenderer;
    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;
    //public float startTimeBtwShots;
    //private float timeBtwShots;
    //public GameObject projectile;
    //public Transform firePoint;



    private Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    void Update()
    {
        if (Vector2.Distance(transform.position, Player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
            if (isFacingRight == false)
            {
                flip();
                isFacingRight = true;
            }



        }
        else if (Vector2.Distance(transform.position, Player.position) < stoppingDistance && Vector2.Distance(transform.position, Player.position) > retreatDistance)
        {
            transform.position = this.transform.position;



        }
        else if (Vector2.Distance(transform.position, Player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, -speed * Time.deltaTime);
            if (isFacingRight == false)
            {
                flip();
                isFacingRight = true;
            }
            FindObjectOfType<PlayerStats>().TakeDamage(3);
        }


        /*if (timeBtwShots <= 0)
        {
            Instantiate(projectile, firePoint.position, firePoint.rotation);

            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }*/
        if (this.isImmune == true)
        {
            SpriteFlicker();
            immunityTime += Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
            }
        }
    }
    void SpriteFlicker()
    {
        if (this.FlickerTime < this.FlickerDuration)
        {
            this.FlickerTime = this.FlickerTime + Time.deltaTime;
        }
        else if (this.FlickerTime >= this.FlickerDuration)
        {
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.FlickerTime = 0;
        }
    }
    public void TakeDamageEnemy(int Damage)
    {
        
        if (this.isImmune == false)
        {
            this.Health -= Damage;
            if (this.Health < 0)
            {
                this.Health = 0;
            }
            if (this.Lives > 0 && this.Health == 0)
            {
                //FindObjectOfType<LevelManager>().RespawnPlayer();
                this.Health = 6;
                this.Lives--;
                
            }
            else if (this.Lives == 0 && this.Health == 0)
            {
                //new NavigatorController().GoToGameOverScene();
                //FindObjectOfType<NavigatorController>().GoToGameOverScene();
                
                Destroy(this.gameObject);
            }
            
        }

        PlayHitReaction();
    }

    void PlayHitReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
    }
    public void flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
    
    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Wall") {
            flip();
        } else if(collider.tag == "Fire") {
            flip();
        } else if(collider.tag == "Player") {
            //FindObjectOfType<PlayerStats>().TakeDamage(Damage);
            flip();
        }
    }

}

//transform.localScale.Set(target.x > transform.position.x ? 1f : -1f, 1f);


