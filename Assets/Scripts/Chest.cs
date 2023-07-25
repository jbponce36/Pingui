using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
	public int score = 100;
	public ParticleSystem explosion;

	void Start()
	{
		explosion = GameObject.FindWithTag("Chest Particle System").GetComponent<ParticleSystem>();
	}

    void OnTriggerEnter(Collider player)
    {
        PlayerStats.RemoveKey();
		PlayerStats.AddScore(score);
		SoundManager.PlayPickupChestSound();
		explosion.transform.position = transform.position;
		explosion.Play();
		Destroy(gameObject);
	}
}
