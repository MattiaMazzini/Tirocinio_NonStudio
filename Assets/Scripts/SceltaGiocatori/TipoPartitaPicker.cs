using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TipoPartitaPicker : MonoBehaviour
{

    private List<string> paroleCasuali;
    int i;
    int max;
    int count;
    public UnityEvent sceltaClassica;
    public UnityEvent sceltaVeloce;

    //A seconda del tipo di partita scelta dal menu principale, invoca l'evento corrispondente con callback assegnata da editor
    public void PickTipo()
    {
        if (PassaggioDati.tipoPartita == "Classica")
        {
            sceltaClassica.Invoke();
        }

        if (PassaggioDati.tipoPartita == "Veloce")
        {
            sceltaVeloce.Invoke();
        }
    }
    
}
