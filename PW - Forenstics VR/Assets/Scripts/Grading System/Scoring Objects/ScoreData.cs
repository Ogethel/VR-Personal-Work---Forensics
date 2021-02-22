using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ScoreData : MonoBehaviour
{

    [SerializeField] private BoolData _firstResponderCheck;
    [SerializeField] private GameAction _firstResponderCheckAction;
    [SerializeField] private IntDataSO _Score;

    public int Score = 0;

    public void Update()
    {

    }
    /*
    public void IncrementIfBool(bool canTrigger)
    {
        if (!boolData.Data) Increment();
    }
    */
}
