using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;    
    [SerializeField] int Hp; //Character's HP
    [SerializeField] int MaxHp; //Character's maximum HP
    [SerializeField] Text LifeText; //Game Life
    [SerializeField] Text ScoreText; //Game Score
    GameObject currentFloor; //To store current floor object
    int Score = 0; //To record game score
    float scoreTime = 0f; //Use to calculate score with time passed in game

    // Start is called before the first frame update
    void Start()
    {
        //Initial character's HP and max HP values to 10
        Hp = 10;
        MaxHp = 10;

        //Initial game hp and score and then display on scene
        LifeText.text = "Life : " + Hp.ToString() + " / " + MaxHp.ToString();
        ScoreText.text = "Floor 0";
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
        
        //Update game score
        UpdateScore();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        //When player's character hits normal floor object with collision
        if (other.gameObject.tag == "Normal")
        {
            //Only set the currentFloor object when character hits the horizontal flat surface
            if (other.contacts[0].normal == new Vector2(0f,1f))
            {
                Debug.Log("Hit normal floor");
                //Set the currentFloor object to the normal floor object
                currentFloor = other.gameObject;
                //Add 1 to Hp
                ModifyHp(1);
            }
        }   
        //When player's character hits nails floor object with collision
        else if (other.gameObject.tag == "Nails")
        {
            //Only set the currentFloor object when character hits the horizontal flat surface
            if (other.contacts[0].normal == new Vector2(0f,1f))
            {
                Debug.Log("Hit nails floor");
                //Set the currentFloor object to the nails floor object
                currentFloor = other.gameObject;
                //Subtract 3 from Hp
                ModifyHp(-3);

            }
        }         
        //When player's character hits ceiling object with collision
        else if (other.gameObject.tag == "Ceiling")
        {
            Debug.Log("Hit ceiling");
            //Disable the character's collider function
            currentFloor.GetComponent<BoxCollider2D>().enabled = false;
            //Subtract 3 from Hp
            ModifyHp(-3);
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

    void ModifyHp(int num)
    {
        //Modify current HP
        Hp += num;

        //Max Hp = 10
        if (Hp > 10)
        {
            Hp = 10;
        }
        //Min Hp = 0
        else if (Hp <= 0 )
        {
            Hp = 0;
        }

        //Display current HP on scene
        LifeText.text = "Life : " + Hp.ToString() + " / " + MaxHp.ToString();
    }

    void UpdateScore()
    {
        scoreTime += Time.deltaTime;

        //Add score every 2 second time passes on game.
        if (scoreTime > 2f)
        {
            Score++;
            scoreTime = 0f;
            ScoreText.text = "Floor " + Score.ToString();
        }
    }
}
