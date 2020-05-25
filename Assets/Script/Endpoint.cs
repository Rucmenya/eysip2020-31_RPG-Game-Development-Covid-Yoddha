using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endpoint : MonoBehaviour
{
 
    public string SceneName;


    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.name == "HCWorker")

        {
            
           
            
#pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel(SceneName);
#pragma warning restore CS0618 // Type or member is obsolete


        }
    }
}
