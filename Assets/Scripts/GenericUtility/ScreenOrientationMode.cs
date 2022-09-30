using System.Collections;
using UnityEngine;

public class ScreenOrientationMode : MonoBehaviour
{
    /** ScreenOrientationMode:
    *   Cambia la rotazione dello schermo in modo forzato, rispettando
    *   i tempi di animazione delle transizioni.
    */

    public void Landscape()
    {
        StartCoroutine(ChangeRotation(1));
    }

    public void Portrait()
    {
        StartCoroutine(ChangeRotation(0));
    }

    //I TEMPI DI WAITFORSECONDS SONO ESATTAMENTE COME I TEMPI DI ANIMAZIONE, MENO 0,05s
    //COSI' FUNZIONA, SE NO ASPETTA PER TROPPO TEMPO E NON FA LA ROTAZIONE
    IEnumerator ChangeRotation(int i)
    {
        if (i == 0)
        {
            yield return new WaitForSeconds(0.45f);
            Screen.orientation = ScreenOrientation.Portrait;
        }
        if (i == 1)
        {
            yield return new WaitForSeconds(0.45f);
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
    }
}