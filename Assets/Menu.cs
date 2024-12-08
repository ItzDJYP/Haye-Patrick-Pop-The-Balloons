using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] TMP_InputField playerNameInput;

    public void OnPlayButton()
    {
        string s = playerNameInput.text.Trim();
        PersistentData.Instance.setName(s);
        SceneManager.LoadScene("Level 1");
    }
    
    public void OnInstructionsButton()
    {
        SceneManager.LoadScene("Instructions Screen");
    }
    public void OnBackButton()
    {
        SceneManager.LoadScene("Title Screen");
    }
    public void OnSettingsButton()
    {
        SceneManager.LoadScene("Settings");
    }
    public void OnTimeScreenButton()
    {
        SceneManager.LoadScene("TimeHighScore");
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }
}