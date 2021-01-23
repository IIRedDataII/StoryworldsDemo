using System;
using System.Collections;
using UnityEngine;

public class HoriziontalDoor : Door
{
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Zementa mach die Tür auf!");
            Open();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {  
            Debug.Log("Tür Zu!");
            Close();
        }
    }

    private void Close()
    {
        StartCoroutine(CloseDoor());
    }

    IEnumerator CloseDoor()
    {
        Vector3 distance = startPos - transform.position;
        while (distance.magnitude > 0.1)
        {
            if (!open)
            {
                transform.Translate(distance * doorSpeed * Time.deltaTime);
            }
        }
        return null;
    }
}