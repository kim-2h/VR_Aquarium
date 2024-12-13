using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public AudioSource[] BGMs;
    public AudioSource[] SFXs;
    void Awake()
    {
    AudioManager.Instance = this; 
     }
    void Start()
    {
        //AudioManager.Instance = this; 
        BGMs[0].Play();
    }

    public void PlaySFX(int idx)
    {
        //Debug.Log(SFXs[idx].name);
        SFXs[idx].Play();
    }


}
