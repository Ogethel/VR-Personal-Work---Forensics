using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

[CreateAssetMenu]

public class Buttons : ScriptableObject
{
    public string keyBoard;
    public TextMeshProUGUI Texting;


    public void Words(string Character)
    {
        keyBoard += Character;

    }

    public void ClearString()
    {
        keyBoard = "";
    }

    public void backSpace()
    {
        if (keyBoard.Length == 0)
        {
            return;
        }
        else
        {

            var count = keyBoard.Length;


            keyBoard = keyBoard.Remove(keyBoard.Length - 1);
        }
    }

}