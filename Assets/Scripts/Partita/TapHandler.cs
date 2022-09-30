using UnityEngine;
using UnityEngine.Events;

public class TapHandler : MonoBehaviour
{
    /** TapHandler:
    *   lancia un evento diverso a seconda di quale delle due schermate è attiva
    */
    public static bool timerScreenOn = false;

    public UnityEvent tapOnTimerScreen;
    public UnityEvent tapOnPartitaScreen;

    public void HandleTap()
    {
        if (timerScreenOn) TimerScreenTap();
        else PartitaScreenTap();
    }

    public void TimerScreenTap()
    {
        timerScreenOn = true;
        tapOnTimerScreen.Invoke();
    }

    public void PartitaScreenTap()
    {
        timerScreenOn = false;
        tapOnPartitaScreen.Invoke();
    }
}
