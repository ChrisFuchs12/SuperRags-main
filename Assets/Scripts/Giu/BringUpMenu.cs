using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringUpMenu : MonoBehaviour
{
    public GameObject setting;
    public bool issettingactive;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (issettingactive == false)
            {
                Pause();
            }

            else
            {
                Resume();
            }
        }
    }

    public void Pause ()
    {
        setting.SetActive(true);
        issettingactive = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume ()
    {
        setting.SetActive(false);
        issettingactive = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}