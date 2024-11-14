using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Variables")]
    public float speed = 5f;
    public float timeBetweenShoots = 0.5f; // Tiempo m�nimo entre disparos en segundos
    public int maxAmmo = 15; // Capacidad m�xima de munici�n
    private int currentAmmo; // Munici�n actual
    private float lastShootTime = 0f; // Almacena el tiempo del �ltimo disparo

    [Header("Referencias")]
    private NewInputSystem inputSystem;
    public Transform firePoint;
    public GameObject bulletPrefab;

    void Awake()
    {
        inputSystem = new NewInputSystem();
        inputSystem.Player.Shoot.performed += ctx => AttemptShoot();
        inputSystem.Player.Charge.performed += ctx => Reload();

        currentAmmo = maxAmmo; // Inicializa con la munici�n m�xima
    }

    void AttemptShoot()
    {
        // Comprueba si ha pasado suficiente tiempo desde el �ltimo disparo y si hay munici�n
        if (Time.time >= lastShootTime + timeBetweenShoots && currentAmmo > 0)
        {
            Shoot();
            lastShootTime = Time.time; // Actualiza el tiempo del �ltimo disparo
            currentAmmo--; // Reduce la munici�n
            Debug.Log($"Disparos restantes: {currentAmmo}");
        }
        else if (currentAmmo <= 0)
        {
            Debug.Log("Sin munici�n. Presiona 'Cargar' para recargar.");
        }
    }

    void Reload()
    {
        // Restaura la munici�n al m�ximo
        currentAmmo = maxAmmo;
        Debug.Log("Recargado. Munici�n completa.");
    }

    void Shoot()
    {
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
        // Movimiento del jugador o cualquier otra l�gica adicional
    }
}
