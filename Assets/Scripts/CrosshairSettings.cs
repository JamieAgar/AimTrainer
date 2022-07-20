using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairSettings : MonoBehaviour
{
    public GameObject[] crosshairPieces;
    private float _gap = 14f;
    private float _size = 1f;
    private float _thickness = 1f;
    private bool _dotState = true;
    private float _dotSize = 1f;
    private Color _color;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGap(float gap)
    {
        _gap = gap;
        float normalizedGap = gap + (_size/10 * 25)/2;
        crosshairPieces[0].transform.localPosition = new Vector3(0, normalizedGap, 0);
        crosshairPieces[1].transform.localPosition = new Vector3(normalizedGap, 0, 0);
        crosshairPieces[2].transform.localPosition = new Vector3(0, -normalizedGap, 0);
        crosshairPieces[3].transform.localPosition = new Vector3(-normalizedGap, 0, 0);
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
    }
    public void ToggleDot(bool state)
    {
        _dotState = state;
        crosshairPieces[4].SetActive(state);
    }
    public void UpdateDotSize(float dotSize)
    {
        _dotSize = dotSize;
        crosshairPieces[4].transform.localScale = new Vector3(dotSize, dotSize, 1);
    }
    public void UpdateColour(Color color)
    {
        _color = color;
        for (int i = 0; i < crosshairPieces.Length; i++)
        {
            crosshairPieces[i].GetComponent<Image>().color = color;
        }
    }
}
