using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP : MonoBehaviour
{
    public Vector2 MapBasicPosition ;
    public Vector2 InteriorPosition ;

    //GameTime
    public float GameTime = 0;

    //Infection Details
    public int[] NPCInfectionList = new int[10];
    public int Uninfected ,TotalInfectedMild ,TotalInfectedModerate,TotalInfectedHigh ,TotalInfectedSevere, Death;

    //Infection Spread
    public float Mild_P = 0.3f , Moderate_P = 0.5f , High_P =0.7f , Severe_P = 0.99f;
    public float P = 0.2f;
    public int TotalContact;

    public int MinRange, MaxRange;

    //NPC Movement Behaviour Info
    public Vector2[] NPCInitialPosition = new Vector2[11];
    public float StartTimeTask1 , PassTimeTask1, MaxTimeallow;
    public Vector2 Origin ,CurrentPosition , Destination;
    public int NPCNumber , NPCNumberTarget , NPCTargetHouse;
    public float DistanceRemain , DistanceMin = 0.5f ;
    public bool Task1Complete ;
    public int JourneyStage ;
 
    public Vector2[] NPCLocation = new Vector2[11];
    public bool gotolocation = false;
    public int Scene; //0 = Mapbasic , 1 = Interior

    //pause
    public bool GamePause = false; 

    //OnLoad
    public bool CharecterPresent = false;
    public int NPCInEnterHouse;

    //NPC IN House
    //public int[,] HouseNPC = new int[10,2];
    public int[] NPCInHouse = new int[12];

    //SetPoint
    public Vector2[] SetpointPosition = new Vector2[11];
}
