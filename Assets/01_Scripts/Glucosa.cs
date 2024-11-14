using UnityEngine;

public class Glucosa : MonoBehaviour
{
    public float speed = 6;
    public float life = 2f;
    public float timeToDestroy = 10;
    public float damage = 1f;
    public float attackRange = 4;

    private Transform targetCelulaLlena; // Objetivo célula llena
    private bool yaImpactada = false;

    void Start()
    {
        BuscarCelulaLlena();
    }

    void Update()
    {
        if (targetCelulaLlena != null && !yaImpactada)
        {
            Vector3 direccion = (targetCelulaLlena.position - transform.position).normalized;
            transform.position += direccion * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, targetCelulaLlena.position) < 0.1f)
            {
                ImpactarCelula();
            }
        }
        else
        {
            NormalMovenment();
        }
    }

    void NormalMovenment()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    void BuscarCelulaLlena()
    {
        GameObject[] celulasLlenas = GameObject.FindGameObjectsWithTag("CelulaLlena");
        float distanciaMinima = Mathf.Infinity;

        foreach (GameObject celula in celulasLlenas)
        {
            CelulaLlena celulaScript = celula.GetComponent<CelulaLlena>();
            if (!celulaScript.estaLlena) // Verifica si la célula no está llena
            {
                float distancia = Vector3.Distance(transform.position, celula.transform.position);
                if (distancia < distanciaMinima)
                {
                    distanciaMinima = distancia;
                    targetCelulaLlena = celula.transform;
                }
            }
        }
    }

    void ImpactarCelula()
    {
        CelulaLlena celulaScript = targetCelulaLlena.GetComponent<CelulaLlena>();
        celulaScript.RecibirImpacto(); // Informa a la célula del impacto

        // Marca la glucosa como impactada y destrúyela
        yaImpactada = true;
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Wall wall = collision.gameObject.GetComponent<Wall>();
            wall.ImpactGlucosa();
            Destroy(gameObject);
        }
    }
}
