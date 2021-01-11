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
            
            if (other.gameObject.name.Equals("Bernd"))
            {
                Bernd bernd = (Bernd)other.gameObject.GetComponent("Bernd");
                Debug.Log("berndWurdeGetroffen");
                bernd.kill();
            }
        }
    }
}

