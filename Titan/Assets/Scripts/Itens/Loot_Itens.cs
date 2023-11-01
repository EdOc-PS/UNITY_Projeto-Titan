using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot_Itens : MonoBehaviour
{
    [Header("Drop de Itens")]
    [SerializeField]
    private GameObject      coin;
    [SerializeField]
    private int             chancesDropItem;
    [SerializeField]
    private int             dropMinItem;
    [SerializeField]
    private int             dropMaxItem;
    
    [Header("Drop de Vida")]
    [SerializeField]
    private GameObject      vida;
    [SerializeField]
    private int             chancesDropVida;
    [SerializeField]
    private int             dropMinVida;
    [SerializeField]
    private int             dropMaxVida;

    // Update is called once per frame
    public void LootItem(){
        int Randoms = Random.Range(1,100);
        if(Randoms < chancesDropItem){
            int qtdeitem = Random.Range(dropMinItem, dropMaxItem);
            for(int i = 0; i < qtdeitem; i++){
                Instantiate(coin, transform.position, transform.rotation);
            }
        }
        int RandomsVida = Random.Range(1,100);
        if(RandomsVida <chancesDropVida){
            int qtdeVida = Random.Range(dropMinVida, dropMaxVida);
            for(int i = 0; i < qtdeVida; i++){
                Instantiate(vida, transform.position, transform.rotation);
            }
        }
    }
}
