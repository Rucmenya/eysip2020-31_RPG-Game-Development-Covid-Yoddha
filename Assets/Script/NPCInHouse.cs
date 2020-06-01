using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCInHouse : MonoBehaviour
{

    public EXP Exp;
    public int NPCNumber;
    float V, H;
    public float speed = 0.01f;
    Animator NPCanimator;
    public int InfectionStage;
    public bool tested = false;
    public bool Mask = false;

    public float[] StageTime, InfectionStartTimeStage = new float[4];
    public int Target, Stage;
    bool Stopedbycharecter;
    float LastInfected;
    public int DrugApplied = 0;
    Material Mat;
    public Color Color;
    float Wait;

    // Start is called before the first frame update
    void Start()
    {
        Mat = GetComponent<SpriteRenderer>().material;
        Mat.SetColor("_Color", Color);


        NPCanimator = GetComponent<Animator>();
        Mat = GetComponent<SpriteRenderer>().material;

       
    }
    void Update()
    {
     
        
        transform.Translate(Mathf.Sign(H)*speed, Mathf.Sign(V)* speed, 0);
        NPCanimator.SetFloat("H", H);
        NPCanimator.SetFloat("V", V);



            }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Wait > 1)
        {


            V = Random.Range(-1, 2);
            H = Random.Range(-1, 2);
            Wait = 0;
        }
        Wait += Time.deltaTime;
    }


}







