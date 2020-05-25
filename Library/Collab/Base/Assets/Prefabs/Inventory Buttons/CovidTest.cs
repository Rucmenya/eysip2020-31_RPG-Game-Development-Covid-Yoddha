using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CovidTest : MonoBehaviour
{
    CharecterMovement collisionReference;
    NPC npc;

    void Start()
    {
        collisionReference = GameObject.FindGameObjectWithTag("Player").GetComponent<CharecterMovement>();
    }

    public void useKit()
    {
        npc=GameObject.Find(collisionReference.tempNpcName).GetComponent<NPC>();
        npc.tested = true;
        Destroy(gameObject);
    }

    public void UseLowDrug()
    {
        npc = GameObject.Find(collisionReference.tempNpcName).GetComponent<NPC>();
        if (npc.InfectionStage >= 1)
        {
            npc.DrugApplied[0] = 1 ;
        }
        
        Destroy(gameObject);
    }

    public void UseHighDrug()
    {
        npc = GameObject.Find(collisionReference.tempNpcName).GetComponent<NPC>();
        if (npc.InfectionStage >= 1)
        {
            npc.DrugApplied[0] = 1;
        }
        Destroy(gameObject);
    }


}
