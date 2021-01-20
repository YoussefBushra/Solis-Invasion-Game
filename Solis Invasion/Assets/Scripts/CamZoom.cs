using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoom : MonoBehaviour
{
    private Camera Cam;
    public float zoomSpeed;
    public KeyCode Z;

    // Start is called before the first frame update
    void Start()
    {
        Cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(Input.GetKey(Z)) {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 3.8f, Time.deltaTime * zoomSpeed);
        } else {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 4.2f, Time.deltaTime * zoomSpeed);
        }
    }
}
