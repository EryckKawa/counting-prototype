using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour
{
    [SerializeField] Rigidbody gemsRb;
    [SerializeField] float customGravity;
    float limitY = -1;
    [SerializeField] int points;
    [SerializeField] AudioSource gemsAudio;
    [SerializeField] AudioClip pickupGems;
    
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // Check if the AudioSource component is assigned
        if (gemsAudio == null)
        {
            gemsAudio = gameObject.AddComponent<AudioSource>();
        }
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

            // Ensure the sound plays even if the GameObject is destroyed
            AudioSource.PlayClipAtPoint(pickupGems, transform.position);

            Destroy(gameObject);
        } 
    }
}
