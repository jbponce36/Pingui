using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = 3f;

    void Update()
    {
        if (transform.position.x > 7) 
        {
			Destroy(gameObject);
		} 
        else
        {
            transform.Translate(movementSpeed * Time.deltaTime, 0, 0, Space.World);
        }
    }

    void OnTriggerEnter(Collider player)
    {
        //Disable the enemy collider so it doesn't keep colliding with the player
        GetComponent<BoxCollider>().enabled = false;
        
		GameObject.FindWithTag("Player").GetComponent<PlayerController>().CollideWithEnemy();
	}
}
