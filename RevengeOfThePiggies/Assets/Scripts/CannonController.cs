using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject piggyPlayer; //reference to the player
    public float strength = 500f;
    
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //get mouse position
        Vector3 direction = worldMousePosition - transform.position;

        float alpha = Mathf.Acos(Vector3.Dot(Vector3.right, direction.normalized))*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, alpha));

        if (Input.GetMouseButtonUp(0))
        {
            piggyPlayer.transform.parent = null;
            piggyPlayer.GetComponent<Rigidbody2D>().AddForce(direction.normalized * strength);
            piggyPlayer.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
