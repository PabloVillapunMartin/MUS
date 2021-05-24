using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterByName : MonoBehaviour
{
    public string parameterName = "";

    FMOD.Studio.EventInstance prueba;
    void Start()
    {
        prueba = FMODUnity.RuntimeManager.CreateInstance("event:/Prueba");
        prueba.start();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            prueba.setParameterByName(parameterName, 1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            prueba.setParameterByName(parameterName, 0f);
        }
    }
}
