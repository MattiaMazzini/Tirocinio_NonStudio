using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LoadPartitaVeloce : MonoBehaviour
{
    /** LoadPartitaVeloce:
    *   Questo script, in funzione solo se si sceglie la modalità Veloce, genera e carica nelle
    *   strutture dati le parole da assegnare casualmente ai giocatori, pescandole dai fileParole
    *   presenti nel sistema (in base alla lingua).
    */
    public void Start()
    {
        if (PassaggioDati.tipoPartita == "Veloce")
        {
            //recupero il file contenente i personaggi da assegnare, in ING o ITA a seconda
            //della lingua scelta
            TextAsset fileParole = new TextAsset();

            if (LocalizationSettings.SelectedLocale.Identifier == "it")
            {
                fileParole = Resources.Load<TextAsset>("ParoleCasuali_IT");
            }
            if (LocalizationSettings.SelectedLocale.Identifier == "en")
            {
                fileParole = Resources.Load<TextAsset>("ParoleCasuali_EN");
            }

            //creo una struttura in cui mettere le parole casuali dal file .csv
            //e poi ne assegno una random a ogni giocatore in gioco
            List<string> paroleCasuali = new List<string>();
            
            var line = fileParole.ToString();
            var values = line.Split('\n');

            foreach(string s in values)
            {
                paroleCasuali.Add(s);
            }

            int max = paroleCasuali.Count - 1;
            int count = PassaggioDati.nomiParole.Keys.Count;

            for (int i = 0; i < count; i++)
            {
                PassaggioDati.nomiParole[i] = paroleCasuali[Random.Range(0,max)];
            }
        }
    }
}
