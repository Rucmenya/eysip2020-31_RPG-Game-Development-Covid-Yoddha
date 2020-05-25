using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAKButtonScript : MonoBehaviour
{
    public GameObject effect;
    Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void UseItem()
    {
        Instantiate(effect, player.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
