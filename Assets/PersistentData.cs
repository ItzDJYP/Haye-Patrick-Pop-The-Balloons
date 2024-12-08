using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] float elapsedTime;
    public static PersistentData Instance;
    //[SerializeField] int playerScore;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerName = "";
        elapsedTime = 0f;
        //playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void setScore(int s)
    {
        playerScore = s;
    }*/
    public void setTime(float t)
    {
        elapsedTime = t;
    }

    public void setName(string n)
    {
        playerName = n;
    }

    public string getName()
    {
        return playerName;
    }
    public float getTime()
    {
        return elapsedTime;
    }
    /*public int getScore()
    {
        return playerScore;
    }*/
}
