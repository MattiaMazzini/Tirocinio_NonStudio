using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.Localization.Settings;

public class RegolScript : MonoBehaviour
{
    /** RegolScript:
    *   imposta un array per le regole e permette, tramite funzioni apposite Avanti() e Indietro(),
    *   di passare da una pagina all'altra delle regole, con annessa animazione.
    *   Addizionalmente, "uscendo" tramite swipe dai limiti dell'array (ovvero facendo
    *   swipe a sinistra nella prima pagina e swipe a destra nell'ultima pagina delle regole)
    *   si ritorna al Main Menu.
    */
    public TextMeshProUGUI m_Testo;

    private int step;
    private const int MAXREGOLE = 7;
    
    //elenco del testo delle pagine del regolamento
    private string[] regole;
    public Image selectedDot;
    public Image otherDot;
    private Image[] pageDots;
    public GameObject pageNumber;
    public UnityEvent toMainMenu;
    public Animator anima;
    public TextMeshProUGUI m_TestoSotto;
    public GameObject hand;

    void Start()
    {

        regole = new string[MAXREGOLE];
        pageDots = new Image[MAXREGOLE];
        pageDots = pageNumber.GetComponentsInChildren<Image>();

        for (int i = 0; i < MAXREGOLE; i++)
        {
            if (i == 0) pageDots[i].GetComponent<Image>().sprite = selectedDot.sprite;
            else pageDots[i].GetComponent<Image>().sprite = otherDot.sprite;
        }
        //inserimento delle regole
        if (LocalizationSettings.SelectedLocale.Identifier == "it")
        {
            regole[0] = "Si incomincia scegliendo la modalità di gioco:\n\nClassica o Veloce.";
            regole[1] = "Classica: inserite i vostri nomi.\nA turno dovrete poi inserire una parola (o farvene assegnare una casuale) che qualcun altro dovrà indovinare!";
            regole[2] = "Veloce: inserite soltanto i vostri nomi e cominciate subito con parole completamente casuali!";
            regole[3] = "Si comincia!\n\nScopo del gioco è indovinare la parola che vi è stata assegnata, facendo agli altri una singola domanda per turno con risposta 'Sì' o 'No'.";
            regole[4] = "Alternativamente, puoi provare a indovinare la tua parola: nel caso in cui tu non ci prenda, passi il turno.";
            regole[5] = "Se invece indovini... Complimenti!\n\nPuoi ancora partecipare al gioco, rispondendo alle domande degli altri.";
            regole[6] = "La partita termina quando ogni giocatore ha indovinato la propria identità.\n\nBuona fortuna!";
        }
        if (LocalizationSettings.SelectedLocale.Identifier == "en")
        {
            regole[0] = "You begin by choosing the game mode:\n\nClassic or Quick.";
            regole[1] = "Classic: insert your names.\nOn your turn, you then have to type in a word (or let a random one be picked for you) that someone else has to guess!";
            regole[2] = "Quick: insert just your names and begin immediately with randomly assigned words!";
            regole[3] = "Let's start!\n\nGoal of the game is to guess the word that has been assigned to you, by making a single 'Yes or No?' question to the group once per turn.";
            regole[4] = "Alternatively, you may try to guess your word: if your guess is not correct, you have to pass the turn.";
            regole[5] = "If you guessed correctly... Congratulations!\n\nYou may still participate by answering questions from the others.";
            regole[6] = "The game is over when each player has guessed their word.\n\nGood luck!";
        }

        step = 0;
    }

    //avanti con gli step delle regole
    public void Avanti()
    {
        anima.SetBool("firstTime", false);
        Destroy(hand);

        step++;
        if(step < regole.Length) {
            anima.Play("CardMoveOut", -1, 1.0f);
            m_TestoSotto.text = regole[step];
            StartCoroutine(WaitModificaStep(0.4f));
        }
        else 
        {
            ModificaStep(step);
        }
        
    }

    IEnumerator WaitModificaStep(float time)
    {
        yield return new WaitForSeconds(time);
        ModificaStep(step);
    }


    //indietro con gli step delle regole
    public void Indietro()
    {

        step--;

        if(step > -1) {
            m_TestoSotto.text = regole[step+1];
            anima.Play("CardMoveIn", -1, 1.0f);
            ModificaStep(step);
        }
        else 
        {
            ModificaStep(step);
        }
    }

    //modifica lo step del regolamento
    void ModificaStep(int step)
    {
        for (int i = 0; i < MAXREGOLE; i++)
        {

            if (step < 0)
            {
                pageDots[0].GetComponent<Image>().sprite = selectedDot.sprite;
                toMainMenu.Invoke();
            }
            else if (step > MAXREGOLE-1)
            {
                pageDots[MAXREGOLE-1].GetComponent<Image>().sprite = selectedDot.sprite;
                toMainMenu.Invoke();
            }
            else
            {
                m_Testo.text = regole[step];
                if (i == step)
                {
                    pageDots[step].GetComponent<Image>().sprite = selectedDot.sprite;
                }
                else
                {
                    pageDots[i].GetComponent<Image>().sprite = otherDot.sprite;
                }
            }
        }
    }

}
