using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Opciones", menuName = "Herramientas/Opciones", order = 1)]
public class Opciones : ObjetoPersistente
{
    public float velocidadBola = 50;
    public dificultad NivelDificultad = dificultad.facil;

    public enum dificultad
    {
        facil,
        medio,
        dificil
    }

    public void CambiarVelocidad(float nuevaVelocidad)
    {
        velocidadBola = nuevaVelocidad;
    }

    public void CambiarDificultad(int NuevaDificultad)
    {
        NivelDificultad = (dificultad) NuevaDificultad;
    }
}
