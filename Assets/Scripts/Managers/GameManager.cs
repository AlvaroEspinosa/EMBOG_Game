using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;
    public GameObject background;

    private SpriteRenderer srBackground;
    public Sprite[] backgroundsImages;
    //public Transform spawnPlayer1;
    //public Transform spawnPlayer2;

    public GameObject hud;
    public float roundTime = 90f;
    private GameHUD hudScript;

    public float contador = 10f;

    private PlayerController control1;
    private PlayerController control2;

    //private bool anyPlayerDead = false;
    private bool endGame = false;
    private bool gameStart = false;

    void Start()
    {
        this.control1 = this.player1.GetComponent<PlayerController>();
        this.control2 = this.player2.GetComponent<PlayerController>();

        this.control1.numberPlayer = 1;
        this.control2.numberPlayer = 2;

        this.hudScript = this.hud.GetComponent<GameHUD>();
        this.srBackground = this.background.GetComponent<SpriteRenderer>();
        int imageNum = Random.Range(0, backgroundsImages.Length);
        //Debug.Log(imageNum.ToString());
        if (imageNum == 0)
        {
            this.srBackground.GetComponent<Animator>().enabled = true;
        }
        this.srBackground.sprite = this.backgroundsImages[imageNum];
    }

    void Update()
    {
        if (this.gameStart) { 

            if (this.roundTime >= 0) { 
                this.roundTime -= Time.deltaTime;
                this.hudScript.updateTimer(this.roundTime);
            }

            if (this.roundTime <= 0)
            {
                if (this.control1.getLife() > this.control2.getLife())
                {
                    this.control2.killPlayer();
                }

                else
                {
                    this.control1.killPlayer();
                }
            }

            if (this.control1.isPlayerDead() || this.control2.isPlayerDead())
            {
                this.control1.setGameEnd();
                this.control2.setGameEnd();
                this.hudScript.activeFinishScreen();
                this.hudScript.updateTimer(0f);
            }

            if (this.control1.isPlayerDead())
                {
                    this.control1.setGameEnd();
                    this.hudScript.chooseWinerAndLoser(false, true);
                    //this.anyPlayerDead = true;
                    //Lanzar animacion de muerte de player
                }

                if (this.control2.isPlayerDead())
                {
                    this.hudScript.chooseWinerAndLoser(true, false);
                    this.control2.setGameEnd();
                    //this.anyPlayerDead = true;
                    //Lanzar animacion de muerte de player
                }

          

                calculateDamage();
                hudScript.updateLifePlayer1(control1.getLife());
                hudScript.updateLifePlayer2(control2.getLife());

                hudScript.updateIntensityPlayer1(control1.getIntensity(),control1.getLastPressed());
                hudScript.updateIntensityPlayer2(control2.getIntensity(), control2.getLastPressed());
        }

        else
        {
            this.contador -= Time.deltaTime;
            this.hudScript.updateCountdownStart(this.contador);
        }

        if (this.contador <= 0f)
        {
            this.gameStart = true;
            this.hudScript.desactiveTutorial();
            this.control1.setGameStart();
            this.control2.setGameStart();
        }
    }


    private void calculateDamage()
    {
        float intensityPlayer1 = this.control1.getIntensity();
        float intensityPlayer2 = this.control2.getIntensity();
        string wavePlayer1 = this.control1.getLastPressed();
        string wavePlayer2 = this.control2.getLastPressed();

        if (wavePlayer1 == wavePlayer2)
        {
            float diffIntensityPlayer = intensityPlayer1 - intensityPlayer2;
            if (diffIntensityPlayer > 0f) //Jugador 1 Gana
            {
                control2.hurtPlayer((diffIntensityPlayer * 0.05f) * control1.damage);
            }
            else if (diffIntensityPlayer < 0f) //Jugador 2 Gana
            {
                control1.hurtPlayer((diffIntensityPlayer * 0.05f) * control2.damage);
            }
            else if (diffIntensityPlayer == 0) //No hurt a los players
            {
            }
        }

        //Si 1 - Rojo
        if ((wavePlayer1 == "WaveR") && ((wavePlayer2 == "WaveB")) ) //Gana Jugador 2
        {
            control1.setIntensity(0);
            control1.hurtPlayer((intensityPlayer2 * 0.05f) * control2.damage);
        }
        if ((wavePlayer1 == "WaveR") && ((wavePlayer2 == "WaveG"))) //Gana Jugador 1
        {
            control2.setIntensity(0);
            control2.hurtPlayer((intensityPlayer1 * 0.05f) * control2.damage);
        }

        //Si 1 - Azul
        if ((wavePlayer1 == "WaveB") && ((wavePlayer2 == "WaveG"))) //Gana Jugador 2
        {
            control1.setIntensity(0);
            control1.hurtPlayer((intensityPlayer2 * 0.05f) * control2.damage);
        }
        if ((wavePlayer1 == "WaveB") && ((wavePlayer2 == "WaveR"))) //Gana Jugador 1
        {
            control2.setIntensity(0);
            control2.hurtPlayer((intensityPlayer1 * 0.05f) * control2.damage);
        }


        //Si 1 - Verde
        if ((wavePlayer1 == "WaveG") && ((wavePlayer2 == "WaveR"))) //Gana Jugador 2
        {
            control1.setIntensity(0);
            control1.hurtPlayer((intensityPlayer2 * 0.05f) * control2.damage);
        }
        if ((wavePlayer1 == "WaveG") && ((wavePlayer2 == "WaveB"))) //Gana Jugador 1
        {
            control2.setIntensity(0);
            control2.hurtPlayer((intensityPlayer1 * 0.05f) * control2.damage);
        }

        //Si 1 - Nada 
        if ((wavePlayer1 == "") && ((wavePlayer2 != ""))) //Gana Jugador 2
        {
            control1.setIntensity(0);
            control1.hurtPlayer((intensityPlayer2 * 0.05f) * control2.damage);
        }
        //Si 2 Nada
        if ((wavePlayer1 != "") && ((wavePlayer2 == ""))) //Gana Jugador 1
        {
            control2.setIntensity(0);
            control2.hurtPlayer((intensityPlayer1 * 0.05f) * control2.damage);
        }
    }
}