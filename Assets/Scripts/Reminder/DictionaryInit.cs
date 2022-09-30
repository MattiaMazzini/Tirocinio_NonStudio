using UnityEngine;

public class DictionaryInit : MonoBehaviour
{
    /** DictionaryInit:
    *   Questo script inizializza le due strutture dati, due dizionari, a supporto della partita.
    */
    public void Init()
    {
        PassaggioDati.numGiocatoreAttuale = 0;
        PassaggioDati.InitPartitaDictionary();
        PassaggioDati.InitVincitori();
    }
}
