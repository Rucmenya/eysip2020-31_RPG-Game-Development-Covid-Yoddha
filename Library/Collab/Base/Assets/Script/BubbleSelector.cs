using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSelector : MonoBehaviour
{
    Animator Anim;
    public NPC npc;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
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
