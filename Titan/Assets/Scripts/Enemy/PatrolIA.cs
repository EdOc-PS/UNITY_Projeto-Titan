using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolIA : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator        SlimeAnim;
    public Collider2D       AreaPatrol; 
    public float            InimigoVelocidade;
    public float            minTempo;
    public float            maxTempo; 

    private Vector3         moveDirecao;
    private Vector3         randomDestino; 
    private bool            isMoving = false; 
    private bool            isWaiting = false;

    //Knockback
    private bool isKnockedBack = false;
    private Vector3 knockbackDirecao;
    public float knockbackForca = 5f;
    public float knockbackDuracao = 0.5f;


    private void Start()
    {
        ProcurarRandomDestino();
        SlimeAnim = GetComponent<Animator>(); 
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update(){
     
            if (isKnockedBack){
                transform.Translate(knockbackDirecao * knockbackForca * Time.deltaTime);
                return;
            }
            else if (!isWaiting){
                if (!isMoving){  
                    if (Random.Range(0f, 1f) < 0.7f){
                        ProcurarRandomDestino();
                        isMoving = true; 
                    }
                    else{
                        StartCoroutine(RandomTempoParado());
                }
            }
            else{
                SlimeAnim.SetInteger("Movimento", 1); 
                Patrol();
            }    
        }
    }


    //Aqui o inimigo esta seguindo o ponto de destino ou parado
    private void Patrol(){
    
        moveDirecao = (randomDestino - transform.position).normalized;
        transform.Translate(moveDirecao * InimigoVelocidade * Time.deltaTime);
        flip();
        if (Vector2.Distance(transform.position, randomDestino) < 0.1f)
        {
            isMoving = false;
            StartCoroutine(RandomTempoParado());
            }
        }
    

    // Define um destino para o inimigo
    private void ProcurarRandomDestino(){
        Vector3 randomPonto = new Vector3(
            Random.Range(AreaPatrol.bounds.min.x, AreaPatrol.bounds.max.x),
            Random.Range(AreaPatrol.bounds.min.y, AreaPatrol.bounds.max.y),
            transform.position.z
        );
        randomDestino = randomPonto;
       
    }

    //Escolhe quanto tempo o inimigo fica parado
    private System.Collections.IEnumerator RandomTempoParado()
    {
        isWaiting = true;
        float waitTime = Random.Range(minTempo, maxTempo);
        SlimeAnim.SetInteger("Movimento", 0); 
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
        
    }
    void flip(){
        if(moveDirecao.x > 0){
            spriteRenderer.flipX = false;
        }else if(moveDirecao.x < 0){
            spriteRenderer.flipX = true;
        }
    }

   
// O metado Damage é chamado aqui
  public void ApplyKnockback(Vector3 direction)
{
    if (!isKnockedBack)
    {
        isKnockedBack = true;
        knockbackDirecao = direction;
        StartCoroutine(EndKnockback());
    }
}

private System.Collections.IEnumerator EndKnockback()
{
    yield return new WaitForSeconds(knockbackDuracao);
    isKnockedBack = false;
}
}

