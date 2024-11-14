using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 12;
    public float timeToDestroy = 6;
    public float damage = 1f;
    public bool playerBullet = false;
    //private Vector3 direction;

    

    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Celula"))
        {
            Celula c = collision.gameObject.GetComponent<Celula>();
            //contar 2 balas
            c.TakeInsulin();
            //e.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    
}
