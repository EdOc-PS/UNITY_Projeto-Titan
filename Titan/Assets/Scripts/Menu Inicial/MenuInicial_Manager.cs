using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial_Manager : MonoBehaviour
{
    [SerializeField]
    private string          Scene;


    public void Iniciar(){
        SceneManager.LoadScene(Scene);
    }
    public void Sair()
    {
        Application.Quit();
    }
}
