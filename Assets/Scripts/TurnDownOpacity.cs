using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnDownOpacity : MonoBehaviour
{
    public Renderer rend;
    public Vector3 playerPosition;

    public float up = 4f;
    public float down = 0.9f;
    public float left = -2f;
    public float right = -0f;
    public float back = 0f;
    public float forward = 1f;

    public float opacitySpeed = 0.1f;
    public float minOpacity = 0.4f;

    public float opacity;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {    
        playerPosition = GameObject.FindWithTag("Player").transform.position;

        //If the player is behind the object, turn down the object's opacity
        //(The player intersects with the cube with these dimentions behind the object)
        if (playerPosition.y > transform.position.y + down && playerPosition.y < transform.position.y + up &&
            playerPosition.x < transform.position.x + right && playerPosition.x > transform.position.x + left &&
            playerPosition.z < transform.position.z + forward && playerPosition.z > transform.position.z + back)
        {
            //Turn down opacity every frame if it's higher than the minimum opacity
            if (rend.material.color.a > minOpacity) 
            {
                //Set new opacity
                Color color = rend.material.color; 
                Color newColor = new Color(color.r, color.g, color.b, color.a - opacitySpeed); 
                rend.material.color = newColor;
            }
        }
        else //If the player is not behind the object, turn up the object's opacity
        {
            //Turn up opacity every frame if it's lower than the max opacity (1f)
            if (rend.material.color.a < 1f)
            {
                //Set new opacity
                Color color = rend.material.color; 
                Color newColor = new Color(color.r, color.g, color.b, color.a + opacitySpeed); 
                rend.material.color = newColor;
            }
        }

        //Actually change the object's opacity
        opacity = rend.material.color.a;
    }
}
