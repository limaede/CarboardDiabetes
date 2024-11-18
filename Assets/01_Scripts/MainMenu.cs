using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private NewInputSystem inputSystem;
    void Awake()
    {
        inputSystem = new NewInputSystem();
        inputSystem.Player.Shoot.performed += ctx => PlayGame();
        inputSystem.Player.Charge.performed += ctx => QuitGame();
        inputSystem.Player.Extra.performed += ctx => ShowMenu();


    }

    
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
