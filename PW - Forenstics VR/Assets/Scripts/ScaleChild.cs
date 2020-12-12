using UnityEngine;


public class ScaleChild : MonoBehaviour
{
    public float scaleNew = .2f;
    //public bool canScale { get; set; } = true;
    //public bool canInteract = true;

    private Collider objectToScale; 
    private Vector3 startScale;
    private Vector3 newScale;

    private void Start()
    {
        startScale = new Vector3(0, 0, 0);
    }

    void OnTriggerEnter(Collider col)
    {
        objectToScale = col;
        if (startScale == Vector3.zero)
        {
            startScale = col.transform.localScale;
        }
        
    }

    public void ScaleObject()
    {
        if (objectToScale != null)
        {
            newScale = startScale * scaleNew;
            objectToScale.transform.localScale = newScale;

        }
        
    }


    public void ReturnScale()
    {
        if (objectToScale != null)
        {
            objectToScale.transform.localScale = startScale;
            startScale = new Vector3(0, 0, 0);
        }
       
    }
}
