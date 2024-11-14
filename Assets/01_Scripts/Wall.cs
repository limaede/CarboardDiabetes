using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    float celula;
    float glucosa;
    float insulina;
    float llenacelula;
    public int maxCelulasNoLlenas = 40;  // L�mite de c�lulas no llenas para Game Over

    // Start is called before the first frame update
    void Start()
    {
        celula = 0; glucosa=0; insulina=0; llenacelula = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Comprobamos si el contador de c�lulas no llenas alcanz� el l�mite
        if (celula >= maxCelulasNoLlenas)
        {
            GameOver();
        }
    }

    public void ImpactCelula()
    {
        celula++;
    }
    public void ImpactGlucosa()
    {
        glucosa++;
    }
    public void ImpactInsulina()
    {
        insulina++;
    }
    public void ImpactLlenaCelula()
    {
        llenacelula++;
    }
    void GameOver()
    {
        Debug.Log("Game Over! Demasiadas c�lulas no llenas han pasado.");

        // Cerrar el juego
        Application.Quit();

        // Opcionalmente, puedes detener el juego en el editor si est�s probando en Unity:
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
