using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigatorController : MonoBehaviour
{
    public int score;
    public int level;
  
    public void GoToIntroScene()
    {
        //AudioManager.instance.BgSource.Stop();
        SceneManager.LoadScene(0);    
    }
    public void GoToMercuryScene()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene(1);
    }
    public void GoToUranusScene()
    {
        SceneManager.LoadScene(2);
    }
    public void GoToGameOverScene()
    {
        SceneManager.LoadScene(3);
    }
    public void GoToBeginningScene()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene(4);
    }
    public void GoToPreVenusScene()
    {
        SceneManager.LoadScene(5);
    }
    public void GoToPreUranusScene()
    {
        SceneManager.LoadScene(6);
    }
    public void GoToVictoryScene()
    {
        SceneManager.LoadScene(7);
    }
    public void GoToScoreScene()
    {
        SceneManager.LoadScene(8);
    }
    public void GoToVenusScene()
    {
        SceneManager.LoadScene(9);
    }
    public void GoToPrePlutoScene()
    {
        SceneManager.LoadScene(10);
    }
    public void GoToPlutoScene()
    {
        SceneManager.LoadScene(11);
    }
    public void GoToSettings()
    {
       // AudioManager.instance.BgSource.Stop();
        SceneManager.LoadScene(12);
    }
    public void GoToHelp()
    {
        //AudioManager.instance.BgSource.Stop();
        SceneManager.LoadScene(13);
    }
    public void Quit()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        //AudioManager.instance.BgSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
    

