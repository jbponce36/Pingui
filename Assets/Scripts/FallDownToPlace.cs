using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDownToPlace : MonoBehaviour
{
    public Vector3 target;
    public float movementSpeed;
    
    void Start()
    {
        if (GameObject.FindWithTag("Level Generator").GetComponent<LevelGenerator>().fallingObjects)
        {
            movementSpeed = GameObject.FindWithTag("Level Generator").GetComponent<LevelGenerator>().fallingSpeed;

            //Save the position where I want the object to fall
            target = transform.position;

            //Change the position of the object to where I want them to fall from
            transform.position = new Vector3(target.x, target.y + 9, target.z);
        }
        else
        {
            //Disable this script if no more falling objects are needed
            this.enabled = false;
        }
    }

    void Update()
    {
        //Make the object fall down to place until it reaches its destination
        if (transform.position.y < target.y)
        {
            transform.position = target;
            movementSpeed = 0f;
        }
        else
        {
		    transform.Translate(0, -movementSpeed * Time.deltaTime, 0, Space.World);
        }
    }
}
