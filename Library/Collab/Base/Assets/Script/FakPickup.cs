using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakPickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject fakButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Hit");
           
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(fakButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;   
                }
            }
        }
    }
}
