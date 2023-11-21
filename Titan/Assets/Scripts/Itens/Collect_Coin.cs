using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collect_Itens : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<Inventario>().GanhaCoin();
            Destroy(this.gameObject);       
        }
    }
}
