using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().CoinPickupAudio();
            Destroy(gameObject);
        }
    }
}
