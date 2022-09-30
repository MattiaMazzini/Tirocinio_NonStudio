using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerInput : MonoBehaviour
{

    //Gestisce il sistema di input del giocatore, in particolare scatena eventi quando percepisce un tap o uno swipe

    public UnityEvent m_SwipeSinistra;
    public UnityEvent m_SwipeDestra;
    public UnityEvent m_SwipeGenerico;
    public UnityEvent m_SimpleTap;

    //isCircle variabile che identifica se siamo nella schermata di gioco, per scegliere se far partire o meno l'animazione del cerchio quando si trascina
    public bool isCircle;

    //Variabili per controllare l'attivazione delle azioni di tocco e di swipe
    private bool tapEnabled;
    private bool swipeEnabled;

    private Vector2 startTouchPosition;
    private Vector2 startLocalPos;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;
    private float touchStartTime = 0.0f;
    private bool isPointerOnUI;

    //Sensibilita' dello swipe e del tocco
    public float swipeRange;
    public float tapRange;

    public GameObject parent;

    public GameObject myPrefab;
    public GameObject myInst;

    void Start()
    {
        tapEnabled = true;
        swipeEnabled = true;

        if(m_SwipeSinistra == null)
            m_SwipeSinistra = new UnityEvent();

        if(m_SwipeDestra == null)
            m_SwipeDestra = new UnityEvent();

        if(m_SimpleTap == null)
            m_SimpleTap = new UnityEvent();
        
        if(parent == null) isCircle = false;
        else isCircle = true;
    }

    void Update()
    {
        Swipe();
        isPointerOnUI = EventSystem.current.IsPointerOverGameObject(0);
    }

    public void Swipe()
    {
        //Momento in cui viene iniziato il tocco con uno o piu dita (TouchPhase.Began)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
            
            touchStartTime = Time.time;

            if(isCircle)
            {
                if(swipeEnabled) {        
                    myInst = Instantiate(myPrefab) as GameObject;
                    myInst.transform.SetParent(parent.transform);
                    myInst.transform.position = new Vector3(startTouchPosition.x, startTouchPosition.y, 1);
                }
            }
        }

        //Momenti successivi all'inizio del tocco (TouchPhase.Moved)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && swipeEnabled)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 distance = currentPosition - startTouchPosition;

            if(isCircle && myInst != null)
            {
                myInst.transform.localScale = new Vector3(distance.magnitude, distance.magnitude, 1);
            }

            float gestureTime = Time.time - touchStartTime;

            if (!stopTouch)
            {
                

                if (distance.magnitude > swipeRange)
                {
                    //AZIONE CON SWIPE OVUNQUE
                    m_SwipeGenerico.Invoke();

                    stopTouch = true;
                }

                if (distance.x < -swipeRange)
                {
                    //swipe Left

                    //AZIONE CON SWIPE A SINISTRA
                    m_SwipeSinistra.Invoke();

                    stopTouch = true;
                }

                else if (distance.x > swipeRange)
                {
                    //swipe Right

                    //AZIONE CON SWIPE A DESTRA
                    m_SwipeDestra.Invoke();

                    stopTouch = true;
                }

                else if (distance.y > swipeRange)
                {
                    //swipe Up

                    //AZIONE CON SWAP IN ALTO

                    stopTouch = true;
                }

                else if (distance.y < -swipeRange)
                {
                    //swipe Down

                    //AZIONE CON SWAP IN BASSO

                    stopTouch = true;
                }
            }
        }

        //Momento in cui il tocco finisce (TouchPhase.Ended)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;

            if(isCircle && myInst != null) Destroy(parent.transform.Find("Circle(Clone)").gameObject);

            endTouchPosition = Input.GetTouch(0).position;
            Vector2 distance = endTouchPosition - startTouchPosition;

            if ((Mathf.Abs(distance.x) < tapRange && Mathf.Abs(distance.y) < tapRange) && tapEnabled)
            {
                //TAP ACTION
                m_SimpleTap.Invoke();
            }
        }
        
    }

    //Abilita/Disabilita il tocco
    public void setTapEnabled(bool status)
    {
        if(status == true)
        {
            StartCoroutine(PassaTempoTap(status));
        } else
        {
            tapEnabled = status;
        }
    }

    //Abilita/Disabilita lo swipe
    public void setSwipeEnabled(bool status)
    {
        if(status == true) {
            StartCoroutine(PassaTempoSwipe(status));
        } else
        {
            swipeEnabled = status;
        }
    }

    //Funzione ausiliaria per poter assegnare un tempo prima dell'attivazione o disattivazione del tap
    IEnumerator PassaTempoTap(bool status)
    {
        yield return new WaitForSeconds(0.6f);
        tapEnabled = status;
    }

    //Funzione ausiliaria per poter assegnare un tempo prima dell'attivazione o disattivazione dello swipe
    IEnumerator PassaTempoSwipe(bool status)
    {
        yield return new WaitForSeconds(0.6f);
        swipeEnabled = status;
    }

    //Distrugge i cerchi relativi all'animazione dello swipe nella schermata giocatori
    public void DestroyEccessCirlce()
    {
        if(isCircle && myInst != null) Destroy(parent.transform.Find("Circle(Clone)").gameObject);
    }


}
