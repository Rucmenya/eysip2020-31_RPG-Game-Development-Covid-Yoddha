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
  
    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.name == "HCWorker")
        {
            if (Manager.GetPosition())
            {
                Exp.MapBasicPosition = new Vector2(transform.position.x, (transform.position.y - offset));
              //Debug.Log(Exp.MapBasicPosition);
                SceneManager.LoadScene(SceneName);
            }     
        }
    }
}