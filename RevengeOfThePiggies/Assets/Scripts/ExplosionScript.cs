using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //Activate any blocks or birds caught in an explosion; also increase score and reduce health
    {
        if (collision.gameObject.tag == "Block")
        {
            collision.gameObject.GetComponent<BlockScript>().activated = true;
            collision.gameObject.GetComponent<BlockScript>().health--;
            collision.gameObject.GetComponent<BlockScript>().scoreManager.updateScore(10);

        }
        if (collision.gameObject.tag == "Bird")
        {
            collision.gameObject.GetComponent<BirdScript>().activated = true;
            collision.gameObject.GetComponent<BirdScript>().health--;
            collision.gameObject.GetComponent<BirdScript>().scoreManager.updateScore(10);
        }
    }
}
