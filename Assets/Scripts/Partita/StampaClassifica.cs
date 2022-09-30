using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StampaClassifica : MonoBehaviour
{
    /** StampaClassifica:
    *   Questo script prende dalla struttura dati dei vincitori i giocatori che hanno vinto
    *   in ordine di uscita dalla partita, e li stampa assegnando una medaglia (sprite) ai primi tre.
    */
    public Sprite goldMedal;
    public Sprite silverMedal;
    public Sprite bronzeMedal;
    public GameObject parentContent;
    private List<GameObject> nomi;
    public GameObject myPrefab;
    private int indice;
    public GameObject soundEffects;

    public GameObject firebaseLogger;

    void Start()
    {
        soundEffects.GetComponent<SoundPlayer>().PlayEndofGameSound();

        Screen.orientation = ScreenOrientation.Portrait;
        nomi = new List<GameObject>();
        for (int i = 0; i < PassaggioDati.vincitori.Length; i++)
        {
            AggiungiNome(i);
        }

        firebaseLogger.GetComponent<test_log_firebase_script>().logLevelEnd();
    }

    private void AggiungiNome(int index)
    {
        //creo un'istanza del prefab del bottone modificabile e con la X e la aggiungo alla lista dei bottoni
        nomi.Add((GameObject)Instantiate(myPrefab));

        //per comodità di scrittura mi imposto un indice e un riferimento all'oggetto corrente
        indice = nomi.Count-1;
        GameObject ogg = nomi[indice];
        
        //imposto alcune proprietà del bottone creato
        ogg.transform.SetParent(parentContent.transform);
        ogg.transform.SetSiblingIndex(indice);
        
        ogg.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = PassaggioDati.vincitori[index].ToString();

        //se il giocatore è in una delle prime tre posizioni, agganciamo la relativa
        //medaglia all'oggetto contenente il nome del vincitore
        if (index == 0)
        {
            ogg.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = goldMedal;
            Color c = ogg.transform.GetChild(1).gameObject.GetComponent<Image>().color;
            c.a = 1;
            ogg.transform.GetChild(1).gameObject.GetComponent<Image>().color = c;
        }
        if (index == 1)
        {
            ogg.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = silverMedal;
            Color c = ogg.transform.GetChild(1).gameObject.GetComponent<Image>().color;
            c.a = 1;
            ogg.transform.GetChild(1).gameObject.GetComponent<Image>().color = c;
        }
        if (index == 2)
        {
            ogg.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = bronzeMedal;
            Color c = ogg.transform.GetChild(1).gameObject.GetComponent<Image>().color;
            c.a = 1;
            ogg.transform.GetChild(1).gameObject.GetComponent<Image>().color = c;
        }
        
        RectTransform myRect = ogg.GetComponent<RectTransform>();
        myRect.localScale = Vector3.one;
    }
}
