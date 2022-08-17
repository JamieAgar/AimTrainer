using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenus : MonoBehaviour
{
    public GameObject crosshairMenu;
    private bool showCrosshairMenu = false;

    public GameObject targetMenu;
    private bool showTargetMenu = false;

    public void OnToggleCrosshairMenu()
    {
        showCrosshairMenu = !showCrosshairMenu;
        crosshairMenu.SetActive(showCrosshairMenu);
        PlayerController pc = GetComponent<PlayerController>();
        if (showCrosshairMenu)
        {
            Cursor.lockState = CursorLockMode.None;
            pc.cursorInputForLook = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            pc.cursorInputForLook = true;
        }
    }
    public void OnToggleTargetMenu()
    {
        showTargetMenu = !showTargetMenu;
        targetMenu.SetActive(showTargetMenu);
        PlayerController pc = GetComponent<PlayerController>();
        if (showTargetMenu)
        {
            Cursor.lockState = CursorLockMode.None;
            pc.cursorInputForLook = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            pc.cursorInputForLook = true;
        }
    }
}
