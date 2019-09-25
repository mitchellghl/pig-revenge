using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayShots : Observer
{
    public override void OnNotify(object o, NotificationType n) //Display shots remaining
    {
        if (n == NotificationType.ShotsUpdated)
        {
            GetComponent<TextMeshProUGUI>().text = "Shots Remaining: " + o;
        }

    }
}
