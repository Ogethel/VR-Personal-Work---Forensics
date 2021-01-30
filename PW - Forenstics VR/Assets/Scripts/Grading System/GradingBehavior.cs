using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GradingBehavior : MonoBehaviour
{
    public UnityEvent onCollisionEnter;


    private void OnTriggerEnter(Collider other)
    {
        onCollisionEnter.Invoke();
    }
}
