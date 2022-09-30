using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFiller : MonoBehaviour
{

    //Riempie label PlayerName della schermata reminder con il nome del primo giocatore di turno

    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = PassaggioDati.giocatori[0];
    }
}
