using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSettings : MonoBehaviour
{
    //[Move Speed Slider, Move Speed Input, Despawn Time Slider, Despawn Time Input,
    // Min Change Time Slider, Min Change Time Input, Max Change Time Slider, Max Change Time Input]
    public GameObject[] uiElements;

    public TargetSettingsSO settingsSO;

    //TODO: Use these values in the Target scripts
    private void OnEnable()
    {
        UpdateUI();
    }
    public void UpdateUI()
    {
        Slider speedSlider = uiElements[0].GetComponent<Slider>();
        speedSlider.value = settingsSO.mimicSpeed.Value;
        TMPro.TMP_InputField speedField = uiElements[1].GetComponent<TMPro.TMP_InputField>();
        speedField.text = settingsSO.mimicSpeed.Value.ToString();

        Slider despawnSlider = uiElements[2].GetComponent<Slider>();
        despawnSlider.value = settingsSO.despawnTime.Value;
        TMPro.TMP_InputField despawnField = uiElements[3].GetComponent<TMPro.TMP_InputField>();
        despawnField.text = settingsSO.despawnTime.Value.ToString();

        Slider minChangeTimeSlider = uiElements[4].GetComponent<Slider>();
        minChangeTimeSlider.value = settingsSO.minChangeTime.Value;
        TMPro.TMP_InputField minChangeTimeField = uiElements[5].GetComponent<TMPro.TMP_InputField>();
        minChangeTimeField.text = settingsSO.minChangeTime.Value.ToString();

        Slider maxChangeTimeSlider = uiElements[6].GetComponent<Slider>();
        maxChangeTimeSlider.value = settingsSO.maxChangeTime.Value;
        TMPro.TMP_InputField maxChangeTimeField = uiElements[7].GetComponent<TMPro.TMP_InputField>();
        maxChangeTimeField.text = settingsSO.maxChangeTime.Value.ToString();
    }

    public void UpdateSpeed(float speed)
    {
        settingsSO.mimicSpeed.Value = speed;
        UpdateUI();
    }
    public void UpdateDespawnTime(float despawnTime)
    {
        settingsSO.despawnTime.Value = despawnTime;
        UpdateUI();
    }
    public void UpdateMinumumChangeTime(float minChangeTime)
    {
        settingsSO.minChangeTime.Value = minChangeTime;
        UpdateUI();
    }
    public void UpdateMaximumChangeTime(float maxChangeTime)
    {
        settingsSO.maxChangeTime.Value = maxChangeTime;
        UpdateUI();
    }

    public void EasyPreset()
    {
        settingsSO.mimicSpeed.Value = 8f;
        settingsSO.despawnTime.Value = 10f;
        settingsSO.minChangeTime.Value = 7f;
        settingsSO.maxChangeTime.Value = 7f;
        UpdateUI();
    }
    public void MediumPreset()
    {
        settingsSO.mimicSpeed.Value = 12f;
        settingsSO.despawnTime.Value = 5f;
        settingsSO.minChangeTime.Value = 2f;
        settingsSO.maxChangeTime.Value = 8f;
        UpdateUI();
    }
    public void HardPreset()
    {
        settingsSO.mimicSpeed.Value = 15f;
        settingsSO.despawnTime.Value = 2f;
        settingsSO.minChangeTime.Value = .5f;
        settingsSO.maxChangeTime.Value = 2f;
        UpdateUI();
    }
}
