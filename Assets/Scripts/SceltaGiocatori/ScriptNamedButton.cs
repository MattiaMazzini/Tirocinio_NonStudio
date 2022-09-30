using UnityEngine;
using TMPro;


public class ScriptNamedButton : MonoBehaviour
{

    //Script che gestisce il bottone con nome salvato come prefab del progetto

    //label presente nella scena ma nascosta per poter sfruttare le funzionalita' di input da tastiera
    public TMP_InputField testo;

    //isMe variabile per identificare quale bottone e' selezionato attualmente
    private bool isMe;

    void Start()
    {
        isMe = false;
        testo.onDeselect.AddListener(NotMeAnymore);
    }

    void Update()
    {
        //modifica il bottone cliccato insieme alla label di testo
        if(isMe)
        {
            gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = testo.text;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    //attiva la label nascosta (utilizzata per sfruttare le funzionalità built-in di unity per gli input da tastiera) e imposta isMe a true
    public void ChangeText()
    {
        testo.text = gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text;
        isMe = true;
        testo.ActivateInputField();
    }

    //imposta isMe a false
    void NotMeAnymore(string testo)
    {
        isMe = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    //imposta il testo del bottone nella label nascosta per non partire da un input vuoto
    public void SetTesto(TMP_InputField campo)
    {
        testo = campo;
    }

    //sovrascrive il testo del bottone con il testo dell'input field "testo"
    public void SetAsInputField()
    {
        gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = testo.text;
    }
}
