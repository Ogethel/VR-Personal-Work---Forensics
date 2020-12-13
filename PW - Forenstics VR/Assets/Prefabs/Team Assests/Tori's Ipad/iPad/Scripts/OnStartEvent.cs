using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Events;

public class OnStartEvent : MonoBehaviour
{
    public UnityEvent Restart;
    // Start is called before the first frame update
    void Start()
    {
        Restart.Invoke();
    }

    
}
