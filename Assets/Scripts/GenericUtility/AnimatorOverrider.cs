using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorOverrider : MonoBehaviour
{
    /** AnimatorOverrider:
    *   genera un overrider che prende il controllo del controller dell'animator di base.
    *   Permette, in altre parole, di avere copie dell'animator originale, mantenendo
    *   la stessa struttura ma potendo alterare le animazioni riprodotte.
    */

    public Animator animator;
    public AnimatorOverrideController overrideController;

    public void SetNewAnimator()
    {
        animator.runtimeAnimatorController = overrideController;
    }
}
