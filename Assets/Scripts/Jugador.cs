using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float vida = 5000f;

    public void ModificarVida(float puntos)
    {
        vida += puntos;
        Debug.Log(EstasVivo());
    }


    private bool EstasVivo()
    {
        return vida > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Meta")) { return; }

        Debug.Log("GANASTE");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            if (vida <= 0)
            {
                ReiniciarNivel();
            }
        }

        else if (collision.gameObject.CompareTag("Lava"))
        {
            Debug.Log("Tocaste la Lava");
            ReiniciarNivel();
        }
    }


    private void ReiniciarNivel()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}