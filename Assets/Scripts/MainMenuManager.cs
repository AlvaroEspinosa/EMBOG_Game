using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

    public GameObject credits;
    public GameObject playerSelection;
    public GameObject loadScreenScene;

    private bool activo = false;

    private Animator anim;

    void Start()
    {
        this.anim = this.loadScreenScene.GetComponent<Animator>();
    }

    void Update()
    {
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("closeLoadScene") && !this.activo)
        {
            this.activo = true;
            this.loadScene("juego");
        }
    }

    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void activeCredits()
    {
        this.credits.SetActive(true);
    }

    public void activePlayerSelection()
    {
        this.playerSelection.SetActive(true);
    }

    public void screenSceneLoader()
    {
        this.loadScreenScene.SetActive(true);
    }
}