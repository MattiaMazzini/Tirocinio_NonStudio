using UnityEngine;
using TMPro;

public class AggiornaLabel : MonoBehaviour
{
    //Script per aggiornare i contenuti della label nella scena scelta nomi

    private int i;
    private int size;
    public int offset;
    private int noUpdate;

    private TextMeshProUGUI testo;

    private string[] nomi;

    //Ottenimento del testo
    void Start()
    {
        size = PassaggioDati.nomiParole.Count;
        i = 0+offset;
        noUpdate = 1;

        nomi = PassaggioDati.giocatori;

        testo = gameObject.GetComponent<TextMeshProUGUI>();
        testo.text = nomi[i];

    }

    //cambia la label di testo con il nome successivo in ordine di inserimento
    public void ProssimoNome()
    {
        i++;
        
        if( i >= size)
        {
            i = 0;
        }
        if(noUpdate != size) testo.text = nomi[i];
        noUpdate++;
    }

    //cambia la label di testo con il nome precedente in ordine di inserimento
    public void NomePrecedente()
    {
        i--;
        
        if( i < 0)
        {
            i = size-1;
        }
        noUpdate--;
        if(noUpdate > 0) testo.text = nomi[i];
        
        
    }


    

}
