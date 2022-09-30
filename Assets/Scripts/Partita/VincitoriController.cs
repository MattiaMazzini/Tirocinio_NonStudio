using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class VincitoriController : MonoBehaviour
{
    /** VincitoriController:
    *   invocato quando dalla Schermata Vincitore si torna alla partita:
    *   elimina il giocatore vincitore dalla struttura dati dei giocatori in partita
    *   e torna alla partita se ci sono ancora giocatori in suddetta struttura,
    *   altrimenti passa a fine partita, mostrando la Classifica.
    */
    public SceneChange sceneChange;
    public TextMeshProUGUI vincitoreUI;
    public TextMeshProUGUI parolaVincitoreUI;
    public UnityEvent noMorePlayers;
    public UnityEvent stillPlaying;

    void Start()
    {
        string vincitore = PassaggioDati.giocatoriAttuali[PassaggioDati.numGiocatoreAttuale];

        vincitoreUI.text = vincitore.ToUpper();
        parolaVincitoreUI.text = PassaggioDati.nomiParoleInPartita[vincitore].ToString().ToUpper();
    }

    public void EliminaVincitore()
    {
        //check per controllare che ci sia
        if(PassaggioDati.nomiParoleInPartita.Contains(PassaggioDati.giocatoriAttuali[PassaggioDati.numGiocatoreAttuale]))
        {
            //finché ci sono giocatori in partita
            if (PassaggioDati.contatoreVincitori < PassaggioDati.vincitori.Length)
            {
                //salva il vincitore nell'array che verrà poi mostrato in Classifica
                PassaggioDati.vincitori[PassaggioDati.contatoreVincitori] = PassaggioDati.giocatoriAttuali[PassaggioDati.numGiocatoreAttuale];
                PassaggioDati.contatoreVincitori++;

                PassaggioDati.nomiParoleInPartita.Remove(PassaggioDati.giocatoriAttuali[PassaggioDati.numGiocatoreAttuale]);
                
                //controlla se siamo all'ultimo o no
                if (PassaggioDati.contatoreVincitori == PassaggioDati.vincitori.Length) //siamo all'ultimo, esce invocando l'evento
                {
                    sceneChange.transitionTime = 1f;
                    noMorePlayers.Invoke();
                }
                else //non siamo all'ultimo, riprende il giro
                {
                    stillPlaying.Invoke();
                }
            }
        }
    }
}
