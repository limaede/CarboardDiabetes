using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Necesario para trabajar con los botones


public class GazeInterractor : MonoBehaviour
{
    public float gazeTime = 2f; // Tiempo que el jugador debe mirar
    private float gazeTimer = 0f;
    private GameObject currentObject;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward); // Rayo desde la cámara
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Objeto detectado: " + hit.collider.gameObject.name);

            if (hit.collider.gameObject != currentObject)
            {
                currentObject = hit.collider.gameObject;
                gazeTimer = 0f; // Reinicia el temporizador
            }

            gazeTimer += Time.deltaTime;

            if (gazeTimer >= gazeTime)
            {
                Debug.Log("Interactuando con: " + currentObject.name);

                // Cambiar de escena si el objeto se llama "Iniciar"
                if (currentObject.name == "btnIniciar")
                {
                    Debug.Log("Cambiando a la escena...");
                    SceneManager.LoadScene("jhael"); // Cambia "Game" por el nombre de tu escena
                }

                // Verificar si el objeto tiene un componente Button y un OnClick asociado
                Button button = currentObject.GetComponent<Button>();
                if (button != null)
                {
                    Debug.Log("Botón detectado: " + currentObject.name);

                    // Si el botón tiene un OnClick, ejecutarlo
                    button.onClick.Invoke();
                }

                gazeTimer = 0f; // Resetea el temporizador para evitar múltiples activaciones
            }
        }
        else
        {
            Debug.Log("No se detectó ningún objeto.");
            currentObject = null;
            gazeTimer = 0f;
        }
    }
}