using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insulina : MonoBehaviour
{
    public float speed = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NormalMovenment();
    }
    void NormalMovenment()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Wall w = collision.gameObject.GetComponent<Wall>();
            w.ImpactInsulina();

            Destroy(gameObject);
        }
    }
}
