using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory List")]

public class InventoryListSO : ScriptableObject
{
    public List<GameObject> currentInventory = new List<GameObject>();

    public void Awake()
    {
        currentInventory.Clear();
    }

    public void AddToInvintory(AltSocketScaler activeSocket)
    {
        currentInventory.Add(activeSocket.objForSO);
    }

    public void SubFromInvintory(AltSocketScaler activeSocket)
    {
        currentInventory.Remove(activeSocket.objForSO);
    }
    //oreach (Collider c in invenAsset.GetComponentsInChildren<Collider>())
    public void ToggleInventoryOn()
    {
        for (int i = 0; i < currentInventory.Count; i++)
        {
           
            if (currentInventory[i].GetComponent<MeshRenderer>() != null)
            {
                currentInventory[i].GetComponent<MeshRenderer>().enabled = true;
                currentInventory[i].GetComponent<BoxCollider>().enabled = true;
            }

            foreach (Collider c in currentInventory[i].GetComponentsInChildren<Collider>())
            {
                c.enabled = true;
            }

            foreach (MeshRenderer c in currentInventory[i].GetComponentsInChildren<MeshRenderer>())
            {
                c.enabled = true;
            }
        }
    }

    public void ToggleInventoryOff()
    {
        for (int i = 0; i < currentInventory.Count; i++)
        {
            if (currentInventory[i].GetComponent<MeshRenderer>() != null)
            {
                currentInventory[i].GetComponent<MeshRenderer>().enabled = false;
                currentInventory[i].GetComponent<BoxCollider>().enabled = false;
            }

            foreach (Collider c in currentInventory[i].GetComponentsInChildren<Collider>())
            {
                c.enabled = false;
            }

            foreach (MeshRenderer c in currentInventory[i].GetComponentsInChildren<MeshRenderer>())
            {
                c.enabled = false;
            }
        }
    }

    /*
    public void ToggleInventory()
    {
        for (int i = 0; i < currentInventory.Count; i++)
        {
            if (currentInventory[i].GetComponent<MeshRenderer>().enabled == true)
            {
                currentInventory[i].GetComponent<MeshRenderer>().enabled = false;
                currentInventory[i].GetComponent<BoxCollider>().enabled = false;
            }

            else
            {
                currentInventory[i].GetComponent<MeshRenderer>().enabled = true;
                currentInventory[i].GetComponent<BoxCollider>().enabled = true;
            }

        }
    }
    */
}
