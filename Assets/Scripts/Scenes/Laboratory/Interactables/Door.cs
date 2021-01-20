using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float doorSpeed;

    [SerializeField] private bool _open;

    public void Update()
    {
        if (_open)
        {
            if ((target.transform.position - transform.position).magnitude > 0.1)
            {
                transform.Translate((target.transform.position - transform.position) * doorSpeed * Time.deltaTime);  
            }
            else
            {
                _open = false;
            }
        }
    }

    public void Open()
    {
        _open = true;
    }

    public void Close()
    {
        _open = false;
    }
}
