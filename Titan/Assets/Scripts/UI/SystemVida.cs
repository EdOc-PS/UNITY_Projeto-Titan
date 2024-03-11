using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class SystemVida : MonoBehaviour
{
    
    [Header("Health Settings")]
    public Sprite           coracaoCheio;
    public Sprite           coracaoEmpty;
    public Transform        ativarColuna2;
    public int              vida; //vida do player
    public int              vidamax; // qtde de corações na UI

    [Header("Health Quantidade")]
    public  Image[]         vidas;

    [Header("Invunerabilidade")]
    public SpriteRenderer   playerSprite;

    [Header("Morte")]
    public  Transform          desativarEspada;
    public  Transform          desativarUI;
    public  Transform          MenuDeathUI;
    private Animator           playerAnimacao; 
    private Controller_Player  controleP;
    private Collider2D         coll2D;
    //Zoom Morte
    public CinemachineVirtualCamera virtualCamera;
    private float newLensOrthoSize = 3f;

    //Fade Morte
    private ActiveFade activeFade;
   
   
    void Start(){
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnimacao = GetComponent<Animator>();
        controleP = GetComponent<Controller_Player>();
        coll2D = GetComponent<Collider2D>();
        activeFade = FindAnyObjectByType<ActiveFade>(); 
    }

    // Update is called once per frame
    void Update(){
        QuantVida();
        DeathPlayer();
    }

    void QuantVida(){
        if(vida > vidamax){
            vida = vidamax;
        }
        if(vidamax > 5){
            ativarColuna2.gameObject.SetActive(true);
        }else{
            ativarColuna2.gameObject.SetActive(false);
        }
        for(int i = 0; i < vidas.Length; i++){
            if(i < vida){
                vidas[i].sprite = coracaoCheio;
            }else{
                vidas[i].sprite = coracaoEmpty;
            }
            if(i < vidamax){
                vidas[i].enabled = true;
            }else{
                vidas[i].enabled = false;
            }
        }
    }
    public void GanhaVida(){
        vida++;
    }
    
    //Dano ao jogador
    public IEnumerator DanoPlayer(){
        if( vida >= 1 ){
            for (int i = 0; i < 5; i++){
                playerSprite.color = new Color(1f, .75f, .7f, .65f);
                yield return new WaitForSeconds(0.16f);
                playerSprite.color = new Color(1f, 1f, 1f, 1f);
                yield return new WaitForSeconds(0.16f);
            }
        }
    }  

    //Morte do jogador
    private void DeathPlayer(){
        if(vida <= 0){
            InDeath();      
        }
    }
    private void InDeath(){
        playerAnimacao.SetBool("isDead", true); 
        desativarEspada.gameObject.SetActive(false);
        controleP.enabled = false;
        coll2D.enabled = false;
        desativarUI.gameObject.SetActive(false);
        ZoomCameraDeath();
        StartCoroutine(ControlObjectsInDeath());
   
    }

    private void ZoomCameraDeath(){
         virtualCamera.m_Lens.OrthographicSize = newLensOrthoSize;
    }
    private IEnumerator ControlObjectsInDeath(){
         Time.timeScale = 0.3f;
         yield return new WaitForSeconds(.4f);
         Time.timeScale = 1f;  
         yield return new WaitForSeconds(.6f);
         activeFade.AtivarFade();
         yield return new WaitForSeconds(1f);
         MenuDeathUI.gameObject.SetActive(true);   
    }
    
}
