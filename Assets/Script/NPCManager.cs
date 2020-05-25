using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour
{
    public NPC[] NPC = new NPC[10];
    public EXP Exp;
    public int From, To;
    public Text TextTI;
    



    // Start is called before the first frame update
    void Start()
    {
        
        
        Exp.Task1Complete = true;
        if (Time.realtimeSinceStartup < 5)
        { int x = Random.Range(0, 10);
            Exp.TotalContact = 0;
            Exp.NPCInfectionList[x] = 1;
            Exp.TotalInfectedMild += 1;
            NPC[x].InfectionStage = 1;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Exp.Task1Complete)
        {
            MakeDicision();
            Exp.Task1Complete = false;
            Exp.StartTimeTask1 = Time.realtimeSinceStartup;
        }
        else
        {
            Exp.PassTimeTask1 = Time.realtimeSinceStartup - Exp.StartTimeTask1;
            if (Exp.PassTimeTask1 > Exp.MaxTimeallow)
            {
                Exp.Task1Complete = true;
            }
        }

        InfectionStatus();
            

        

    }

     void MakeDicision()
    {
        From = Random.Range(0, 10);
        To = Random.Range(0, 10);
       while(Exp.NPCInfectionList[From] > 4)
        {
            From = Random.Range(0, 10);
        }
        while (Exp.NPCInfectionList[To] > 4 || To == From)
        {
            To = Random.Range(0, 10);
        }

        Exp.NPCNumber = From;
        Exp.NPCNumberTarget = To;

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
        for (int s = 0; s <=9 ; s++)
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
        for (int x = 0; x <= 9; x++)
        {
            Exp.NPCLocation[x] = NPC[x].transform.position;
          //  Debug.Log(NPC[x].transform.position);

        }
        //Debug.Log("GetPosition");
        Exp.gotolocation = true;
        return true;
    }

}