using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Bounce_Coin : MonoBehaviour
{

    [Header("Valores para o Bounce Effect")]
    
    [SerializeField]
    private float        bAltura;
    [SerializeField]
    private float        bVelocidade;
    Vector3             originalPosicao;


    void Start() {
        Bounce();
    }

    void Bounce(){
        originalPosicao = transform.position;
        
        Vector3 bounceTarget = originalPosicao + new Vector3(0f, bAltura, 0f);

        transform.DOMove(bounceTarget, bVelocidade).SetEase(Ease.OutQuad).SetLoops(-1, LoopType.Yoyo);
      
     
    
    }
    
}
