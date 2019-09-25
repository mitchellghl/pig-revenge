using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiggyController : MonoBehaviour
{
    Quaternion startRotation;
    Transform cannon;
    public Transform resetPoint;
    public ScoreManager scoreManager;
    public ShotsManager shotsManager;
    public Slider powerSlider;

    // Start is called before the first frame update
    void Start()
    {
        cannon = transform.parent; //Get cannon for reset point
        startRotation = transform.rotation; //Get initial rotation
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2")) //Reset the pig if right mouse is clicked
        {
            Reset();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //Get points on collision
    {
        if (collision.gameObject.tag != "Ground")
        {
            scoreManager.updateScore(10);
        }
    }

    private void Reset() //Reset function
    {
        if (shotsManager.shots > 0) //Only works if there are shots remaining
        {
            transform.parent = cannon.transform; //Reset pig location to cannon
            transform.position = resetPoint.position;
            transform.rotation = startRotation;
            GetComponent<Rigidbody2D>().gravityScale = 0; //Get rid of gravity and velocity
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            shotsManager.updateShots(1); //Reduce remaining shots
            powerSlider.value = 0; //Reset power slider
        }
    }
}
