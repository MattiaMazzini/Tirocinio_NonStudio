using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDistinction : MonoBehaviour
{
    /** AnimationDistinction:
    *   nel Main Menu, distingue il tipo di animazione da riprodurre in due casi diversi:
    *   - se si sta avviando il gioco per la prima volta, fa animazione di default (fade);
    *   - se si torna al Main Menu da altre scene, fa altra animazione (cerchio al momento).
    */

    public Animator animator;
    private static bool firstTime = true;
    public GameObject crossfadeImage;

    void Awake()
    {
        if (firstTime)
        {
            animator.SetBool("firstTime", true);
            firstTime = false;
        }
        else
        {
            crossfadeImage.SetActive(false);
            animator.SetBool("firstTime", false);
        }
    }
}
