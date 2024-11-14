using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Referencias")]
    public List<GameObject> Prefabs;
    public Transform leftupPoint;
    public Transform rightdownPoint;

    [Header("Estadisticas")]
    public float timeBtwSpawn = 1.5f;
    public int totalKilledEnemies = 0;
    public int currentKilledEnemies = 0;
    public int maxKilledEnemies = 10;
    public int enemiesToAdd = 5;
    public int enemiesToSpawn = 1;
    public int appearFinalBoss = 2;
    public float speedIncreaseFactor = 0.9f; // Factor de aumento de velocidad (reducido en un 10%)
    //public float speedIncreasePerInterval = 2.0f; // Incremento de velocidad para las células

    private float timer = 0f;

    private Vector3 leftupPosition;
    private Vector3 rightdownPosition;

    void Start()
    {
        leftupPosition = leftupPoint.position;
        rightdownPosition = rightdownPoint.position;

        Debug.Log($"Posiciones iniciales - leftupPosition.y = {leftupPosition.y}, rightdownPosition.y = {rightdownPosition.y}");
    }

    void Update()
    {
        if (timer < timeBtwSpawn)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                float x = Random.Range(leftupPoint.position.x, rightdownPoint.position.x);
                float y = Random.Range(rightdownPoint.position.y, leftupPoint.position.y);

                int prefab = Random.Range(0, Prefabs.Count);

                Instantiate(Prefabs[prefab], new Vector3(x, y, transform.position.z), Quaternion.Euler(0, 0, 180));
                Debug.Log($"Instanciado enemigo en: x = {x}, y = {y}");
            }
        }
    }

    public void AddKilledEnemies()
    {
        totalKilledEnemies++;
        currentKilledEnemies++;

        if (currentKilledEnemies % 20 == 0) // Cada 20 células impactadas
        {
            timeBtwSpawn *= speedIncreaseFactor; // Reduce el intervalo de spawn
            Debug.Log($"Velocidad de spawn incrementada, nuevo intervalo: {timeBtwSpawn}");
        }

        if (currentKilledEnemies >= maxKilledEnemies)
        {
            currentKilledEnemies = 0;
            maxKilledEnemies += enemiesToAdd;
            enemiesToSpawn++;
        }
    }
}
