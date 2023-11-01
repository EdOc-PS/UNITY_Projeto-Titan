using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Slash : MonoBehaviour
{
    private Transform slashTransform;

    private void Start()
    {
        slashTransform = transform;
    }

    private void Update()
    {
      SlashAtaque();
    }
    void SlashAtaque(){
    if (Input.GetMouseButtonDown(0)){
        // Obtém a posição atual do mouse na tela e converte para o espaço do jogo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - slashTransform.position).normalized;
        direction.z = 0f; // Mantém o valor z
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplica a rotação o Slash da  espada de acordo com click do player
        slashTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

         // Rotaciona o slash para ficar certo
        Vector3 scale = slashTransform.localScale;
            if (direction.x < 0f){
                scale.y = 1;
            }else if(direction.x > 0f){
                scale.y = 1;
            }

            slashTransform.localScale = scale;
        }
    }
}