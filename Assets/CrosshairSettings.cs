using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairSettings : MonoBehaviour
{
    public GameObject[] crosshairPieces;
    private float _gap;
    private float _size;

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
        // (2/5 * size) = 0, then add gap to center it properly
        gap = (2 / 5 * _size) + gap;
        _gap = gap;
        crosshairPieces[0].transform.position = new Vector3(0, gap, 0);
        crosshairPieces[1].transform.position = new Vector3(gap, 0, 0);
        crosshairPieces[2].transform.position = new Vector3(0, -gap, 0);
        crosshairPieces[3].transform.position = new Vector3(-gap, 0, 0);
    }
    public void UpdateSize(float size)
    {
        //Size is too small otherwise
        size = size * 25;
        _size = size;
        crosshairPieces[0].transform.position = new Vector3(0, size, 0);
        crosshairPieces[1].transform.position = new Vector3(size, 0, 0);
        crosshairPieces[2].transform.position = new Vector3(0, -size, 0);
        crosshairPieces[3].transform.position = new Vector3(-size, 0, 0);
    }
}
