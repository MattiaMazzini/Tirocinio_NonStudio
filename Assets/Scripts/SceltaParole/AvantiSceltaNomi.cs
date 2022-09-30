using UnityEngine;
using UnityEngine.Events;

public class AvantiSceltaNomi : MonoBehaviour
{

    /*
        Script che permette di avanzare e arretrare nella scena di scelta nomi
        Cambia i parametri della scena a seconda di che giocatori ci si riferisce
    */

    private int count;
    private int i;
    public GameObject panelController;
    public UnityEvent toReminder;
    public UnityEvent toSceltaGiocatori;

    void Start()
    {
        count = PassaggioDati.nomiParole.Count;
        i = 0;
    }

    //dopo aver impostato tutti i nomi necessari procede alla prossima scena
    public void Avanti()
    {
        i++;
        if(i == count)
        {
            panelController.SetActive(false);
            toReminder.Invoke();
        }
    }

    public void Indietro()
    {
        i--;
        if(i < 0)
        {
            toSceltaGiocatori.Invoke();
        }
    }

}
