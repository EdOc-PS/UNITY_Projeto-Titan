using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoFollow : MonoBehaviour
{

   [SerializeField]private float    raioV; 
   [SerializeField]private float    velocidade;
   
   public   LayerMask               playerLayer;
   private  SpriteRenderer          spriteRenderer;
   private  Animator                slimeAnim;
   private Transform                player;  
   public PatrolIA                  scrpit; 


   void Start(){
    slimeAnim = GetComponent<Animator>(); 
    spriteRenderer = GetComponent<SpriteRenderer>();
   }
   void Update(){
            Seguir();
    }

    private void OnDrawGizmos(){
        Gizmos.DrawWireSphere(this.transform.position, this.raioV);
    } 
    void Seguir(){   
            Collider2D colisor = Physics2D.OverlapCircle(transform.position, raioV, playerLayer);
              if (colisor != null){
                    scrpit.enabled =false;           
                    player = colisor.transform;
                    raioV = 10;
                    Vector3 direcao = player.position - transform.position;
                    transform.Translate(direcao.normalized * velocidade * Time.deltaTime, Space.World); 
                        slimeAnim.SetInteger("Movimento", 1);                   
                        if(direcao.x > 0){
                            spriteRenderer.flipX = false;
                        }else if(direcao.x < 0){
                            spriteRenderer.flipX = true;
                        }
                }else{
                    scrpit.enabled = true;
                    raioV = 4; 
                } 
    }     
}
