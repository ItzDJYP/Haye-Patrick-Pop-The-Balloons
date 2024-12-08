using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Globalization;
public class Scorekeeper : MonoBehaviour
{
    /*[SerializeField] int score = 0;
    const int SCORE_THRESHOLD = 1;
    int scoreThresholdForThisLevel;
    [SerializeField] TextMeshProUGUI scoreText;*/
    //const int DEFAULT_POINTS = 1;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI completeGameText;
    [SerializeField] int level;
    [SerializeField] float time;
    [SerializeField] Timer timer;
    private int remainingBalloons;
    private readonly int[] balloonsPerLevel = {1, 3, 5, 7};

    // Start is called before the first frame update
    void Start()
    {
        //score = PersistentData.Instance.getScore();
        level = SceneManager.GetActiveScene().buildIndex;
        //scoreThresholdForThisLevel = (level - 1) * SCORE_THRESHOLD;
        //DisplayScore();
        time = PersistentData.Instance.getTime();
        remainingBalloons = balloonsPerLevel[level - 1];
        DisplayTime(time);
        DisplayLevel(level);
        DisplayName();
    }

    /*public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);
    }*/

    /*public void AddPoints(int value)
    {
        AdvanceLevel();
    }*/
    /*public void AddPoints(int value)
    {
        score += value;
        DisplayScore();
        PersistentData.Instance.setScore(score);
        if (score >= SCORE_THRESHOLD)
            AdvanceLevel();
    }*/

    // Update is called once per frame
    void Update()
    {

    }
    /*private void DisplayScore()
    {
        scoreText.text = "Score: " + score;
    }*/
    public void BalloonPopped()
    {
        remainingBalloons--;
        if (remainingBalloons <= 0)
        {
            CompleteLevel();
        }
    }
    public int GetRemainingBalloons()
    {
        return remainingBalloons;
    }
    private void DisplayLevel(int level)
    {
        levelText.text = "Level: " + level;
    }
    private void DisplayName()
    {
        nameText.text = "Hi, " + PersistentData.Instance.getName() + "!";
    }
    private void DisplayTime(float time)
    {
        timeText.text = "Time: " + time;
    }
    private void DisplayComplete(float time)
    {
        completeGameText.text = "CONGRATULATIONS " + PersistentData.Instance.getName() + "!\r\nYOU MADE IT! YOU FINISHED IN + " + (PersistentData.Instance.getTime() / 60)
            + " MINUTES AND " + (PersistentData.Instance.getTime() % 60) + " SECONDS!";
    }
    private void CompleteLevel()
    {
        // Stop the timer and get the elapsed time
        int elapsedTime = timer.StopTimer();
        // Determine the next step
        AdvanceLevel();
    }

    private void AdvanceLevel()
    {
        //PersistentData.Instance.AddHighScore(PersistentData.Instance.getName(), elapsedTime);
        //SceneManager.LoadScene(level + 1);
        int level = SceneManager.GetActiveScene().buildIndex + 1;
        if (level == 4){
             SceneManager.LoadScene("End Screen");
        }
        else
        {
            SceneManager.LoadScene(level);
        }
    }
}
