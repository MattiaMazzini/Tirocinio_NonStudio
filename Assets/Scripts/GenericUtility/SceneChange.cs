using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{  

    //Script che gestisce il cambio delle scene

    public Animator transition;
    public float transitionTime = 1f;
    public string backScene = "";

    void Update()
    {
        //Se il bottone indetro e' premuto porta alla scena precedente
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!backScene.Equals(""))
            {
                StartCoroutine(LoadLevel(backScene));
            }
        }
    }

    //Cambia scena attuale con la scena indicata dal parametro
    public void Cambia(string scenaNuova)
    {
        StartCoroutine(LoadLevel(scenaNuova));
    }

    //Carica la scena (Utilizzato da Cambia per poter includere un tempo di transizione da una scena all'altra)
    IEnumerator LoadLevel(string scenaNuova)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scenaNuova);  
    }
    
}