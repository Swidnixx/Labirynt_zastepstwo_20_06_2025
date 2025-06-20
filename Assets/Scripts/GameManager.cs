using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public int timeToEnd;

    public int points = 0;

    public int redKey = 0;
    public int greenKey = 0;
    public int goldKey = 0;

    bool gamePaused = false;
    bool endGame = false;
    bool win = false;

    void Start()
    {
       if(gameManager == null)
       {
            gameManager = this;
       }

       if(timeToEnd <= 0) 
       {
            timeToEnd = 100;
       }

        Debug.Log("Time: " + timeToEnd + " s");
        InvokeRepeating("Stopper", 2, 1);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        PickUpCheck();
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time: " + timeToEnd + " s");
        
        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }

        if (endGame)
        {
            EndGame();
        }
    }

    public void PauseGame()
    {
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
        {
            Debug.Log("You Win!!! Reoad?");
        } else
        {
            Debug.Log("You Lose!!! Reload?");
        }
    }

    public void AddPoints(int point)
    {
        points += point;
    }

    public void AddTime(int addTime)
    {
        timeToEnd += addTime;
    }
    public void FreezTime(int freez)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freez, 1);
    }

    public void AddKey(KeyColor color)
    {
        if (color == KeyColor.Gold)
        {
            goldKey++;
        }
        else if (color == KeyColor.Green)
        {
            greenKey++;
        }
        else if (color == KeyColor.Red)
        {
            redKey++;
        }
    }

    void PickUpCheck()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Actual Time: " + timeToEnd);
            Debug.Log("Key red: " + redKey + " green: " + greenKey + " gold: " + goldKey);
            Debug.Log("Points: " + points);
        }
    }

    public bool HasKey(KeyColor properKey)
    {
        switch (properKey)
        {
            case KeyColor.Red:
                return redKey > 0;
                
            case KeyColor.Green:
                return greenKey > 0;
         
            case KeyColor.Gold:
                return goldKey > 0;
        }

        return false;
    }
    public void UseKey(KeyColor properKey)
    {
        switch (properKey)
        {
            case KeyColor.Red:
                redKey--;
                break;
            case KeyColor.Green:
                greenKey--;
                break;
            case KeyColor.Gold:
                goldKey--;
                break;
        }
    }
}
