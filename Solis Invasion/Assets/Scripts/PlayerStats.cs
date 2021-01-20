using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int Health = 6;
    public int Lives = 3;
    public bool bullets = false;

    public float FlickerTime = 0f;
    public float FlickerDuration = 0.1f;

    private SpriteRenderer spriteRenderer;
    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;
    public int coinsCollected = 0;
    public int LevelNumber = 0;

    public AudioClip Score;
    public AudioClip TakeBullet;
    public AudioClip HitDamage;
    public AudioClip GameOver;

    public Text ScoreUI;
    public Slider HealthUI;

    public Image[] livesImages;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        coinsCollected = PlayerPrefs.GetInt("Score");
        LevelNumber = PlayerPrefs.GetInt("Level");
        AudioManager.instance.BgSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.isImmune == true) {
            SpriteFlicker();
            immunityTime += Time.deltaTime;
            if(immunityTime >= immunityDuration) {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
            }
        }

        ScoreUI.text = "" + coinsCollected;
        HealthUI.value = Health;
    }

    void SpriteFlicker() {
        if(this.FlickerTime < this.FlickerDuration) {
            this.FlickerTime = this.FlickerTime + Time.deltaTime;
        } else if(this.FlickerTime >= this.FlickerDuration) {
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.FlickerTime = 0;
        }
    }

    public void TakeDamage(int Damage) {
        AudioManager.instance.RandomizeSfx(HitDamage);
        if(this.isImmune == false) {
            this.Health -= Damage;
            if(this.Health < 0) {
                this.Health = 0;
            }
            if(this.Lives > 0 && this.Health == 0) {
                FindObjectOfType<LevelManager>().RespawnPlayer();
                this.Health = 6;
                this.Lives--;
                bullets = false;
                livesImages[Lives].enabled = false;
            } else if(this.Lives == 0 && this.Health == 0) {
                //new NavigatorController().GoToGameOverScene();
                //FindObjectOfType<NavigatorController>().GoToGameOverScene();
                SceneManager.LoadScene(3);
                Debug.Log("GameOver");
                AudioManager.instance.BgSource.Stop();
                AudioManager.instance.playSingle(GameOver);
                Destroy(this.gameObject);
            }
            Debug.Log("Player Health: " + this.Health.ToString());
            Debug.Log("Player Lives: " + this.Lives.ToString());
        }
        
        PlayHitReaction();
    }

    void PlayHitReaction() {
        this.isImmune = true;
        this.immunityTime = 0f;
    }

    public void CollectCoin(int coinValue) {
        this.coinsCollected += coinValue; 
        PlayerPrefs.SetInt("Score", coinsCollected);
        AudioManager.instance.RandomizeSfx(Score);
    }

    public void CollectBullet() {
        this.bullets = true; 
        AudioManager.instance.RandomizeSfx(TakeBullet);
    }

    /*public void LevelUp() {
         PlayerPrefs.SetInt("Level", LevelNumber++);
    }*/
}
