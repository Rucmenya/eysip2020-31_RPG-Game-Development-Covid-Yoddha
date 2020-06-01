using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endpoint : MonoBehaviour
{
 
    //public string SceneName;
    public EXP Exp;
    Inventory inv;
    public AudioClip DoorAudio;


    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.name == "HCWorker")

        {
            other.gameObject.transform.position = Exp.MapBasicPosition;
            inv = other.gameObject.GetComponent<Inventory>();
            inv.PLayAudioCharacter(DoorAudio);
            other.transform.position = Exp.MapBasicPosition;
           // SceneManager.LoadScene(SceneName);



        }
    }
}
