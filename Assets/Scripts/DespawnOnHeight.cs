using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnOnHeight : MonoBehaviour
{
    public int height = 10;

    void Update()
    {
        //Destrop object when camera is higher than the objects position + a height offset
        if (Camera.main.transform.position.y > transform.position.y + height)
        {
            Destroy(gameObject);
        }
    }
}
