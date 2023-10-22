using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] float velocidad = 5f;
    [SerializeField] int puntosDeDanio = 1;
    void Update()
    {
        transform.position += Vector3.left * velocidad * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Jugador jugador = collision.gameObject.GetComponent<Jugador>();
        if (jugador != null)
        {
            jugador.ModificarVida(-puntosDeDanio);
            Debug.Log(" PUNTOS DE DAÑO REALIZADOS AL JUGADOR " + puntosDeDanio);
        }

        Destroy(gameObject);
    }
}
