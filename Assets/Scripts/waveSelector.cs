using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSelector : MonoBehaviour
{
    public Sprite[] redWaveArray1;
    public Sprite[] redWaveArray2;
    public Sprite[] redWaveArray3;
    public AudioClip[] redAudioArray1;
    public AudioClip[] redAudioArray2;
    public AudioClip[] redAudioArray3;

    public Sprite[] greenWaveArray1;
    public Sprite[] greenWaveArray2;
    public Sprite[] greenWaveArray3;
    public AudioClip[] greenAudioArray1;
    public AudioClip[] greenAudioArray2;
    public AudioClip[] greenAudioArray3;

    public Sprite[] blueWaveArray1;
    public Sprite[] blueWaveArray2;
    public Sprite[] blueWaveArray3;
    public AudioClip[] blueAudioArray1;
    public AudioClip[] blueAudioArray2;
    public AudioClip[] blueAudioArray3;

    public GameObject redKey;
    public GameObject greenKey;
    public GameObject blueKey;

    private RectTransform redKeyTransform;
    private RectTransform greenKeyTransform;
    private RectTransform blueKeyTransform;

    private float redOriginalPosition;
    private float greenOriginalPosition;
    private float blueOriginalPosition;

    private SpriteRenderer sr;
    private int counter = 0;
    private string lastWave = "";
    private bool keyUp = false;

    public AudioSource wave_sound;

    void Start()
    {
        this.sr = this.gameObject.GetComponent<SpriteRenderer>();
        this.wave_sound = this.gameObject.GetComponent<AudioSource>();
        this.sr.sprite = null;

        this.redKeyTransform = this.redKey.GetComponent<RectTransform>();
        this.greenKeyTransform = this.greenKey.GetComponent<RectTransform>();
        this.blueKeyTransform = this.blueKey.GetComponent<RectTransform>();

        this.redOriginalPosition = this.redKeyTransform.anchoredPosition.y;
        this.greenOriginalPosition = this.greenKeyTransform.anchoredPosition.y;
        this.blueOriginalPosition = this.blueKeyTransform.anchoredPosition.y;
    }

    public void changeSpriteGeneral(string color, float intensity)
    {
        if (this.lastWave != color)
        {
            this.counter = 0;
            //Debug.Log("Distinto " + this.lastWave + " y " + color + " y " + intensity);
        }

        else
        {
            this.counter++;

            if (this.counter > this.redWaveArray1.Length -1)  //Por ejemplo, vale cualquier longitud si todas son la misma.
                this.counter = 0;
                          

            if (color == "WaveR")
            {
                this.flipFlopKeys("red");
                this.changeSpriteRed(intensity);
            }

            else if (color == "WaveG")
            {
                this.flipFlopKeys("green");
                this.changeSpriteGreen(intensity);
            }

            else if (color == "WaveB")
              {
                this.flipFlopKeys("blue");
                this.changeSpriteBlue(intensity);
            }
        }

        this.lastWave = color;
        this.wave_sound.Play();
        //Debug.Log("Igual " + this.lastWave + " y " + color + " y " + intensity);
    }

    public void desactiveWave()
    {
        this.sr.sprite = null;
        this.wave_sound.Stop();
    }

    private void changeSpriteRed(float intensity)
    {
        if (intensity <= 0)
            this.desactiveWave();

        else if (intensity <= 3 && intensity > 0) {
            this.sr.sprite = this.redWaveArray1[this.counter];
            this.wave_sound.Stop();
            this.wave_sound.clip = this.redAudioArray1[Random.Range(0, this.redAudioArray1.Length-1)];
            this.wave_sound.Play();
        }

        else if (intensity <= 6  && intensity  > 3)
        {
            this.sr.sprite = this.redWaveArray2[this.counter];
            this.wave_sound.Stop();
            this.wave_sound.clip = this.redAudioArray2[Random.Range(0, this.redAudioArray2.Length - 1)];
            this.wave_sound.Play();
        }
        else if (intensity >6)
        {
            this.sr.sprite = this.redWaveArray3[this.counter];
            this.wave_sound.Stop();
            this.wave_sound.clip = this.redAudioArray3[Random.Range(0, this.redAudioArray3.Length - 1)];
            this.wave_sound.Play();
        }
    }

    private void changeSpriteGreen(float intensity)
    {
        if (intensity <= 0)
            this.desactiveWave();

        else if (intensity <= 3 && intensity > 0)
        {
            this.sr.sprite = this.greenWaveArray1[this.counter];
            this.wave_sound.Stop();
            this.wave_sound.clip = this.greenAudioArray1[Random.Range(0, this.greenAudioArray1.Length - 1)];
            this.wave_sound.Play();
        }

        else if (intensity <= 6 && intensity > 3)
        {
            this.sr.sprite = this.greenWaveArray2[this.counter];
            this.wave_sound.Stop();
            this.wave_sound.clip = this.greenAudioArray2[Random.Range(0, this.greenAudioArray2.Length - 1)];
            this.wave_sound.Play();
        }
        else if (intensity > 6)
        {
            this.sr.sprite = this.greenWaveArray3[this.counter];
            this.wave_sound.Stop();
            this.wave_sound.clip = this.greenAudioArray3[Random.Range(0, this.greenAudioArray3.Length - 1)];
            this.wave_sound.Play();
        }
    }

    private void changeSpriteBlue(float intensity)
    {
        if (intensity <= 0)
            this.desactiveWave();

        else if (intensity <= 3 && intensity > 0)
        {
            this.sr.sprite = this.blueWaveArray1[this.counter];
            this.wave_sound.Stop();
            this.wave_sound.clip = this.blueAudioArray1[Random.Range(0, this.blueAudioArray1.Length - 1)];
            this.wave_sound.Play();
        }

        else if (intensity <= 6 && intensity > 3)
        {
            this.sr.sprite = this.blueWaveArray2[this.counter];
            this.wave_sound.Stop();
            this.wave_sound.clip = this.blueAudioArray2[Random.Range(0, this.blueAudioArray2.Length - 1)];
            this.wave_sound.Play();
        }
        else if (intensity > 6)
        {
            this.sr.sprite = this.blueWaveArray3[this.counter];
            this.wave_sound.Stop();
            this.wave_sound.clip = this.blueAudioArray3[Random.Range(0, this.blueAudioArray3.Length - 1)];
            this.wave_sound.Play();
        }
    }

    private void flipFlopKeys(string color)
    {
        this.setOriginalPositions();

        if (color == "red")
        {
            this.redKeyTransform.anchoredPosition = new Vector2(this.redKeyTransform.anchoredPosition.x, this.redOriginalPosition+30);
        }

        else if (color == "green")
        {
            this.greenKeyTransform.anchoredPosition = new Vector2(this.greenKeyTransform.anchoredPosition.x, this.greenOriginalPosition+30);
        }

        else if (color == "blue")
        {
            this.blueKeyTransform.anchoredPosition = new Vector2(this.blueKeyTransform.anchoredPosition.x, this.blueOriginalPosition+30);
        }
    }

    private void setOriginalPositions()
    {
        this.redKeyTransform.anchoredPosition = new Vector2(this.redKeyTransform.anchoredPosition.x, this.redOriginalPosition);
        this.greenKeyTransform.anchoredPosition = new Vector2(this.greenKeyTransform.anchoredPosition.x, this.greenOriginalPosition);
        this.blueKeyTransform.anchoredPosition = new Vector2(this.blueKeyTransform.anchoredPosition.x, this.blueOriginalPosition);
    }
}