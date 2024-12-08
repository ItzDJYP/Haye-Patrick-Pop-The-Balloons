using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText; // Reference to the timer UI text
    private float elapsedTime = 0f;
    private bool isRunning = true; // Tracks if the timer is running

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    // Stops the timer and returns the elapsed time in seconds
    public int StopTimer()
    {
        isRunning = false;
        return Mathf.FloorToInt(elapsedTime);
    }

    // Resets the timer
    public void ResetTimer()
    {
        elapsedTime = 0f;
        UpdateTimerDisplay();
    }

    // Starts or resumes the timer
    public void StartTimer()
    {
        isRunning = true;
    }

    // Updates the timer UI
    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Get the current elapsed time without stopping the timer
    public int GetElapsedTime()
    {
        return Mathf.FloorToInt(elapsedTime);
    }
}
