using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInstanceMngr : MonoBehaviour
{
    FMOD.Studio.EventInstance prueba;

    private void Awake()
    {
        prueba = FMODUnity.RuntimeManager.CreateInstance("event:/Prueba");
    }

    void Start()
    {
        prueba.start();
    }

    public FMOD.Studio.EventInstance getAudioInstance()
    {
        return prueba;
    }
}
