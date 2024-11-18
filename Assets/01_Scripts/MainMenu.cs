using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Awake()
    {
        inputSystem = new NewInputSystem();
        inputSystem.Player.Shoot.performed += ctx => PlayGame();
        inputSystem.Player.Charge.performed += ctx => QuitGame();


    }

    private NewInputSystem inputSystem;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
