using UnityEngine;

public class CelulaLlena : MonoBehaviour
{
    public float speed = 6;
    private int impactosRecibidos = 0; // Contador de impactos
    public bool estaLlena = false; // Indica si la célula está llena

    void Start()
    {
    }

    void Update()
    {
        NormalMovenment();
    }

    void NormalMovenment()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void RecibirImpacto()
    {
        if (!estaLlena) // Solo recibir impacto si no está llena
        {
            impactosRecibidos++;
            if (impactosRecibidos >= 2)
            {
                estaLlena = true;
                // Aquí puedes agregar alguna lógica visual para indicar que la célula está llena
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Wall w = collision.gameObject.GetComponent<Wall>();
            w.ImpactLlenaCelula();
            Destroy(gameObject);
        }
    }
}
