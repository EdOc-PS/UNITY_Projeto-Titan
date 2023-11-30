using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collect_Life : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<SystemVida>().GanhaVida();
            Destroy(this.gameObject);       
        }
    }
}
