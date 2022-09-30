using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Analytics;
using Firebase;

public class test_log_firebase_script : MonoBehaviour
{

    //script che gestisce il log, all'inizio e fine partita, di eventi su firebase

    public void logLevelStart()
    {
        Firebase.Analytics.FirebaseAnalytics.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLevelStart);
    }

    public void logLevelEnd()
    {
        Firebase.Analytics.FirebaseAnalytics.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLevelEnd);
    }

}
