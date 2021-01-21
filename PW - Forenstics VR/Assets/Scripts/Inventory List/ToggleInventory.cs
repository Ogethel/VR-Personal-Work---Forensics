using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Invin Toggle")]

public class ToggleInventory : ScriptableObject
{

    public void TurnAssetOn(GameObject invenAsset)
    {
        invenAsset.GetComponent<MeshRenderer>().enabled = true;

        foreach (Collider c in invenAsset.GetComponentsInChildren<Collider>())
        {
            c.enabled = true;
        }
    }

    public void TurnAssetOff(GameObject invenAsset)
    {
        invenAsset.GetComponent<MeshRenderer>().enabled = false;

        foreach (Collider c in invenAsset.GetComponentsInChildren<Collider>())
        {
            c.enabled = false;
        }
    }

    //invenAsset.GetComponentInChildren<SphereCollider>().enabled = false;
}
