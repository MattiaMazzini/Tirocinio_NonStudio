using UnityEngine;
using UnityEngine.UI;

//script per selezionare il bottone corretto nel main menu (per es. gioca o gioco veloce)
//lo script è scalabile in caso si vogliano aggiungere più bottoni di gioco attraverso l'interfaccia grafica di Unity

public class ButtonSelector : MonoBehaviour
{
    /*
    public Button[] bottoni;
    //rappresenta le posizioni dei bottoni in base al centro in multipli di 325
    private int[] posizione;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        
        //assegnamento dei listener ai bottoni attraverso interfaccia grafica
        i = 0;
        while(i < bottoni.Length)
        {
            bottoni[i].onClick.AddListener(cambio);
            i++;
        }

        //assegnamento delle posizioni dei bottoni all'avvio del gioco
        posizione = new int[bottoni.Length];
        i = 0;
        while(i < posizione.Length)
        {
            posizione[i] = i;
            i++;
        }
    }

    //funzione che sposta i bottoni a seconda di quello cliccato
    void cambio()
    {
        Debug.Log("Hello");
        if(this.GetComponent<RectTransform>().anchoredPosition.x == 0)
        {

        }
    }

    void change(int valore){
        Debug.Log(valore);
    }
    */
}
