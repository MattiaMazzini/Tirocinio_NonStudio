using UnityEngine;
using UnityEngine.Events;

public class TipoPartitaPicker_Reminder : MonoBehaviour
{
    /** TipoPartitaPicker_Reminder:
    *   Script di ausilio al riconoscimento del tipo di partita quando ci si trova
    *   nella schermata Reminder, per ritornare alla schermata corretta se si preme
    *   il tasto indietro.
    */
    public UnityEvent sceltaClassica;
    public UnityEvent sceltaVeloce;

    void Update()
    {
        //tasto 'esc' premuto della tastiera corrisponde a tasto indietro di uno smartphone android
        if (Input.GetKeyDown(KeyCode.Escape))
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
    
    //Chiama l'evento assegnato da editor a seconda del tipo di partita
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
