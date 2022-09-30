using System.Collections;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    /** GameController:
    *   Questo script regola l'intera struttura della partita:
    *   - passa da un giocatore all'altro
    *   - controlla che sia rispettato il giro di giocatori, anche quando vengono rimossi dalla struttura dati,
    *   ricominciando dal primo alla fine del giro
    *   - alterna le due schermate, quella con la parola mostrata e quella di intermezzo
    *   - tramite il float inputDeactivationTime è possibile regolare la durata della disattivazione
    *   del tap, per aggiustare come più si desidera il tempo in cui si è sicuri che un doppio tap
    *   non guasti l'esperienza di gioco erroneamente portando alla parola successiva
    */
    public TextMeshProUGUI giocatoreAttualeUI;
    public TextMeshProUGUI giocatoreSuccessivoUI;
    public TextMeshProUGUI parolaAssociataUI;
    public GameObject schermataIntermezzo;
    public GameObject schermataPartita;
    public GameObject parolaAssociataObj;
    public GameObject playerInputSwipe;

    public GameObject pauseMenu;
    public GameObject pauseButton;
    public static bool gameIsPaused = false;

    private string giocatoreAttuale;
    private string parolaAssociata;
    private bool isIntermezzo;
    private bool isBack;
    public float inputDeactivationTime = 0.4f;

    public GameObject soundManager;

    void Start()
    {
        Resume();
        schermataIntermezzo.SetActive(false);
        isIntermezzo = false;
        GestisciDati();
    }

    // A ogni invocazione, estrae e presenta i dati del giocatore attuale, e memorizza chi verrà dopo;
    //se siamo a fine giro, il giocatore successivo sarà il primo dell'array
    private void GestisciDati()
    {
        if (PassaggioDati.numGiocatoreAttuale < PassaggioDati.giocatoriAttuali.Length)
        {
            giocatoreAttuale = PassaggioDati.giocatoriAttuali[PassaggioDati.numGiocatoreAttuale];
            parolaAssociata = PassaggioDati.nomiParoleInPartita[giocatoreAttuale].ToString();
        }
        //se non lo contiene vuol dire che sto eccedendo il numero di giocatori in partita e devo tornare al primo
        else
        {
            PassaggioDati.numGiocatoreAttuale = 0;
            giocatoreAttuale = PassaggioDati.giocatoriAttuali[PassaggioDati.numGiocatoreAttuale];
            parolaAssociata = PassaggioDati.nomiParoleInPartita[giocatoreAttuale].ToString();
        }

        //setto il valore della casella di testo del giocatore successivo
        if (PassaggioDati.numGiocatoreAttuale < PassaggioDati.giocatoriAttuali.Length-1)
        {
            giocatoreSuccessivoUI.text = PassaggioDati.giocatoriAttuali[PassaggioDati.numGiocatoreAttuale+1].ToUpper();
        }
        else
        {
            giocatoreSuccessivoUI.text = PassaggioDati.giocatoriAttuali[0].ToUpper();
        }



        giocatoreAttualeUI.text = giocatoreAttuale.ToUpper();
        parolaAssociataUI.text = parolaAssociata.ToUpper();
    }

    /* FUNZIONI DI CAMBIO SCHERMATA ---------------------------- */

    //passa alla schermata intermezzo
    public void SetIntermezzoScreenActive()
    {
        schermataPartita.SetActive(false);
        schermataIntermezzo.SetActive(true);

        isIntermezzo = true;

        playerInputSwipe.GetComponent<PlayerInput>().setSwipeEnabled(false);
    }

    //dalla schermata intermezzo ritorna a quella di gioco con il giocatore attuale, senza alterare i dati
    public void GoBack()
    {
        schermataIntermezzo.SetActive(false);

        schermataPartita.SetActive(true);

        isIntermezzo = false;

        playerInputSwipe.SetActive(true);
        playerInputSwipe.GetComponent<PlayerInput>().setSwipeEnabled(true);
        playerInputSwipe.GetComponent<PlayerInput>().setTapEnabled(true);
    }

    //dalla schermata intermezzo va a quella di gioco con il giocatore successivo, alterando i dati
    public void GoNext()
    {
        schermataIntermezzo.SetActive(false);

        PassaggioDati.numGiocatoreAttuale++;
        GestisciDati();

        schermataPartita.SetActive(true);

        isIntermezzo = false;

        playerInputSwipe.GetComponent<PlayerInput>().setSwipeEnabled(true);
    }

    //breve sospensione del touch per evitare che un veloce doppio tap possa far passare due volte il turno
    IEnumerator InputWaitTime()
    {
        playerInputSwipe.GetComponent<PlayerInput>().setTapEnabled(false);
        yield return new WaitForSeconds(inputDeactivationTime);
        playerInputSwipe.GetComponent<PlayerInput>().setTapEnabled(true);
    }

    /* FUNZIONI MENU DI PAUSA ---------------------------- */

    public void Pause()
    {
        gameIsPaused = true;

        pauseMenu.SetActive(true);
        parolaAssociataObj.SetActive(false);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;

        playerInputSwipe.GetComponent<PlayerInput>().setTapEnabled(false);
        playerInputSwipe.GetComponent<PlayerInput>().setSwipeEnabled(false);
    }
    public void Resume()
    {
        gameIsPaused = false;
        
        pauseMenu.SetActive(false);
        parolaAssociataObj.SetActive(true);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;

        playerInputSwipe.SetActive(true);
        playerInputSwipe.GetComponent<PlayerInput>().setTapEnabled(true);
        playerInputSwipe.GetComponent<PlayerInput>().setSwipeEnabled(true);
    }

    /* ------------------------------ */

    public void TapAction()
    {
        if(isIntermezzo) 
        {
            soundManager.GetComponent<SoundPlayer>().PlayTurnStartSound();
            GoNext();
        }
        else
        {
            soundManager.GetComponent<SoundPlayer>().PlayPassPlayerSound();
            SetIntermezzoScreenActive();
        }
    }
}
