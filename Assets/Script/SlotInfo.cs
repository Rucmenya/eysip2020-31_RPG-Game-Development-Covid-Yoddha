using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotInfo : MonoBehaviour
{
    public int slotNo;
    public Inventory inventory;
        
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[slotNo] = false;
        }
    }
}
