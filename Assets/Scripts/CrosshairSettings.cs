using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private Color _color;

    public void UpdateUI()
    {
        Slider gapSlider = uiElements[0].GetComponent<Slider>();
        gapSlider.value = _gap;
        TMPro.TMP_InputField gapField = uiElements[1].GetComponent<TMPro.TMP_InputField>();
        gapField.text = _gap.ToString();

        Slider sizeSlider = uiElements[2].GetComponent<Slider>();
        sizeSlider.value = _size;
        TMPro.TMP_InputField sizeField = uiElements[3].GetComponent<TMPro.TMP_InputField>();
        sizeField.text = _size.ToString();

        Slider thicknessSlider = uiElements[4].GetComponent<Slider>();
        thicknessSlider.value = _thickness;
        TMPro.TMP_InputField thicknessField = uiElements[5].GetComponent<TMPro.TMP_InputField>();
        thicknessField.text = _thickness.ToString();

        Toggle dotToggle = uiElements[6].GetComponent<Toggle>();
        dotToggle.isOn = _dotState;

        Slider dotSizeSlider = uiElements[7].GetComponent<Slider>();
        dotSizeSlider.value = _dotSize;
        TMPro.TMP_InputField dotSizeField = uiElements[8].GetComponent<TMPro.TMP_InputField>();
        dotSizeField.text = _dotSize.ToString();

        FlexibleColorPicker fcp = uiElements[9].GetComponent<FlexibleColorPicker>();
        fcp.color = _color;
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
    public void UpdateColour(Color color)
    {
        _color = color;
        for (int i = 0; i < crosshairPieces.Length; i++)
        {
            crosshairPieces[i].GetComponent<Image>().color = color;
        }
        UpdateUI();
    }
}
