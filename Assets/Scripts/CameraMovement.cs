using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float movementSpeed = 0.8f;
    public Vector3 offset;
    public Vector3 destination;
    public Vector3 playerPosition;
    public float maxMoveDistance = 0.05f;
    public float maxDistanceOffset = 1.5f;
    public Transform player;

    void Start()
    {
        offset = transform.position;
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        //Moves the camera at a fixed speed
        transform.Translate(0, movementSpeed * Time.deltaTime, movementSpeed * Time.deltaTime, Space.World);
        
        playerPosition = player.position;

        //If the player is near the top of the screen, move the camera faster
        //(We check the z axis because the y position of the player changes when it jumps)
        if (playerPosition.z > transform.position.z - offset.z + maxDistanceOffset)
        {
            destination = new Vector3(transform.position.x, playerPosition.z + offset.y, playerPosition.z + offset.z);
            transform.position = Vector3.MoveTowards(transform.position, destination, maxMoveDistance);
        }
    }
}
