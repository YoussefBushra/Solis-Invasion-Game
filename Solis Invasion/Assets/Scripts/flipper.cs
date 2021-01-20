using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class flipper : MonoBehaviour
{
    public AIPath path;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(path.desiredVelocity.x >= 0.01f) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if(path.desiredVelocity.x <= -0.01f) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
