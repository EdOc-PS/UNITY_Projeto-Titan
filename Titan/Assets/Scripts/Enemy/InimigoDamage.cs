using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoDamage : MonoBehaviour
{
    [Header ("Sistema de Dano")]
    public  SystemVida      vidas;
    [SerializeField]
    private int             quantidadeDano;
   

    
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            for(int i = 0; i < quantidadeDano; i++){
            vidas.vida--;
            }
            StartCoroutine(vidas.DanoPlayer()); 
        }
    }
    
}
