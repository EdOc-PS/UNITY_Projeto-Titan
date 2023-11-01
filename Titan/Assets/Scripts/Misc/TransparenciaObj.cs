using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency : MonoBehaviour
{   

    [Range (0, 1)]
    [SerializeField] private float TransparenciaValor;
    [SerializeField] private float TransparenciaTempo;
    
    private SpriteRenderer spriteRender;
    // Start is called before the first frame update
    void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
     
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Controller_Player>()){
                StartCoroutine(FadeArvore(spriteRender, TransparenciaTempo, spriteRender.color.a, TransparenciaValor));
                spriteRender.sortingOrder = 11;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
         if (collision.gameObject.GetComponent<Controller_Player>()){
                StartCoroutine(FadeArvore(spriteRender, TransparenciaTempo, spriteRender.color.a, 1f));
                spriteRender.sortingOrder = 5;
        }
    }
    private IEnumerator FadeArvore(SpriteRenderer TransparenciaIntencity, float fadeTempo, float startvalor, float targetTrasparencia){
        float timeElapsed = 0;  
        while(timeElapsed < fadeTempo){
            timeElapsed += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startvalor, targetTrasparencia, timeElapsed / fadeTempo);
            TransparenciaIntencity.color = new Color(TransparenciaIntencity.color.r, TransparenciaIntencity.color.g, TransparenciaIntencity.color.b, newAlpha);
            yield return null;
        }
        
    }
}
