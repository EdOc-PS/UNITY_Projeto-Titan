using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demage : MonoBehaviour
{
    [SerializeField] private int DanoEspada;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.GetComponent<InimigoVida>()){
            InimigoVida inimigovida = other.gameObject.GetComponent<InimigoVida>();
            inimigovida.TomarDano(DanoEspada);
            PatrolIA patrolIA = other.gameObject.GetComponent<PatrolIA>();
        if (patrolIA != null) {
            Vector3 knockbackDirecao = (other.transform.position - transform.position).normalized;
            patrolIA.ApplyKnockback(knockbackDirecao);
        }
        }
    }
}
