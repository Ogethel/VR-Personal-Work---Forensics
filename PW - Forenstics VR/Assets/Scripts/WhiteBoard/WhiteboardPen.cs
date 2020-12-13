using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteboardPen : MonoBehaviour
{
    public GameObject penTip;
    public WhiteBoard whiteboard;
    private RaycastHit touch;


    // Start is called before the first frame update
    void Start()
    {
        this.whiteboard = GameObject.Find("Whiteboard").GetComponent<WhiteBoard>();
    }

    // Update is called once per frame
    void Update()
    {
        float tipHeight = penTip.transform.localScale.y;
        Vector3 tip = penTip.transform.position;

        if (Physics.Raycast(tip, transform.up, out touch, tipHeight))
        {
            if (!(touch.collider.tag == "Whiteboard"))
            {
                return;
            }

            this.whiteboard = touch.collider.GetComponent<WhiteBoard>();
            Debug.Log("Touching");
        }
    }
}
