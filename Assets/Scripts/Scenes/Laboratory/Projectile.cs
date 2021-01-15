using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.name.Equals("Bernd") && !GameData.Instance.BerndDead)
        {
            Bernd bernd = (Bernd)other.gameObject.GetComponent("Bernd");
            bernd.kill();
        }
        
        if (!(other.CompareTag("Player") || other.CompareTag("Interactable") || other.CompareTag("Object")))
        {
            Debug.Log("Ich hab was getroffen: " + other);
            Destroy(gameObject);
        }
    }
}

