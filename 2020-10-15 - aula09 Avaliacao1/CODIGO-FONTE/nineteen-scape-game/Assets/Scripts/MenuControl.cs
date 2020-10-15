using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    private GameObject CanvasCreditsMenu;
    private GameObject CanvasStartMenu;

    public void CreditsButton()
    {
        CanvasCreditsMenu.SetActive(true);
        CanvasStartMenu.SetActive(false);
    }

    public void BackStartMenuStart()
    {
        CanvasCreditsMenu.SetActive(false);
        CanvasStartMenu.SetActive(true);
    }

    void Start()
    {
        CanvasCreditsMenu = GameObject.Find("CanvasCreditsMenu").gameObject;
        CanvasStartMenu = GameObject.Find("CanvasStartMenu").gameObject;

        this.BackStartMenuStart();
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }

    private void Load()
    {
            
    }

}
