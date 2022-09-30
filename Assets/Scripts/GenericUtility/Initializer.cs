using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Initializer : MonoBehaviour
{
    /** Initializer:
    *   invoca due funzioni di PassaggioDati che inizializzano alcune strutture necessarie alla partita.
    */

    public UnityEvent initHandler = null;

    void Start()
    {
        if(initHandler != null) initHandler.Invoke();
    }

    public void InitGiocatori()
    {
        PassaggioDati.InitArray();
    }

    public void InitNomiParole()
    {
        PassaggioDati.Init();
    }

}
