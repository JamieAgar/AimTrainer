using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TargetSettings : MonoBehaviour
{
    //[Move Speed Slider, Move Speed Input, Despawn Time Slider, Despawn Time Input,
    // Min Change Time Slider, Min Change Time Input, Max Change Time Slider, Max Change Time Input]
    public GameObject[] uiElements;

    private float _mimicSpeed = 12f;
    private float _despawnTime = 5f;
    private float _minChangeTime = .5f;
    private float _maxChangeTime = 2f;

    //TODO: Use these values in the Target scripts
    private void OnEnable()
    {
        UpdateUI();
    }
    public void UpdateUI()
    {
        Slider speedSlider = uiElements[0].GetComponent<Slider>();
        speedSlider.value = _mimicSpeed;
        TMPro.TMP_InputField speedField = uiElements[1].GetComponent<TMPro.TMP_InputField>();
        speedField.text = _mimicSpeed.ToString();

        Slider despawnSlider = uiElements[2].GetComponent<Slider>();
        despawnSlider.value = _despawnTime;
        TMPro.TMP_InputField despawnField = uiElements[3].GetComponent<TMPro.TMP_InputField>();
        despawnField.text = _despawnTime.ToString();

        Slider minChangeTimeSlider = uiElements[4].GetComponent<Slider>();
        minChangeTimeSlider.value = _minChangeTime;
        TMPro.TMP_InputField minChangeTimeField = uiElements[5].GetComponent<TMPro.TMP_InputField>();
        minChangeTimeField.text = _minChangeTime.ToString();

        Slider maxChangeTimeSlider = uiElements[6].GetComponent<Slider>();
        maxChangeTimeSlider.value = _maxChangeTime;
        TMPro.TMP_InputField maxChangeTimeField = uiElements[7].GetComponent<TMPro.TMP_InputField>();
        maxChangeTimeField.text = _maxChangeTime.ToString();
    }

    public void UpdateSpeed(float speed)
    {
        _mimicSpeed = speed;
        UpdateUI();
    }
    public void UpdateDespawnTime(float despawnTime)
    {
        _despawnTime = despawnTime;
        UpdateUI();
    }
    public void UpdateMinumumChangeTime(float minChangeTime)
    {
        _minChangeTime = minChangeTime;
        UpdateUI();
    }
    public void UpdateMaximumChangeTime(float maxChangeTime)
    {
        _maxChangeTime = maxChangeTime;
        UpdateUI();
    }

    public void EasyPreset()
    {
        _mimicSpeed = 8f;
        _despawnTime = 10f;
        _minChangeTime = 7f;
        _maxChangeTime = 7f;
        UpdateUI();
    }
    public void MediumPreset()
    {
        _mimicSpeed = 12f;
        _despawnTime = 5f;
        _minChangeTime = 2f;
        _maxChangeTime = 8f;
        UpdateUI();
    }
    public void HardPreset()
    {
        _mimicSpeed = 15f;
        _despawnTime = 2f;
        _minChangeTime = .5f;
        _maxChangeTime = 2f;
        UpdateUI();
    }
}
