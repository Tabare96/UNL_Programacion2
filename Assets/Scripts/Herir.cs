using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herir : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] int puntos = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();
            jugador.ModificarVida(-puntos);
            Debug.Log(" PUNTOS DE DAÑO REALIZADOS AL JUGADOR " + puntos);
            if (this.gameObject.CompareTag("Bala"))
            {
                gameObject.SetActive(false);
                Debug.Log("choco una bala");
            }
        }
        else if (collision.gameObject.CompareTag("Pared"))
        {
            gameObject.SetActive(false);
        }
    }
}