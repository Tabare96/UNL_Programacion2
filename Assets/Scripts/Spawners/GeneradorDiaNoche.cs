using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class GeneradorDiaNoche : MonoBehaviour
{
    [SerializeField] private Camera camara;
    [SerializeField] private Color nocheColor;
    //[SerializeField] private Light2D luz2D;

    [SerializeField][Range(4, 128)] private int duracionDia;
    [SerializeField][Range(4, 24)] private int dias;

    private Color diaColor;

    void Start()
    {
        diaColor = camara.backgroundColor;
        StartCoroutine(CambiarColor(duracionDia));
    }


    IEnumerator CambiarColor(float tiempo)
    {
        Color colorDestino = camara.backgroundColor == diaColor ? nocheColor : diaColor;
        //Color colorDestinoLuz = luz2D.colo != Color.white ? Color.white : nocheColor;
        float duracionCiclo = tiempo * 0.6f;
        float duracionCambio = tiempo * 0.4f;

        for (int i = 0; i < dias; i++)
        {
            yield return new WaitForSeconds(duracionCiclo);

            float tiempoTranscurrido = 0;

            while (tiempoTranscurrido < duracionCambio)
            {
                tiempoTranscurrido += Time.deltaTime;
                float t = tiempoTranscurrido / duracionCambio;

                float smothT = Mathf.SmoothStep(0f, 1f, t);
                
                camara.backgroundColor = Color.Lerp(camara.backgroundColor, colorDestino, smothT);
                //luz2D.color = Color.Lerp(luz2D.color, colorDestinoLuz, smothT);

                yield return null;
            }

            //colorDestinoLuz = luz2D.color != Color.white ? Color.white : nocheColor;
            colorDestino = camara.backgroundColor == diaColor ? nocheColor : diaColor;
        }
    }
}
