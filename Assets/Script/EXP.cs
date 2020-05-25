using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP : MonoBehaviour
{
    public Vector2 MapBasicPosition ;
    public Vector2 InteriorPosition ;

    //Infection Details
    public int[] NPCInfectionList = new int[10];
    public int Uninfected ,TotalInfectedMild ,TotalInfectedModerate,TotalInfectedHigh ,TotalInfectedSevere, Death;

    //Infection Spread
    public float Mild_P = 0.3f , Moderate_P = 0.5f , High_P =0.7f , Severe_P = 0.99f;
    public float P = 0.2f;
    public int TotalContact;

    public int MinRange, MaxRange;

    //NPC Movement Behaviour
    public float StartTimeTask1 , PassTimeTask1, MaxTimeallow;
    public Vector2 Origin ,CurrentPosition , Destination;
    public int NPCNumber , NPCNumberTarget;
    public float DistanceRemain , DistanceMin = 0.5f ;
    public bool Task1Complete ;
    public bool Taskassign;
 
    public Vector2[] NPCLocation = new Vector2[10];
    public bool gotolocation = false;
    public int Scene; //0 = Mapbasic , 1 = Interior
}
