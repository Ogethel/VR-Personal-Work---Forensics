using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDroplets : MonoBehaviour
{

    public Transform spawnPoint;
    public GameObject waterTexture;
    public LayerMask canHit;
    public float offsetVal = .5f;
    private bool hasAlreadyCollided = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasAlreadyCollided)
        {
            if ((canHit.value & 1<<other.gameObject.layer) ==1<<other.gameObject.layer)
            {
                hasAlreadyCollided = true;
                Vector3 newInsTransform = new Vector3(0, offsetVal, 0);
                GameObject newTexture;
                newTexture = Instantiate(waterTexture, this.transform.position + newInsTransform, Quaternion.identity);
            }
        }
    }

}
