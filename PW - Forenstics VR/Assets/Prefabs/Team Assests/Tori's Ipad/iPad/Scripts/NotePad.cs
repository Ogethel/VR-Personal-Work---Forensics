using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class NotePad : MonoBehaviour

{
    public Buttons ChangeWords;
    
    public TextMeshProUGUI Text;
   
    // Update is called once per frame
    void Update()
    {
        Text.text = ChangeWords.keyBoard;
    }

    
}
