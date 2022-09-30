using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic instance;

    /** BackgroundMusic:
    *   La funzione Awake (applicabile tra l'altro a qualsiasi altro gameObject per cui si voglia adottare questo comportamento)
    *   attiva il gameObject a cui lo script è legato e poi verifica il valore di instance:
    *   - se instance è null, allora gli assegna un valore (alla prima invocazione della funzione, sostanzialmente); quindi all'avvio
    *   parte la musica.
    *   - se instance ha un valore (this), quindi è un'invocazione successiva alla prima, qualsiasi nuovo gameObject viene distrutto;
    *   quindi tutte le volte in cui ripartirebbe la funzione (= ogni volta che si torna a Home, dato che l'oggetto contenente lo script
    *   è solo lì), la funzione si attiva ma questo nuovo gameObject viene distrutto, lasciando solo il primo.
    */
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
