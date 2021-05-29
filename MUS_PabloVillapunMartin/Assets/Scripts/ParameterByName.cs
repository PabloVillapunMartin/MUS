using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterByName : MonoBehaviour
{
    public string parameterName = "";
    public float maxValue = 0.8f;
    public float minValue = 0.0f;
    public float fadeSpeed = 0.3f;

    FMOD.Studio.EventInstance prueba;
    bool fadeIn = false;
    bool fadeOut = false;
    float value;
    void Start()
    {
        prueba = GameObject.Find("AudioInstance").GetComponent<AudioInstanceMngr>().getAudioInstance();
        value = minValue;
    }

    private void Update()
    {
        if (fadeIn) FadeIn();
        else if (fadeOut) FadeOut();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fadeIn = true;
            fadeOut = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            fadeOut = true;
            fadeIn = false;
        }
    }

    private void FadeIn()
    {
        value += fadeSpeed * Time.deltaTime;
        if (value > maxValue) value = maxValue;
        prueba.setParameterByName(parameterName, value);

        if (value == maxValue) fadeIn = false;
    }

    private void FadeOut()
    {
        value -= fadeSpeed * Time.deltaTime;
        if (value < minValue) value = minValue;
        prueba.setParameterByName(parameterName, value);

        if (value == minValue) fadeOut = false;
    }
}
