using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : EnemyController
{
    public float HorizontalSpeed;
    public float VerticalSpeed;
    public float Amplitude;
    private Vector3 temp_position;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        temp_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        temp_position.x += HorizontalSpeed;
        temp_position.y = 3.5f + Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * Amplitude;
        transform.position = temp_position;
    }
}
