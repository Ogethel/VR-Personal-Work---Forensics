using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class AppSwitcher : MonoBehaviour
{


    public UnityEvent EndOfTextEvent;
    
    //Call when AppPanel is opened
    
    public void OpenApp()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        GetComponent<CanvasGroup>().interactable = true;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    
    // call when next button is pressed
    
    public void CloseApp()
    {
        GetComponent<CanvasGroup>().alpha = 0;
        GetComponent<CanvasGroup>().interactable = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        EndOfTextEvent.Invoke();
    }
    
    
}
