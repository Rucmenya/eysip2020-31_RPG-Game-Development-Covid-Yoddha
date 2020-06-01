using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject Button;
    Animator Anim;
    public int ItemNo;
    public AudioSource Source;
    public AudioClip Spawn, PickUp;
   
    private void Start()
    {
        
        Anim = GetComponent<Animator>();
        Source = GetComponent<AudioSource>();
        Source.clip = Spawn;
        Source.Play();
        Anim.SetInteger("Item" ,ItemNo );
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            inventory = FindObjectOfType<Inventory>().GetComponent<Inventory>();
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.PLayAudioCharacter(PickUp);
                    inventory.isFull[i] = true;
                    Instantiate(Button, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;   
                }
            }
        }
    }
}
