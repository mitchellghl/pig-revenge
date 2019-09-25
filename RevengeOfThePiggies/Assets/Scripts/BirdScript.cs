using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public int health;
    public bool activated = false;
    const int maxHealth = 10;
    public ScoreManager scoreManager;
    public GameObject scoreManagerObject;
    public GameObject explosion;
    private GameObject deathBoom;

    void Start() //Find and set score manager and starting health
    {
        scoreManagerObject = GameObject.FindGameObjectWithTag("ScoreManager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
        health = maxHealth;
    }

    private void FixedUpdate() //If health reaches 0, die and spawn an explosion that dies in 0.25secs
    {
        if (health <= 0)
        {
            scoreManager.updateScore(200);
            deathBoom = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(deathBoom, 0.25f);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") //Become activated if hit by player
        {
            activated = true;
        }
        if (activated) //If activated, score points, lose health, and activate others
        {
            health -= 1;
            scoreManager.updateScore(10);
            if (collision.gameObject.tag == "Block")
            {
                collision.gameObject.GetComponent<BlockScript>().activated = true;
                Debug.Log("Activated!");
            }
            if (collision.gameObject.tag == "Bird")
            {
                collision.gameObject.GetComponent<BirdScript>().activated = true;
                Debug.Log("Activated!");
            }
            if (collision.gameObject.tag == "Player")
            {
                health -= 1;
                scoreManager.updateScore(10);
            }
        }
    }
}
