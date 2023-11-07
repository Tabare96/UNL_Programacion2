using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    [SerializeField]
    private PerfilJugador perfilJugador;
    public PerfilJugador PerfilJugador { get => perfilJugador; }


    //------------ Eventos del Jugador ------------//

    [SerializeField]
    private UnityEvent<int> OnLivesChanged;
    [SerializeField]
    private UnityEvent<string> OnTextChanged;

    private void Start()
    {
        OnLivesChanged.Invoke(perfilJugador.Vida);
        OnTextChanged.Invoke(GameManager.Instance.GetScore().ToString());
    }


    public void ModificarVida(int puntos)
    {
        perfilJugador.Vida += puntos;
        GameManager.Instance.AddScore(puntos * 100);
        OnTextChanged.Invoke(GameManager.Instance.GetScore().ToString());
        if (perfilJugador.Vida < 0) { perfilJugador.Vida = 0; }
        else if (perfilJugador.Vida > 10) { perfilJugador.Vida = 10; }

        OnLivesChanged.Invoke(perfilJugador.Vida);
        //Debug.Log("la vida del jugador es: " + perfilJugador.Vida);
    }


    private bool EstasVivo()
    {
        return perfilJugador.Vida > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // si el jugador choca con la lava, reinicia el nivel
        if (collision.gameObject.CompareTag("Lava"))
        {
            Debug.Log("Toco la lava");
            //SceneManager.LoadScene(SceneManager.GetActiveScene()."Nivel1");
            perfilJugador.Vida = 4;
            SceneManager.LoadScene("Nivel1");

        }
        if (collision.gameObject.CompareTag("Meta"))
        {
            Debug.Log("GANASTE");
        }
    }
}
