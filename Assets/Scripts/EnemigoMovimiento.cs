//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemigoMovimiento : MonoBehaviour
//{

//    // Variables a configurar desde el editor
//    [Header("Configuracion")]
//    [SerializeField] float distanciaRecorrida = 5f;

//    public float velocidad = 2.0f;       // Velocidad del enemigo
//    //public float distanciaRecorrida = 5.0f; // Distancia después de la cual cambiará dirección

//    private bool haciaDerecha = true;
//    private float distanciaRecorridaActual = 0.0f;
//    private Vector3 startPosition;

//    private void Start()
//    {
//        startPosition = transform.position;
//    }

//    private void Update()
//    {
//        float movement = velocidad * Time.deltaTime;

//        if (haciaDerecha)
//        {
//            transform.Translate(Vector2.right * movement);
//            distanciaRecorridaActual += movement;
//            transform.localScale = new Vector3(1, 1, 1); // Voltear sprite a la derecha
//        }
//        else
//        {
//            transform.Translate(Vector2.left * movement);
//            distanciaRecorridaActual -= movement;
//            transform.localScale = new Vector3(-1, 1, 1); // Voltear sprite a la izquierda
//        }

//        if (Mathf.Abs(distanciaRecorridaActual) >= distanciaRecorrida)
//        {
//            CambiarDireccion();
//        }
//    }

//    private void CambiarDireccion()
//    {
//        haciaDerecha = !haciaDerecha;
//        distanciaRecorridaActual = 0.0f;
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovimiento : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] float distanciaRecorrida = 5f;
    [SerializeField] bool moverEnHorizontal = true; // Agrega esta variable para elegir la dirección

    public float velocidad = 2.0f;
    private bool haciaDerecha = true;
    private float distanciaRecorridaActual = 0.0f;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float movement = velocidad * Time.deltaTime;

        if (moverEnHorizontal)
        {
            if (haciaDerecha)
            {
                transform.Translate(Vector2.right * movement);
                distanciaRecorridaActual += movement;
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.Translate(Vector2.left * movement);
                distanciaRecorridaActual -= movement;
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            if (haciaDerecha)
            {
                transform.Translate(Vector2.up * movement);
                distanciaRecorridaActual += movement;
            }
            else
            {
                transform.Translate(Vector2.down * movement);
                distanciaRecorridaActual -= movement;
            }
        }

        if (Mathf.Abs(distanciaRecorridaActual) >= distanciaRecorrida)
        {
            CambiarDireccion();
        }
    }

    private void CambiarDireccion()
    {
        haciaDerecha = !haciaDerecha;
        distanciaRecorridaActual = 0.0f;
    }
}

