using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float speed = 5f;
	[SerializeField] private Rigidbody playerRb;
	[SerializeField] private float rotationSpeed = 5f;
	[SerializeField] AudioSource audioSource;
	[SerializeField] AudioClip dirtSound;
	[SerializeField] GameManager gameManager;
	private Quaternion targetRotation;

	// Start is called before the first frame update
	void Start()
	{
		targetRotation = transform.rotation;
	}

	// Update is called once per frame
	void Update()
	{
		HandleMovement();
		HandleRotation();
	}

	void HandleMovement()
	{
		float horizontalInput = Input.GetAxis("Horizontal");

		// Movimentação
		Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * speed;
		playerRb.velocity = new Vector3(movement.x, playerRb.velocity.y, movement.z);

		if (horizontalInput > 0)
		{
			targetRotation = Quaternion.Euler(0f, 0f, 0f);
		}
		else if (horizontalInput < 0)
		{
			targetRotation = Quaternion.Euler(0f, -180f, 0f);
		}
	}

	void HandleRotation()
	{
		// Rotaciona suavemente em direção à rotação alvo
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
	}

}
