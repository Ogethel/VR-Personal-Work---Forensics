using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;


public class VRMeasuringTape : MonoBehaviour
{
    [SerializeField]
    private GameObject measurementPointPrefab;

    [SerializeField]
    private float measurementFactor = 39.37f;

    [SerializeField]
    private Vector3 offsetMeasurement = Vector3.zero;

    [SerializeField]
    private TextMeshPro distanceText;

    [SerializeField]
    private Transform tapeMeasure;

    public float sphereSize = .2f;

    public bool objectToggle { get; set; } = true;

    public bool isRaycasting { get; set; } = false;

    private bool moveWRay = true;

    public LayerMask tapeMeasureOnly;

    public LayerMask exceptTapeMeasure;

    private LineRenderer measureLine;

    private GameObject activeObject;

    private GameObject startPoint;

    private GameObject endPoint;

    private void Awake()
    {
        distanceText.text = "Distance:";

        moveWRay = false;
        isRaycasting = false;

        tapeMeasure = gameObject.transform;

        startPoint = Instantiate(measurementPointPrefab, Vector3.zero, Quaternion.identity);
        endPoint = Instantiate(measurementPointPrefab, Vector3.zero, Quaternion.identity);

        measureLine = GetComponent<LineRenderer>();

        startPoint.SetActive(false);
        startPoint.SetActive(false);
    }

    private void OnEnable()
    {
        if (measurementPointPrefab == null)
        {
            Debug.LogError("measurePointPrefab must be Set");
            enabled = false;
        }
    }

    void Update()
    {
        //Vector3 dir = tapeMeasure.forward;
        //Ray ray = new Ray(tapeMeasure.position, dir);
        //RaycastHit initialhit = Physics.Raycast(ray.origin, ray.direction, 100, tapeMeasureOnly);

        RaycastHit hit;

        if (isRaycasting)
        {
           
            if (Physics.SphereCast(tapeMeasure.transform.position, sphereSize, tapeMeasure.forward, out hit, 100, tapeMeasureOnly))
            {
                if (hit.collider != null)
                {
                    activeObject = hit.collider.gameObject;
                    moveWRay = true;
                }
            }

            else
            {
                if (objectToggle)
                {
                    activeObject = endPoint;
                    moveWRay = true;
                    ToggleActivePointObject();
                }

                if (!objectToggle)
                {
                    activeObject = startPoint;
                    moveWRay = true;
                    ToggleActivePointObject();
                }
                
            }
        }

        MoveMeasurementPoints();


        if (startPoint.activeSelf && endPoint.activeSelf)
        {
            distanceText.transform.position = endPoint.transform.position + offsetMeasurement;
            distanceText.transform.rotation = endPoint.transform.rotation;
            measureLine.SetPosition(0, startPoint.transform.position);
            measureLine.SetPosition(1, endPoint.transform.position);

            distanceText.text = $"Distance: {(Vector3.Distance(startPoint.transform.position, endPoint.transform.position) * measurementFactor).ToString("F2")} in";
        }
    }

    void MoveMeasurementPoints()
    {
        RaycastHit hit;
        if (moveWRay && isRaycasting)
        {

            if (Physics.Raycast(tapeMeasure.transform.position, tapeMeasure.forward, out hit, 100, exceptTapeMeasure))
            {
                measureLine.gameObject.SetActive(true);
                startPoint.SetActive(true);
                endPoint.SetActive(true);

                Quaternion activePointRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                activeObject.transform.SetPositionAndRotation(hit.point, activePointRotation);
            }
        }
        else
        {
            moveWRay = false;
        }
    }

    void ToggleActivePointObject()
    {
        if (objectToggle)
        {
            objectToggle = false;
        }
        if (!objectToggle)
        {
            objectToggle = true;
        }
    }
}
