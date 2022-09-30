using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using UnityEngine.Localization.Settings;


public class AggiungiNomi : MonoBehaviour
{

    //Script che gestisce l'aggiunta di nuovi giocatori
    
    public GameObject myPrefab;
    public GameObject padreBottoni;

    public TMP_InputField campo;

    private List<GameObject> nomi;
    private GameObject nome;
    private int numeroUltimoNome;
    private int indice;

    public Button m_bottoneAvanti;
    public GameObject disabledButton;
    public GameObject disabledText;
    public ScrollRect scrollRect;
    public float verticalPosition = 0f;

    void Start()
    {
        numeroUltimoNome = 0;
        nomi = new List<GameObject>();
        if(PassaggioDati.nomiParole.Count == 0)
        {
            for(int i = 0; i < 2; i++)
            {
                AggiungiNome();
                nomi[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        } else 
        {
            string[] chiavi = new string[PassaggioDati.nomiParole.Count];
            PassaggioDati.nomiParole.Keys.CopyTo(chiavi, 0);
            for(int i = 0; i < PassaggioDati.nomiParole.Count; i++)
            {
                AggiungiNome();
                nomi[i].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = chiavi[i];
                if(PassaggioDati.nomiParole.Count <= 2) {
                    nomi[i].transform.GetChild(2).gameObject.SetActive(false);
                }
            }
        }
        
    }

    void Update()
    {
        if(checkNomi())
        {
            attivaAvanti();
        } else
        {
            disattivaAvanti();
        }
        
    }

    //funzione di callback per istanziare un nuovo bottone nome e aggiungerlo sotto quelli già esistenti all'interno
    public void AggiungiNome()
    {
        //creo un'istanza del prefab del bottone modificabile e con la X e la aggiungo alla lista dei bottoni
        nomi.Add((GameObject)Instantiate(myPrefab));

        //per comodità di scrittura mi imposto un indice e un riferimento all'oggetto corrente
        indice = nomi.Count-1;
        GameObject ogg = nomi[indice];

        //aumento il contatore di ultimo bottone per mantenere un corretto naming dei bottoni successivi
        numeroUltimoNome++;     
        
        //imposto alcune proprietà del bottone creato
        ogg.transform.SetParent(padreBottoni.transform);
        ogg.transform.SetSiblingIndex(indice);

        if (LocalizationSettings.SelectedLocale.Identifier == "it")
            ogg.name = "Giocatore "+ (numeroUltimoNome);
        if (LocalizationSettings.SelectedLocale.Identifier == "en")
            ogg.name = "Player "+ (numeroUltimoNome);
        
        ogg.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = ogg.name;

        //per poter passare un oggetto come parametro alla callback sfrutto un delegato
        UnityAction call = delegate() { RimuoviNome(ogg); };
        ogg.transform.Find("X").gameObject.GetComponent<Button>().onClick.AddListener(call);

        //imposto il riferimento al campo di testo nascosto all'interno del nuovo bottone (quest'ultimo ne avrà bisogno per cambiare testo insieme alla label nascosta)
        ogg.GetComponent<ScriptNamedButton>().SetTesto(campo);
        
        //prendo il componente RectTransform del nuovo bottone e ne imposto la scala al corretto valore (per essere sicuro che venga generato della corretta misura)
        RectTransform myRect = ogg.GetComponent<RectTransform>();
        myRect.localScale = Vector3.one;

        if(nomi.Count > 2)
        {
            for(int i = 0; i < nomi.Count; i++)
            {
                nomi[i].transform.GetChild(2).gameObject.SetActive(true);
            }
        }

        //per portare la scrollarea fino in basso all'aggiunta di un nuovo elemento
        scrollRect.normalizedPosition = new Vector2(0, verticalPosition);
    }

    //funzione di callback per rimuovere un bottone nome
    public void RimuoviNome(GameObject oggetto)
    {
        //riomuove il bottone dalla lista e distrugge l'oggetto bottone
        nomi.Remove(oggetto);
        Destroy(oggetto);
        if(nomi.Count <= 2)
        {
            for(int i = 0; i < nomi.Count; i++)
            {
                nomi[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    //salva i nomi nel dictionary statico in PassaggioDati per mantenerli al cambio scena
    public void SalvaNomi()
    {     
        if(PassaggioDati.nomiParole.Count != 0) PassaggioDati.Init();

        //ciclo gli elementi della lista salvandone i nomi come chiave del OrderedDictionary
        foreach(GameObject corr in nomi)
        {
            //il secondo figlio è il game object che rappresenta il testo di un bottone
            string nome = corr.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text;
            PassaggioDati.nomiParole.Add(nome, "empty");
        }
    
        PassaggioDati.InitArray();
    }

    //verifica che nessun nome sia invalido
    //nome invalido = nome vuoto / nome gia' esistente
    public bool checkNomi()
    {
        bool risultato = true;
        foreach(GameObject g in nomi)
        {
            string nomeAttuale = g.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text;
            if(nomeAttuale == "")
            {
                risultato = false;
            }
        }
        for(int i = 0; i < nomi.Count; i++)
        {
            for(int j = 0; j < nomi.Count; j++)
            {
                string nomeAttualeG = nomi[i].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text;
                string nomeAttualeH = nomi[j].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text;
                if(nomeAttualeG.Equals(nomeAttualeH) && i!=j)
                {
                    risultato = false;
                }
            }
        }

        return risultato;
    }

    //Disattiva il bottone di avanti
    public void disattivaAvanti()
    {
        m_bottoneAvanti.gameObject.SetActive(false);
        disabledText.SetActive(true);
        disabledButton.SetActive(true);    
    }

    //Attiva il bottone di avanti
    public void attivaAvanti()
    {
        disabledButton.SetActive(false);
        disabledText.SetActive(false);
        m_bottoneAvanti.gameObject.SetActive(true);
    }
}
