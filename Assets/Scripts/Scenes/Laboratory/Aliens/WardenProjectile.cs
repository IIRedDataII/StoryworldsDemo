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
            string[] messages = {"u got shot by some weird ass space insect, boiii"};
            other.GetComponent<PlayerDeath>()?.Die(messages);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Warden"))
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
