using UnityEngine.Events;
using UnityEngine;

public class OnMouseEvent : MonoBehaviour
{
    public UnityEvent MouseDown;
    public UnityEvent MouseUp;
	
    private void OnMouseDown()
    {
        MouseDown.Invoke();
    }
    private void OnMouseUp()
    {
        MouseUp.Invoke();
    }
}