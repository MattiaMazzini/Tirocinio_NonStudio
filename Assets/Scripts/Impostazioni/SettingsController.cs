using UnityEngine;

public class SettingsController : MonoBehaviour
{
    /** SettingsController:
    *   controlla e imposta le preferenze del giocatore per l'audio, e fornisce
    *   funzioni ausiliarie per accendere/spegnere musica e suoni.
    */

    private bool muted = false;
    private bool mutedSFX = false;
    private AudioSource backgroundMusic;
    private AudioSource sfxSounds;

    void Start() {
        backgroundMusic = GameObject.Find("Background Music").GetComponent<AudioSource>();
        sfxSounds = GameObject.Find("SoundEffects").GetComponent<AudioSource>();
    }

    void Update()
    {
        LoadAudioPrefs();
    }

/* PREFERENZE AUDIO --------------------------------------------------------- */

    public void LoadAudioPrefs()
    {
        if(!PlayerPrefs.HasKey("muted")) //Volume attivo di default
        {
            PlayerPrefs.SetInt("muted", 0);
        }
        if(!PlayerPrefs.HasKey("mutedSFX"))
        {
            PlayerPrefs.SetInt("mutedSFX", 0);
        }

        LoadAudioSettings();

        backgroundMusic.mute = muted;
        if(sfxSounds != null) sfxSounds.mute = mutedSFX;
    }

    public void LoadAudioSettings()
    {
        if (PlayerPrefs.GetInt("muted") == 1) muted = true;
        else muted = false;

        if (PlayerPrefs.GetInt("mutedSFX") == 1) mutedSFX = true;
        else mutedSFX = false;
    }
    
    public void VolumeIsOn()
    {
        PlayerPrefs.SetInt("muted", 0);
        backgroundMusic.mute = muted;
    }

    public void VolumeIsOff()
    {
        PlayerPrefs.SetInt("muted", 1);
        backgroundMusic.mute = muted;
    }

    public void SFXIsOn()
    {
        PlayerPrefs.SetInt("mutedSFX", 0);
        sfxSounds.mute = mutedSFX;
    }

    public void SFXIsOff()
    {
        PlayerPrefs.SetInt("mutedSFX", 1);
        sfxSounds.mute = mutedSFX;
    }

/*--------------------------------------------------------------------------- */



}
