using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Variables")]
    public float speed = 5f;
    public float timeBetweenShoots = 0.5f; // Tiempo mínimo entre disparos en segundos
    public int maxAmmo = 15; // Capacidad máxima de munición
    private int currentAmmo; // Munición actual
    private float lastShootTime = 0f; // Almacena el tiempo del último disparo

    [Header("Referencias")]
    private NewInputSystem inputSystem;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource audioShoot;
    public AudioSource audioLoad;

    [Header("UI")]
    public Text cantInsu;
    public Text TotalcantInsu;

    void Awake()
    {
        cantInsu.text = maxAmmo.ToString();
        inputSystem = new NewInputSystem();
        inputSystem.Player.Shoot.performed += ctx => AttemptShoot();
        inputSystem.Player.Charge.performed += ctx => Reload();

        currentAmmo = maxAmmo; // Inicializa con la munición máxima

        TotalcantInsu.text = currentAmmo.ToString();
    }
    

    void AttemptShoot()
    {
        // Comprueba si ha pasado suficiente tiempo desde el último disparo y si hay munición
        if (Time.time >= lastShootTime + timeBetweenShoots && currentAmmo > 0)
        {
            Shoot();
            lastShootTime = Time.time; // Actualiza el tiempo del último disparo
            currentAmmo--; // Reduce la munición

            TotalcantInsu.text = currentAmmo.ToString();
            Debug.Log($"Disparos restantes: {currentAmmo}");
        }
        else if (currentAmmo <= 0)
        {
            Debug.Log("Sin munición. Presiona 'Cargar' para recargar.");
        }
    }

    void Reload()
    {
        // Restaura la munición al máximo
        audioShoot.Play();
        currentAmmo = maxAmmo;

        TotalcantInsu.text = currentAmmo.ToString();
        Debug.Log("Recargado. Munición completa.");
    }

    void Shoot()
    {
        audioShoot.Play();
        Instantiate(bulletPrefab, firePoint.position, transform.rotation);
    }

    void OnEnable()
    {
        inputSystem.Enable();
    }

    void OnDisable()
    {
        inputSystem.Disable();
    }

    void Update()
    {
        // Movimiento del jugador o cualquier otra lógica adicional
    }
}
