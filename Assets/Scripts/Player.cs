using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;    
    GameObject currentFloor; //To store current floor object
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start the game!");
    }

    // Update is called once per frame
    void Update()
    {
        //When player press right arrow key
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Move player's character to the right
            transform.Translate(moveSpeed*Time.deltaTime,0,0);
        }
        //When player press left arrow key
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Move player's character to the left
            transform.Translate(-moveSpeed*Time.deltaTime,0,0);    
        }
        
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        //When player's character hits normal floor object with collision
        if (other.gameObject.tag == "Normal")
        {
            Debug.Log("Hit normal floor");
            //Set the currentFloor object to the normal floor object
            currentFloor = other.gameObject;
        }   
        //When player's character hits nails floor object with collision
        else if (other.gameObject.tag == "Nails")
        {
            Debug.Log("Hit nails floor");
            //Set the currentFloor object to the nails floor object
            currentFloor = other.gameObject;
        }         
        //When player's character hits ceiling object with collision
        else if (other.gameObject.tag == "Ceiling")
        {
            Debug.Log("Hit ceiling");
            //Disable the character's collider function
            currentFloor.GetComponent<BoxCollider2D>().enabled = false;
        }         

    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        //When player's character falls down and hits by triggering the death line
        if (other.gameObject.tag == "DeathLine")
        {
            Debug.Log("Die");
        }   
    }
}
