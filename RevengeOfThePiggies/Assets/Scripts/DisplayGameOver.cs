using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayGameOver : Observer
{
    public override void OnNotify(object o, NotificationType n) //If remaining shots hits 0, display game over
    {
        if (n == NotificationType.ShotsUpdated)
        {
            if ((int)o == 0)
            {
                GetComponent<TextMeshProUGUI>().text = "Game Over!";
            }
        }
    }
}
