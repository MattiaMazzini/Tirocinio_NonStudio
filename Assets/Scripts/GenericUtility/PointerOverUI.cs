using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PointerOverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    /** PointerOverUI:
    *   verifica che il click non venga effettuato su un elemento di ui
    *   per distinguere gli eventi di tap o click su bottone.
    */

    public GameObject playerInput;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        playerInput.GetComponent<PlayerInput>().DestroyEccessCirlce();
        playerInput.SetActive(false);
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        playerInput.GetComponent<PlayerInput>().DestroyEccessCirlce();
        playerInput.SetActive(true);
    }


}
