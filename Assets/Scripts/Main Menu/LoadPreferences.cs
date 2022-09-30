using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LoadPreferences : MonoBehaviour
{
    /** LoadPreferences:
    *   carica le preferenze espresse dal giocatore in altre sessioni di gioco riguardo
    *   alle impostazioni (suono, musica, lingua); fornisce infine funzioni invocabili
    *   per settare il tipo di partita desiderato.
    */

    private bool muted = false;
    private bool mutedSFX = false;

    private AudioSource backgroundMusic;
    private AudioSource sfxSounds;

    // Controlla il valore dato a muted nelle sessioni di gioco precedenti e attiva/disattiva il volume di conseguenza
    void Start ()
    {
        //Suoni
        backgroundMusic = GameObject.Find("Background Music").GetComponent<AudioSource>();
        sfxSounds = GameObject.Find("SoundEffects").GetComponent<AudioSource>();

        //Invocazione delle playerprefs settate nelle precedenti sessioni
        LoadAudioPrefs();
        LoadLanguagePrefs();

        //Non facciamo spegnere lo schermo finché si è nel gioco
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void LoadAudioPrefs ()
    {
        if(!PlayerPrefs.HasKey("muted")) //se nelle sessioni precedenti non è stata silenziata la musica, allora entra 
        {
            PlayerPrefs.SetInt("muted", 0);
        }
        if(!PlayerPrefs.HasKey("mutedSFX")) //se nelle sessioni precedenti non è stato silenziato il suono, allora entra
        {
            PlayerPrefs.SetInt("mutedSFX", 0);
        }

        LoadAudioSettings();

        if (backgroundMusic != null) backgroundMusic.mute = muted;
        if(sfxSounds != null) sfxSounds.mute = mutedSFX;
    }

    public void LoadLanguagePrefs ()
    {
        int localeID = 1;

        //se non esiste una PlayerPref "language", setta "it" di default nella PlayerPref "language"
        if(!PlayerPrefs.HasKey("language"))
        {
            PlayerPrefs.SetString("language", LocalizationSettings.SelectedLocale.Identifier.ToString());
        }

        if (PlayerPrefs.GetString("language") == "en") localeID = 0;
        if (PlayerPrefs.GetString("language") == "it") localeID = 1;

        StartCoroutine(SetLocale(localeID));
    }

    IEnumerator SetLocale (int localeID)
    {
        //en: 0
        //it: 1
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
    }

    private void LoadAudioSettings ()
    {
        if (PlayerPrefs.GetInt("muted") == 1) muted = true;
        else muted = false;
        if (PlayerPrefs.GetInt("mutedSFX") == 1) mutedSFX = true;
        else mutedSFX = false;
    }

    public void SetTipoPartitaToClassica ()
    {
        PassaggioDati.tipoPartita = "Classica";
    }

    public void SetTipoPartitaToVeloce ()
    {
        PassaggioDati.tipoPartita = "Veloce";
    }

}
