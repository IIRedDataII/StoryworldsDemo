﻿using UnityEngine;

public class UpJunction : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Alien") && other.GetComponent<AlienBehaviour>().CompareInnerCollider(other))
        {
            other.gameObject.GetComponent<Pathing>().direction = Vector3.up;
        }
    }
    
}
