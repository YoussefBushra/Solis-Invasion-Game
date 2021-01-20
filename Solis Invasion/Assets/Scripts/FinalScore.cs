using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public Text ScoreUI;
    public Text LevelUI;
    public Text PlanetUI;
    int score, level;
    
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        level = PlayerPrefs.GetInt("Level");
    }

    // Update is called once per frame
    void Update()
    {
        ScoreUI.text = score.ToString();
        LevelUI.text = level.ToString();
        if(level == 1) PlanetUI.text = "Mercury";
        if(level == 2) PlanetUI.text = "Venus";
        if(level == 3) PlanetUI.text = "Uranus";
        if(level == 4) PlanetUI.text = "Pluto";
    }
}
