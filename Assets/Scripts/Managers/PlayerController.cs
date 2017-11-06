using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int numberPlayer;
    public float life = 100f;
    public int pulsePerSecond = 5; //Intensidad limite
    public float damage = 0.5f;
    public GameObject wave;
    public string SpriteChar = "";
    public Animator anim;

    public AudioClip[] clips;

    private waveSelector waveSelector;
    private string waveR;
    private string waveG;
    private string waveB;
    private string inputwaveR;
    private string inputwaveG;
    private string inputwaveB;
    private string lastPressed = "";

    private int intensity = 0;
    private int pulseCount = 0;
    private float currentTime = 0f;

    private bool isDead = false;
    private bool endGame = false;
    private bool gameStart = false;

    private AudioSource audioSource;

    void Start () {
        this.currentTime = 0f;
        this.inputwaveR = "WaveR" + numberPlayer;
        this.inputwaveG = "WaveG" + numberPlayer;
        this.inputwaveB = "WaveB" + numberPlayer;

        this.waveR = "WaveR" ;
        this.waveG = "WaveG" ;
        this.waveB = "WaveB" ;
        this.waveSelector = this.wave.GetComponent<waveSelector>();

        anim = GetComponent<Animator>();
        this.audioSource = this.gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update () {
        if (this.gameIsStarted()) { 
        if (!this.endGame) {  //if some player is dead, the input trigger stops
            if (Input.GetButtonDown(this.inputwaveR))
            {
                //Cambiar Boton HUD
                if (this.lastPressed != this.waveR)
                {
                    this.pulseCount = 0;
                    this.intensity = 1;
                    this.currentTime = 0f;
                }

                if (this.currentTime >= 1f)
                {

                    //Debug.Log("Fin segundo-> Pulsaciones " + this.pulseCount);
                    this.setPlayerIntensity();
                    this.pulseCount = 0;
                    this.currentTime -= 1f;
                }

                else
                {
                    this.pulseCount++;
                }

                this.lastPressed = this.waveR;
                this.waveSelector.changeSpriteGeneral(this.lastPressed, this.intensity);
            }

            else if (Input.GetButtonDown(this.inputwaveG))
            {
               
                //Cambiar Boton HUD
                if (this.lastPressed != this.waveG)
                {
                    this.pulseCount = 0;
                    this.intensity = 1;
                    this.currentTime = 0f;
                }

                if (this.currentTime >= 1f)
                {

                    //Debug.Log("Fin segundo-> Pulsaciones " + this.pulseCount);
                    this.setPlayerIntensity();
                    this.pulseCount = 0;
                    this.currentTime -= 1f;
                }

                else
                {
                    this.pulseCount++;
                }

                this.lastPressed = this.waveG;
                this.waveSelector.changeSpriteGeneral(this.lastPressed, this.intensity);
            }

            else if (Input.GetButtonDown(this.inputwaveB))
            {
     
                //Cambiar Boton HUD
                if (this.lastPressed != this.waveB)
                {
                    this.pulseCount = 0;
                    this.intensity = 1;
                    this.currentTime = 0f;
                }

                if (this.currentTime >= 1f)
                {
                    //Debug.Log("Fin segundo-> Pulsaciones " + this.pulseCount);
                    this.setPlayerIntensity();
                    this.pulseCount = 0;
                    this.currentTime -= 1f;
                }

                else
                {
                    this.pulseCount++;
                }

                this.lastPressed = this.waveB;
                this.waveSelector.changeSpriteGeneral(this.lastPressed, this.intensity);
            }


            else
            {
                if (this.currentTime >= 1.5f)
                {
                    if ((!Input.GetButtonDown(this.inputwaveR)) && (!Input.GetButtonDown(this.inputwaveB)) && (!Input.GetButtonDown(this.inputwaveG)))
                    {
                        //Debug.Log("NO APRETAR NINGUN BOTON->" + this.intensity);

                        this.waveSelector.changeSpriteGeneral(this.lastPressed, 0);
                        this.waveSelector.wave_sound.Stop();

                        this.lastPressed = "";
                         this.pulseCount = 0;
                         this.intensity = 0;
                         this.currentTime = 0f;
                        //this.currentTime -= 1.5f;
                    }
                }
            }



        }

        else
        {
            this.waveSelector.desactiveWave();
        }


        this.currentTime += Time.deltaTime;
        anim.SetFloat("life", this.life);
        }
    }

    public int getPlayerNumber()
    {
        return this.numberPlayer;
    }

    private void setPlayerIntensity()
    {
        /*if (this.pulseCount >= 7)
        {
            if (this.intensity >= 9)
                this.intensity = 10;
            else
                this.intensity += 2;
        }*/
            
        if (this.pulseCount >= 5)
        {
            if (this.intensity < 10)
                this.intensity++;
            if (this.intensity >= 10)
                this.intensity = 10;
        }
            
        else if (this.pulseCount < 5)
        {
            if (this.intensity > 0)
                this.intensity--;
            if (this.intensity <= 0)
                this.intensity = 0;
        }

         else if (this.pulseCount == 0)
        {
            this.intensity = 0;
        }

       
        //Debug.Log("Intensidad->" + this.intensity);
    }

    public void hurtPlayer(float damage)
    {
        this.life-=this.damage;
        if (this.life <= 0.9f)
            this.killPlayer();
    }

    private void attackEnemy()
    {

    }

    public void killPlayer()
    {
        this.isDead = true;
    }

    public bool isPlayerDead()
    {
        return this.isDead;
    }

    public void setGameEnd()
    {
        this.endGame = true;
    }

    public float getIntensity()
    {
        return this.intensity;
    }
    public void setIntensity(int newIntensity)
    {
        this.intensity = newIntensity;
    }

    public string getLastPressed()
    {
        return this.lastPressed;
    }

    public float getLife()
    {
        return this.life;
    }

    public void setClip(int i)
    {
        this.audioSource.Stop();
        this.audioSource.clip = this.clips[i];
        this.audioSource.Play();
    }

    private bool gameIsStarted()
    {
        return this.gameStart;
    }

    public void setGameStart()
    {
        this.gameStart = true;
    }
}