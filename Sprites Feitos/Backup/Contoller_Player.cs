using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contoller_Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D     PlayerRigidibody2D;
    private Vector2         PlayerDirecao;
    private Animator        PlayerAnimacao;   
    public float            PlayerVelocidade;
   
    void Start()
    {
        PlayerRigidibody2D = GetComponent<Rigidbody2D>();
        PlayerAnimacao = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        // Movimentação do Player
        PlayerDirecao = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));  
        PlayerDirecao = PlayerDirecao.normalized;

        // Animações das direções de movimentação (Conferir no Animator) 
        // Direção X - Direita e Esquerda
        if(PlayerDirecao.x > 0){
             DirecaoDireita();        
        }
        else if(PlayerDirecao.x < 0){
             DirecaoEsquerda();           
        }
        else{
            PlayerAnimacao.SetInteger("Movimento", 0); 
        }
        //Direção Y - Cima e Baixo
         if(PlayerDirecao.y > 0){
            //Verificar a direção - Cima e Direita
            if(PlayerDirecao.x > 0){
                DirecaoDireita();  
            }
            //Cima e Esquerda
            else if(PlayerDirecao.x < 0){
                DirecaoEsquerda();
            }
            //Cima
            else{
                PlayerAnimacao.SetInteger("Movimento", 2);
                PlayerAnimacao.SetInteger("Parado", 2); 
            }
        }

        else if(PlayerDirecao.y < 0){
            //Verificar a direção - Baixo e Direita
            if(PlayerDirecao.x > 0){
                DirecaoDireita();
            }
            //Baixo e Esquerda
            else if(PlayerDirecao.x < 0){
               DirecaoEsquerda();
            }
            //Baixo
            else{
                PlayerAnimacao.SetInteger("Movimento", -2);
                PlayerAnimacao.SetInteger("Parado", -2);
            }
        }
    }
    void FixedUpdate()
    {
        PlayerRigidibody2D.MovePosition(PlayerRigidibody2D.position + PlayerDirecao * PlayerVelocidade * Time.fixedDeltaTime);    
    }

    // Direção X - Direita e Esquerda - (Função para ser chamada)
    void DirecaoDireita(){
            if(PlayerDirecao.sqrMagnitude > 0){
                PlayerAnimacao.SetInteger("Movimento", 1);
                PlayerAnimacao.SetInteger("Parado", 1);             
            }}
    void DirecaoEsquerda(){
      if(PlayerDirecao.sqrMagnitude > 0){
                PlayerAnimacao.SetInteger("Movimento", -1);
                PlayerAnimacao.SetInteger("Parado", -1);
            }}
}
