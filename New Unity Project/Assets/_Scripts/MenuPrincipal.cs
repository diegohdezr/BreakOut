using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject MenuOpciones;
    public GameObject MenuInicial;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void EnableOptions()
    {
        
        MenuInicial.SetActive(false);
        MenuOpciones.SetActive(true);
    }

    public void EnableMainMenu()
    {
        MenuOpciones.SetActive(false);
        MenuInicial.SetActive(true);
    }
}
