using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveFade : MonoBehaviour
{
    private Animator        UIAnimacao;   

    void Start()
    {
    UIAnimacao = GetComponent<Animator>();  
    }

    // Update is called once per frame
    public void AtivarFade()
    {
       UIAnimacao.SetTrigger("ActiveFade" ); 
    }
}
