using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SaveHighScores : MonoBehaviour
{

    [SerializeField] const int NUM_HIGH_SCORES = 5;
    [SerializeField] const string NAME_KEY = "HighScoreName";
    [SerializeField] const string SCORE_KEY = "HighScore";

    [SerializeField] string playerName;
    [SerializeField] float playerTime;

    [SerializeField] TextMeshProUGUI[] nameTexts;
    [SerializeField] TextMeshProUGUI[] timeTexts;

    // Start is called before the first frame update
    void Start()
    {
        playerName = PersistentData.Instance.getName();
        playerTime = PersistentData.Instance.getTime();

        SaveTime();
        DisplayHighScores();   
    }

    private void SaveTime()
    {
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            string currentNameKey = NAME_KEY + i;
            string currentScoreKey = SCORE_KEY + i;

            { 
                if (PlayerPrefs.HasKey(currentScoreKey))
                {
                    int currentScore = PlayerPrefs.GetInt(currentScoreKey);
                    if (playerTime > currentScore)
                    {
                        //handle this case
                        int tempScore = currentScore;
                        string tempName = PlayerPrefs.GetString(currentNameKey);

                        PlayerPrefs.SetString(currentNameKey, playerName);
                        PlayerPrefs.SetFloat(currentScoreKey, playerTime);

                        playerTime = tempScore;
                        playerName = tempName;
                    }

                }
                else
                {
                    PlayerPrefs.SetString(currentNameKey, playerName);
                    PlayerPrefs.SetFloat(currentScoreKey, playerTime);
                    return;
                }
            }
        }
    }

    public void DisplayHighScores()
    {    
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            nameTexts[i].text = PlayerPrefs.GetString(NAME_KEY+i);
            timeTexts[i].text = PlayerPrefs.GetInt(SCORE_KEY+i).ToString();
        }
    }
}
