using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHousev2 : MonoBehaviour
{

    public EXP Exp;
    public NPCManager Manager;
    public float yoffset = 1.5f , xoffset = 1.5f;
    NPC Npc;
    private Inventory inv;
    public int HouseNo;
    public AudioClip DoorAudio;
    public GameObject SetPoint;
    Material SofaMat;


    private void OnTriggerStay2D(Collider2D other)
    {
       // Debug.Log("Playercollide");
        if (other.gameObject.name == "HCWorker")
        {
                inv = other.gameObject.GetComponent<Inventory>();
                inv.PLayAudioCharacter(DoorAudio);
                Exp.MapBasicPosition = new Vector2((transform.position.x - xoffset), (transform.position.y - yoffset));
                Debug.Log(SetPoint.transform.position);
                Exp.NPCInEnterHouse = GetNPCinHouse();
                other.gameObject.transform.position = SetPoint.transform.position;
           
        }
        else if (other.CompareTag("NPC"))
        {

            other.gameObject.transform.position = SetPoint.transform.position;
            Npc = other.gameObject.GetComponent<NPC>();
            Exp.NPCInHouse[Npc.NPCNumber] = HouseNo;
            Npc.CurrentlyInHouse = HouseNo;
            Debug.Log(Npc.NPCNumber);
        }
    }

    int GetNPCinHouse()
    {
        int TotalNpc = 0;
        for (int t = 0; t <= 9; t++)
        {
            if (Exp.NPCInHouse[t] == HouseNo)
            {
                TotalNpc += 1;
            }

            
        }
        SofaMat = GameObject.Find("Sofa" + HouseNo.ToString()).GetComponent<SpriteRenderer>().material;
        SofaMat.SetFloat("_Selector", TotalNpc);

        return TotalNpc;

    }
}