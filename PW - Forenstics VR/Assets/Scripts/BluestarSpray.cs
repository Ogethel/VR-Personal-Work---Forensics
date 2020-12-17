using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluestarSpray : MonoBehaviour
{
    public float speed = 5;
    public GameObject waterDroplet;
    public Transform nozzel;
    // public AudioSource audioSource;
    // public AudioClip audioClip;

    public void Spray()
    {
        GameObject spawnedDroplet = Instantiate(waterDroplet, nozzel.position, nozzel.rotation);
        spawnedDroplet.GetComponent<Rigidbody>().velocity = speed * nozzel.forward;
        Destroy(spawnedDroplet, 2);
    }
}
