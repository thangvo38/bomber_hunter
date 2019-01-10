using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    AudioSource source;
    float baseVolume;
    void Start()
    {
        source = this.GetComponent<AudioSource>();
        baseVolume = source.volume;
    }

    void Update()
    {
        source.volume = baseVolume * Statics.CurrentVolume;
    }
}
