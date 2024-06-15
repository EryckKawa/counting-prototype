using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLimits : MonoBehaviour
{
	[SerializeField] private float limitXRight;
	[SerializeField] private float limitXLeft;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		LimitsBounds();
	}
	
	void LimitsBounds()
	{
		if (transform.position.x > limitXRight)
		{
			transform.position = new Vector3(limitXRight, transform.position.y , transform.position.z);
		}
		
		if (transform.position.x < limitXLeft)
		{
			transform.position = new Vector3(limitXLeft, transform.position.y , transform.position.z);
			
		}
	}
}
