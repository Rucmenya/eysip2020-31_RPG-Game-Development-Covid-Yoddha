using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class NPC : MonoBehaviour
{
    Vector3 CurrentPosition, FinalDestination;
    public Vector2[] IntermideateDestination = new Vector2[10];
    public EXP Exp;
    public int NPCNumber, CurrentlyInHouse;
    public float TotalDistance , IntermideateDistance;
    float V, H;
    public float speed = 0.01f ;
    Animator NPCanimator;
    public int InfectionStage;
    public bool tested = false;
    public bool Mask = false;
    float TestedTime , TestedTimePass;
    public float[] StageTime, InfectionStartTimeStage = new float[4];
    public int Target , Stage , IntermideatePoint;
  
    readonly int[] W = new int[2];
    bool PathPlanned = false;
    bool Stopedbycharecter;
    int WaitForFrametopass;
    float LastInfected;
    public int DrugApplied = 0;
    Material Mat;
    public Color Color;
    public AudioSource Source;
    public float PassTime , WalkAudioSpeed;
    public AudioClip Walk, Cough ,Sneeze;

    // Start is called before the first frame update
    void Start()
    {
        Mat = GetComponent<SpriteRenderer>().material;
        Mat.SetColor("_Color", Color);
        Mat.SetFloat("_AgeSelector",((int)Random.Range(0,4)));

        Source = GetComponent<AudioSource>();


        NPCanimator = GetComponent<Animator>();
        Mat = GetComponent<SpriteRenderer>().material;

      
            Exp.NPCInHouse[NPCNumber] = 100;
            Exp.NPCInfectionList[NPCNumber] = 0;
            Exp.NPCInitialPosition[NPCNumber] = transform.position;
            InfectionStage = 0;
            Exp.gotolocation = false;
            for (int d = 0; d < 3; d++)
            {
                StageTime[d] = 0; InfectionStartTimeStage[d] = 0;
            }
       

    }
    void Update()
    {
        if (!Exp.GamePause)
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
                if (WaitForFrametopass > 30) Stopedbycharecter = false;
            }

            InfectionProgression();

            if (DrugApplied >= 1)
            {
                Debug.Log("DrugApplied Low");
                if (InfectionStage >= 1)
                {
                    Mat.SetFloat("_Fever", 0);
                    InfectionStage -= 1;
                    InfectionStartTimeStage[InfectionStage] = 0;
                    Exp.NPCInfectionList[NPCNumber] -= 1;
                    if (InfectionStage > 0)
                    {
                        InfectionStartTimeStage[InfectionStage - 1] = Exp.GameTime;
                        StageTime[InfectionStage - 1] = 0;
                    }
                    StageTime[InfectionStage] = 0;
                    DrugApplied -= 1;
                }
                else DrugApplied = 0;


            }

            if (Mask) Mat.SetFloat("_Mask", 1);

            if (TestedTime == 0 && tested)
            {
                TestedTime = Exp.GameTime;
            }
            else if (TestedTime != 0 && tested)
            {
                TestedTimePass = Exp.GameTime - TestedTime;
                if (TestedTimePass >= 10 && InfectionStage == 0)
                {
                    tested = false;
                }

            }

        }
        else
        {
            //Debug.Log("Not Pause");
        }
    }

    void InfectionProgression()
    {
        if (InfectionStage == 1)
        {
            if (InfectionStartTimeStage[0] == 0) InfectionStartTimeStage[0] = Exp.GameTime;

            if ((StageTime[0] > (Random.Range(Exp.MinRange, Exp.MaxRange))))
            {
                Exp.NPCInfectionList[NPCNumber] += 1;
                InfectionStage += 1;
                PlayAudio(2);
            }
            else StageTime[0] += Time.deltaTime;
        }

        if (InfectionStage == 2)
        {
            if (InfectionStartTimeStage[1] == 0) InfectionStartTimeStage[1] = Exp.GameTime;

            if ((StageTime[1] > (Random.Range(Exp.MinRange, Exp.MaxRange))))
            {
                Exp.NPCInfectionList[NPCNumber] += 1;
                InfectionStage += 1;
                PlayAudio(2);

            }

            else StageTime[1] += Time.deltaTime;
        }

        if (InfectionStage == 3)
        {
            if (InfectionStartTimeStage[2] == 0) InfectionStartTimeStage[2] = Exp.GameTime;

            if ((StageTime[2] > (Random.Range(Exp.MinRange, Exp.MaxRange))))
            {
                Exp.NPCInfectionList[NPCNumber] += 1;
                InfectionStage += 1;
                PlayAudio(1);
                Mat.SetFloat("_Fever", 1);
            }

            else StageTime[2] += Time.deltaTime;
        }

        if (InfectionStage == 4)
        {
            if (InfectionStartTimeStage[3] == 0) InfectionStartTimeStage[3] = Exp.GameTime;

            if ((StageTime[3] > (Random.Range(Exp.MinRange, Exp.MaxRange))))
            {
                Exp.NPCInfectionList[NPCNumber] += 1;
                InfectionStage += 1;
                PlayAudio(2);
                PlayAudio(1);
                


            }

            else StageTime[3] = Time.deltaTime;
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

        /*  S = FindObjectOfType<AudioManager>().sounds[2];
          if (S.AudioLength < SoundLen)
          {
              FindObjectOfType<AudioManager>().Play("FootSteps");
              SoundLen = 0;
          }
          else SoundLen += Time.deltaTime;
          */
        PlayAudio(0);
        // Source.Play();

        // if (Stage == 2)
        // { if (IntermideateDistance <= 0.7) Stage += 1; }
        // else if (IntermideateDistance <= 0.2) Stage += 1;
        if (IntermideateDistance <= 0.5) Stage += 1;
        if (Stage == IntermideatePoint)
        {   Exp.Task1Complete = true;
            IntermideatePoint = 0;
        }
    }


   void PathPlan()
    {
        int j = 1;
        Stage = 0;
        Target = Exp.NPCTargetHouse;
        FinalDestination = Exp.Destination;

        if (CurrentlyInHouse > Target)
        {
            while (CurrentlyInHouse - (j+Target) != 0)
            {
                IntermideateDestination[j - 1] = Exp.SetpointPosition[CurrentlyInHouse - j];
                j += 1;
            }
        }

        if (CurrentlyInHouse < Target)
        {
            while (Target - (j+ CurrentlyInHouse) != 0)
            {
                IntermideateDestination[j - 1] = Exp.SetpointPosition[CurrentlyInHouse + j];
                j += 1;
            }
        }

        IntermideateDestination[j - 1] = Exp.SetpointPosition[Target];
        IntermideatePoint = j;
        PathPlanned = true;
       // Debug.Log("Planned");
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
                    

                    if ((Exp.GameTime - LastInfected) > 1)
                    {
                        LastInfected = Exp.GameTime;
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


                 if(Exp.NPCNumberTarget == NPCNumber && (other.gameObject.GetComponent<NPC>().NPCNumber == Exp.NPCNumber))
                {
                    other.gameObject.transform.position = Exp.NPCInitialPosition[NPCNumber];
                    gameObject.transform.position = Exp.NPCInitialPosition[NPCNumber];
                    Exp.Task1Complete = true;
                }
            }
        }
    }


   void PlayAudio(int A)
     {
        if (A == 0)
        { Source.clip = Walk;
            if (PassTime >= WalkAudioSpeed)
            {
                Source.Play();
                PassTime =0 ;
            }
            else { PassTime += Time.deltaTime; }
        }
        if (A == 1)
        {
            Source.clip = Cough;

                Source.Play();
        }
        if (A == 2)
        {
            Source.clip = Sneeze;
                Source.Play();
        }
    }


}





 
    
