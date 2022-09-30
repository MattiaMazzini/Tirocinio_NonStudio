using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    /** OpenLink:
    *   apre il link passato alla funzione.
    */

    public void OpenLinkOnClick(string link)
    {
        Application.OpenURL(link);
    }
}
