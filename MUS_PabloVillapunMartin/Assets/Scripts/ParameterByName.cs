using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterByName : MonoBehaviour
{
    public string parameterName = "";
    public float maxValue = 1.0f;
    public float minValue = 0.0f;

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
            prueba.setParameterByName(parameterName, maxValue);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            prueba.setParameterByName(parameterName, minValue);
        }
    }
}
