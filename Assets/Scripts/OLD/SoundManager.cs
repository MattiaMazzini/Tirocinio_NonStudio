using UnityEngine;
using TMPro;

public class SoundManager : MonoBehaviour
{
/*
    public TextMeshProUGUI volumeOn;
    public TextMeshProUGUI  volumeOff;
    private bool muted = false;

    void Start ()
    {
        if(!PlayerPrefs.HasKey("muted")) // Se nelle sessioni precedenti non è stato silenziato il volume, allora entra 
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }

        else
        {
            Load();
        }

        AudioListener.pause = muted;
    }
*/
    /*  Altera muted da false a true e invoca le funzioni:
    *   - Save, per salvare le impostazioni nelle preferenze del giocatore
    *   - UpdateButtonText, per cambiare il testo del button
    */
/*
    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        
        Save();
    }

    // (invocata solo all'avvio) carica le preferenze dell'utente impostate in altre sessioni di avvio
    public void Load()
    {
        if (PlayerPrefs.GetInt("muted") == 1) muted = true;
        else muted = false;
    }

    // (invocata solo al click del button) salva le preferenze dell'utente
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
*/
}
