using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startpoint : MonoBehaviour
{
    private CharecterMovement HCWorker;
  
    void Start()
    {
        HCWorker = FindObjectOfType<CharecterMovement>();
        HCWorker.transform.position =new Vector2( transform.position.x ,transform.position.y);   
    }
}
