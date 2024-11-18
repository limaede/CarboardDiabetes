using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mensaje : MonoBehaviour
{
    public string textValue1a= "Dispara insulina con el boton cuadrado a las celulas para que estas hagan ingresar glucosa,";
    public string textValue1b= "no olvides recargar tu insulina con O. Si quieres ir al menu ve con X";
    public Text textElement1;
    public List<string> mensajesDiabetes = new List<string>
    {
        "La diabetes tipo 2 se puede prevenir con hábitos saludables.",
        "Controlar la glucosa es clave para prevenir complicaciones.",
        "El ejercicio regular ayuda a reducir los niveles de azúcar.",
        "Mantén una dieta balanceada rica en vegetales y frutas.",
        "Consulta regularmente a tu médico para controlar tu salud.",
        "Evita los alimentos procesados y ricos en azúcares añadidos.",
        "La insulina es vital para muchas personas con diabetes.",
        "Beber agua en lugar de refrescos ayuda a controlar el peso.",
        "Revisar tus niveles de azúcar frecuentemente es esencial.",
        "El estrés puede aumentar los niveles de glucosa en la sangre.",
        "La actividad física mejora la sensibilidad a la insulina.",
        "Dormir lo suficiente contribuye al control de la diabetes.",
        "El monitoreo constante es clave para una vida saludable.",
        "Reducir el consumo de sal ayuda a evitar hipertensión.",
        "Infórmate sobre los alimentos con bajo índice glucémico.",
        "Controlar el peso reduce el riesgo de complicaciones.",
        "Evita fumar, ya que incrementa el riesgo de problemas cardíacos.",
        "Conocer los síntomas de hipoglucemia puede salvar vidas.",
        "Aprender a contar carbohidratos es útil para el manejo diario.",
        "Una vida activa y saludable es posible con diabetes."
    };

    public Text textElement2;

    public float tiempoMensajeInicial = 15f; // Duración del primer mensaje
    public float tiempoMensajeSecundario = 5f; // Tiempo que cada mensaje se muestra
    public float tiempoEsperaEntreMensajes = 3f; // Tiempo entre mensajes

    void Start()
    {
        StartCoroutine(MostrarTextosIniciales());

        // Comienza la secuencia de mensajes
        StartCoroutine(MostrarMensajes());
    }

    IEnumerator MostrarTextosIniciales()
    {
        textElement1.text = textValue1a; // Mostrar la primera parte
        yield return new WaitForSeconds(5f); // Esperar 3 segundos
        textElement1.text = textValue1b; // Mostrar la segunda parte
        yield return new WaitForSeconds(5f); // Esperar otros 3 segundos
        textElement1.text = ""; // Vaciar el texto
    }

    IEnumerator MostrarMensajes()
    {
        // Mostrar el primer mensaje por unos segundos
        yield return new WaitForSeconds(tiempoMensajeInicial);
        textElement1.text = ""; // Ocultar el primer mensaje

        // Mostrar los mensajes de la lista uno por uno
        while (true)
        {
            foreach (string mensaje in mensajesDiabetes)
            {
                textElement2.text = mensaje; // Mostrar el mensaje actual
                yield return new WaitForSeconds(tiempoMensajeSecundario); // Esperar unos segundos
                textElement2.text = ""; // Vaciar el mensaje
                yield return new WaitForSeconds(tiempoEsperaEntreMensajes); // Esperar antes de mostrar el siguiente
            }
        }
    }
}
