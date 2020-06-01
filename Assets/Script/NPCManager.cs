using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour
{
    public NPC[] NPC = new NPC[11];
    public EXP Exp;
    public int From, To;
    public Text TextTI;
    public Text TotalTime;
    GameObject P1, P2;
    public GameObject HCWorker;
    float PassTime = 0;





    // Start is called before the first frame update
    void Start()
    {
            int x = Random.Range(0, 10);
            Exp.TotalContact = 0;
            Exp.NPCInfectionList[x] = 1;
            Exp.TotalInfectedMild += 1;
            NPC[x].InfectionStage = 1;
            Exp.Task1Complete = true;

        

        Exp.SetpointPosition[0] = GameObject.Find("Point1").gameObject.transform.position;
        Exp.SetpointPosition[1] = GameObject.Find("Point2").gameObject.transform.position;
        Exp.SetpointPosition[2] = GameObject.Find("Point3").gameObject.transform.position;
        Exp.SetpointPosition[3] = GameObject.Find("Point4").gameObject.transform.position;
        Exp.SetpointPosition[4] = GameObject.Find("Point5").gameObject.transform.position;
        Exp.SetpointPosition[5] = GameObject.Find("Point6").gameObject.transform.position;
        Exp.SetpointPosition[6] = GameObject.Find("Point7").gameObject.transform.position;
        Exp.SetpointPosition[7] = GameObject.Find("Point8").gameObject.transform.position;
        Exp.SetpointPosition[8] = GameObject.Find("Point9").gameObject.transform.position;
        Exp.SetpointPosition[9] = GameObject.Find("Point10").gameObject.transform.position;
        Exp.SetpointPosition[10] = GameObject.Find("Point11").gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Exp.Task1Complete && (PassTime >= 4f))
        {
            MakeDicision();
            Exp.Task1Complete = false;
            Exp.StartTimeTask1 = Exp.GameTime;
            PassTime = 0;
        }
        else if (Exp.Task1Complete && PassTime <= 4f) PassTime += Time.deltaTime;
        else
        {
            Exp.PassTimeTask1 = Exp.GameTime - Exp.StartTimeTask1;
            if (Exp.PassTimeTask1 > Exp.MaxTimeallow)
            {
                Exp.Task1Complete = true;
            }
        }

        InfectionStatus();


        TotalTime.text = (((int)(Exp.GameTime/60)).ToString() + " : " + (((int)Exp.GameTime)-((int)Exp.GameTime/60)*60).ToString()) ;

    }

     void MakeDicision()
    {
        From = Random.Range(0, 11);
        To = Random.Range(0, 11);
       while(Exp.NPCInfectionList[From] > 4)
        {
            From = Random.Range(0, 11);
        }
        while (Exp.NPCInfectionList[To] > 4 || To == From)
        {
            To = Random.Range(0, 11);
        }

        Exp.NPCNumber = From;
        int x = NPC[From].CurrentlyInHouse;
        P1 = NPC[From].gameObject;
       // P1.SetActive(true);
        P1.transform.position = Exp.SetpointPosition[x];

        Exp.NPCNumberTarget = To;
        Exp.NPCTargetHouse = NPC[To].CurrentlyInHouse;
        int y = NPC[To].CurrentlyInHouse;
        P2 = NPC[To].gameObject;
       // P2.SetActive(true);
        P2.transform.position = Exp.SetpointPosition[y];

        for (int r = 0; r <= 9; r++)
        {
            if (r == From)
            {
                Exp.Origin = NPC[r].transform.position;
            }
            if (r == To)
            {
                Exp.Destination = NPC[r].transform.position;
            }


        }
    }

    public void InfectionStatus()
    {
        int U = 0, MI = 0, MO = 0, H = 0, S = 0, D = 0;
        for (int s = 0; s <=10 ; s++)
        {
            int a = Exp.NPCInfectionList[s];
           
            switch (a)
            {
                case 0:
                   U += 1;
                    break;
                case 1:
                    MI += 1;
                    break;
                case 2:
                    MO += 1;
                    break;
                case 3:
                    H += 1;
                    break;
                case 4:
                    S += 1;
                    break;
                case 5:
                     D += 1;
                    break;
            }

        }
        Exp.Uninfected = U;
        Exp.TotalInfectedMild = MI;
        Exp.TotalInfectedModerate = MO;
        Exp.TotalInfectedHigh = H;
        Exp.TotalInfectedSevere = S;
        Exp.Death = D;
        TextTI.text = U.ToString();
        if (D >= 8)
        {   
            SceneManager.LoadScene(2);
            Debug.Log("Quit");
        }
        if(U==10)
        {
           // SceneManager.LoadScene(2);
        }
    }

    public bool  GetPosition()
    {
        SaveNPCMovement();
        for (int x = 0; x <= 9; x++)
        {
            Exp.NPCLocation[x] = NPC[x].transform.position;
          //  Debug.Log(NPC[x].transform.position);

        }
        //Debug.Log("GetPosition");
        Exp.gotolocation = true;
        return true;
    }

    public void SaveNPCMovement()
    {
       Exp.JourneyStage =  NPC[From].Stage;

    }

}