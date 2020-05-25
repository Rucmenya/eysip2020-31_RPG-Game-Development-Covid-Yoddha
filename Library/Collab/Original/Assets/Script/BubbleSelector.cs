using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSelector : MonoBehaviour
{
    Animator Anim;
    public NPC npc;

    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (npc.tested == true)
        {
            Anim.SetInteger("Stage", npc.InfectionStage);
        }
        else 
        {
            Anim.SetInteger("Stage", 0);
        }
    }
}
