using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel2Uranus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Astronaut") {
            PlayerPrefs.SetInt("Level", 3);
            //new NavigatorController().GoToUranusScene();
            SceneManager.LoadScene(6);
        }
    }
}
