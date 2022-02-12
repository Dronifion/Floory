using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{   
    //An empty FloorManager object is created on Unity to store all floors objects
    [SerializeField] GameObject[] floorPrefabs;

    //This function will spawn floor object at the bottom of the scene
    //This function is public because it will be used in Floor class    
    public void SpawnFloor()
    {
        //Randomly choose value 0 or 1. 0=Normal Floor and 1=Nails Floor
        int r = Random.Range(0, floorPrefabs.Length);

        //Instantiate floor object according to random value
        GameObject floor =Instantiate(floorPrefabs[r], transform);

        //Randomly position the new floor object with x value from -3.48f to 3.32f
        //These x values were measured manually with eyeballs on the Unity's scene
        floor.transform.position = new Vector3(Random.Range(-3.48f, 3.32f), -6f, 0f);
    }
}
