using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!(other.CompareTag("Player") || other.CompareTag("Interactable") || other.CompareTag("Object")))
        {
            Debug.Log("Ich hab was getroffen: " + other);
            Destroy(gameObject);
        }
    }
}

