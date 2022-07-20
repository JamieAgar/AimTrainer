using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject menu;
    private bool showMenu = false;

    public void OnToggleMenu()
    {
        showMenu = !showMenu;
        menu.SetActive(showMenu);
        PlayerController pc = GetComponent<PlayerController>();
        if (showMenu)
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
