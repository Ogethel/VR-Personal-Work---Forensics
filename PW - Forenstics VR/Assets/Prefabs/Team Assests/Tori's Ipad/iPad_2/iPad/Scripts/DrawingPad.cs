using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingPad : MonoBehaviour
{
    //public GameObject drawingPad;
    public MarkerDraw drawingPad;
    private RaycastHit touch;
    private bool lastTouch;
    private Quaternion lastAngle;

    void Start()
    {
        this.drawingPad = GameObject.Find("DrawingPad").GetComponent<MarkerDraw>();
    }

    void Update()
    {
        float tipHeight = transform.Find("Tip").transform.localScale.y;
        Vector3 tip = transform.Find("Tip").transform.position;

        if (lastTouch)
        {
            tipHeight *= 1.1f;
        }

        if (Physics.Raycast(tip, transform.up, out touch, tipHeight))
        {
            if (!(touch.collider.tag == "DrawingPad"))
                return;

            this.drawingPad = touch.collider.GetComponent<MarkerDraw>();
          //  controllerActions.TriggerHapticPulse(0.05f);

            this.drawingPad.SetColor(Color.black);
            this.drawingPad.SetTouchPosition(touch.textureCoord.x, touch.textureCoord.y);
            this.drawingPad.ToggleTouch(true);

            if (!lastTouch)
            {
                lastTouch = true;
                lastAngle = transform.rotation;
            }
            
        }
        else
        {
            this.drawingPad.ToggleTouch(false);
            lastTouch = false;
            
        }

        if (lastTouch)
        {
            transform.rotation = lastAngle;
        }
       
    }

 //  public override void Grab(GameObject grabbingObject)
  // {
    //   base.Grab (grabbingObject);
       
   //}
}