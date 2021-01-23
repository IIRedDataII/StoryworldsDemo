using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform targetOpen;
    [SerializeField] private Transform targetClose;
    [SerializeField] protected float doorSpeed;

    [SerializeField] protected bool open;
    [SerializeField] protected bool close;

    public void Update()
    {
        if (open)
        {
            if ((targetOpen.position - transform.position).magnitude > 0.1)
            {
                transform.Translate((targetOpen.position - transform.position) * doorSpeed * Time.deltaTime);  
            }
            else
            {
                open = false;
            }
        }

        if (close)
        {
            if ((targetClose.position - transform.position).magnitude > 0.1)
            {
                transform.Translate((targetClose.position - transform.position) * doorSpeed * Time.deltaTime);  
            }
            else
            {
                close = false;
            }
        }
    }

    public void Open()
    {
        open = true;
    }

    private void Close()
    {
        close = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        close = false;
        Open();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        open = false;
        Close();
    }
}
