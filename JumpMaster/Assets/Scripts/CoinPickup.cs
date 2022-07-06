using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] int coinValue = 10;

    bool wasCollected = false;

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToCoin(coinValue);
            FindObjectOfType<AudioManager>().CoinPickupAudio();
            Destroy(gameObject);
        }
    }
}
