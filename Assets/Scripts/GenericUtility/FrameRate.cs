using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour
{
    //Imposta il target framerate a 60fps

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

}
