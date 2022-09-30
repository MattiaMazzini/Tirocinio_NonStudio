using UnityEngine;
using TMPro;

public class PlayerSelector : MonoBehaviour
{
    /** PlayerSelector:
    *   Questo script inizializza la struttura dati dei giocatori in gioco di volta in volta
    *   e mostra il giocatore attualmente giocante.
    */
    
    public TextMeshProUGUI giocatoreUI;

    void Start()
    {
        PassaggioDati.InitGiocatoriAttuali();

        if (PassaggioDati.contatoreVincitori == 0)
        {
            giocatoreUI.text = PassaggioDati.giocatoriAttuali[PassaggioDati.numGiocatoreAttuale].ToUpper();
        }

        else
        {
            if (PassaggioDati.numGiocatoreAttuale < PassaggioDati.giocatoriAttuali.Length)
            {
                giocatoreUI.text = PassaggioDati.giocatoriAttuali[PassaggioDati.numGiocatoreAttuale].ToUpper();
            }
            else
            {
                giocatoreUI.text = PassaggioDati.giocatoriAttuali[0].ToUpper();
            }
        }

    }
}
