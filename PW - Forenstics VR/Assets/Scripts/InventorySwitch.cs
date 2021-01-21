using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySwitch : MonoBehaviour
{
    public LayerMask canStore;

    public void InventoryOff()
    {
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, canStore);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            Debug.Log(hitColliders);
        }
    }

    //public List<GameObject> curInventory;

    //public LayerMask canStore;

    //private void Start()
    //{
    //    curInventory = new List<GameObject>();
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if ((canStore.value & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
    //    {
    //        curInventory.Add(other.gameObject);
    //        Debug.Log(curInventory);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if ((canStore.value & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
    //    {
    //        curInventory.Remove(other.gameObject);
    //        Debug.Log(curInventory);
    //    }
    //}

    //public void InventoryOff()
    //{
    //    for (int i = 0; i < curInventory.Count; i++)
    //    {
    //        GameObject curInventory(i)
    //    }
    //}

    //Ctrl K + C will comment your current selection. Ctrl K + U will uncomment it.
}
