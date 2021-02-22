using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class BoolData : ScriptableObject
{
    public bool Data;

    public void SetTrue()
    {
        Data = true;
    }

    public void SetFalse()
    {
        Data = false;
    }

    public void ToggleData()
    {
        Data = !Data;
    }
}
