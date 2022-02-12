using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move all floor objects in FloorManager upward
        transform.Translate(0, moveSpeed*Time.deltaTime, 0);

        //Destroy floor object when it reach above 6 y scale
        //It will also create a new floor at the bottom of the scene when one floor object is destroy
        if (transform.position.y > 6f)
        {
            //Destroy floor object
            Destroy(gameObject);

            //Create new floor object at the bottom of the scene by calling the public method from FloorManager class
            transform.parent.GetComponent<FloorManager>().SpawnFloor();
        }
    }
}
