using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progresion : MonoBehaviour
{

    private Jugador jugador;

    private PerfilJugador perfilJugador;
    public PerfilJugador PerfilJugador { get => perfilJugador; }
    

    private void Awake()
    {
        jugador = GetComponent<Jugador>();
    }

    public void GanarExperiencia(int nuevaExperiencia)
    {
        perfilJugador.Experiencia += nuevaExperiencia;
        


        if (perfilJugador.Experiencia >= perfilJugador.Experiencia)
        {
            SubirNivel();
        }
    }

    private void SubirNivel()
    {
        perfilJugador.Experiencia -= perfilJugador.ExperienciaProximoNivel;
        perfilJugador.ExperienciaProximoNivel += perfilJugador.EscalarExperiencia;
    }
}
