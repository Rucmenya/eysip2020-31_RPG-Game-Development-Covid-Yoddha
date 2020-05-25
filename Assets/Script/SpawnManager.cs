using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Animator Anim; 
    public GameObject fakPrefab;
    public GameObject covidKitPrefab;
    public GameObject lowDrugPrefab;
    public GameObject moderateDrugPrefab;
    public GameObject faceMaskPrefab;
    public GameObject ppePrefab;
    GameObject temp;
    int selector=0;

    public float lowerSpawnTime = 10, upperSpawnTime = 20 ;
    public int fakLimit=0, covidKitLimit = 0, lowDrugLimit = 0, moderateDrugLimit = 0, faceMaskLimit = 0, ppeLimit = 0;
    int fak = 0, covidKit = 0, lowDrug = 0, moderateDrug = 0, faceMask = 0, ppe = 0;


    void Start()
    {
        Anim.GetComponent<Animator>();
        StartCoroutine(SpawnTimer());
    }

    private void SpawnObject() 
    {    
        selector = Random.Range(0, 5);
        float a = Random.Range(-10, 10);
        float b = Random.Range(-1, 1);
        float c = 0.2f;


        if ((selector == 0) && (fak < fakLimit))
        {
              gameObject.transform.position = new Vector2(a, b-c);
              Anim.SetInteger("T", 1);
              temp = Instantiate(fakPrefab) as GameObject;
              temp.transform.position = new Vector2(a,b);
              fak++;
              
        }
        else if ((selector == 1) && (covidKit < covidKitLimit))
        {
            gameObject.transform.position = new Vector2(a, b-c);
            Anim.SetInteger("T", 1);
            temp = Instantiate(covidKitPrefab) as GameObject;
            temp.transform.position = new Vector2(a,b);
            covidKit++;
        }
        else if ((selector == 2) && (lowDrug < lowDrugLimit))
        {
            gameObject.transform.position = new Vector2(a, b-c);
            Anim.SetInteger("T", 1);
            temp = Instantiate(lowDrugPrefab) as GameObject;
            temp.transform.position = new Vector2(a,b);
            lowDrug++;
        }
        else if ((selector == 3) && (moderateDrug < moderateDrugLimit))
        {
            gameObject.transform.position = new Vector2(a, b-1);
            Anim.SetInteger("T", 1);
            temp = Instantiate(moderateDrugPrefab) as GameObject;
            temp.transform.position = new Vector2(a,b);
            moderateDrug++;
        }
        else if ((selector == 4) && (faceMask < faceMaskLimit))
        {
            gameObject.transform.position = new Vector2(a, b-c);
            Anim.SetInteger("T", 1);
            temp = Instantiate(faceMaskPrefab) as GameObject;
            temp.transform.position = new Vector2(a,b);
            faceMask++;
        }
        else if ((selector == 5 && ppe < ppeLimit))
        {

            temp = Instantiate(ppePrefab) as GameObject;
            temp.transform.position = new Vector2(a,b);
            ppe++;
        }
    }

    IEnumerator SpawnTimer()
    {
        while (true)
        {  
            yield return new WaitForSeconds(Random.Range(lowerSpawnTime,upperSpawnTime));   
            SpawnObject();
            yield return new WaitForSeconds(1);
            Anim.SetInteger("T", 0);
        }
    }
}
