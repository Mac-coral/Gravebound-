using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Settings;
    public GameObject Tutorial;
    public GameObject Credits;

    public GameObject playButton;
    public GameObject settingsButton;
    public GameObject tutorialButton;
    public GameObject creditsButton;
    public GameObject exitButton;
    
    public void SettingsMenu()
    {
        Settings.SetActive(true);
        playButton.SetActive(false);
        settingsButton.SetActive(false);
        tutorialButton.SetActive(false);
        creditsButton.SetActive(false); 
        exitButton.SetActive(false);
    }

    public void TutorialMenu()
    {
        Tutorial.SetActive(true);
        playButton.SetActive(false);
        settingsButton.SetActive(false);
        tutorialButton.SetActive(false);
        creditsButton.SetActive(false);
        exitButton.SetActive(false);
    }

    public void CreditsMenu()
    {
        Credits.SetActive(true);
        playButton.SetActive(false);
        settingsButton.SetActive(false);
        tutorialButton.SetActive(false);
        creditsButton.SetActive(false);
        exitButton.SetActive(false);
    }

    public void Back()
    {
        Settings.SetActive(false);
        Tutorial.SetActive(false);
        Credits.SetActive(false);
        playButton.SetActive(true);
        settingsButton.SetActive(true);
        tutorialButton.SetActive(true);
        creditsButton.SetActive(true);
        exitButton.SetActive(true);
    }

    public void Play() 
    {
        SceneManager.LoadScene("Outdoor Scene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
