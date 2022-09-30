using System.Collections.Specialized;

public static class PassaggioDati
{
    //classe per passare dati fra le scene

    public static string tipoPartita = "";

    public static OrderedDictionary nomiParole;
    public static string[] giocatori;

    /**************************************/

    public static OrderedDictionary nomiParoleInPartita;
    public static int numGiocatoreAttuale = 0;
    public static string[] giocatoriAttuali;
    public static string[] vincitori;
    public static int contatoreVincitori;

    public static void Init()
    {
        nomiParole = new OrderedDictionary();
        nomiParoleInPartita = new OrderedDictionary();
    }

    public static void InitPartitaDictionary()
    {
        nomiParoleInPartita.Clear();
        
        string[] keys = new string[nomiParole.Keys.Count];
        string[] values = new string[nomiParole.Keys.Count];

        nomiParole.Keys.CopyTo(keys, 0);
        nomiParole.Values.CopyTo(values, 0);


        for (int i = 0; i < nomiParole.Keys.Count; i++)
        {
            nomiParoleInPartita.Insert(i, keys[i], values[i]);
        }
    }

    public static void InitVincitori()
    {
        vincitori = new string[nomiParole.Keys.Count];
        contatoreVincitori = 0;
    }

    //da invocare all'inizio e a ogni eliminazione di un giocatore dal giro di partita
    public static void InitArray()
    {
        giocatori = new string[nomiParole.Keys.Count];
        nomiParole.Keys.CopyTo(giocatori, 0); //copio le varie chiavi, i giocatori, a partire dall'elemento 0 dell'array di stringhe
    }

    public static void InitGiocatoriAttuali()
    {
        giocatoriAttuali = new string[nomiParoleInPartita.Keys.Count];
        nomiParoleInPartita.Keys.CopyTo(giocatoriAttuali, 0);
    }
}
