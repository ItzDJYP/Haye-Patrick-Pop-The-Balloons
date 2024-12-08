using UnityEngine;
using UnityEngine.UI;

public class Fullscreen : MonoBehaviour
{
    [SerializeField] private Toggle fullscreenToggle;

    void Start()
    {
        // Initialize the toggle state based on current fullscreen setting
        fullscreenToggle.isOn = Screen.fullScreen;

        // Add a listener to handle the toggle change
        fullscreenToggle.onValueChanged.AddListener(delegate { ToggleFullscreen(fullscreenToggle.isOn); });
    }

    public void ToggleFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

        // Optionally, save the fullscreen setting to PlayerPrefs for persistence
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
        PlayerPrefs.Save();
    }
}
