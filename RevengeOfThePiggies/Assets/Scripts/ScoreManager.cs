using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Subject
{
    public int score = 0;
    public Observer displayScore;

    private void Start()
    {
        registerObserver(displayScore); //Register score display
        Notify(score, NotificationType.ScoreUpdated); //Set initial score to 0
    }

    public void updateScore(int point) //Whenever points come in, update the score
    {
        score += point;
        Notify(score, NotificationType.ScoreUpdated);
    }
}
