using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerUranus : MonoBehaviour
{
    public float jetForce;
    public KeyCode up;
    
    ParticleSystem ps;
    //public bool isFlying = false;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKey(up)) {
            fly();
            ps.Play();
        }
        if(Input.GetKeyUp(up)) {
            ps.Stop();
        }
    }


    void fly() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jetForce);
    }

}
