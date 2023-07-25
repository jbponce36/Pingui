using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
	void OnTriggerEnter(Collider player)
	{
		PlayerStats.AddKey();
		SoundManager.PlayPickupKeySound();
		Destroy(gameObject);
	}
}
