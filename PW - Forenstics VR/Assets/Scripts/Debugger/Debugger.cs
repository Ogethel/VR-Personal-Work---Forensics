using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class Debugger : ScriptableObject
{
   
    public void DebugLog(string eventNote)
    {
        Debug.Log(eventNote);
    }
}
