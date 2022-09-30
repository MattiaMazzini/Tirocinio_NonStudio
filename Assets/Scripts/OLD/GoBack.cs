using UnityEngine;

public class GoBack : MonoBehaviour
{/*
    //l'ultima string nella lista è la scena corrente
    private Stack<int> loadedScenes;
    private bool initialized;

    private void Init()
    {
        loadedScenes = new Stack<int>();
        initialized = true;
    }
    //b
    public void LoadScene (int buildIndex)
    {
        if (!initialized) Init();
        loadedScenes.Push(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(buildIndex);
    }

    public void LoadScene (string sceneName)
    {
        if (!initialized) Init();
        loadedScenes.Push(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(sceneName);
    }

    public void PreviousScene()
    {
        if (!initialized) Init();

        if (loadedScenes.Count > 0)
        {
            SceneManager.LoadScene(loadedScenes.Pop());
        }
        else
        {
            Application.Quit();
        }
    }
    */
}
