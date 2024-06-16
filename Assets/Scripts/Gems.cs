using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour
{
	[SerializeField] Rigidbody gemsRb;
	[SerializeField] float customGravity;
	float limitY = -1;
	[SerializeField] int points;
	private GameManager gameManager;

	// Start is called before the first frame update
	void Start()
	{
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		CustomGravity();
		DestoyLimits();
	}
	
	void CustomGravity()
	{
		gemsRb.AddForce(customGravity * gemsRb.mass * Vector3.down);
	}
	
	void DestoyLimits()
	{
		if (transform.position.y <= limitY)
		{
			gameManager.LoseLife();
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			gameManager.AddScore(points);
			Destroy(gameObject);
		} 
		
	}
}
