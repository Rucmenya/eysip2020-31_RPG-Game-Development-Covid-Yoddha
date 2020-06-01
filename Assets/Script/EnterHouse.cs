using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHouse : MonoBehaviour
{
    public string SceneName;
    public EXP Exp;
    public NPCManager Manager;
    public float offset = 1.5f;
    GameObject G;
    NPC Npc;
    private Inventory inv;
    public int HouseNo;
    public AudioClip DoorAudio;


    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.name == "HCWorker")
        {
            if (Manager.GetPosition())
            {
                inv = other.gameObject.GetComponent<Inventory>();
                inv.PLayAudioCharacter(DoorAudio);
                Exp.MapBasicPosition = new Vector2(transform.position.x, (transform.position.y - offset));
                //Debug.Log(Exp.MapBasicPosition);
                Exp.NPCInEnterHouse = GetNPCinHouse();
                SceneManager.LoadScene(SceneName);
            }     
        }
        else if(other.CompareTag("NPC"))
        {
            G = other.gameObject;
            G.SetActive(false);
            Npc = G.GetComponent<NPC>();
            Exp.NPCInHouse[Npc.NPCNumber] = HouseNo;
            Debug.Log(Npc.NPCNumber);
        }
    }

    int GetNPCinHouse()
    {
        int TotalNpc = 0;
        for (int t = 0; t <= 9;t++)
        { 
           if( Exp.NPCInHouse[t] == HouseNo)
            {
                TotalNpc += 1;
            }
        }

        return TotalNpc;
         
    }
}