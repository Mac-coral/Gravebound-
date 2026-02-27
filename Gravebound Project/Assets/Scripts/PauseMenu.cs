using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Canvas pauseMenu;
    public Canvas settingMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenu.enabled = false;
        settingMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            enablePause();
        }
    }

    public void enablePause()
    {
        pauseMenu.enabled = true;
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void disablePause()
    {
        pauseMenu.enabled = false;
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void enableSettings()
    {
        settingMenu.enabled = true;
        Time.timeScale = 0.0f;
    }

    public void disableSettings()
    {
        settingMenu.enabled = false;
        Time.timeScale = 0.0f;
    }

}
