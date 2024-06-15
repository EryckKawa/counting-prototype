using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGems : MonoBehaviour
{
	[SerializeField] List<GameObject> gemsTargets;
	[SerializeField] float initTimer = 2f;
	[SerializeField] float repeatRate = 1.5f;
	// Start is called before the first frame update
	void Start()
	{
		InvokeRepeating("SpawnRandomGems", initTimer, repeatRate);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	
	void SpawnRandomGems()
	{
		int gemsIndex = Random.Range(0, gemsTargets.Count);

		float randomXRange = Random.Range(-1, 1);
		
		Instantiate(gemsTargets[gemsIndex], new Vector3(randomXRange, transform.position.y, transform.position.z), gemsTargets[gemsIndex].transform.rotation);
	}
}
