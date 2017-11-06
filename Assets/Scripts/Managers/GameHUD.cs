using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHUD : MonoBehaviour {

    public GameObject finishGameScreen;
    public Sprite win;
    public Sprite lose;

    public Image player1End;
    public Image player2End;

    public Text timer;

    public Slider LifePlayer1;
    public Slider LifePlayer2;

    public Slider IntensityPlayer1;
    public Slider IntensityPlayer2;

    public Image IntensityfillPlayer1;
    public Image IntensityfillPlayer2;
    public Sprite[] IntensitiesFill;

    public GameObject tutorial;
    public Text countDownStart;

    void Start () {
		
	}
	
	void Update () {

	}

    public void activeFinishScreen()
    {
        this.finishGameScreen.SetActive(true);
    }

    public void chooseWinerAndLoser(bool player1, bool player2) //true winner false loser
    {
        if (player1)
        {
            this.player1End.sprite = this.win;
            this.player2End.sprite = this.lose;
        }

        else
        {
            this.player1End.sprite = this.lose;
            this.player2End.sprite = this.win;
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("juego");
    }

    public void updateTimer(float t)
    {
       // int min = (int) Mathf.Round((t / 60));
       //   int seg = (int) Mathf.Round(t % 60);
       //this.timer.text = min + ":" + seg;
       this.timer.text = Mathf.Round((t)).ToString();
    }

    public void updateLifePlayer2(float lifePlayer2)
    {
        LifePlayer2.value = lifePlayer2;
    }

    public void updateLifePlayer1(float lifePlayer1)
    {
        LifePlayer1.value = lifePlayer1;
    }

    public void updateIntensityPlayer2(float newIntensityPlayer2, string typeWave)
    {
        switch (typeWave)
        {
            case "WaveR":
                IntensityfillPlayer2.sprite = IntensitiesFill[0];
                break;
            case "WaveG":
                IntensityfillPlayer2.sprite = IntensitiesFill[1];
                break;
            case "WaveB":
                IntensityfillPlayer2.sprite = IntensitiesFill[2];
                break;
        }
        IntensityPlayer2.value = newIntensityPlayer2;
    }

    public void updateIntensityPlayer1(float newIntensityPlayer1, string typeWave)
    {
   switch (typeWave)
        {
            case "WaveR":
                IntensityfillPlayer1.sprite = IntensitiesFill[0]; 
                break;
            case "WaveG":
                IntensityfillPlayer1.sprite = IntensitiesFill[1];
                break;
            case "WaveB":
                IntensityfillPlayer1.sprite = IntensitiesFill[2];
                break;
        }
        IntensityPlayer1.value = newIntensityPlayer1;
    }

    public void updateCountdownStart(float f)
    {
        this.countDownStart.text = Mathf.RoundToInt(f).ToString();
    }

    public void desactiveTutorial()
    {
        this.tutorial.SetActive(false);
    }
}
