using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    }


    public void ModificarVida(int puntos)
    {
        perfilJugador.Vida += puntos;
        
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
        if (!collision.gameObject.CompareTag("Meta")) { return; }

        Debug.Log("GANASTE");
    }
}
