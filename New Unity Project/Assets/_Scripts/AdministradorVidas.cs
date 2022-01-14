using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorVidas : MonoBehaviour
{
    [HideInInspector]public List<GameObject> vidas;
    public GameObject bolaPrefab;
    private  Bola bolaScript;
    public GameObject MenuGameOver;
    // Start is called before the first frame update
    void Start()
    {
        Transform[] Hijos = GetComponentsInChildren<Transform>();
        foreach (Transform hijo in Hijos)
        {
            vidas.Add(hijo.gameObject);
        }
        
    }

    public void EliminarVida()
    {
        var objetoAEliminar = vidas[vidas.Count - 1];
        Destroy(objetoAEliminar);
        vidas.RemoveAt(vidas.Count-1);
        if (vidas.Count <= 0)
        {
            MenuGameOver.SetActive(true);
            return;
        }
        var bola = Instantiate(bolaPrefab) as GameObject;
        bolaScript = bola.GetComponent<Bola>();
        bolaScript.BolaDestruida.AddListener(this.EliminarVida);
        
        Debug.Log($"vidas restantes: {vidas.Count}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
