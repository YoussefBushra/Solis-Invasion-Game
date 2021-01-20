using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource soundeffx;
    public AudioSource BgSource;
    public static AudioManager instance = null;
    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Start()
    {
       //BgSource = GetComponent<AudioSource>();
       //BgSource.Play();
    }

    public void playSingle(AudioClip clip) {
        soundeffx.clip = clip;
        soundeffx.Play();
    }
    public void RandomizeSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        soundeffx.pitch = randomPitch;
        soundeffx.clip = clips[randomIndex];
        soundeffx.Play();
    }
}
