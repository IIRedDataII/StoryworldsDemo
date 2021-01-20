using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardenProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerDeath>()?.kill();
            Destroy(gameObject);
        }
        else if(other.CompareTag("Warden"))
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
