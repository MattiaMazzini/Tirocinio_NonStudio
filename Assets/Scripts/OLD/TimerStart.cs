using UnityEngine;



public class TimerStart : MonoBehaviour
{
    /*

    private const int DEFAULTTIME = 5;
    private int countdownTime = DEFAULTTIME;
    public TextMeshProUGUI countdownText;
    public UnityEvent timerEnd;

    void Start()
    {

        if(timerEnd == null)
            timerEnd = new UnityEvent();

        StartCoroutine(CountdownToStart());

    }
    public void SetTime(int seconds)
    {
        this.countdownTime = seconds;
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        //quando countdownTime raggiunge 0
        countdownText.text = "VIA!";
        
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);
        timerEnd.Invoke();
    }
*/
}