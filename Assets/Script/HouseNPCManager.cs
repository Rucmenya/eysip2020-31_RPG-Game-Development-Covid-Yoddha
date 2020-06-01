using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseNPCManager : MonoBehaviour
{
    public EXP Exp;
    public GameObject NPC1 , Position;
    GameObject NPC ;
    int TotalNPC;
    // Start is called before the first frame update
    void Start()
    {
        TotalNPC = Exp.NPCInEnterHouse;

        while (TotalNPC != 0)
        {
            NPC = Instantiate(NPC1) as GameObject;
            NPC.transform.position = Position.transform.position;
            TotalNPC -= 1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
