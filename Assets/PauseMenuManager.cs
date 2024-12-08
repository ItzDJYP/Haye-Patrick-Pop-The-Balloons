using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuManager : MonoBehaviour
{
    GameObject[] pauseMode;
    GameObject[] playMode;
    void Start(){
        pauseMode = GameObject.FindGameObjectsWithTag("ShowInPauseMode");
        playMode = GameObject.FindGameObjectsWithTag("ShowInPlayMode");
        foreach (GameObject g in pauseMode)
            g.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        foreach(GameObject g in pauseMode)
            g.SetActive(true);

        foreach(GameObject g in playMode)
            g.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        foreach (GameObject g in pauseMode)
            g.SetActive(false);

        foreach (GameObject g in playMode)
            g.SetActive(true);
    }

    public void LoadTitleScreen()
    {
        Time.timeScale = 1f;           // Reset time scale in case it's still paused
        SceneManager.LoadScene("Title Screen"); // Replace with your main menu scene name
    }
}