using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Transform  menuPausa;
    public Transform  desativarEspada;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }

    void Pause(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(menuPausa.gameObject.activeSelf){
                menuPausa.gameObject.SetActive(false);
                desativarEspada.gameObject.SetActive(true);
                Time.timeScale = 1;
            }else{
                menuPausa.gameObject.SetActive(true);
                desativarEspada.gameObject.SetActive(false);
                Time.timeScale = 0;
            }
        }
    }
    public void Resume(){
                menuPausa.gameObject.SetActive(false);
                desativarEspada.gameObject.SetActive(true);
                Time.timeScale = 1;
    }
    public void Exit(){
        Application.Quit();
    }
}
