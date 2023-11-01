using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoVida : MonoBehaviour
{
    [SerializeField]
    private int             VidaTotal;
    private int             VidaAtual;
    private Loot_Itens      loot_Itens;
    void Start()
    {
        VidaAtual = VidaTotal;
        loot_Itens =GetComponent<Loot_Itens>();
    }
    public void TomarDano(int dano){
        VidaAtual -= dano;
        Debug.Log(VidaAtual);
        DeathInimigo();
    }
    // Update is called once per frame
    private void DeathInimigo(){
        if(VidaAtual <= 0){
             gameObject.SetActive(false);
             loot_Itens.LootItem();
             //ou pode destruir o gameObject
        }
    }
   
        
    
}
