using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSound : MonoBehaviour
{
    public AudioClip explosion;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        AudioManager.instance.RandomizeSfx(explosion);
    }
}
