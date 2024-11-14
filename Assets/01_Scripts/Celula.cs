using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celula : MonoBehaviour
{
    public float speed = 6;
    public float insulina = 0;

    private Spawner spawner;

    public GameObject celulaAbierta;

    void Start()
    {
        // Encuentra el objeto Spawner en la escena
        spawner = FindObjectOfType<Spawner>();
    }

    void Update()
    {
        NormalMovenment();
    }

    void NormalMovenment()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    public void TakeInsulin()
    {
        if (insulina < 2)
        {
            insulina++;
        }
        else
        {
            Instantiate(celulaAbierta, transform.position, transform.rotation);
            spawner.AddKilledEnemies(); // Notifica al Spawner que se ha impactado una célula
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Wall w = collision.gameObject.GetComponent<Wall>();
            w.ImpactCelula();
            Destroy(gameObject);
        }
    }
}
