using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public class LanguageManager : MonoBehaviour
{
    /** LanguageManager:
    *   Cambia la lingua in base al pulsante premuto nella sezione Impostazioni,
    *   cambiando così tutti i testi dipendenti dai LocalizationSettings
    *   (attuali localizzazioni presenti nel progetto: 'it', 'en' )
    */

    //con un bool evito che multiple pressioni dei bottoni possano invocare più volte la funzione
    private bool active = false;

    public Button itaButton;
    public Button engButton;
    public Sprite activeItaSprite;
    public Sprite activeEngSprite;
    public Sprite inactiveItaSprite;
    public Sprite inactiveEngSprite;

    //en: 0
    //it: 1
    public void Start ()
    {
        if (LocalizationSettings.SelectedLocale.Identifier == "en")
        {
            //lingua selezionata: en
            engButton.GetComponent<Image>().sprite = activeEngSprite;
            itaButton.GetComponent<Image>().sprite = inactiveItaSprite;
        }
        if (LocalizationSettings.SelectedLocale.Identifier == "it")
        {
            //lingua selezionata: it
            engButton.GetComponent<Image>().sprite = inactiveEngSprite;
            itaButton.GetComponent<Image>().sprite = activeItaSprite;
        }
    }
    public void ChangeLocale (int localeID)
    {
        if (active == true) return;

        if ( localeID == 0)
        {
            //lingua selezionata: en
            engButton.GetComponent<Image>().sprite = activeEngSprite;
            itaButton.GetComponent<Image>().sprite = inactiveItaSprite;
            PlayerPrefs.SetString("language", "en");
        }
        if ( localeID == 1)
        {
            //lingua selezionata: it
            engButton.GetComponent<Image>().sprite = inactiveEngSprite;
            itaButton.GetComponent<Image>().sprite = activeItaSprite;
            PlayerPrefs.SetString("language", "it");
        }
        StartCoroutine(SetLocale(localeID));
    }

    IEnumerator SetLocale (int localeID)
    {
        //en: 0
        //it: 1
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        active = false;
    }


}
