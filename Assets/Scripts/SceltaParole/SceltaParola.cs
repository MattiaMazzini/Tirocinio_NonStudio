using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization.Settings;

public class SceltaParola : MonoBehaviour
{

    //Script che gestisce la label di inserimento della parola

    private TMP_InputField text;
    private List<string> paroleCasuali;
    private int max;

    private int i;
    private int count;

    void Start()
    {
        TextAsset fileParole = new TextAsset();

        //Scelta coerente rispetto alla lingua scelta nelle impostazioni delle parole casuali (es. 'EN' -> Pope Francis   /   'IT' -> Papa Francesco)
        if (LocalizationSettings.SelectedLocale.Identifier == "it")
        {
            fileParole = Resources.Load<TextAsset>("ParoleCasuali_IT");
        }
        if (LocalizationSettings.SelectedLocale.Identifier == "en")
        {
            fileParole = Resources.Load<TextAsset>("ParoleCasuali_EN");
        }

        paroleCasuali = new List<string>();
        
        var line = fileParole.ToString();
        var values = line.Split('\n');

        foreach(string s in values)
        {
            paroleCasuali.Add(s);
        }

        max = paroleCasuali.Count - 1;
        text = gameObject.GetComponent<TMP_InputField>();

        i = 0;
        count = PassaggioDati.nomiParole.Count;
    }

    //Sovrascrive il testo della label con una parola casuale dal file in cui sono salvate
    public void ParolaCasuale()
    {
        text.text = paroleCasuali[Random.Range(0,max)];
    }

    //Se il testo della label e' vuoto o se ha il valore di default lo sovrascrive con una parola casuale
    public void ParolaCasualeSeVuoto()
    {
        if(text.text.Equals("") || text.text.Equals("Inserisci parola"))
        {
            text.text = paroleCasuali[Random.Range(0,max)];
        }
    }

    //Salva la parola con cui e' stata riempita la label di testo nell'array di passaggioDati
    public void SalvaParola()
    {
        i++;
        if (i >= count)
        {
            i = 0;
        }

        PassaggioDati.nomiParole[i] = text.text;
        paroleCasuali.Remove(text.text);

        if(i != 0)
        {
            AzzeraTesto();
        }
    }

    //Reimposta il testo di default nella label
    public void AzzeraTesto()
    {
        text.text = "Inserisci parola";
    }
}
