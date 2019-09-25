using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotsManager : Subject
{
    public int shots = 5; //Max shots
    public Observer displayShots;
    public Observer gameOver;

    private void Start()
    {
        registerObserver(displayShots); //Register shot display
        registerObserver(gameOver); //Register game over text
        Notify(shots, NotificationType.ShotsUpdated); //Set initial shots remaining
    }

    public void updateShots(int shot) //Whenever the pig is reset, reduce shots remaining and notify observers
    {
        shots -= shot;
        Notify(shots, NotificationType.ShotsUpdated);
    }
}
