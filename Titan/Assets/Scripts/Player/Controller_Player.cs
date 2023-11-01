using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    
    // Start is called before the first frame update
    private Rigidbody2D     PlayerRigidibody2D;
    private Vector2         PlayerDirecao;
    private Animator        PlayerAnimacao;   
    public  float           PlayerVelocidade;

    //Dash
    public  float           PlayerDash;
    public  float           RecargaDash;
            float           PlayerVelocidadeAtual;
            bool            inDash; 
    //Dash-desativar ataque        
   private  bool             isClickMouse = true;


    //Ataque-Movimentos
    private Vector3        targetPosition;
    private float          DirecaoMovida;
    private bool           isAtaque = false;
   
    //Controle das particulas
    public ParticleSystem trail;

    void Start()
    {
        PlayerRigidibody2D = GetComponent<Rigidbody2D>();
        PlayerAnimacao = GetComponent<Animator>();  
        PlayerVelocidadeAtual = PlayerVelocidade; 
    }

    // Update is called once per frame
    void Update()
    {
        
        // Movimentação do Player
        if(PlayerVelocidadeAtual == PlayerVelocidade){
            PlayerDirecao = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); 
            PlayerDirecao = PlayerDirecao.normalized;     
        }
        //Dash para o player 
        Dash(); 
        Dust();
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

        //Ataque
         OnAtaque();
         if(isAtaque){
            if(targetPosition.x > transform.position.x){
                PlayerAnimacao.SetInteger("Ataque", 1);
                PlayerAnimacao.SetInteger("Movimento", 3); 
                PlayerAnimacao.SetInteger("Parado", 1); 
            }else if(targetPosition.x < transform.position.x){
                PlayerAnimacao.SetInteger("Ataque", -1);
                PlayerAnimacao.SetInteger("Movimento", 3); 
                PlayerAnimacao.SetInteger("Parado", -1); 
            }
         }

    }

        void FixedUpdate()
        {
            PlayerRigidibody2D.MovePosition(PlayerRigidibody2D.position + PlayerDirecao 
            *  PlayerVelocidadeAtual * Time.fixedDeltaTime);           
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
                
        //Dash do Player
        void Dash(){
            if(Input.GetKeyDown(KeyCode.Space) && PlayerDirecao != Vector2.zero && inDash == false){   
                isClickMouse = !isClickMouse;
                PlayerAnimacao.SetTrigger("Dash");
                inDash = true;
                PlayerVelocidadeAtual = PlayerDash;
                DirecaoMovida = .0f;
                Invoke("PosDash", .76f);
            }
        }
    // Volta da velocidade padrão apos o Dash do player contendo um tempo de recarga        
        void PosDash(){
            isClickMouse = !isClickMouse;
            PlayerVelocidadeAtual = PlayerVelocidade;
            DirecaoMovida = .0f;
            Invoke("FimDash", RecargaDash); 
            PlayerAnimacao.SetTrigger("Dash"); 
        }
        void FimDash(){
            inDash = false;
        }
        void OnAtaque(){            
            if(isClickMouse){             
                if(Input.GetKeyDown(KeyCode.Mouse0)){  
                    isAtaque = true;
                    DirecaoMovida = .0f;
                    // Seta a velocidade do player para zero para ele não mover
                    PlayerVelocidadeAtual = 0;
                    // Obtém a posição do clique do mouse na tela
                    targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    targetPosition.z = 0f;
                    Vector3 PlayerDirecao = (targetPosition - transform.position).normalized;
                    transform.position += PlayerDirecao * DirecaoMovida;   
                    Invoke("soltar", 0.4f);
                 
                    }
            }
        }
        void soltar() {
            PlayerVelocidadeAtual = PlayerVelocidade;
            isAtaque = false;
            DirecaoMovida = .0f;
        }
        void Dust(){
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)){
                trail.Play();
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D)){
                trail.Stop();
            }
        }
    //outro metodo
    /*if(Input.GetKeyUp(KeyCode.Mouse0)) {
                    //ao soltar a tecla o player volta a ter a veocidade
                    PlayerVelocidadeAtual = PlayerVelocidade;
        }*/
      
}