using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseColor : MonoBehaviour
{
    public Color HallColor , RoomColor, WallColor;
    public Material Mat;
    public Material SofaMat ;
    // Start is called before the first frame update
    void Start()
    {
        Mat = GetComponent<SpriteRenderer>().material;
        Mat.SetColor("_HallColor",HallColor);
        Mat.SetColor("_RoomColor", RoomColor);
        Mat.SetColor("_WallColor", WallColor);

    }





}
