using UnityEngine;
using UnityEngine.UI;

public class RoundButtonScript : MonoBehaviour
{
    /*

    public Button[] m_roundButtons;

    //posizione del bottone
    private Vector2 posizioneBottone;
    private GameObject currCircle;
    private RectTransform currRect;
    private Image currImg;

    public float moltiplicatore;
    public int spostamento;
    
    private int i;


    public void spostaSinistra()
    {
        for(int i = 0; i < m_roundButtons.Length; i++)
        {
            currRect = m_roundButtons[i].gameObject.GetComponent<RectTransform>();
            currCircle = m_roundButtons[i].gameObject.transform.GetChild(0).gameObject;
            currImg = currCircle.GetComponent<Image>();
            sposta(Vector3.left);
        }
        
    }

    public void spostaDestra()
    {
        for(int i = 0; i < m_roundButtons.Length; i++)
        {
            currRect = m_roundButtons[i].gameObject.GetComponent<RectTransform>();
            currCircle = m_roundButtons[i].gameObject.transform.GetChild(0).gameObject;
            currImg = currCircle.GetComponent<Image>();
            sposta(Vector3.right);
        }
    }

    private void sposta(Vector3 direzione)
    {
        currRect.Translate(moltiplicatore*spostamento*direzione);
        posizioneBottone = currRect.anchoredPosition;

        //colora
        if(posizioneBottone.x == 0)
        {
            currImg.color = new Color32(255,255,255,255);
        }
        else
        {
            currImg.color = new Color32(197,197,197,255);
        }
    }
*/
}
