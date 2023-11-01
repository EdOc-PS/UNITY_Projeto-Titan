//using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Espada : MonoBehaviour
{   
    //Slash da espada
    [SerializeField]private GameObject  Slash_Prefab;
    [SerializeField]private Transform   SlashSpawn;
    private                 GameObject  SlashEspada;

    //Animações da espada
    private PlayerControls      controle;
    private Animator            PlayerAnimacao;  
    private Controller_Espada   ControllerEspada;
    private Controller_Player   ControllerPlayer;

    //Invisibilidade da espada 
    private bool isVisivel = false;
    private SpriteRenderer RendererEspada;

    //Cooldown
    private float AtaqueCooldown = 0; 
    private float UltimoAtaqueTime; // O momento em que o último ataque ocorreu
    private bool isClickMouse = true;

    //Collider
    private PolygonCollider2D Pcollider2D;

    private void Awake(){
          controle = new  PlayerControls();          
    }
    void Start(){ 
          
            RendererEspada = GetComponent<SpriteRenderer>();
            PlayerAnimacao = GetComponent<Animator>(); 
            Pcollider2D = GetComponent<PolygonCollider2D>();
            controle.Combate.Ataque.started += _ => Attack();
            //certifica a invisibilidade da espada
             if (RendererEspada != null){
                RendererEspada.enabled = isVisivel;
                Pcollider2D.enabled = false; 
            }   
           
    }
    void Update(){
        OnAtaque();
        AtaqueDash();
    }
    private void OnEnable(){
        controle.Enable();
    }  
    
    private void Attack(){
        if (isClickMouse){
            if(Input.GetKeyDown(KeyCode.Mouse0) && Time.time -UltimoAtaqueTime >= AtaqueCooldown){
                PlayerAnimacao.SetTrigger("Ataque");
                SlashEspada = Instantiate(Slash_Prefab, SlashSpawn.position, Quaternion.identity);
                SlashEspada.transform.parent = this.transform.parent;
                }
            }
    }
    void OnAtaque(){
         if (isClickMouse){
            if(Input.GetKeyDown(KeyCode.Mouse0) && Time.time -UltimoAtaqueTime >= AtaqueCooldown){
                AtaqueCooldown = .5f;
                TornarVisivel();
                Invoke("TornarInvisivel", 0.26f);
                UltimoAtaqueTime = Time.time; 
            }   
         } 
    }
    //Não poder atacar enquanto "dasha"
    void AtaqueDash(){
        if(Input.GetKeyDown(KeyCode.Space)){
            isClickMouse = !isClickMouse;
            Invoke("AtaqueDashEnable", .75f);
        }
    }
    void AtaqueDashEnable(){
        isClickMouse = !isClickMouse;
    }

    private void TornarVisivel()
    {
        isVisivel = !isVisivel;
        if (RendererEspada != null)
        {
            RendererEspada.enabled = isVisivel;
            Pcollider2D.enabled = true;
        }
    }
    void TornarInvisivel(){
        isVisivel = !isVisivel;
        if (RendererEspada != null)
        {
            RendererEspada.enabled = false;
            Pcollider2D.enabled = false;
        }
    }
}   