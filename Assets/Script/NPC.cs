using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    Vector3 CurrentPosition, FinalDestination;
    public Vector2[] IntermideateDestination = new Vector2[6];
    public EXP Exp;
    public int NPCNumber;
    public float TotalDistance , IntermideateDistance;
    float V, H;
    public float speed = 0.01f ;
    Animator NPCanimator;
    public int InfectionStage;
    public bool tested = false;
    float TestedTime , TestedTimePass;
    public float[] StageTime, InfectionStartTimeStage = new float[4];
    public int Target , Stage;
    public GameObject[] SetpointPosition = new GameObject[5];
    readonly int[] W = new int[2];
    bool PathPlanned = false;
    bool Stopedbycharecter;
    int WaitForFrametopass;
    float LastInfected;
    public int DrugApplied = 0;


    // Start is called before the first frame update
    void Start()
    {
        SetpointPosition[0] = GameObject.Find("Point1");
        SetpointPosition[1] = GameObject.Find("Point2");
        SetpointPosition[2] = GameObject.Find("Point3");
        SetpointPosition[3] = GameObject.Find("Point4");
        SetpointPosition[4] = GameObject.Find("Point5");

        NPCanimator = GetComponent<Animator>();

        if (Time.realtimeSinceStartup < 5)
        {
            Exp.NPCInfectionList[NPCNumber] = 0;
            InfectionStage = 0;
            Exp.gotolocation = false;
            for (int d = 0; d < 3; d++)
            {
                StageTime[d] = 0; InfectionStartTimeStage[d] = 0;
            }
        }

        if (Exp.gotolocation)
        {
            transform.position = Exp.NPCLocation[NPCNumber];
            InfectionStage = Exp.NPCInfectionList[NPCNumber];
        }
    }
    void Update()
    {
        if (!Stopedbycharecter)
        {
            if (Exp.NPCNumber == NPCNumber)
            {
                if (!PathPlanned)
                {
                    PathPlan();
                }
                JourneyProgression();
            }
            else
            {
                PathPlanned = false;
                NPCanimator.SetFloat("V", 0f);
                NPCanimator.SetFloat("H", 0f);
            }
            WaitForFrametopass = 0;
        }
        else
        {
            WaitForFrametopass += 1;
            if(WaitForFrametopass > 30) Stopedbycharecter = false;
        }

        InfectionProgression();

        if (DrugApplied >= 1)
        {
            Debug.Log("DrugApplied Low");
            if (InfectionStage >= 1)
            {
                InfectionStage -= 1;
                InfectionStartTimeStage[InfectionStage] = 0;
                Exp.NPCInfectionList[NPCNumber] -= 1;
                if (InfectionStage > 0)
                {
                    InfectionStartTimeStage[InfectionStage - 1] = Time.realtimeSinceStartup;
                    StageTime[InfectionStage - 1] = 0;
                }
                StageTime[InfectionStage] = 0;
                DrugApplied -= 1;
            }
            else DrugApplied = 0;


        }

        if(TestedTime == 0 && tested)
        {
            TestedTime = Time.realtimeSinceStartup;
        }
        else if(TestedTime != 0 && tested )
        {
            TestedTimePass = Time.realtimeSinceStartup - TestedTime;
            if(TestedTimePass >= 10 && InfectionStage == 0)
            {
                tested = false;
            }

        }

    }

    void InfectionProgression()
    {
        if (InfectionStage == 1)
        {
            if (InfectionStartTimeStage[0] == 0) InfectionStartTimeStage[0] = Time.realtimeSinceStartup;

            if ((StageTime[0] > (Random.Range(Exp.MinRange, Exp.MaxRange))))
            {
                Exp.NPCInfectionList[NPCNumber] += 1;
                InfectionStage += 1;
            }
            else StageTime[0] = Time.realtimeSinceStartup - InfectionStartTimeStage[0];
        }

        if (InfectionStage == 2)
        {
            if (InfectionStartTimeStage[1] == 0) InfectionStartTimeStage[1] = Time.realtimeSinceStartup;

            if ((StageTime[1] > (Random.Range(Exp.MinRange, Exp.MaxRange))))
            {
                Exp.NPCInfectionList[NPCNumber] += 1;
                InfectionStage += 1;
            }

            else StageTime[1] = Time.realtimeSinceStartup - InfectionStartTimeStage[1];
        }

        if (InfectionStage == 3)
        {
            if (InfectionStartTimeStage[2] == 0) InfectionStartTimeStage[2] = Time.realtimeSinceStartup;

            if ((StageTime[2] > (Random.Range(Exp.MinRange, Exp.MaxRange))))
            {
                Exp.NPCInfectionList[NPCNumber] += 1;
                InfectionStage += 1;
            }

            else StageTime[2] = Time.realtimeSinceStartup - InfectionStartTimeStage[2];
        }

        if (InfectionStage == 4)
        {
            if (InfectionStartTimeStage[3] == 0) InfectionStartTimeStage[3] = Time.realtimeSinceStartup;

            if ((StageTime[3] > (Random.Range(Exp.MinRange, Exp.MaxRange))))
            {
                Exp.NPCInfectionList[NPCNumber] += 1;
                InfectionStage += 1;
            }

            else StageTime[3] = Time.realtimeSinceStartup - InfectionStartTimeStage[3];
        }

        if (InfectionStage == 5)
        {
            gameObject.SetActive(false);
        }
    }
    void JourneyProgression()
    {     
        CurrentPosition = transform.position;
        TotalDistance = Vector3.Distance(CurrentPosition, FinalDestination);
        IntermideateDistance = Vector3.Distance(CurrentPosition,IntermideateDestination[Stage]);

        V = CurrentPosition.y - IntermideateDestination[Stage].y;
        H = CurrentPosition.x - IntermideateDestination[Stage].x;

            //Debug.Log(TotalDistance);

                transform.Translate(Mathf.Sign(-H) * speed, Mathf.Sign(-V) * speed, 0f);
                NPCanimator.SetFloat("H", -H);
                NPCanimator.SetFloat("V", -V);


        if (Stage == 2)
        { if (IntermideateDistance <= 0.7) Stage += 1; }
        else if (IntermideateDistance <= 0.2) Stage += 1;

        if (Stage == 6)   Exp.Task1Complete = true; 
    }


   void PathPlan()
    {
        Stage = 0;
        Target = Exp.NPCNumberTarget;
        W[0] = DecideSetpoint(NPCNumber);
        W[1] = DecideSetpoint(Target);
        FinalDestination = Exp.Destination;
        IntermideateDestination[0] = SetpointPosition[W[0]].transform.position;
        IntermideateDestination[1] = SetpointPosition[W[1]].transform.position;
        IntermideateDestination[2] = FinalDestination;
        IntermideateDestination[3] = SetpointPosition[W[1]].transform.position;
        IntermideateDestination[4] = SetpointPosition[W[0]].transform.position;
        IntermideateDestination[5] = Exp.Origin;
        PathPlanned = true;
       // Debug.Log("Planned");
     }

     int DecideSetpoint(int a)
    { if(a >= 5) return ( a - 5);
      else  return a;
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Exp.NPCNumber == NPCNumber)
        {
            Stopedbycharecter = true;
            transform.Translate(0f, 0f, 0f);
            NPCanimator.SetFloat("H", 0);
            NPCanimator.SetFloat("V", 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("NPC"))
        {

            if (InfectionStage <= 1)
            {

                NPC C = other.gameObject.GetComponent<NPC>();

                if (C.InfectionStage >= 1)
                {
                    

                    if ((Time.realtimeSinceStartup - LastInfected) > 1)
                    {
                        LastInfected = Time.realtimeSinceStartup;
                        Exp.TotalContact += 1;
                        float z = (Random.Range(0, 11));

                        if (z <= (10 * Exp.P * C.InfectionStage))
                        {
                            Debug.Log("Infected");
                            InfectionStage = +1;
                            Exp.NPCInfectionList[NPCNumber] = 1;
                        }
                        else Debug.Log("Safe");
                    }
                }
            }
        }
    }
}





 
    
