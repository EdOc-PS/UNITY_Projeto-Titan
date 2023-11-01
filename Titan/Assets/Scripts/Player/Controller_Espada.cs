using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Espada : MonoBehaviour
{
    private Transform swordTransform;
   

    private void Start()
    {
        swordTransform = transform;
    }

    private void Update()
    {
       Ataque();
    }  
    void Ataque(){
    if (Input.GetMouseButtonDown(0)){
            // Obtém a posição atual do mouse na tela e converte para o espaço do jogo
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (mousePosition - swordTransform.position).normalized;
            direction.z = 0f; // Mantém o valor z
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Aplica a rotação à espada de acordo com  click do player
            swordTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            // Rotaciona a espada para ficar certa
            Vector3 scale = swordTransform.localScale;
                if (direction.x < 0f){
                    scale.y = -1;
                }else if(direction.x > 0f){
                    scale.y = 1;
                }

                swordTransform.localScale = scale;
            }
    }
}