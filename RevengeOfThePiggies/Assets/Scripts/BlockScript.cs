using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public int health;
    public bool activated = false;
    const int maxHealth = 10;
    public ScoreManager scoreManager;
    public GameObject scoreManagerObject;

    void Start() //Find and set score manager and starting health
    {
        scoreManagerObject = GameObject.FindGameObjectWithTag("ScoreManager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
        health = maxHealth;
    }

    private void FixedUpdate() //Die if health reaches 0
    {
        if(health <= 0)
        {
            scoreManager.updateScore(100);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") //Become activated if hit by player
        {
            activated = true;
        }
        if (activated) //If activated, lose health, increase score, and activate others
        {
            health -= 1;
            scoreManager.updateScore(10);
            if(collision.gameObject.tag == "Block")
            {
                collision.gameObject.GetComponent<BlockScript>().activated = true;
                Debug.Log("Activated!");
            }
            if(collision.gameObject.tag == "Bird")
            {
                collision.gameObject.GetComponent<BirdScript>().activated = true;
                Debug.Log("Activated!");
            }
            if(collision.gameObject.tag == "Player")
            {
                health -= 1;
                scoreManager.updateScore(10);
            }
        }
    }
}
