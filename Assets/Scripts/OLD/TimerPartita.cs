using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
/*
public class TimerPartita : MonoBehaviour
{    
    private int countdownTime;
    public TextMeshProUGUI countdownText;
    public UnityEvent timerEnd;
    public bool active = false;
    public Animator transition;
    public float transitionTime = 1f;

    void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("Inizio Round"))
        {
            ActivateTimer();
        }
    }
    

    public void ActivateTimer()
    {
        SetTime();

        active = true;
        if(timerEnd == null) timerEnd = new UnityEvent();

        StartCoroutine(CountdownToStart());
    }

    public void ResetTimer()
    {
        SetTime();
        StopAllCoroutines();
        active = false;
    }

    public void SetTime()
    {
        countdownTime = PlayerPrefs.GetInt("timer", 3);
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0 && active == true)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        if (countdownTime == 0 && active == true)
        {
            //quando countdownTime raggiunge 0
            countdownText.text = "";

            yield return new WaitForSeconds(1f);
            ResetTimer();

            timerEnd.Invoke();
        }
    }
}
*/