using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public AudioSource Source;
    public bool[] isFull;
    public GameObject[] slots;

    public void PLayAudioCharacter(AudioClip A)
    {
        Source = GetComponent<AudioSource>();
        Source.clip = A;
        Source.Play();
    }
}
