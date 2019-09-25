using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform piggy;
    const int moveSpeed = 50; //Camera follow speed

    void FixedUpdate()
    {
        Vector3 goal = new Vector3(piggy.position.x, transform.position.y, transform.position.z); //Set piggy position as goal
        transform.position = Vector3.MoveTowards(transform.position, goal, Time.deltaTime * moveSpeed); //Move towards piggy
    }
}
