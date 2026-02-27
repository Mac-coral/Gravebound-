using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider masterVolume;
    public Slider musicVolume;
    public Slider sfxVolume;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(!PlayerPrefs.HasKey("MasterVolume"))
        {
            PlayerPrefs.SetFloat("MasterVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }
    
    public void volumeChange()
    {
        AudioListener.volume = masterVolume.value;
        Save();
    }

    void Load()
    {
        masterVolume.value = PlayerPrefs.GetFloat("MasterVolume");
    }

    void Save()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolume.value);
    }
}
