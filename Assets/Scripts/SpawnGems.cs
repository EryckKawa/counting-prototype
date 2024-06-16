using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGems : MonoBehaviour
{
	[SerializeField] List<GameObject> gemsTargets;
	[SerializeField] float initTimer = 2f;
	[SerializeField] float repeatRate = 1.5f;
	[SerializeField] float spawnSpeed;
	// Start is called before the first frame update
	void Start()
	{
		InvokeRepeating(nameof(SpawnRandomGems), initTimer, repeatRate);
	}

	void SpawnRandomGems()
	{
		int gemsIndex = Random.Range(0, gemsTargets.Count);

		float randomXRange = Random.Range(-1.5f, 1.5f);
		
		Instantiate(gemsTargets[gemsIndex], new Vector3(randomXRange, transform.position.y, transform.position.z), gemsTargets[gemsIndex].transform.rotation);
	}
	
	public void SetRepeatRate(float newRepeatRate)
	{
		CancelInvoke(nameof(SpawnRandomGems));
		repeatRate = newRepeatRate;
		InvokeRepeating(nameof(SpawnRandomGems), 0f, repeatRate); // Reinicia o InvokeRepeating com o novo repeatRate
	}
	
	public float GetRepeatRate()
	{
		return repeatRate;
	}
}
