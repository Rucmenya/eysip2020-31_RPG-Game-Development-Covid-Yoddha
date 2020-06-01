using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseInventoryItem : MonoBehaviour
{
    CharecterMovement collisionReference;
    NPC npc;
    private Inventory inventory;
    public GameObject effect;
    Transform player;
    public AudioClip CovidKit, PPE, LowDrug, HighDrug, FirstAidKit , Mask;

    void Start()
    {
        collisionReference = GameObject.FindGameObjectWithTag("Player").GetComponent<CharecterMovement>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void UseKit()
    {
        if (collisionReference.tempNpcName != null)
        {
            inventory = FindObjectOfType<Inventory>().GetComponent<Inventory>();
            inventory.PLayAudioCharacter(CovidKit);
            npc = GameObject.Find(collisionReference.tempNpcName).GetComponent<NPC>();
            npc.tested = true;
            Destroy(gameObject);
        }
    }

    public void UseLowDrug()
    {
        if (collisionReference.tempNpcName != null)
        {
            npc = GameObject.Find(collisionReference.tempNpcName).GetComponent<NPC>();
            if (npc.InfectionStage >= 1)
            {
                inventory = FindObjectOfType<Inventory>().GetComponent<Inventory>();
                inventory.PLayAudioCharacter(LowDrug);
                npc.DrugApplied = 1;
               
            }
            Destroy(gameObject);
        }
    }

    public void UseModerateDrug()
    {
        if (collisionReference.tempNpcName != null)
        {
            npc = GameObject.Find(collisionReference.tempNpcName).GetComponent<NPC>();
            if (npc.InfectionStage >= 1)
            {
                inventory = FindObjectOfType<Inventory>().GetComponent<Inventory>();
                inventory.PLayAudioCharacter(HighDrug);
                npc.DrugApplied = 2;
        
            }
            Destroy(gameObject);
        }
    }
    public void UseMask()
    {

        if (collisionReference.tempNpcName == null)
        {
            inventory = FindObjectOfType<Inventory>().GetComponent<Inventory>();
            inventory.PLayAudioCharacter(Mask);
            Destroy(gameObject);
            collisionReference.Mask = true;

        }
        else
        {
            inventory = FindObjectOfType<Inventory>().GetComponent<Inventory>();
            inventory.PLayAudioCharacter(Mask);
            npc = GameObject.Find(collisionReference.tempNpcName).GetComponent<NPC>();
            npc.Mask = true;
            Destroy(gameObject);
        }
    }

    public void UseFAK()
    {
        Instantiate(effect, player.position, Quaternion.identity);
        collisionReference.Health = 100;
        inventory = FindObjectOfType<Inventory>().GetComponent<Inventory>();
        inventory.PLayAudioCharacter(FirstAidKit);
        Destroy(gameObject);
    }

    public void UsePPEKit()
    {
        inventory = FindObjectOfType<Inventory>().GetComponent<Inventory>();
        inventory.PLayAudioCharacter(PPE);
        collisionReference.PPEKIT = true;
        Destroy(gameObject);
    }
}
