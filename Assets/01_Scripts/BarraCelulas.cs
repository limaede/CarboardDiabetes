using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraCelulas : MonoBehaviour
{
    public Image celulas;
    public float celulasActuales;
    public float celulasMaxima;
    void Update()
    {
        celulas.fillAmount = celulasActuales/celulasMaxima;
    }
}
