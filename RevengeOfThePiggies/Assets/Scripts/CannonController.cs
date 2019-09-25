using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour
{
    public Rigidbody2D piggyRB; //reference to player rigid body
    public Camera mainCamara; // reference to main camera
    public float strength; //value that charges up as you hold down fire button
    public float maxStrength; //maximum strength for firing; set in console
    private Vector3 shootDirection; //holds vector3 for direction to shoot at cursor
    const int maxAngle = 80; //constraint aiming angle to max 80 degrees
    const int minAngle = 5; //constrain aiming angle to min 5 degrees
    const int strengthGrowth = 200; //rate for increasing strength
    public Slider powerSlider;
    public ShotsManager shotsManager;
    
    void Start()
    {
        strength = 0; //make sure strength starts at 0
    }

    void Update()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamara.transform.position.z);
        Vector3 worldMousePosition = mainCamara.ScreenToWorldPoint(mousePosition); //get mouse position
        shootDirection = worldMousePosition - transform.position; //where you are aiming

        float alpha = Mathf.Acos(Vector3.Dot(Vector3.right, shootDirection.normalized))*Mathf.Rad2Deg; //calculate fire angle

        if(alpha < maxAngle && alpha > minAngle && shootDirection.y > 0) //contrain aiming angles; rotate cannon
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, alpha)); 
        }
        
    }

    void FixedUpdate()
    {
        if (shotsManager.shots > 0)
        {
            if (Input.GetButton("Fire1") && strength < maxStrength) //increase strength when mouse is down up until max strength
            {
                strength += strengthGrowth; //Increase strength
                powerSlider.value = strength / maxStrength; //Increase red power slider
            }

            if (Input.GetButtonUp("Fire1")) //fire piggy when left mouse is released
            {
                piggyRB.transform.parent = null;
                piggyRB.AddForce(shootDirection.normalized * strength);
                piggyRB.gravityScale = 1;
                strength = 0;
            }
        }
    }
}
