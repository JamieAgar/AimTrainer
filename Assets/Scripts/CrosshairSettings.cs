using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairSettings : MonoBehaviour
{
    //[Gap Slider, Gap Input, Size Slider, Size Input, Thickness Slider,
    // Thickness Input, Dot Toggle, Dot Size Slider, Dot Size Input, ColorPicker]
    public GameObject[] uiElements;

    public GameObject[] crosshairPieces;
    private float _gap = 14f;
    private float _size = 1f;
    private float _thickness = 1f;
    private bool _dotState = true;
    private float _dotSize = 1f;

    Slider gapSlider;
    TMPro.TMP_InputField gapField;
    Slider sizeSlider;
    TMPro.TMP_InputField sizeField;
    Slider thicknessSlider;
    TMPro.TMP_InputField thicknessField;
    Toggle dotToggle;
    Slider dotSizeSlider;
    TMPro.TMP_InputField dotSizeField;

    void OnEnable()
    {
        gapSlider = uiElements[0].GetComponent<Slider>();
        gapField = uiElements[1].GetComponent<TMPro.TMP_InputField>();

        sizeSlider = uiElements[2].GetComponent<Slider>();
        sizeField = uiElements[3].GetComponent<TMPro.TMP_InputField>();

        thicknessSlider = uiElements[4].GetComponent<Slider>();
        thicknessField = uiElements[5].GetComponent<TMPro.TMP_InputField>();

        dotToggle = uiElements[6].GetComponent<Toggle>();

        dotSizeSlider = uiElements[7].GetComponent<Slider>();
        dotSizeField = uiElements[8].GetComponent<TMPro.TMP_InputField>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        gapSlider.value = _gap;
        gapField.text = _gap.ToString();

        sizeSlider.value = _size;
        sizeField.text = _size.ToString();

        thicknessSlider.value = _thickness;
        thicknessField.text = _thickness.ToString();

        dotToggle.isOn = _dotState;

        dotSizeSlider.value = _dotSize;
        dotSizeField.text = _dotSize.ToString();
    }

    public void UpdateGap(float gap)
    {
        _gap = gap;
        float normalizedGap = gap + (_size/10 * 25)/2;
        crosshairPieces[0].transform.localPosition = new Vector3(0, normalizedGap, 0);
        crosshairPieces[1].transform.localPosition = new Vector3(normalizedGap, 0, 0);
        crosshairPieces[2].transform.localPosition = new Vector3(0, -normalizedGap, 0);
        crosshairPieces[3].transform.localPosition = new Vector3(-normalizedGap, 0, 0);
        UpdateUI();
    }
    public void UpdateSize(float size)
    {
        _size = size;
        //Set scale between 0-10
        size = size / 10;
        for(int i = 0; i < crosshairPieces.Length-1; i++)
        {
            crosshairPieces[i].transform.localScale = new Vector3(crosshairPieces[i].transform.localScale.x, size, 1);
        }
        UpdateGap(_gap);
    }
    public void UpdateThickness(float thickness)
    {
        _thickness = thickness;
        for (int i = 0; i < crosshairPieces.Length - 1; i++)
        {
            crosshairPieces[i].transform.localScale = new Vector3(thickness, crosshairPieces[i].transform.localScale.y, 1);
        }
        UpdateUI();
    }
    public void ToggleDot(bool state)
    {
        _dotState = state;
        crosshairPieces[4].SetActive(state);
        UpdateUI();
    }
    public void UpdateDotSize(float dotSize)
    {
        _dotSize = dotSize;
        crosshairPieces[4].transform.localScale = new Vector3(dotSize, dotSize, 1);
        UpdateUI();
    }
}
