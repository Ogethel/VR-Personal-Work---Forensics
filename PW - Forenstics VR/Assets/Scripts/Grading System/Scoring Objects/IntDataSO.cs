using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class IntDataSO : ScriptableObject
{
    public BoolData boolData;
    public int Data;

    public void Increment()
    {
        Data += 1;
    }

    public void IncrementIfBool(BoolData canTrigger)
    {
        if (!canTrigger.Data) Increment();     
    }
}
