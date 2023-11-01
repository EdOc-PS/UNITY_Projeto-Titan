using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash_Destroy : MonoBehaviour
{
    // destruir a ultima animação do Slash da espada
   public void DestroySlash(){
        Destroy(gameObject);
   }
}
