using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] Sentences;
    private int index = 0;
    public float typingSpeed;
    public GameObject continueButton;
    public AudioClip Typing;

    public GameObject GoButton;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        textDisplay.text = "";
        AudioManager.instance.RandomizeSfx(Typing);
        StartCoroutine(TypeDialogue());
        continueButton.SetActive(false);
        GoButton.SetActive(false);
        AudioManager.instance.BgSource.Stop();
    }

    public IEnumerator TypeDialogue() {
        foreach(char letter in Sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        if(!(index < Sentences.Length - 1)) {
            continueButton.SetActive(false);
            GoButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(textDisplay.text == Sentences[index]){
            if (index < Sentences.Length - 1) {
                continueButton.SetActive(true);
            }
            AudioManager.instance.soundeffx.Pause();
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        AudioManager.instance.soundeffx.Play(0);
        if (index < Sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(TypeDialogue());
        }
        else
        {
            AudioManager.instance.soundeffx.Pause();
            textDisplay.text = "";
            continueButton.SetActive(false);
            //SceneManager.LoadScene(1);
        }
    }

}

