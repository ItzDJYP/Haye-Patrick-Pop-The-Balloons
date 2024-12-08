using UnityEngine;
using UnityEngine.UI;

public class SFXVolumeController : MonoBehaviour
{
    [SerializeField] private Slider sfxSlider;
    private float sfxVolume = 1.0f; // Default volume

    void Start()
    {
        // Load saved volume level (optional, for persisting volume settings)
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            sfxVolume = PlayerPrefs.GetFloat("SFXVolume");
            sfxSlider.value = sfxVolume;
        }
        else
        {
            sfxSlider.value = sfxVolume;
        }

        // Add listener to handle volume changes
        sfxSlider.onValueChanged.AddListener(delegate { OnSFXVolumeChange(); });
    }

    public void OnSFXVolumeChange()
    {
        sfxVolume = sfxSlider.value;
        AudioListener.volume = sfxVolume; // Adjust this based on your needs

        // Save the volume setting (optional)
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }
}
