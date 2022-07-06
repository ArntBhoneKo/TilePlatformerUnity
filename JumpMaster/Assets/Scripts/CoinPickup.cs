using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(FindObjectOfType<AudioManager>().coinPickupSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
