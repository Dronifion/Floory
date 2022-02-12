using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start the game!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveSpeed*Time.deltaTime,0,0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-moveSpeed*Time.deltaTime,0,0);    
        }
        
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Normal")
        {
            Debug.Log("Hit normal floor");
        }   
        else if (other.gameObject.tag == "Nails")
        {
            Debug.Log("Hit nails floor");
        } 

    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "DeathLine")
        {
            Debug.Log("Die");
        }   
    }
}
