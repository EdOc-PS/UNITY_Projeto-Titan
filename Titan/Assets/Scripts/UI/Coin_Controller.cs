using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin_Controller : MonoBehaviour
{
    [Header("UI Scores")]
    public TextMeshProUGUI coinText;
    public Inventario inventario;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        coinText.text = inventario.qtdeCoin.ToString();
    }
}
