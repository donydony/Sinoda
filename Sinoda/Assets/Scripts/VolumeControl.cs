using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetMainVolumeLevel(float SliderValue)
    {
        mixer.SetFloat("MainVol", Mathf.Log10(SliderValue) * 20);
    }
    
}
