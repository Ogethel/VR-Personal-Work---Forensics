using System.Collections;
using System.IO;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;


public class DrawingPage : MonoBehaviour
{

    //Code gotten from DitzelGames (youtube)
    public GameObject rayCastPoint;
    public GameObject Brush;
    public float BrushSize = 0.1f;
    public RenderTexture RTexture;
    public bool isActive = false;

    public LayerMask drawingPad;


    // Update is called once per frame
    void Update()
    {
        if(isActive == true)
        {
            RaycastHit hit;
            if (Physics.Raycast(rayCastPoint.transform.position, rayCastPoint.transform.forward, out hit, 100))
            {
                Instantiate(Brush);
                Quaternion activePointRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                Brush.transform.SetPositionAndRotation(hit.point, activePointRotation);
            }
        }
    }
    public void SetActive()
    {
        isActive = true;
        Debug.Log(isActive);
    }

    public void DeActivate()
    {
        isActive = false;
        Debug.Log(isActive);
    }
    //if (Physics.Raycast(rayCastPoint.transform.position, rayCastPoint.transform.forward, out hit, 100, drawingPad))
}