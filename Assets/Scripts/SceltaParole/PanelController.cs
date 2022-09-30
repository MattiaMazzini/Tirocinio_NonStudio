using UnityEngine;
using TMPro;


public class PanelController : MonoBehaviour
{

    public GameObject sceltaParoleUI;
    public GameObject passaPanel;
    public TextMeshProUGUI nomePassaPanel;
    public TextMeshProUGUI nomeSuccessivoSceltaParole;
    private bool passaPanelIsActive = false;


    void Start()
    {
        passaPanel.SetActive(false);
    }

    public void CambiaSchermata()
    {

        //è attiva la schermata di pausa; attivo la schermata sceltaParole
        if (passaPanelIsActive)
        {
            passaPanel.SetActive(false);
            sceltaParoleUI.SetActive(true);

            passaPanelIsActive = false;
        }

        //è attiva la schermata di sceltaparole; attivo la schermata passaPanel
        else
        {
            sceltaParoleUI.SetActive(false);
            passaPanel.SetActive(true);

            nomePassaPanel.text = nomeSuccessivoSceltaParole.text;

            passaPanelIsActive = true;
        }
    }
}
