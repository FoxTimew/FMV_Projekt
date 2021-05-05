using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Event")]
public class EventBehaviour : ScriptableObject
{
    public void TestEvent()
    {
        Debug.Log("Test Event Réussi");
        
        Destroy(References.instance.testGameObject);
        
        //Une fois déclaré dans References :
        //References.instance. ...
    }

    public void TestEvent2()
    {
        Debug.Log("Test Event 2 Réussi");
    }

    public void TestEvent3()
    {
        Debug.Log("Test Event 3 Réussi");
    }
}
