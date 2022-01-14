using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// este script mantendra un objeto dentro de los limites de la pantalla
/// siempre que se utilice una camara ortografica con cordenadas 0,0,0
/// </summary>
public class ControlBordes : MonoBehaviour
{
    [Header("Configurar en el Inspector")] 
    public float radio = -1f;
    public bool mantenerEnPantalla = true;

    [Header("Configuraciones Dinamicas")] 
    public bool estaEnPantalla = true;
    public float anchoCamara;
    public float altoCamara;

    public bool offDerecha, offIzquierda, offArriba, offAbajo;

    private void Awake()
    {
        altoCamara = Camera.main.orthographicSize;
        anchoCamara = Camera.main.aspect * altoCamara;
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        estaEnPantalla = true;
        offDerecha = offIzquierda = offArriba = offAbajo = false;
        if (pos.x > anchoCamara - radio)
        {
            pos.x = anchoCamara - radio;
            offDerecha = true;
        }
        if (pos.x < -anchoCamara + radio)
        {
            pos.x = -anchoCamara + radio;
            offIzquierda = true;
        }
        if (pos.y > altoCamara - radio)
        {
            pos.y = altoCamara - radio;
            offArriba = true;
        }
        if (pos.y < -altoCamara + radio)
        {
            pos.y = -altoCamara + radio;
            offAbajo = true;
        }

        estaEnPantalla = !(offAbajo || offIzquierda || offDerecha || offArriba);
        if (mantenerEnPantalla && !estaEnPantalla)
        {
            transform.position = pos;
            estaEnPantalla = true;
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 tamanoBorde = new Vector3(anchoCamara * 2, altoCamara * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, tamanoBorde);
    }
}
